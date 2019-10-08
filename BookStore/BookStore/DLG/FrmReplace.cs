using System;
using System.Windows.Forms;

namespace BookStore.DLG
{
    public partial class FrmReplace : Form
    {
        public string Input, Replace;
        public FrmReplace()
        {
            InitializeComponent();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Input = textBoxInput.Text;
            Replace = textBoxReplace.Text;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
