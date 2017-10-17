using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextEditer
{
    public partial class TextEditer : Form
    {
        private readonly List<string> _lines = new List<string>();
        private string _fileName;

        public TextEditer()
        {
            InitializeComponent();
        }

        private void richTextBoxMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void richTextBoxMain_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var filesName = (Array)e.Data.GetData(DataFormats.FileDrop);
                if (filesName.Length > 1)
                {
                    MessageBox.Show("只支持单文本文件拖拽！");
                    return;
                }
                _fileName = filesName.GetValue(0).ToString();

                using (var sr = new StreamReader(_fileName, checkBoxUTF8Read.Checked ? Encoding.UTF8 : Encoding.Default))
                {
                    richTextBoxMain.Text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "只支持单文本文件拖拽！");
            }
        }
        
        private void RefreshTextBox()
        {
            var sb = new StringBuilder();
            foreach (var line in _lines)
            {
                sb.AppendLine(line);
            }
            richTextBoxMain.Text = sb.ToString().TrimEnd();
        }


        private void buttonTrimLine_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxMain.Lines)
            {
                _lines.Add(line.Trim());
            }

            RefreshTextBox();
        }

        private void buttonAddHeadBlank_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxMain.Lines)
            {
                _lines.Add("　　" + line);
            }

            RefreshTextBox();
        }

        private void buttonRemoveBlankLine_Click(object sender, EventArgs e)
        {
            _lines.Clear();
            
            var lastLine = "";
            foreach (var currLine in richTextBoxMain.Lines)
            {
                if (currLine != "" || lastLine != "")
                {
                    _lines.Add(currLine);
                }
                lastLine = currLine;
            }

            RefreshTextBox();
        }
        
        private void buttonAddBlankLine_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxMain.Lines)
            {
                _lines.Add(line);
                _lines.Add("");
            }

            RefreshTextBox();
        }

        private void buttonShort2Long_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            var sb = new StringBuilder();
            foreach (var line in richTextBoxMain.Lines)
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
        
        private void buttonLong2Short_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxMain.Lines)
            {
                if (line == "")
                {
                    _lines.Add("");
                    continue;
                }
                foreach (var newLine in GetSubStringList(line, 35))
                {
                    _lines.Add(newLine);
                }
            }

            RefreshTextBox();
        }

        private static IEnumerable<string> GetSubStringList(string txt, int subLength)
        {
            var list = new List<string>();
            var temp = txt;

            for (var i = 0; i < temp.Length; i += subLength)
            {
                list.Add((temp.Length - i) > subLength ? temp.Substring(i, subLength) : temp.Substring(i));
            }

            return list;
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sw = new StreamWriter(_fileName, false, Encoding.Default))
                {
                    var txt = richTextBoxMain.Text.Replace("\n", "\r\n");   //Unix -> Dos
                    sw.Write(txt);
                }
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
