using System;
using System.Windows.Forms;
using BookStore.BLL;
using BookStore.Model;

namespace BookStore.UC
{
    public partial class UserControlBook : UserControl
    {
        private BookDO _currBook;

        public UserControlBook()
        {
            InitializeComponent();
            RefreshBookList();
        }

        internal void RefreshBookList()
        {
            dataGridViewBookList.DataSource = BookStoreBLL.GetBookList();
            dataGridViewBookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void DataGridViewBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var bookID = dataGridViewBookList.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                _currBook = BookStoreBLL.GetBook(bookID);

                textBoxTitle.Text = _currBook.Title;
                textBoxAlias.Text = _currBook.Alias;
                textBoxAuthor.Text = _currBook.Author;
                textBoxNote.Text = _currBook.Note;
                comboBoxRate.SelectedIndex = _currBook.Rate;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (_currBook != null)
            {
                _currBook = new BookDO(_currBook.ID, textBoxTitle.Text, textBoxAlias.Text, textBoxAuthor.Text, textBoxNote.Text, comboBoxRate.SelectedIndex);
                if (BookStoreBLL.ModifyBook(_currBook))
                {
                    RefreshBookList();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (_currBook != null)
            {
                if (MessageBox.Show($"确认删除 “{_currBook.Title}” 文件？", "警告⚠", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (BookStoreBLL.RemoveBook(_currBook.ID))
                    {
                        RefreshBookList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        private void DataGridViewBook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_currBook != null)
            {
                var tabControlMain = ((TabControl) Parent.Parent);
                var newTabName = "V" + _currBook.ID;
                var newTabText = _currBook.Title;

                if (tabControlMain.TabPages.ContainsKey(newTabName))
                {
                    tabControlMain.SelectTab(newTabName);
                    return;
                }

                var ucVersion = new UserControlVersion(_currBook.ID);
                var versionPage = new TabPage(newTabText) {Name = newTabName};

                versionPage.Controls.Add(ucVersion);
                ucVersion.Dock = DockStyle.Fill;

                tabControlMain.TabPages.Add(versionPage);
                tabControlMain.SelectTab(newTabName);
            }
        }
    }
}