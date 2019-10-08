using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BookStore.BLL;
using BookStore.Model;

namespace BookStore
{
    public partial class FrmBookStore : Form
    {
        private readonly List<string> _fileList = new List<string>();
        
        public FrmBookStore()
        {
            BookStoreBLL.CreateTable();
            InitializeComponent();
        }

        private void ButtonImportBooks_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Text File|*.txt";

                    if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                    _fileList.Clear();
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        try
                        {
                            _fileList.Add(fileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(fileName + ex.Message);
                        }
                    }
                }

                foreach (var fileName in _fileList)
                {
                    using var sr = new StreamReader(fileName, Encoding.Default);

                    var title = Path.GetFileNameWithoutExtension(fileName);
                    var fileContent = sr.ReadToEnd();
                    var contentHash = Utils.GetHash(fileContent);
                    
                    if (BookStoreBLL.IsThisHashExist(contentHash))
                    {
                        MessageBox.Show($"{title} 重复！");                        
                    }
                    else
                    {
                        var book = new BookDO(title, "", "", "");
                        var version = new VersionDO(book.ID, fileContent, contentHash, fileContent.Length);

                        if (!BookStoreBLL.AddBook(book))
                        {
                            MessageBox.Show($"{title} book 导入失败！");
                        }
                        else
                        {
                            if (!BookStoreBLL.AddVersion(version))
                            {
                                MessageBox.Show($"{title} version 导入失败！");
                            }
                        }
                    }
                }

                MessageBox.Show("导入完成！");

                ucBook.RefreshBookList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                using var folderBrowserDialog = new FolderBrowserDialog();

                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

                var savePath = folderBrowserDialog.SelectedPath;

                var bookList = BookStoreBLL.GetBookList();

                for (var i = 0; i < bookList.Rows.Count; i++)
                {
                    var id = bookList.Rows[i]["ID"].ToString();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TabControlMain_DoubleClick(object sender, EventArgs e)
        {
            var index = tabControlMain.SelectedIndex;

            if (index > 0)
            {
                tabControlMain.TabPages.RemoveAt(index);
                tabControlMain.SelectTab(index - 1);
            }            
        }


    }
}