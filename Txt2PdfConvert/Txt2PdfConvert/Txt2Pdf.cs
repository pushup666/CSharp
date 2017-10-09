using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Txt2PdfConvert
{
    public partial class Txt2Pdf : Form
    {
        private readonly Dictionary<string, bool> _files = new Dictionary<string, bool>();

        public Txt2Pdf()
        {
            InitializeComponent();
        }

        private void ButtonAddFileClick(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = @"C:\";
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var fileName in openFileDialog.FileNames)
                        {
                            try
                            {
                                _files.Add(fileName, true);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(fileName + ex.Message);
                            }
                        }  
                    }
                }

                ShowFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAddFolderClick(object sender, EventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var fileName in Directory.GetFiles(folderBrowserDialog.SelectedPath))
                        {
                            try
                            {
                                _files.Add(fileName, true);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(fileName + ex.Message);
                            }
                        }
                    }
                }

                ShowFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonClearListClick(object sender, EventArgs e)
        {
            _files.Clear();
            ShowFileList();
        }

        private void ButtonConvertClick(object sender, EventArgs e)
        {
            try
            {
                var beginTime = DateTime.Now;
                foreach (string fileName in checkedListBoxFileName.CheckedItems)
                {
                    GeneratePdf(fileName);
                }
                MessageBox.Show(string.Format("耗时：{0} 秒", DateTime.Now.Subtract(beginTime).TotalSeconds));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowFileList()
        {
            checkedListBoxFileName.Items.Clear();
            foreach(var file in _files)
            {
                checkedListBoxFileName.Items.Add(file.Key, file.Value);
            }
        }
        
        private static void GeneratePdf(string fileName)
        {
            try
            {
                var baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\msyhbd.ttc,0", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                var font = new Font(baseFont, 14f);                       //iPad mini2
                var document = new Document(new Rectangle(600, 800));     //iPad mini2

                //var font = new Font(baseFont, 22f);                         //iPhone 5s
                //var document = new Document(new Rectangle(450, 800));       //iPhone 5s

                PdfWriter.GetInstance(document, new FileStream(Path.ChangeExtension(fileName, "pdf"), FileMode.Create));
                document.Open();
                
                using (var sr = new StreamReader(fileName, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        document.Add(new Paragraph(line == "" ? "\n" : line.Trim(), font));
                    }
                }

                document.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
