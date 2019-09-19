using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class BookStore : Form
    {
        private List<string> _fileList = new List<string>();

        public BookStore()
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
                        MessageBox.Show(Utils.GetHash(sr.ReadToEnd()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}