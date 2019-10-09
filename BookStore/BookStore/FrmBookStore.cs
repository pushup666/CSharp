//#define LOG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BookStore.BLL;
using BookStore.Model;
using BookStore.UC;


namespace BookStore
{

    public partial class FrmBookStore : Form
    {
        private readonly List<string> _fileList = new List<string>();
        private readonly UserControlBook _ucBook = new UserControlBook();

        public FrmBookStore()
        {
            BookStoreBLL.CreateTable();
            InitializeComponent();
        }

        private void FrmBookStore_Load(object sender, EventArgs e)
        {
            var bookPage = new TabPage("书库") { Name = "Library" };

            bookPage.Controls.Add(_ucBook);
            _ucBook.Dock = DockStyle.Fill;

            tabControlMain.TabPages.Add(bookPage);
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

        private void ButtonImportBooks_Click(object sender, EventArgs e)
        {
            try
            {
#if LOG
                using var sw = new StreamWriter($@"{Environment.CurrentDirectory}\{DateTime.Now:yyyy-MM-dd}.log", true);
                var stopw = new Stopwatch();
#endif
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Text File|*.txt";

                    if (openFileDialog.ShowDialog() != DialogResult.OK) return;
#if LOG
                    stopw.Restart();
#endif
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
#if LOG
                    sw.WriteLine($"准备工作 {stopw.ElapsedMilliseconds} ms");
#endif
                }

                var count = 0;
                foreach (var fileName in _fileList)
                {
                    if (++count % 100 == 0)
                    {
                        Console.WriteLine($"已导入： {count.ToString()}项");
                    }
#if LOG
                    stopw.Restart();
#endif
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
#if LOG
                    sw.WriteLine($"导入{fileName} {stopw.ElapsedMilliseconds} ms");
#endif
                }

                MessageBox.Show($"{count.ToString()}项 导入完成！");

                _ucBook.RefreshBookList();
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
        
        private void ButtonVacuum_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"确认将标记为“已删除”的数据从数据库里清空？同时这将收缩数据库未使用的空间。", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BookStoreBLL.VacuumDatabase();
                MessageBox.Show("释放空间完成！");
            }
        }
    }
}