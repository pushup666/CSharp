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
using BookStore.Model;

namespace BookStore.UC
{
    public partial class UserControlBook : UserControl
    {
        private BookDO _currBbook;

        public UserControlBook()
        {
            InitializeComponent();
            RefreshBookList();
        }

        internal void RefreshBookList()
        {
            dataGridViewBookList.DataSource = BookStoreBLL.GetBookList();
        }

        private void DataGridViewBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var bookID = dataGridViewBookList.Rows[e.RowIndex].Cells["UID"].Value.ToString();
                _currBbook = BookStoreBLL.GetBook(bookID);

                textBoxTitle.Text = _currBbook.Title;
                textBoxAlias.Text = _currBbook.Alias;
                textBoxAuthor.Text = _currBbook.Author;
                textBoxNote.Text = _currBbook.Note;
                comboBoxRate.SelectedIndex = _currBbook.Rate;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (_currBbook != null)
            {
                _currBbook = new BookDO(_currBbook.UID, textBoxTitle.Text, textBoxAlias.Text, textBoxAuthor.Text,
                    textBoxNote.Text, comboBoxRate.SelectedIndex);
                BookStoreBLL.ModifyBook(_currBbook);
            }

            RefreshBookList();
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (_currBbook != null)
            {
                if (MessageBox.Show($"确认删除 “{_currBbook.Title}” 文件？", "警告⚠", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BookStoreBLL.RemoveBook(_currBbook);
                }
            }

            RefreshBookList();
        }

        private void DataGridViewBook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_currBbook != null)
            {
                var mainTabPages = ((TabControl) Parent.Parent).TabPages;

                if (mainTabPages.ContainsKey(_currBbook.Title))
                {
                    return;
                }

                var ucVersion = new UserControlVersion(_currBbook.UID);
                var versionPage = new TabPage(_currBbook.Title) {Name = _currBbook.Title};

                versionPage.Controls.Add(ucVersion);
                ucVersion.Dock = DockStyle.Fill;

                mainTabPages.Add(versionPage);
            }
        }
    }
}
