using System;
using System.Collections.Generic;
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

        public FrmBookStore()
        {
            BookStoreBLL.CreateTable();
            InitializeComponent();
        }

        private void FrmBookStore_Load(object sender, EventArgs e)
        {
            var bookPage = new TabPage("书库") { Name = "Library" };
            var ucBook = new UserControlBook();

            bookPage.Controls.Add(ucBook);
            ucBook.Dock = DockStyle.Fill;

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

                var count = 0;
                foreach (var fileName in _fileList)
                {
                    if (++count % 100 == 0)
                    {
                        //Console.WriteLine($"已导入： {count.ToString()}项");
                    }

                    var title = Path.GetFileNameWithoutExtension(fileName);

                    var ansiContent = File.ReadAllText(fileName, Encoding.Default);
                    var utf8Content = File.ReadAllText(fileName, Encoding.UTF8);

                    string fileContent;
                    if (ansiContent.Length > utf8Content.Length)
                    {
                        //判断是否是UTF-8的简单方法，可能不准确
                        MessageBox.Show($"{title} 疑似UTF-8格式，已转码保存，请核实是否正确。");
                        fileContent = utf8Content;
                    }
                    else
                    {
                        fileContent = ansiContent;
                    }
                    
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

                MessageBox.Show($"{count}项 导入完成！");

                ((UserControlBook)tabControlMain.TabPages[0].Controls[0]).RefreshBookList();
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

                        var filename = $@"{savePath}\{author}{title}{alias}{note}_{hash}.txt";
                        var content = latestVersion.Content;

                        using var sw = new StreamWriter(filename, false, Encoding.UTF8);
                        sw.Write(content);
                    }
                }

                MessageBox.Show("导出UTF-8完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        
        private void ButtonVacuum_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认将标记为“已删除”的数据从数据库里清空？同时这将收缩数据库未使用的空间，建议在RamDisk上操作。", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show(BookStoreBLL.VacuumDatabase() ? "释放空间完成！" : "释放空间失败！");
            }
        }

        private void TabControlMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control.Name.StartsWith("V_"))
            {
                ((UserControlVersion)e.Control.Controls[0]).UpdateBookLastRead();

            }
        }

        private void FrmBookStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage page in tabControlMain.TabPages)
            {
                if (page.Name.StartsWith("V_"))
                {
                    tabControlMain.TabPages.Remove(page);
                }
            }
        }
    }
}