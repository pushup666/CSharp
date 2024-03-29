﻿using BookStore.BLL;
using BookStore.DLG;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BookStore.UC
{
    public partial class UserControlBook : UserControl
    {
        private BookDO _currBook;

        private readonly int _pageSize;
        private int _rowCount, _pageCount;
        private int _currentPage = 1;  
        

        public UserControlBook()
        {
            InitializeComponent();

            if (!int.TryParse(Utils.GetAppConfig("PageSize"), out _pageSize))
            {
                _pageSize = 100;
            }

            RefreshBookList();
        }

        public void RefreshBookList()
        {
            using var bookList = checkBoxUseFilter.Checked ? BookStoreBLL.GetBookList(textBoxTitleFilter.Text, comboBoxRateFilter.Text, comboBoxOrderBy.Text) : BookStoreBLL.GetBookList();

            if (bookList == null) return;

            _rowCount = bookList.Rows.Count;
            _pageCount = (int)Math.Ceiling((double)_rowCount / _pageSize);

            if (_pageCount == 0)
            {
                _pageCount = 1;
            }

            var currentPageBookList = bookList.Copy();
            currentPageBookList.Clear();

            var beginRow = Math.Max((_currentPage - 1) * _pageSize, 0);
            var endRow = Math.Min(_currentPage * _pageSize, _rowCount);

            for (var i = beginRow; i < endRow; i++)
            {
                currentPageBookList.ImportRow(bookList.Rows[i]);
            }

            dataGridViewBookList.DataSource = currentPageBookList;
            dataGridViewBookList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            labelRowCount.Text = $"总行数：{_rowCount}";
            labelPageSize.Text = $"每页行数：{_pageSize}";
            labelCurrentPage.Text = $"当前页数：{_currentPage} / {_pageCount}";
        }



        private void DataGridViewBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetSelectedBookInfo(e.RowIndex);
        }

        private void GetSelectedBookInfo(int rowIndex)
        {
            try
            {
                //Save();
                
                if (rowIndex >= 0 && rowIndex < dataGridViewBookList.Rows.Count)
                {
                    var bookID = dataGridViewBookList.Rows[rowIndex].Cells["ID"].Value.ToString();
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
            GetNewVersionTabOfCurrBook();
        }

        private void GetNewVersionTabOfCurrBook()
        {
            if (_currBook != null)
            {
                var tabControlMain = ((TabControl)Parent.Parent);
                var newTabName = "V_" + _currBook.ID;
                var newTabText = _currBook.Title;

                if (tabControlMain.TabPages.ContainsKey(newTabName))
                {
                    tabControlMain.SelectTab(newTabName);
                    return;
                }

                var versionPage = new TabPage(newTabText) { Name = newTabName };
                tabControlMain.TabPages.Add(versionPage);
                tabControlMain.SelectTab(newTabName);

                var ucVersion = new UserControlVersion(_currBook.ID, _currBook.Title);
                versionPage.Controls.Add(ucVersion);
                ucVersion.Dock = DockStyle.Fill;
            }
        }

        private void DataGridViewBookList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    GetNewVersionTabOfCurrBook();
                    break;
                case Keys.Up:
                    GetSelectedBookInfo(dataGridViewBookList.CurrentCell.RowIndex - 1);
                    break;
                case Keys.Down:
                    GetSelectedBookInfo(dataGridViewBookList.CurrentCell.RowIndex + 1);
                    break;
                case Keys.Left:
                    JumpToPrevPage();
                    GetSelectedBookInfo(dataGridViewBookList.CurrentCell.RowIndex);
                    break;
                case Keys.Right:
                    JumpToNextPage();
                    GetSelectedBookInfo(dataGridViewBookList.CurrentCell.RowIndex);
                    break;
                case Keys.PageUp:
                    JumpToFirstPage();
                    GetSelectedBookInfo(dataGridViewBookList.CurrentCell.RowIndex);
                    break;
                case Keys.PageDown:
                    JumpToLastPage();
                    GetSelectedBookInfo(dataGridViewBookList.CurrentCell.RowIndex);
                    break;
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
                if (MessageBox.Show($"确认删除 “{_currBook.Title}” 文件？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

            foreach (var id in bookIDList)
            {
                var book = BookStoreBLL.GetBook(id);
                var latestVersion = BookStoreBLL.GetLatestVersion(id);

                if (latestVersion != null)
                {
                    var title = book.Title;
                    var alias = book.Alias == "" ? "" : $"({book.Alias})";
                    var note = book.Note == "" ? "" : $"{book.Note}";

                    var author = book.Author == "" ? "" : $"[{book.Author}]";
                    var hash = latestVersion.ContentHash.Substring(0, 4);

                    var filename = $@"{savePath}\{author}{title}{alias}{note}_{hash}.txt";
                    var content = latestVersion.Content;

                    using var sw = new StreamWriter(filename, false, Encoding.UTF8);
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

        private void Replace()
        {
            using var dt = BookStoreBLL.GetBookList();

            using var replaceFrm = new FrmReplace();
            if (replaceFrm.ShowDialog() == DialogResult.OK && replaceFrm.Input != string.Empty)
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

            MessageBox.Show("替换结束！");
        }



        private void ButtonFirstPage_Click(object sender, EventArgs e)
        {
            JumpToFirstPage();
        }
        
        private void ButtonPrevPage_Click(object sender, EventArgs e)
        {
            JumpToPrevPage();
        }

        private void ButtonNextPage_Click(object sender, EventArgs e)
        {
            JumpToNextPage();
        }

        private void ButtonLastPage_Click(object sender, EventArgs e)
        {
            JumpToLastPage();
        }


        private void JumpToFirstPage()
        {
            _currentPage = 1;
            RefreshBookList();
        }

        private void JumpToPrevPage()
        {
            if (_currentPage <= 1) return;
            _currentPage--;
            RefreshBookList();
        }

        private void JumpToNextPage()
        {
            if (_currentPage >= _pageCount) return;
            _currentPage++;
            RefreshBookList();
        }


        private void JumpToLastPage()
        {
            _currentPage = _pageCount;
            RefreshBookList();
        }
    }
}