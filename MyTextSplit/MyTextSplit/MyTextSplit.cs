using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTextSplit
{
    public partial class MyTextSplit : Form
    {
        private Dictionary<string, long> _files = new Dictionary<string, long>();

        public MyTextSplit()
        {
            InitializeComponent();
        }

        private void MyTextSplit_Load(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath);

            foreach (var file in di.GetFiles("*.txt"))
            {
                try
                {
                    _files.Add(file.FullName, file.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(file.Name + ex.Message);
                }
            }

            _files = _files.OrderBy(r => r.Value).ToDictionary(r => r.Key, r => r.Value);

            if (_files.Count == 0)
            {
                MessageBox.Show("没有文件！");
            }
            else
            {
                GetNextFile();
            }
        }

        private void GetNextFile()
        {
            FileInfo file = new FileInfo(_files.First().Key);
            textBoxName.Text = file.FullName;

            textBoxFolder.Text = Path.GetFileNameWithoutExtension(file.Name);
            textBoxChapter.Text = 1.ToString();

            using (StreamReader sr = new StreamReader(textBoxName.Text, Encoding.Default))
            {
                richTextBoxInput.Text = sr.ReadToEnd();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            _files.Remove(textBoxName.Text);
            FileInfo file = new FileInfo(textBoxName.Text);
            file.MoveTo(textBoxName.Text + ".bak");

            if(_files.Count == 0)
            {
                MessageBox.Show("全部完成！");
            }
            else
            {
                GetNextFile();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "/Split/" + textBoxFolder.Text))
            {
                Directory.CreateDirectory(Application.StartupPath + "/Split/" + textBoxFolder.Text);
            }

            using (StreamWriter sw = new StreamWriter(Application.StartupPath + "/Split/" + textBoxFolder.Text + "/" + textBoxPrefix.Text + textBoxChapter.Text + textBoxSuffix.Text+".txt"))
            {
                sw.Write(richTextBoxOutput.Text);
            }

            textBoxChapter.Text = (int.Parse(textBoxChapter.Text) + 1).ToString();

            richTextBoxOutput.Text = "";
        }

        private void buttonRemoveBlank_Click(object sender, EventArgs e)
        {
            string text = richTextBoxOutput.Text;

            text = text.Replace(" ", "");
            text = text.Replace("　", "");
            text = text.Replace("", "");
            text = text.Replace("   ", "");
            text = text.Replace("", "");

            richTextBoxOutput.Text = text.Trim();
        }

        private void buttonRemoveBlankLine_Click(object sender, EventArgs e)
        {
            string text = richTextBoxOutput.Text;

            while (text.Contains("\n\n\n"))
            {
                text = text.Replace("\n\n\n", "\n\n");
            }

            richTextBoxOutput.Text = text.Trim();
        }

        private void buttonAddBlankLine_Click(object sender, EventArgs e)
        {
            string text = richTextBoxOutput.Text;

            text = text.Replace("\n", "\n\n");

            richTextBoxOutput.Text = text.Trim();
        }

        private void buttonShort2Long_Click(object sender, EventArgs e)
        {
            string text = richTextBoxOutput.Text;

            text = text.Replace("\n\n", "aaaa");
            text = text.Replace("\n", "");
            text = text.Replace("aaaa", "\n\n");

            richTextBoxOutput.Text = text.Trim();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            richTextBoxOutput.Text = richTextBoxInput.Text;
        }
    }
}
