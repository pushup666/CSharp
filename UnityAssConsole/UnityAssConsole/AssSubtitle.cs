﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace UnityAssConsole
{
    public class AssSubtitle
    {
        public const bool showAbstract = true;
        public Dictionary<string, Tuple<string, string>> ScriptInfo { get; set; }
        public IList<string> V4pStyleFormat { get; set; }
        public Dictionary<string, AssStyle> V4pStyles { get; set; }
        public IList<string> EventFormat { get; set; }
        public IList<AssEvent> Events { get; set; }
        public Dictionary<string, AssEmbeddedFont> Fonts { get; set; }
        public Dictionary<string, AssEmbeddedGraphics> Graphics { get; set; }

        public Dictionary<string, string> UnknownSections { get; set; }

        public void Load(string path, Encoding enc = null)
        {
            string[] lines;
            if (enc == null)
            {
                lines = File.ReadAllLines(path);
            }
            else
            {
                lines = File.ReadAllLines(path, enc);
            }

            var workingSection = AssSection.ScriptInfo;
            var scriptInfoCommentIndex = 0;
            V4pStyleFormat = new List<string>();
            EventFormat = new List<string>();

            ScriptInfo = new Dictionary<string, Tuple<string, string>>();
            V4pStyles = new Dictionary<string, AssStyle>();
            Events = new List<AssEvent>();
            Fonts = new Dictionary<string, AssEmbeddedFont>();
            Graphics = new Dictionary<string, AssEmbeddedGraphics>();
            UnknownSections = new Dictionary<string, string>();

            // Regex defination
            var regexScriptInfoKeyValue = new Regex(@"^(?<key>[0-9a-zA-z ]+)\s*\:\s*(?<value>.+)$");
            var unknowSectionName = string.Empty;

            for (var lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                var line = lines[lineIndex].Trim();

                // Format checking
                if (lineIndex == 0)
                {
                    if (!line.StartsWith("[Script Info]"))
                    {
                        Trace.TraceWarning($"{path} {lineIndex} This is not a correct ASS(V4+) standard style file. The first line is not [Script Info].");
                    }
                }

                if (string.IsNullOrWhiteSpace(line))
                {
                    // Skip space line.
                    continue;
                }

                // Section detection.
                if (line.StartsWith("["))
                {
                    if (line.StartsWith("[Script Info]"))
                    {
                        workingSection = AssSection.ScriptInfo;
                        continue;
                    }
                    else if (line.StartsWith("[V4+ Styles]"))
                    {
                        workingSection = AssSection.V4pStyles;
                        continue;
                    }
                    else if (line.StartsWith("[Events]"))
                    {
                        workingSection = AssSection.Events;
                        continue;
                    }
                    else if (line.StartsWith("[Fonts]"))
                    {
                        workingSection = AssSection.Fonts;
                        continue;
                    }
                    else if (line.StartsWith("[Graphics]"))
                    {
                        workingSection = AssSection.Graphics;
                        continue;
                    }
                    else
                    {
                        workingSection = AssSection.Unknown;
                        unknowSectionName = line;
                        continue;
                    }
                }

                switch (workingSection)
                {
                    // Skiplines
                    case AssSection.Unknown:
                        if (UnknownSections.ContainsKey(unknowSectionName))
                        {
                            UnknownSections[unknowSectionName] += "\n" + line;
                        }
                        else
                        {
                            UnknownSections[unknowSectionName] = line;
                        }
                        continue;

                    // Loading ScriptInfo section.
                    case AssSection.ScriptInfo:
                        if (line.StartsWith("!:"))
                        {
                            ScriptInfo["Comment" + scriptInfoCommentIndex] = new Tuple<string, string>("comment", line.Substring(2));
                            scriptInfoCommentIndex++;
                        }
                        else if (line.StartsWith(";"))
                        {
                            ScriptInfo["Comment" + scriptInfoCommentIndex] = new Tuple<string, string>("comment", line.Substring(1));
                            scriptInfoCommentIndex++;
                        }
                        else
                        {
                            var match = regexScriptInfoKeyValue.Match(line);
                            if (match.Success)
                            {
                                var key = match.Groups["key"].Value;
                                var value = match.Groups["value"].Value;
                                ScriptInfo[key] = new Tuple<string, string>("key-value", value);
                            }
                            else
                            {
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": Unknown syntax while load key-value in Script Info Section.");
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": " + line);
                            }
                        }
                        continue;

                    // Loading V4 Styles+ Section.
                    case AssSection.V4pStyles:
                        if (V4pStyleFormat.Count == 0)
                        {
                            if (line.StartsWith("Format:"))
                            {
                                V4pStyleFormat = line.Substring(7).Split(',').Select(x => x.Trim()).ToList();
                            }
                            else
                            {
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": The format has not been defined, this line would be skipped.");
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": " + line);
                            }
                        }
                        else
                        {
                            if (line.StartsWith("Style:"))
                            {
                                var values = line.Substring(6).Split(',').Select(x => x.Trim()).ToList();
                                if (values.Count == V4pStyleFormat.Count)
                                {
                                    try
                                    {
                                        // mapping
                                        var style = MappingToStyle(V4pStyleFormat, values);
                                        V4pStyles[style.Name] = style;
                                    }
                                    catch (Exception exc)
                                    {
                                        Trace.TraceWarning("LINE " + (lineIndex + 1) + ": Error(" + exc.Message + ") while map this line to object.");
                                        Trace.TraceWarning("LINE " + (lineIndex + 1) + ": " + line);
                                    }
                                }
                                else
                                {
                                    Trace.TraceWarning("LINE " + (lineIndex + 1) + ": the count of the fields(" + values.Count + ") in style do not match with format defined(" + V4pStyleFormat.Count + "), this line would be skipped.");
                                    Trace.TraceWarning("LINE " + (lineIndex + 1) + ": " + line);
                                }
                            }
                            else
                            {
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": Unknown syntax not started with 'Style:', this line would be skipped.");
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": " + line);
                            }
                        }
                        continue;

                    // Loading Events Section.
                    case AssSection.Events:
                        if (EventFormat.Count == 0)
                        {
                            if (line.StartsWith("Format:"))
                            {
                                EventFormat = line.Substring(7).Split(',').Select(x => x.Trim()).ToList();
                            }
                            else
                            {
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": The format has not been defined, this line would be skipped.");
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": " + line);
                            }
                        }
                        else
                        {
                            var availablePrefix = Enum.GetNames(typeof(AssEventType));
                            var regex = new Regex(@"^(?<prefix>" + string.Join("|", availablePrefix) + @"):\s*(?<values>.+)$");
                            var match = regex.Match(line);
                            if (match.Success)
                            {
                                var values = match.Groups["values"].Value.Split(new[] { ',' }, EventFormat.Count).Select(x => x.Trim()).ToList();
                                if (values.Count == EventFormat.Count)
                                {
                                    try
                                    {
                                        // mapping
                                        var evt = MappingToEvent(match.Groups["prefix"].Value, EventFormat, values);
                                        Events.Add(evt);
                                    }
                                    catch (Exception exc)
                                    {
                                        Trace.TraceWarning("LINE " + (lineIndex + 1) + ": Error(" + exc.Message + ") while map this line to object.");
                                        Trace.TraceWarning("LINE " + (lineIndex + 1) + ": " + line);
                                    }
                                }
                                else
                                {
                                    Trace.TraceWarning("LINE " + (lineIndex + 1) + ": the count of the fields(" + values.Count + ") in style do not match with format defined(" + EventFormat.Count + "), this line would be skipped.");
                                    Trace.TraceWarning("LINE " + (lineIndex + 1) + ": " + line);
                                }
                            }
                            else
                            {
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": Unknown syntax, this line would be skipped.");
                                Trace.TraceWarning("LINE " + (lineIndex + 1) + ": " + line);
                            }
                        }
                        continue;
                }
            }
        }

        public string Stringify()
        {
            var sb = new StringBuilder();

            // Script Info
            sb.AppendLine("[Script Info]");
            foreach (var si in ScriptInfo)
            {
                if (si.Value.Item1.Equals("comment"))
                {
                    sb.AppendLine($";" + si.Value.Item2);
                }
                if (si.Value.Item1.Equals("key-value"))
                {
                    sb.AppendLine($"{si.Key}: {si.Value.Item2}");
                }
            }
            sb.AppendLine();

            // Unknown Sections
            foreach (var us in UnknownSections)
            {
                sb.AppendLine(us.Key);
                sb.AppendLine(us.Value);
                sb.AppendLine();
            }

            // V4+ Styles
            sb.AppendLine("[V4+ Styles]");
            sb.AppendLine($"Format: {string.Join(", ", V4pStyleFormat)}");
            foreach (var s in V4pStyles)
            {
                sb.AppendLine(FormatStyle(V4pStyleFormat, s.Value));
            }
            sb.AppendLine();

            // Events
            sb.AppendLine("[Events]");
            sb.AppendLine($"Format: {string.Join(", ", EventFormat)}");
            foreach (var ev in Events)
            {
                sb.AppendLine(FormatEvent(EventFormat, ev));
            }
            sb.AppendLine();

            return sb.ToString();
        }

        public void Save(string path, Encoding enc = null)
        {
            if (enc == null)
            {
                File.WriteAllText(path, Stringify(), Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(path, Stringify(), enc);
            }
        }

        private static AssEvent MappingToEvent(string prefix, IList<string> eventFormat, IList<string> values)
        {
            var eventType = (AssEventType)Enum.Parse(typeof(AssEventType), prefix);
            var evt = new AssEvent();
            evt.Type = eventType;
            for (var i = 0; i < eventFormat.Count; i++)
            {
                var field = eventFormat[i];
                var value = values[i];
                switch (field.Trim())
                {
                    case "Layer": evt.Layer = Convert.ToInt32(value); continue;
                    case "Start": evt.Start = new AssEventTime(value); continue;
                    case "End": evt.End = new AssEventTime(value); continue;
                    case "Style": evt.Style = value; continue;
                    case "Name": evt.Name = value; continue;
                    case "MarginL": evt.MarginL = Convert.ToInt32(value); continue;
                    case "MarginR": evt.MarginR = Convert.ToInt32(value); continue;
                    case "MarginV": evt.MarginV = Convert.ToInt32(value); continue;
                    case "Effect": evt.Effect = value; continue;
                    case "Text": evt.Text = value; continue;
                    default:
                        Trace.TraceWarning("MAPPING ERROR: Unknown field - " + field);
                        continue;
                }
            }
            return evt;
        }

        private static string FormatEvent(IList<string> eventFormat, AssEvent evt, string spliter = ",")
        {
            var sb = new StringBuilder();
            sb.Append(evt.Type.ToString() + ": ");
            for (var i = 0; i < eventFormat.Count; i++)
            {
                var field = eventFormat[i];
                switch (field.Trim())
                {
                    case "Layer": sb.Append(evt.Layer); break;
                    case "Start": sb.Append(evt.Start); break;
                    case "End": sb.Append(evt.End); break;
                    case "Style": sb.Append(evt.Style); break;
                    case "Name": sb.Append(evt.Name); break;
                    case "MarginL": sb.Append(evt.MarginL); break;
                    case "MarginR": sb.Append(evt.MarginR); break;
                    case "MarginV": sb.Append(evt.MarginV); break;
                    case "Effect": sb.Append(evt.Effect); break;
                    case "Text": sb.Append(evt.Text); break;
                    default:
                        Trace.TraceWarning("MAPPING ERROR: Unknown field - " + field);
                        break;
                }
                if (i != eventFormat.Count - 1)
                {
                    sb.Append(spliter);
                }
            }
            return sb.ToString();
        }

        private static AssStyle MappingToStyle(IList<string> v4pStyleFormat, IList<string> values)
        {
            var style = new AssStyle();
            for (var i = 0; i < v4pStyleFormat.Count; i++)
            {
                var field = v4pStyleFormat[i];
                var value = values[i];
                switch (field.Trim())
                {
                    case "Name": style.Name = value; continue;
                    case "Fontname": style.Fontname = value; continue;
                    case "Fontsize": style.Fontsize = Convert.ToDouble(value); continue;
                    case "PrimaryColour": style.PrimaryColour = value; continue;
                    case "SecondaryColour": style.SecondaryColour = value; continue;
                    case "OutlineColour": style.OutlineColour = value; continue;
                    case "BackColour": style.BackColour = value; continue;
                    case "Bold": style.Bold = Convert.ToInt16(value) == -1; continue;
                    case "Italic": style.Italic = Convert.ToInt16(value) == -1; continue;
                    case "Underline": style.Underline = Convert.ToInt16(value) == -1; continue;
                    case "StrikeOut": style.StrikeOut = Convert.ToInt16(value) == -1; continue;
                    case "ScaleX": style.ScaleX = Convert.ToDouble(value); continue;
                    case "ScaleY": style.ScaleY = Convert.ToDouble(value); continue;
                    case "Spacing": style.Spacing = Convert.ToInt32(value); continue;
                    case "Angle": style.Angle = Convert.ToDouble(value); continue;
                    case "BorderStyle": style.BorderStyle = (V4pStyleBorderStyle)Convert.ToInt16(value); continue;
                    case "Outline": style.Outline = Convert.ToInt32(value); continue;
                    case "Shadow": style.Shadow = Convert.ToInt32(value); continue;
                    case "Alignment": style.Alignment = (V4pStyleAlignment)Convert.ToInt16(value); continue;
                    case "MarginL": style.MarginL = Convert.ToInt32(value); continue;
                    case "MarginR": style.MarginR = Convert.ToInt32(value); continue;
                    case "MarginV": style.MarginV = Convert.ToInt32(value); continue;
                    case "Encoding": style.Encoding = Convert.ToInt32(value); continue;
                    default:
                        Trace.TraceWarning("MAPPING ERROR: Unknown field - " + field);
                        continue;
                }
            }
            return style;
        }

        private static string FormatStyle(IList<string> v4pStyleFormat, AssStyle style, string spliter = ",")
        {
            var sb = new StringBuilder();
            sb.Append("Style: ");
            for (var i = 0; i < v4pStyleFormat.Count; i++)
            {
                var field = v4pStyleFormat[i];
                switch (field.Trim())
                {
                    case "Name": sb.Append(style.Name); break;
                    case "Fontname": sb.Append(style.Fontname); break;
                    case "Fontsize": sb.Append(style.Fontsize); break;
                    case "PrimaryColour": sb.Append(style.PrimaryColour); break;
                    case "SecondaryColour": sb.Append(style.SecondaryColour); break;
                    case "OutlineColour": sb.Append(style.OutlineColour); break;
                    case "BackColour": sb.Append(style.BackColour); break;
                    case "Bold": sb.Append(style.Bold ? "-1" : "0"); break;
                    case "Italic": sb.Append(style.Italic ? "-1" : "0"); break;
                    case "Underline": sb.Append(style.Underline ? "-1" : "0"); break;
                    case "StrikeOut": sb.Append(style.StrikeOut ? "-1" : "0"); break;
                    case "ScaleX": sb.Append(style.ScaleX); break;
                    case "ScaleY": sb.Append(style.ScaleY); break;
                    case "Spacing": sb.Append(style.Spacing); break;
                    case "Angle": sb.Append(style.Angle); break;
                    case "BorderStyle": sb.Append((int)style.BorderStyle); break;
                    case "Outline": sb.Append(style.Outline); break;
                    case "Shadow": sb.Append(style.Shadow); break;
                    case "Alignment": sb.Append((int)style.Alignment); break;
                    case "MarginL": sb.Append(style.MarginL); break;
                    case "MarginR": sb.Append(style.MarginR); break;
                    case "MarginV": sb.Append(style.MarginV); break;
                    case "Encoding": sb.Append(style.Encoding); break;
                    default:
                        Trace.TraceWarning("MAPPING ERROR: Unknown field - " + field);
                        break;
                }
                if (i != v4pStyleFormat.Count - 1)
                {
                    sb.Append(spliter);
                }
            }
            return sb.ToString();
        }

    } // class ASSSubtitle

    public class AssStyle
    {
        /// <summary>
        /// The name of the Style. Case sensitive. Cannot include commas.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The fontname as used by Windows. Case-sensitive.
        /// </summary>
        public string Fontname { get; set; }

        /// <summary>
        /// The fontsize.
        /// </summary>
        public double Fontsize { get; set; }

        public string PrimaryColour { get; set; }

        public string SecondaryColour { get; set; }

        public string OutlineColour { get; set; }

        public string BackColour { get; set; }

        public bool Bold { get; set; }

        public bool Italic { get; set; }

        public bool Underline { get; set; }

        public bool StrikeOut { get; set; }

        public double ScaleX { get; set; }

        public double ScaleY { get; set; }

        public int Spacing { get; set; }

        public double Angle { get; set; }

        public V4pStyleBorderStyle BorderStyle { get; set; }

        public int Outline { get; set; }

        public int Shadow { get; set; }

        public V4pStyleAlignment Alignment { get; set; }

        public int MarginL { get; set; }

        public int MarginR { get; set; }

        public int MarginV { get; set; }

        public int AlphaLevel { get; set; }

        public int Encoding { get; set; }

        public override string ToString()
        {
            if (AssSubtitle.showAbstract)
            {
                return $"{Name}: {Fontname},{Fontsize}{(Bold ? "B" : "")}{(Italic ? "I" : "")}{(Underline ? "U" : "")}{(StrikeOut ? "S" : "")}";
            }
            else
            {
                base.ToString();
            }
        }
    }

    public class AssEvent : ICloneable
    {
        public AssEventType Type { get; set; }

        public int Layer { get; set; }

        public AssEventTime Start { get; set; }

        public AssEventTime End { get; set; }

        public string Style { get; set; }

        public string Name { get; set; }

        public int MarginL { get; set; }

        public int MarginR { get; set; }

        public int MarginV { get; set; }

        public string Effect { get; set; }

        public string Text { get; set; }

        public object Clone()
        {
            var newInst = new AssEvent();
            newInst.Type = this.Type;
            newInst.Layer = this.Layer;
            newInst.Start = new AssEventTime(this.Start.ToString());
            newInst.End = new AssEventTime(this.End.ToString());
            newInst.Style = this.Style;
            newInst.Name = this.Name;
            newInst.MarginL = this.MarginL;
            newInst.MarginR = this.MarginR;
            newInst.MarginV = this.MarginV;
            newInst.Effect = this.Effect;
            newInst.Text = this.Text;
            return newInst;
        }

        public AssEvent()
        {
            this.Type = AssEventType.Dialogue;
            this.Layer = 0;
            this.Start = new AssEventTime(0, 0, 0, 0);
            this.End = new AssEventTime(0, 0, 0, 0);
            this.Style = "Default";
            this.Name = string.Empty;
            this.MarginL = 0;
            this.MarginR = 0;
            this.MarginV = 0;
            this.Effect = string.Empty;
            this.Text = string.Empty;
        }

        public override string ToString()
        {
            if (AssSubtitle.showAbstract)
            {
                return $"{Start} - {End} | {Type}:{Name}:{Text}";
            }
            else
            {
                base.ToString();
            }
        }
    }

    public class AssEventTime : IComparable
    {
        public int Hour { get; set; }

        public int Minute { get; set; }

        public int Second { get; set; }

        public int Millisecond { get; set; }

        public AssEventTime(string assTime)
        {
            var parts = assTime.Split(':', '.');
            var msIndex = parts.Length - 1;
            var secIndex = parts.Length - 2;
            var minIndex = parts.Length - 3;
            var hourIndex = parts.Length - 4;
            this.Hour = hourIndex >= 0 ? Convert.ToInt32(parts[hourIndex]) : 0;
            this.Minute = minIndex >= 0 ? Convert.ToInt32(parts[minIndex]) : 0;
            this.Second = secIndex >= 0 ? Convert.ToInt32(parts[secIndex]) : 0;
            this.Millisecond = msIndex >= 0 ? Convert.ToInt32((parts[msIndex] + "000").Substring(0, 3)) : 0;
        }

        public AssEventTime(int hour, int minute, int second, int millisecond)
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
            this.Millisecond = millisecond;
        }

        public long TotalMilliseconds()
        {
            return this.Hour * 3600000 + this.Minute * 60000 + this.Second * 1000 + this.Millisecond;
        }

        public static explicit operator AssEventTime(TimeSpan ts)
        {
            return new AssEventTime(ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        public static explicit operator TimeSpan(AssEventTime time)
        {
            return new TimeSpan(0, time.Hour, time.Minute, time.Second, time.Millisecond);
        }

        public static AssEventTime operator +(AssEventTime aet, double num)
        {
            var target = new AssEventTime(aet.ToString());
            var ms = Convert.ToInt32(Math.Floor(num * 1000));
            target.Millisecond = target.Millisecond + ms;
            if (target.Millisecond > 1000)
            {
                target.Second += target.Millisecond / 1000;
                target.Millisecond = target.Millisecond % 1000;
            }
            if (target.Second > 60)
            {
                target.Minute += target.Second / 60;
                target.Second = target.Second % 60;
            }
            if (target.Minute > 60)
            {
                target.Hour += target.Minute / 60;
                target.Minute = target.Minute % 60;
            }

            return target;
        }

        public static AssEventTime operator -(AssEventTime aet, double num)
        {
            var ms = Convert.ToInt32(Math.Floor(num * 1000));
            var target = new AssEventTime(aet.ToString());
            target.Millisecond = aet.Millisecond - ms;
            if (target.Millisecond < 0)
            {
                target.Millisecond += 1000;
                target.Second -= 1;
            }
            if (target.Second < 0)
            {
                target.Second += 60;
                target.Minute -= 1;
            }
            if (target.Minute < 0)
            {
                target.Minute += 60;
                target.Hour -= 1;
            }
            return target;
        }

        public override bool Equals(object obj)
        {
            return CompareTo(obj) == 0;
        }

        public override int GetHashCode()
        {
            return (int)this.TotalMilliseconds();
        }
        public override string ToString()
        {
            return this.Hour.ToString().Substring(0, 1) + ":"
                   + this.Minute.ToString().PadLeft(2, '0') + ":"
                   + this.Second.ToString().PadLeft(2, '0') + "."
                   + this.Millisecond.ToString().PadLeft(3, '0').Substring(0, 2);
        }

        public int CompareTo(object obj)
        {
            var target = obj as AssEventTime;
            if (target == null)
            {
                target = new AssEventTime(obj.ToString());
            }
            return (int)(this.TotalMilliseconds() - target.TotalMilliseconds());
        }
    }

    public class AssEmbeddedFont
    {

    }

    public class AssEmbeddedGraphics
    {

    }

    public enum V4pStyleBorderStyle
    {
        BorderAndShadow = 1,
        ColorBackground = 3
    }

    public enum V4pStyleAlignment
    {
        SubLF = 1,
        SubCT = 2,
        SubRT = 3,
        MidLF = 4,
        MidCT = 5,
        MidRT = 6,
        TopLF = 7,
        TopCT = 8,
        TopRT = 9
    }

    public enum AssEventType
    {
        Dialogue,
        Comment,
        Picture,
        Sound,
        Movie,
        Command
    }

    public enum AssSection
    {
        Unknown,
        ScriptInfo,
        V4pStyles,
        Events,
        Fonts,
        Graphics
    }
}
