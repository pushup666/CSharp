using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.BLL;
using BookStore.Model;

namespace BookStore
{
    public partial class BookStoreFrm : Form
    {
        private List<string> _fileList = new List<string>();

        public BookStoreFrm()
        {
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
                    openFileDialog.Filter = "TXT File|*.txt";

                    if (openFileDialog.ShowDialog() != DialogResult.OK) return;

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
                    using (var sr = new StreamReader(fileName, Encoding.Default))
                    {
                        var fileContent = sr.ReadToEnd();
                        var contentHash = Utils.GetHash(fileContent);

                        if (!BookStoreBLL.IsThisHashExist(contentHash))
                        {
                            
                            var book = new BookDO(Path.GetFileNameWithoutExtension(fileName), "", "", "");
                            BookStoreBLL.AddBook(book);
                            var version = new VersionDO(book.UID, fileContent, contentHash, fileContent.Length);
                            BookStoreBLL.AddVersion(version);
                        }
                    }
                }

                MessageBox.Show("导入完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ ex.StackTrace);
            }
        }
    }
}