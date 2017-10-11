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

        private void textBoxMain_DragDrop(object sender, DragEventArgs e)
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

                using (var sr = new StreamReader(_fileName, Encoding.Default))
                {
                    textBoxMain.Text = sr.ReadToEnd();
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

           textBoxMain.Text = sb.ToString().Trim();
        }


        private void buttonTrimLine_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in textBoxMain.Lines)
            {
                _lines.Add(line.Trim());
            }

            RefreshTextBox();
        }

        private void buttonRemoveBlankLine_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            var lastLine = "";
            foreach (var currLine in textBoxMain.Lines)
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

            foreach (var line in textBoxMain.Lines)
            {
                _lines.Add(line.Trim());
                _lines.Add("");
            }

            RefreshTextBox();
        }

        private void buttonShort2Long_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            StringBuilder sb = new StringBuilder();
            foreach (var line in textBoxMain.Lines)
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



        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sw = new StreamWriter(_fileName, false, Encoding.Default))
                {
                    sw.Write(textBoxMain.Text);
                }
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }
    }
}
