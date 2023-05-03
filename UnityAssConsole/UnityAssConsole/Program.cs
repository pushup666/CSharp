using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace UnityAssConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (var arg in args)
                {
                    var openFileName = arg;
                    var ass = new AssSubtitle();

                    //Console.WriteLine($"openFileName: {openFileName}", openFileName);
                    ass.Load(openFileName, Encoding.Default);

                    ass.ScriptInfo.Clear();
                    ass.ScriptInfo.Add("ScriptType", new Tuple<string, string>("key-value", "v4.00+"));
                    ass.ScriptInfo.Add("Collisions", new Tuple<string, string>("key-value", "Normal"));
                    ass.ScriptInfo.Add("PlayResX", new Tuple<string, string>("key-value", "384"));
                    ass.ScriptInfo.Add("PlayResY", new Tuple<string, string>("key-value", "288"));
                    ass.ScriptInfo.Add("Timer", new Tuple<string, string>("key-value", "100"));

                    ass.V4pStyles.Clear();
                    var style = new AssStyle
                    {
                        Name = "Default",

                        Fontname = "微软雅黑",
                        Fontsize = Convert.ToDouble(18),

                        PrimaryColour = "&H00FFFFFF",               //AABBGGRR
                        SecondaryColour = "&H00000000",
                        OutlineColour = "&H00000000",               //边框颜色，Outline > 0
                        BackColour = "&H00000000",                  //阴影颜色，Shadow > 0

                        Bold = Convert.ToInt16("0") == -1,          //粗体
                        Italic = Convert.ToInt16("0") == -1,        //斜体
                        Underline = Convert.ToInt16("0") == -1,     //下划线
                        StrikeOut = Convert.ToInt16(("0")) == -1,   //中划线

                        ScaleX = Convert.ToDouble("100"),
                        ScaleY = Convert.ToDouble("100"),
                        Spacing = Convert.ToInt32("0"),             //字符间像素数
                        Angle = Convert.ToDouble("0"),              //旋转角度

                        BorderStyle = (V4pStyleBorderStyle)Convert.ToInt16("1"),   //BorderAndShadow = 1, ColorBackground = 3
                        Outline = Convert.ToInt32("2"),
                        Shadow = Convert.ToInt32("0"),

                        Alignment = (V4pStyleAlignment)Convert.ToInt16("2"),       //1: Bottom left 2: Bottom center 3: Bottom right    5: Top left 6: Top center 7: Top right    9: Middle left 10: Middle center 11: Middle right
                        MarginL = Convert.ToInt32("5"),
                        MarginR = Convert.ToInt32("5"),
                        MarginV = Convert.ToInt32("5"),

                        Encoding = Convert.ToInt32("134")
                    };
                    ass.V4pStyles[style.Name] = style;

                    ass.UnknownSections.Clear();

                    foreach (var evt in ass.Events)
                    {
                        try
                        {
                            evt.Style = "Default";
                            evt.Name = "SSF";
                            evt.MarginL = 0;
                            evt.MarginR = 0;
                            evt.MarginV = 0;
                            evt.Effect = "";

                            evt.Text = Regex.Replace(evt.Text, "{.+?}", "");

                            var texts = evt.Text.Split(new[] { "\\N" }, StringSplitOptions.RemoveEmptyEntries);

                            switch (texts.Length)
                            {
                                case 0:
                                    Console.WriteLine("Error: " + evt.Text);
                                    break;
                                case 1:
                                    evt.Text = texts[0].Trim();
                                    break;
                                case 2:
                                    evt.Text = texts[0].Trim() + "\\N{\\fs10}" + texts[1].Trim();
                                    break;
                                default:
                                    Console.WriteLine("Error: " + evt.Text);
                                    evt.Text = evt.Text.Replace("\\N"," ");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    var path = Path.GetDirectoryName(openFileName);
                    if (path == string.Empty)
                    {
                        path = Environment.CurrentDirectory;
                    }
                    path += "\\Unity";

                    Directory.CreateDirectory(path);

                    var saveFileName = string.Format($"{path}\\{Path.GetFileName(openFileName)}");

                    //Console.WriteLine($"saveFileName: {saveFileName}", saveFileName);
                    File.WriteAllText(saveFileName, ass.Stringify(), Encoding.UTF8);
                    Console.WriteLine($"{saveFileName}\nSaved");
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Usage:\nUnityAssConsole AssFileFullName");
            }
        }
    }
}
