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
        private string _bookID;
        public UserControlVersion(string bookID)
        {
            InitializeComponent();
            _bookID = bookID;
            RefreshVersionList();
        }

        internal void RefreshVersionList()
        {
            dataGridViewVersionList.DataSource = BookStoreBLL.GetBookList();
        }
    }
}
