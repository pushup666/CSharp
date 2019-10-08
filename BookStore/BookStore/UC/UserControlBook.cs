using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BookStore.BLL;
using BookStore.DLG;
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
            dataGridViewBookList.DataSource = checkBoxUseFilter.Checked ? BookStoreBLL.GetBookList(textBoxFilter.Text) : BookStoreBLL.GetBookList();
            dataGridViewBookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Replace()
        {
            using var dt = BookStoreBLL.GetBookList();

            using var replaceFrm = new FrmReplace();
            if (replaceFrm.ShowDialog() == DialogResult.OK)
            {
                //处理Title
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var id = dt.Rows[i]["ID"].ToString();
                    var title = dt.Rows[i]["Title"].ToString();
                    var alias = dt.Rows[i]["Alias"].ToString();
                    var author = dt.Rows[i]["Author"].ToString();
                    var note = dt.Rows[i]["Note"].ToString();
                    var rate = int.Parse(dt.Rows[i]["Rate"].ToString());

                    if (title.Contains(replaceFrm.Input))
                    {
                        BookDO newbook = new BookDO(id, title.Replace(replaceFrm.Input, replaceFrm.Replace), alias, author, note, rate);
                        BookStoreBLL.ModifyBook(newbook);
                    }
                }

            }
            
            MessageBox.Show("测试结束！");
        }

        private void DataGridViewBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Save();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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

                var ucVersion = new UserControlVersion(_currBook.ID, _currBook.Title);
                var versionPage = new TabPage(newTabText) {Name = newTabName};

                versionPage.Controls.Add(ucVersion);
                ucVersion.Dock = DockStyle.Fill;

                tabControlMain.TabPages.Add(versionPage);
                tabControlMain.SelectTab(newTabName);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (_currBook != null)
            {
                _currBook = new BookDO(_currBook.ID, textBoxTitle.Text, textBoxAlias.Text, textBoxAuthor.Text, textBoxNote.Text, comboBoxRate.SelectedIndex);
                if (BookStoreBLL.ModifyBook(_currBook))
                {
                    //RefreshBookList();
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
                        //RefreshBookList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            using var folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

            var savePath = folderBrowserDialog.SelectedPath;

            var bookIDList = new List<string>();

            foreach (DataGridViewRow row in dataGridViewBookList.SelectedRows)
            {
                bookIDList.Add(row.Cells["ID"].Value.ToString());
            }

            for (var i = 0; i < bookIDList.Count; i++)
            {
                var id = bookIDList[i];
                var book = BookStoreBLL.GetBook(id);
                var latestVersion = BookStoreBLL.GetLatestVersion(id);

                if (latestVersion != null)
                {
                    var title = book.Title;
                    var alias = book.Alias == "" ? "" : $"({book.Alias})";
                    var note = book.Note == "" ? "" : $"{book.Note}";

                    var author = book.Author == "" ? "" : $"[{book.Author}]";
                    var hash = latestVersion.ContentHash.Substring(0, 4);

                    var filename = $@"{savePath}\{title}{alias}{note}{author}_{hash}.txt";
                    var content = latestVersion.Content;

                    using var sw = new StreamWriter(filename, false);
                    sw.Write(content);
                }
            }

            MessageBox.Show("导出完成！");
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshBookList();
        }

        private void ButtonReplace_Click(object sender, EventArgs e)
        {
            Replace();
        }
    }
}