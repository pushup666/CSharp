﻿using System;
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
                }
                MessageBox.Show(string.Format("耗时：{0} 秒", DateTime.Now.Subtract(beginTime).TotalSeconds));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSplit_Click(object sender, EventArgs e)
        {
            try
            {
                var beginTime = DateTime.Now;
                foreach (string fileName in checkedListBoxFileName.CheckedItems)
                {
                    SplitPdf(fileName);
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
        
        private void GeneratePdf(string fileName)
        {
            try
            {
                if (fileName != null)
                {
                    var baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\msyhbd.ttc,0", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font font; 
                    Document document;

                    if (radioButtonMini2.Checked)
                    {
                        font = new Font(baseFont, 14f);                       //iPad mini2
                        document = new Document(new Rectangle(600, 800));     //iPad mini2
                    }
                    else
                    {
                        font = new Font(baseFont, 23f);                         //iPhone 5s
                        document = new Document(new Rectangle(450, 800));       //iPhone 5s
                    }

                    //font.Color = BaseColor.WHITE;
                    //document.PageSize.BackgroundColor = BaseColor.BLACK;

                    var pdfName = Path.ChangeExtension(fileName, "pdf");
                    PdfWriter.GetInstance(document, new FileStream(pdfName, FileMode.Create));

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void SplitPdf(string fileName)
        {
            try
            {
                if (fileName != null)
                {
                    var pagesPerPdf = radioButtonMini2.Checked ? 3000 : 5000;

                    var reader = new PdfReader(Path.ChangeExtension(fileName, "pdf"));
                    var pagesCount = reader.NumberOfPages;
                    var filesCount = pagesCount / pagesPerPdf + 1;


                    for (var i = 0; i < filesCount; i++)
                    {
                        var document = new Document(reader.GetPageSizeWithRotation(1));

                        string pdfSplitName = $@"{Path.GetDirectoryName(fileName)}\{Path.GetFileNameWithoutExtension(fileName)}-{(i + 1).ToString("D2")}.pdf";
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
