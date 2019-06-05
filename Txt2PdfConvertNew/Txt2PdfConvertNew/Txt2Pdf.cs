using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace Txt2PdfConvertNew
{
    public partial class Txt2Pdf : Form
    {
        private readonly Dictionary<string, bool> _files = new Dictionary<string, bool>();
        private const int MaxPagesPerPdf = 5000;

        public Txt2Pdf()
        {
            InitializeComponent();
            comboBoxDevice.SelectedIndex = 0;
            //TestSplit();
        }

        private void ButtonAddFileClick(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
                    SplitPdf(fileName);
                }
                MessageBox.Show($@"耗时：{DateTime.Now.Subtract(beginTime).TotalSeconds} 秒");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowFileList()
        {
            checkedListBoxFileName.Items.Clear();
            foreach (var file in _files)
            {
                checkedListBoxFileName.Items.Add(file.Key, file.Value);
            }
        }

        private void GeneratePdf(string fileName)
        {
            var pdfName = Path.ChangeExtension(fileName, "pdf");
            var pw = new PdfWriter(pdfName);
            var pdf = new PdfDocument(pw);
            var font = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\msyhbd.ttc,0", PdfEncodings.IDENTITY_H, false);
            
            var doc = new Document(pdf);

            using (var sr = new StreamReader(fileName, checkBoxUTF8.Checked ? Encoding.UTF8 : Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    doc.Add(new Paragraph(line == "" ? "\n" : line.Trim()).SetFont(font).SetFontSize(24));
                }
            }


            doc.Close();
        }

        private void TestSplit()
        {
            using (var sw = new StreamWriter(@"D:\111.csv", false, Encoding.Default))
            {
                StringBuilder sb = new StringBuilder();
                for (var i = 1; i < 30000; i++)
                {
                    var pagesCount = i;
                    var filesCount = (int)Math.Ceiling((double)pagesCount / MaxPagesPerPdf);
                    var pagesPerPdf = (int)Math.Ceiling((double)pagesCount / filesCount);

                    sb.AppendLine($"{pagesCount},{filesCount},{pagesPerPdf}");
                }

                sw.Write(sb.ToString());
            }

        }


        private void SplitPdf(string fileName)
        {
            //try
            //{
            //    if (fileName != null)
            //    {
            //        var reader = new PdfReader(Path.ChangeExtension(fileName, "pdf"));
            //        var pagesCount = reader.NumberOfPages;
            //        var filesCount = (int)Math.Ceiling((double)pagesCount / MaxPagesPerPdf);
            //        var pagesPerPdf = (int)Math.Ceiling((double)pagesCount / filesCount);

            //        for (var i = 0; i < filesCount; i++)
            //        {
            //            var document = new Document(reader.GetPageSizeWithRotation(1));

            //            string pdfSplitName = $@"{Path.GetDirectoryName(fileName)}\{Path.GetFileNameWithoutExtension(fileName)}-{(i + 1).ToString("D2")}.pdf";
            //            var pdfCopyProvider = new PdfCopy(document, new FileStream(pdfSplitName, FileMode.Create));

            //            document.Open();

            //            for (var j = 0; j < pagesPerPdf; j++)
            //            {
            //                var index = i * pagesPerPdf + j + 1;

            //                if (index <= pagesCount)
            //                {
            //                    pdfCopyProvider.AddPage(pdfCopyProvider.GetImportedPage(reader, index));
            //                }
            //            }

            //            document.Close();
            //        }

            //        reader.Close();

            //        File.Delete(Path.ChangeExtension(fileName, "pdf"));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
