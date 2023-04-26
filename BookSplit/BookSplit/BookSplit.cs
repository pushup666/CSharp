using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSplit
{
    public partial class BookSplit : Form
    {
        private string _fileName;
        private string[] _lineList;
        private Dictionary<int, string> _lineDict;

        public BookSplit()
        {
            InitializeComponent();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Text File|*.txt";

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                _fileName = openFileDialog.FileName;
                this.Text = $"BookSplit - {_fileName}";
                _lineList = File.ReadAllLines(openFileDialog.FileName, Encoding.Default);
            }

            LoadListToDict();
            RefreshView();
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            LoadListToDict();
            RefreshView();
        }


        private void LoadListToDict()
        {
            _lineDict = new Dictionary<int, string>();

            for (var i = 0; i < _lineList.Length; i++)
            {
                if (_lineList[i].Trim() == string.Empty)
                {
                    continue;
                }

                _lineDict.Add(i, _lineList[i]);
            }
        }

        private void RefreshView()
        {
            dataGridViewLineList.DataSource = _lineDict.ToList();
            dataGridViewLineList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            var pattern = comboBoxFilter.Text;
            var lengthmax = Convert.ToInt32(numericUpDownMaxLength.Value);

            if (pattern == "" && lengthmax == 0)
            {
                RefreshView();
                return;
            }
            
            if (pattern != "")
            {
                var listDelete = new List<int>();
                var r = new Regex(pattern);
                foreach (var item in _lineDict)
                {
                    if (!r.IsMatch(item.Value))
                    {
                        listDelete.Add(item.Key);
                    }
                }

                foreach (var key in listDelete)
                {
                    _lineDict.Remove(key);
                }
            }

            if (lengthmax > 0)
            {
                var listDelete = new List<int>();
                foreach (var item in _lineDict)
                {
                    if (item.Value.Length > lengthmax)
                    {
                        listDelete.Add(item.Key);
                    }
                }

                foreach (var key in listDelete)
                {
                    _lineDict.Remove(key);
                }
            }

            RefreshView();
        }

        private void ButtonFile_Click(object sender, EventArgs e)
        {
            string savePath;
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
                savePath = folderBrowserDialog.SelectedPath;
            }

            var chapterSplit = new int[dataGridViewLineList.RowCount + 1, 2];

            chapterSplit[0, 0] = 0;
            chapterSplit[dataGridViewLineList.RowCount, 1] = _lineList.Length -1;

            for (var i = 0; i < dataGridViewLineList.RowCount; i++)
            {
                var line = int.Parse(dataGridViewLineList.Rows[i].Cells["Key"].Value.ToString());
                chapterSplit[i, 1] = line - 1;
                chapterSplit[i + 1, 0] = line;
            }
            
            for (var i = 0; i < chapterSplit.Length / 2; i++)
            {
                var lineNoBegin = chapterSplit[i, 0];
                var lineNoEnd = chapterSplit[i, 1];
                var chapterTitle = _lineList[lineNoBegin];

                var sb = new StringBuilder();
                for (var j = lineNoBegin; j <= lineNoEnd; j++)
                {
                    sb.AppendLine(_lineList[j]);
                }

                File.WriteAllText($"{savePath}\\{lineNoBegin}_{chapterTitle}.txt", sb.ToString(), Encoding.Default);
            }

            MessageBox.Show("Finish!");
        }

        private void ButtonFolder_Click(object sender, EventArgs e)
        {
            string savePath;
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
                savePath = folderBrowserDialog.SelectedPath;
            }

            for (var i = 0; i < dataGridViewLineList.RowCount; i++)
            {
                var lineNo = int.Parse(dataGridViewLineList.Rows[i].Cells["Key"].Value.ToString());
                var chapterTitle = dataGridViewLineList.Rows[i].Cells["Value"].Value.ToString();

                Directory.CreateDirectory($"{savePath}\\{lineNo}_{chapterTitle}");
            }

            MessageBox.Show("Finish!");
        }

        private void DataGridViewLineList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();//添加行号
        }

        private void ButtonDeleteRow_Click(object sender, EventArgs e)
        {
            var listDelete = new List<int>();

            foreach (DataGridViewRow row in dataGridViewLineList.SelectedRows)
            {
                listDelete.Add((int)row.Cells["Key"].Value);
            }

            foreach (var key in listDelete)
            {
                _lineDict.Remove(key);
            }

            RefreshView();
        }
    }
}
