using System;
using System.Windows.Forms;

namespace BookStore.DLG
{
    public partial class FrmInput : Form
    {
        public string Input;
        public FrmInput()
        {
            InitializeComponent();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Input = textBoxInput.Text;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
