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
    public partial class UserControlVersion : UserControl
    {
        private readonly string _bookID;
        public UserControlVersion(string bookID)
        {
            InitializeComponent();

            _bookID = bookID;
            RefreshVersionList();
        }

        private void RefreshVersionList()
        {
            dataGridViewVersionList.DataSource = BookStoreBLL.GetVersionList(_bookID);
        }

        private void DataGridViewVersionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var versionNo = int.Parse(dataGridViewVersionList.Rows[e.RowIndex].Cells["VersionNo"].Value.ToString());
                richTextBoxVersionContent.Text = BookStoreBLL.GetVersionContent(_bookID, versionNo);
            }
        }
    }
}
