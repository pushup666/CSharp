using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Txt2PdfConvert
{
    public partial class Txt2Pdf : Form
    {
        private readonly Dictionary<string, bool> _files = new Dictionary<string, bool>();
        private const int MaxPagesPerPdf = 5000;

        public Txt2Pdf()
        {
            InitializeComponent();
            comboBoxDevice.SelectedIndex = 0;
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

        private void ShowFileList()
        {
            checkedListBoxFileName.Items.Clear();
            foreach (var file in _files)
            {
                checkedListBoxFileName.Items.Add(file.Key, file.Value);
            }
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
        
        private void GeneratePdf(string fileName)
        {
            try
            {
                if (fileName != null)
                {
                    Document document;
                    float textFontSize;

                    switch (comboBoxDevice.Text)
                    {
                        case "iPad Mini2":
                            textFontSize = 36f;                                                 //iPad mini2 326 ppi
                            document = new Document(new Rectangle(1536, 2048));         //iPad mini2 2048x1536
                            break;
                        case "iPad Pro 11":
                            textFontSize = 36f;                                                 //iPad Pro 11 264 ppi
                            document = new Document(new Rectangle(1668, 2388));         //iPad Pro 11 2388x1668
                            break;
                        case "iPhone 5s":
                            textFontSize = 32f;                                                 //iPhone 5s 264 ppi
                            document = new Document(new Rectangle(640, 1136));          //iPhone 5s 1136x640
                            break;
                        case "iPhone 8":
                            textFontSize = 32f;                                                 //iPhone 8 264 ppi
                            document = new Document(new Rectangle(750, 1334));          //iPhone 8 1334x750
                            break;
                        default:
                            textFontSize = 36f;                                                 //iPad Pro 11 264 ppi
                            document = new Document(new Rectangle(1668, 2388));         //iPad Pro 11 2388x1668
                            break;
                    }

                    var baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\msyhbd.ttc,0", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                    var textFont = new Font(baseFont, (float)(textFontSize * 1.0));
                    var chapterFont = new Font(baseFont, (float)(textFontSize * 1.5));
                    var titleFont = new Font(baseFont, (float)(textFontSize * 2.0));

                    if (checkBoxReverse.Checked)
                    {
                        textFont.Color = BaseColor.WHITE;
                        chapterFont.Color = BaseColor.WHITE;
                        titleFont.Color = BaseColor.WHITE;
                        document.PageSize.BackgroundColor = BaseColor.BLACK;
                    }

                    var pdfName = Path.ChangeExtension(fileName, "pdf");
                    PdfWriter.GetInstance(document, new FileStream(pdfName, FileMode.Create));

                    document.Open();

                    using (var sr = new StreamReader(fileName, checkBoxUTF8.Checked ? Encoding.UTF8 : Encoding.Default))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Font font;
                            if (line.StartsWith("<TITLE>"))
                            {
                                font = titleFont;
                                line = line.Remove(0, 7);
                            }
                            else if (line.StartsWith("<CHAPTER>"))
                            {
                                font = chapterFont;
                                line = line.Remove(0, 9);
                            }
                            else
                            {
                                font = textFont;
                            }

                            document.Add(new Paragraph(line == "" ? "\n" : line.Trim(), font));
                        }
                    }

                    document.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void SplitPdf(string fileName)
        {
            try
            {
                if (fileName != null)
                {
                    var reader = new PdfReader(Path.ChangeExtension(fileName, "pdf"));
                    var pagesCount = reader.NumberOfPages;
                    var filesCount = (int)Math.Ceiling((double)pagesCount / MaxPagesPerPdf);
                    var pagesPerPdf = (int)Math.Ceiling((double)pagesCount / filesCount);

                    for (var i = 0; i < filesCount; i++)
                    {
                        var document = new Document(reader.GetPageSizeWithRotation(1));

                        var pdfSplitName = $@"{Path.GetDirectoryName(fileName)}\{Path.GetFileNameWithoutExtension(fileName)}-{i + 1:D2}.pdf";
                        var pdfCopyProvider = new PdfCopy(document, new FileStream(pdfSplitName, FileMode.Create));

                        document.Open();

                        for (var j = 0; j < pagesPerPdf; j++)
                        {
                            var index = i * pagesPerPdf + j + 1;

                            if (index <= pagesCount)
                            {
                                pdfCopyProvider.AddPage(pdfCopyProvider.GetImportedPage(reader, index));
                            }
                        }

                        pdfCopyProvider.Close();
                        document.Close();
                    }

                    reader.Close();

                    File.Delete(Path.ChangeExtension(fileName, "pdf"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
    }
}
