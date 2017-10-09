using System;
using System.Windows.Forms;

namespace TextEditer
{
    public partial class TextEditer : Form
    {
        public TextEditer()
        {
            InitializeComponent();
        }

        private void buttonRemoveBlankLine_Click(object sender, EventArgs e)
        {
            string text = richTextBoxMain.Text;

            while (text.Contains("\n\n\n"))
            {
                text = text.Replace("\n\n\n", "\n\n");
            }

            richTextBoxMain.Text = text.Trim();
        }

        private void buttonRemoveBlank_Click(object sender, EventArgs e)
        {
            string text = richTextBoxMain.Text;

            text = text.Replace(" ", "");
            text = text.Replace("　", "");
            text = text.Replace("", "");
            text = text.Replace("", "");

            richTextBoxMain.Text = text.Trim();
        }

        private void buttonAddBlankLine_Click(object sender, EventArgs e)
        {
            string text = richTextBoxMain.Text;

            text = text.Replace("\n", "\n\n");

            richTextBoxMain.Text = text.Trim();
        }

        private void buttonShort2Long_Click(object sender, EventArgs e)
        {
            string text = richTextBoxMain.Text;

            text = text.Replace("\n\n", "aaaa");
            text = text.Replace("\n", "");
            text = text.Replace("aaaa", "\n\n");

            richTextBoxMain.Text = text.Trim();
        }
    }
}
