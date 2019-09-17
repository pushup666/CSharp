using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TextEditor
{
    public partial class TextEditor : Form
    {
        private readonly List<string> _lines = new List<string>();
        private string _fileName;

        public TextEditor()
        {
            InitializeComponent();
        }

        private void RichTextBoxMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void RichTextBoxMain_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var filesNameArr = (Array)e.Data.GetData(DataFormats.FileDrop);
                if (filesNameArr.Length > 1)
                {
                    MessageBox.Show("只支持单文本文件拖拽！");
                    return;
                }
                _fileName = filesNameArr.GetValue(0).ToString();

                using (var sr = new StreamReader(_fileName, checkBoxUTF8.Checked ? Encoding.UTF8 : Encoding.Default))
                {
                    richTextBoxMain.Text = sr.ReadToEnd();
                    Text = "TextEditor - " + _fileName;
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

        private void TrimLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxMain.Lines)
            {
                _lines.Add(line.Trim());
            }

            RefreshTextBox();
        }

        private void AddHeadBlankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxMain.Lines)
            {
                if (line == "")
                {
                    _lines.Add(line);
                }
                else
                {
                    _lines.Add("　　" + line);
                }
            }

            RefreshTextBox();
        }

        private void RemoveBlankLineToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void AddBlankLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxMain.Lines)
            {
                _lines.Add(line);
                _lines.Add("");
            }

            RefreshTextBox();
        }

        private void RestoreBlankLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxMain.Lines)
            {
                if (line.Length < 33)
                {
                    _lines.Add(line);
                    _lines.Add("");
                }
                else
                {
                    _lines.Add(line);
                }
            }

            RefreshTextBox();
        }

        private void Short2LongToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void Long2ShortToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sw = new StreamWriter(_fileName, false, checkBoxUTF8.Checked ? Encoding.UTF8 : Encoding.Default))
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

        private void ButtonRegex_Click(object sender, EventArgs e)
        {
            var sb = new  StringBuilder();
            var i = 1;

            foreach (var line in richTextBoxMain.Lines)
            {
                var m = Regex.Match(line, textBoxRegex.Text);
                if (m.Success)
                {
                    sb.AppendLine($"{i++} {line}");
                }
            }

            richTextBoxSide.Text = sb.ToString();
        }

        private void ButtonAddLabel_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            _lines.Add("<TITLE>");

            foreach (var line in richTextBoxMain.Lines)
            {
                var m = Regex.Match(line, textBoxRegex.Text);
                if (m.Success)
                {
                    _lines.Add("<CHAPTER>" + line);
                }
                else
                {
                    _lines.Add(line);
                }
            }

            RefreshTextBox();
        }
    }
}
