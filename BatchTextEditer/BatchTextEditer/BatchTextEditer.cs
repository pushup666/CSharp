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

namespace BatchTextEditer
{
    public partial class BatchTextEditer : Form
    {
        private Dictionary<string, long> _files = new Dictionary<string, long>();

        public BatchTextEditer()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "/QQ"))
            {
                Directory.CreateDirectory(Application.StartupPath + "/QQ");
            }

            using (StreamWriter sw = new StreamWriter(Application.StartupPath + "/QQ/" + textBoxName.Text))
            {
                sw.Write(richTextBoxInput.Text);
            }

            FileInfo file = new FileInfo(Application.StartupPath + "/" + textBoxName.Text);

            _files.Remove(file.FullName);
            file.MoveTo(file.FullName + ".bak");

            if (_files.Count == 0)
            {
                MessageBox.Show("全部完成！");
            }
            else
            {
                GetNextFile();
            }
        }

        private void buttonRemoveBlank_Click(object sender, EventArgs e)
        {
            string text = richTextBoxInput.Text;

            text = text.Replace(" ", "");
            text = text.Replace("　", "");
            text = text.Replace("", "");
            text = text.Replace("   ", "");
            text = text.Replace("", "");

            richTextBoxInput.Text = text.Trim();
        }

        private void buttonRemoveBlankLine_Click(object sender, EventArgs e)
        {
            string text = richTextBoxInput.Text;

            while (text.Contains("\n\n\n"))
            {
                text = text.Replace("\n\n\n", "\n\n");
            }

            richTextBoxInput.Text = text.Trim();
        }

        private void buttonShort2Long_Click(object sender, EventArgs e)
        {
            string text = richTextBoxInput.Text;

            text = text.Replace("\n\n", "aaaa");
            text = text.Replace("\n", "");
            text = text.Replace("aaaa", "\n\n");

            richTextBoxInput.Text = text.Trim();
        }

        private void buttonAddBlankLine_Click(object sender, EventArgs e)
        {
            string text = richTextBoxInput.Text;

            text = text.Replace("\n", "\n\n");

            richTextBoxInput.Text = text.Trim();
        }

        private void BatchTextEditer_Load(object sender, EventArgs e)
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

            //_files = _files.OrderBy(r => r.Value).ToDictionary(r => r.Key, r => r.Value);

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
            textBoxName.Text = file.Name;

            using (StreamReader sr = new StreamReader(textBoxName.Text, Encoding.Default))
            {
                richTextBoxInput.Text = sr.ReadToEnd();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定删除？", "警告！", MessageBoxButtons.YesNo))
            {
                FileInfo file = new FileInfo(Application.StartupPath + "/" + textBoxName.Text);

                _files.Remove(file.FullName);
                file.Delete();

                if (_files.Count == 0)
                {
                    MessageBox.Show("全部完成！");
                }
                else
                {
                    GetNextFile();
                }
            }
        }
    }
}
