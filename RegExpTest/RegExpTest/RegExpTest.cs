using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegExpTest
{
    public partial class RegExpTest : Form
    {
        private readonly List<string> _lines = new List<string>();

        public RegExpTest()
        {
            InitializeComponent();
        }

        private void ButtonPreProcess_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                richTextBox2.Text = richTextBox1.Text;
            }

            var tmp = "";
            while (tmp != richTextBox2.Text)
            {
                tmp = richTextBox2.Text;

                AddNewLineBefore();
                Short2Long();
            }

            RemoveAllBlankLine();
        }

        private void ButtonRegex_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            var r = new Regex("style=\".+\"");
            foreach (var line in richTextBox2.Lines)
            {
                _lines.Add(r.Replace(line, "style=\"\"")); 
            }
            RefreshTextBox();
        }

        private void AddNewLineBefore()
        {
            _lines.Clear();
            
            foreach (var line in richTextBox2.Lines)
            {
                var index = line.IndexOf("><", StringComparison.CurrentCulture);
                if (index > 0)
                {
                    _lines.Add(line.Substring(0, index + 1));
                    _lines.Add("");
                    _lines.Add(line.Substring(index + 1));
                }
                else
                {
                    _lines.Add(line);
                }
            }
            RefreshTextBox();
        }

        private void Short2Long()
        {
            _lines.Clear();

            var sb = new StringBuilder();
            foreach (var line in richTextBox2.Lines)
            {
                if (line != "")
                {
                    sb.Append(line);
                }
                else
                {
                    _lines.Add(sb.ToString());
                    _lines.Add("");
                    sb.Clear();
                }
            }
            _lines.Add(sb.ToString());

            RefreshTextBox();
        }

        private void RemoveAllBlankLine()
        {
            _lines.Clear();

            foreach (var currLine in richTextBox2.Lines)
            {
                if (currLine != "")
                {
                    _lines.Add(currLine);
                }
            }

            RefreshTextBox();
        }

        private void RefreshTextBox()
        {
            var sb = new StringBuilder();
            foreach (var line in _lines)
            {
                sb.AppendLine(line);
            }
            richTextBox2.Text = sb.ToString().TrimEnd();
        }


    }
}
