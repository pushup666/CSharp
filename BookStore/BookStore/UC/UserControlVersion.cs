﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.BLL;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.UC
{
    public partial class UserControlVersion : UserControl
    {
        private readonly string _bookID;
        private VersionDO _currVersion;
        private readonly List<string> _lines = new List<string>();

        public UserControlVersion(string bookID)
        {
            InitializeComponent();

            _bookID = bookID;
            RefreshVersionList();
        }

        private void RefreshVersionList()
        {
            dataGridViewVersionList.DataSource = BookStoreBLL.GetVersionList(_bookID);
            dataGridViewVersionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dataGridViewVersionList.RowCount > 0)
            {
                var versionNo = dataGridViewVersionList.Rows[0].Cells["No"].Value.ToString();
                _currVersion = BookStoreBLL.GetVersion(_bookID, int.Parse(versionNo));

                richTextBoxVersionContent.Text = _currVersion.Content;
            }
        }

        private void DataGridViewVersionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var versionNo = dataGridViewVersionList.Rows[e.RowIndex].Cells["No"].Value.ToString();
                _currVersion = BookStoreBLL.GetVersion(_bookID, int.Parse(versionNo));

                richTextBoxVersionContent.Text = _currVersion.Content;
            }
        }

        private void DataGridViewVersionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var title = dataGridViewVersionList.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                var versionNo = dataGridViewVersionList.Rows[e.RowIndex].Cells["No"].Value.ToString();
                _currVersion = BookStoreBLL.GetVersion(_bookID, int.Parse(versionNo));

                //BookStoreBLL.IsVersionLineHashMatch(_currVersion.ID);

                var tabControlMain = ((TabControl)Parent.Parent);
                var tabName = $"{title} - {versionNo}";

                if (tabControlMain.TabPages.ContainsKey(tabName))
                {
                    tabControlMain.SelectTab(tabName);
                    return;
                }

                var ucLine = new UserControlLine(_currVersion.BookID);
                var linePage = new TabPage(tabName) {Name = tabName};

                linePage.Controls.Add(ucLine);
                ucLine.Dock = DockStyle.Fill;

                tabControlMain.TabPages.Add(linePage);
                tabControlMain.SelectTab(tabName);
            }
        }

        private void RefreshTextBox()
        {
            var sb = new StringBuilder();
            foreach (var line in _lines)
            {
                sb.AppendLine(line);
            }
            richTextBoxVersionContent.Text = sb.ToString().TrimEnd();
        }



        private void TrimLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxVersionContent.Lines)
            {
                _lines.Add(line.Trim());
            }

            RefreshTextBox();
        }

        private void AddHeadBlankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxVersionContent.Lines)
            {
                if (line == "")
                {
                    _lines.Add(line);
                }
                else
                {
                    _lines.Add("　　" + line);
                }
            }

            RefreshTextBox();
        }

        private void RemoveBlankLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            var lastLine = "";
            foreach (var currLine in richTextBoxVersionContent.Lines)
            {
                if (currLine != "" || lastLine != "")
                {
                    _lines.Add(currLine);
                }
                lastLine = currLine;
            }

            RefreshTextBox();
        }

        private void AddBlankLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxVersionContent.Lines)
            {
                _lines.Add(line);
                _lines.Add("");
            }

            RefreshTextBox();
        }

        private void RestoreBlankLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxVersionContent.Lines)
            {
                if (line.Length < 33)
                {
                    _lines.Add(line);
                    _lines.Add("");
                }
                else
                {
                    _lines.Add(line);
                }
            }

            RefreshTextBox();
        }

        private void Short2LongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            var sb = new StringBuilder();
            foreach (var line in richTextBoxVersionContent.Lines)
            {
                if (line != "")
                {
                    sb.Append(line);
                }
                else
                {
                    _lines.Add(sb.ToString());
                    _lines.Add("");
                    sb.Clear();
                }
            }
            _lines.Add(sb.ToString());

            RefreshTextBox();
        }

        private void Long2ShortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxVersionContent.Lines)
            {
                if (line == "")
                {
                    _lines.Add("");
                    continue;
                }
                foreach (var newLine in GetSubStringList(line, 35))
                {
                    _lines.Add(newLine);
                }
            }

            RefreshTextBox();
        }

        private static IEnumerable<string> GetSubStringList(string txt, int subLength)
        {
            var list = new List<string>();
            var temp = txt;

            for (var i = 0; i < temp.Length; i += subLength)
            {
                list.Add((temp.Length - i) > subLength ? temp.Substring(i, subLength) : temp.Substring(i));
            }

            return list;
        }

        private void ToLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Clear();

            foreach (var line in richTextBoxVersionContent.Lines)
            {
                _lines.Add(line);
            }

            if (BookStoreBLL.Version2Lines(_currVersion.BookID, _lines))
            {
                MessageBox.Show($"拆解完成！");
            }
            else
            {
                MessageBox.Show($"拆解失败！");
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currVersion != null)
            {
                var contentNew = richTextBoxVersionContent.Text.Replace("\n", "\r\n");
                var contentNewHash = Utils.GetHash(contentNew);

                if (contentNewHash == _currVersion.ContentHash)
                {
                    MessageBox.Show("无改动！");
                }
                else
                {
                    var version = new VersionDO(_currVersion.BookID, contentNew, contentNewHash, contentNew.Length);
                    BookStoreBLL.AddVersion(version);

                    RefreshVersionList();
                }
            }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currVersion != null)
            {
                if (MessageBox.Show($"确认删除 版本“{_currVersion.VersionNo}” 文件？", "警告⚠", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BookStoreBLL.RemoveVersion(_currVersion.ID);
                }
            }

            RefreshVersionList();
        }
    }
}