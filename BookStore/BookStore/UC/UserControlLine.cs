using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BookStore.BLL;
using BookStore.Model;

namespace BookStore.UC
{
    public partial class UserControlLine : UserControl
    {
        private readonly string _bookID;
        private readonly string _bookTitle;

        public UserControlLine(string bookID, string bookTitle)
        {
            _bookID = bookID;
            _bookTitle = bookTitle;

            InitializeComponent();
            RefreshVersionList();
        }

        private void RefreshVersionList()
        {
            dataGridViewLineList.DataSource = BookStoreBLL.GetLineList(_bookID);
            dataGridViewLineList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var content = BookStoreBLL.Lines2String(_bookID);
            var hash = Utils.GetHash(content);

            if (BookStoreBLL.IsThisHashExist(hash))
            {
                MessageBox.Show("已存在");
                return;
            }

            var version = new VersionDO(_bookID, content, hash, content.Length);

            if (BookStoreBLL.AddVersion(version))
            {
                MessageBox.Show("保存成功！");

                var tabControlMain = ((TabControl)Parent.Parent);
                tabControlMain.TabPages.RemoveByKey("L"+ _bookID);

                var newTabName = "V" + _bookID;
                var currBook = BookStoreBLL.GetBook(_bookID);
                var newTabText = currBook.Title;

                if (tabControlMain.TabPages.ContainsKey(newTabName))
                {
                    tabControlMain.TabPages.RemoveByKey(newTabName);
                }

                var ucVersion = new UserControlVersion(_bookID, _bookTitle);
                var versionPage = new TabPage(newTabText) { Name = newTabName };

                versionPage.Controls.Add(ucVersion);
                ucVersion.Dock = DockStyle.Fill;

                tabControlMain.TabPages.Add(versionPage);
                tabControlMain.SelectTab(newTabName);
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            var lineIDList = new List<string>();

            foreach (DataGridViewRow row in dataGridViewLineList.SelectedRows)
            {
                lineIDList.Add(row.Cells["ID"].Value.ToString());
            }

            if (BookStoreBLL.DeleteLines(lineIDList))
            {
                RefreshVersionList();
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }

        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            
            var pattern = textBoxFilter.Text;
            using var dt = BookStoreBLL.GetLineList(_bookID);

            if (pattern =="")
            {
                RefreshVersionList();
                return;
            }

            var r = new Regex(pattern);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var line = dt.Rows[i]["Content"].ToString();
                if (!r.IsMatch(line))
                {
                    dt.Rows[i].Delete();
                }
            }

            dataGridViewLineList.DataSource = dt;
            dataGridViewLineList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void DataGridViewLineList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var lineNo = int.Parse(dataGridViewLineList.Rows[e.RowIndex].Cells["LineNo"].Value.ToString());

                var tabControlMain = ((TabControl)Parent.Parent);
                var newTabName = "V" + _bookID;
                var newTabText = _bookTitle;

                if (tabControlMain.TabPages.ContainsKey(newTabName))
                {
                    tabControlMain.SelectTab(newTabName);
                    var ver = (UserControlVersion)tabControlMain.TabPages[newTabName].Controls["UserControlVersion"];
                    ver.JumpToLine(lineNo);
                    return;
                }

                var ucVersion = new UserControlVersion(_bookID, _bookTitle);
                var versionPage = new TabPage(newTabText) { Name = newTabName };

                versionPage.Controls.Add(ucVersion);
                ucVersion.Dock = DockStyle.Fill;

                tabControlMain.TabPages.Add(versionPage);
                tabControlMain.SelectTab(newTabName);


            }
        }
    }
}