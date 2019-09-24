using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.BLL;

namespace BookStore.UC
{
    public partial class UserControlLine : UserControl
    {
        private readonly string _versionID;
        public UserControlLine(string versionID)
        {
            InitializeComponent();
            _versionID = versionID;
            RefreshVersionList();
        }

        private void RefreshVersionList()
        {
            dataGridViewLineList.DataSource = BookStoreBLL.GetLineList(_versionID);
            dataGridViewLineList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            foreach (var row in dataGridViewLineList.SelectedRows)
            {
                
            }

            RefreshVersionList();
        }
    }
}
