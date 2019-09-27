using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BookStore.BLL;
using BookStore.Model;

namespace BookStore
{
    public partial class BookStoreFrm : Form
    {
        private readonly List<string> _fileList = new List<string>();


        public BookStoreFrm()
        {
            //BookStoreBLL.CreateTable();
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

                    var fileContent = sr.ReadToEnd();
                    var contentHash = Utils.GetHash(fileContent);

                    if (!BookStoreBLL.IsThisHashExist(contentHash))
                    {

                        var book = new BookDO(Path.GetFileNameWithoutExtension(fileName), "", "", "");
                        BookStoreBLL.AddBook(book);

                        var version = new VersionDO(book.ID, fileContent, contentHash, fileContent.Length);
                        BookStoreBLL.AddVersion(version);
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