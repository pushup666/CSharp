using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace DuplicateFinder
{
    public partial class DuplicateFinder : Form
    {
        readonly List<string> _folderList = new List<string>();
        readonly Dictionary<string, string> _fileDict = new Dictionary<string, string>();           //Name  MD5
        readonly Dictionary<string, string> _uniqueFileDict = new Dictionary<string, string>();     //MD5   Name

        public DuplicateFinder()
        {
            InitializeComponent();
        }


        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void buttonDelFolder_Click(object sender, EventArgs e)
        {
            DelFolder();
        }

        private void buttonImportFiles_Click(object sender, EventArgs e)
        {
            ImportFiles();
        }

        private void buttonDelMarkFiles_Click(object sender, EventArgs e)
        {
            DelMarkFiles();
        }
        
        private void dataGridViewFiles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //ChangeRowForeColor();
        }

        

        private void AddFolder()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    var folder = folderBrowserDialog.SelectedPath;
                    textBoxFolder.Text = folder;

                    if (_folderList.Contains(folder))
                    {
                        MessageBox.Show("该目录已添加！");
                        return;
                    }
                    _folderList.Add(folder);
                }
            }

            UpdateFolderListShow();
        }
        
        private void DelFolder()
        {
            var folders = listBoxFolder.SelectedItems;

            foreach (var folder in folders)
            {
                if (_folderList.Contains(folder.ToString()))
                {
                    _folderList.Remove(folder.ToString());
                }
            }

            UpdateFolderListShow();
        }

        private void UpdateFolderListShow()
        {
            listBoxFolder.Items.Clear();

            foreach (var folder in _folderList)
            {
                listBoxFolder.Items.Add(folder);
            }
        }
        


        private void ImportFiles()
        {
            var start = DateTime.Now;
            double allFileSize = 0;

            _fileDict.Clear();
            _uniqueFileDict.Clear();
            listBoxLog.Items.Clear();

            foreach (var folder in _folderList)
            {
                GetAllSubFiles(folder);
            }
            
            foreach (var file in _fileDict)
            {
                var f = new FileInfo(file.Key);
                allFileSize += f.Length;

                if (_uniqueFileDict.ContainsKey(file.Value))
                {
                    continue;
                }
                _uniqueFileDict.Add(file.Value, file.Key);
            }

            var totalSeconds = DateTime.Now.Subtract(start).TotalSeconds;
            var allFileSizeInM = allFileSize/1024/1024;

            MessageBox.Show($"历时：{totalSeconds:N} S；文件大小：{allFileSizeInM:N} M；速度：{allFileSizeInM / totalSeconds:N} M/S");
            MessageBox.Show($"文件总数：{_fileDict.Count}，重复文件数：{_fileDict.Count - _uniqueFileDict.Count}");

            UpdateFileListShow();
        }

        private void GetAllSubFiles(string folder)
        {
            foreach (var subFolder in Directory.GetDirectories(folder))
            {
                GetAllSubFiles(subFolder);
            }

            foreach (var file in Directory.GetFiles(folder))
            {
                if (!_fileDict.ContainsKey(file))
                {
                    var md5 = GetHashFromFile(file);
                    if (md5.StartsWith("Error"))
                    {
                        continue;
                    }
                    _fileDict.Add(file, md5);
                }
            }
        }

        private void UpdateFileListShow()
        {
            var dt = new DataTable();
            dt.Columns.Add("Mark", typeof(bool));
            dt.Columns.Add("MD5", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            
            foreach (var file in _fileDict)
            {
                var dr = dt.NewRow();
                dr["Mark"] = !_uniqueFileDict.ContainsValue(file.Key);
                dr["MD5"] = file.Value;
                dr["Name"] = file.Key;
                dt.Rows.Add(dr);
            }

            dataGridViewFiles.DataSource = dt;
            dataGridViewFiles.Columns[1].ReadOnly = true;
            dataGridViewFiles.Columns[2].ReadOnly = true;
            dataGridViewFiles.AutoResizeColumns();
        }


		
        private void DelMarkFiles()
        {
            foreach (DataGridViewRow row in dataGridViewFiles.Rows)
            {
                if ((bool)row.Cells["Mark"].Value)
                {
                    //File.Delete(row.Cells["Name"].Value.ToString());
                    FileSystem.DeleteFile(row.Cells["Name"].Value.ToString(), UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
            }

            MessageBox.Show("删除完成！");
        }

        

        private void ChangeRowForeColor()
        {
            foreach (DataGridViewRow row in dataGridViewFiles.Rows)
            {
                var foreColor = int.Parse(GetHashFromString((string)row.Cells["MD5"].Value).Substring(0, 6), NumberStyles.HexNumber);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(foreColor);
            }
        }

        private string GetHashFromFile(string fileName)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

                var file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var retVal = md5.ComputeHash(file);
                file.Close();

                var sb = new StringBuilder();
                foreach (var t in retVal)
                {
                    sb.Append(t.ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                var msg = "Error:\r\n" + ex.Message;
                listBoxLog.Items.Add(msg);
                return msg;
            }
        }

        private string GetHashFromString(string input)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

                var retVal = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sb = new StringBuilder();
                foreach (var t in retVal)
                {
                    sb.Append(t.ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                var msg = "Error:\r\n" + ex.Message;
                listBoxLog.Items.Add(msg);
                return msg;
            }
        }

        private void buttonImportMods_Click(object sender, EventArgs e)
        {
            ImportMods();
        }

        private void ImportMods()
        {
            _fileDict.Clear();
            _uniqueFileDict.Clear();
            listBoxLog.Items.Clear();

            foreach (var fileName in Directory.GetFiles(@"C:\Users\ssf\AppData\Roaming\Factorio\mods"))
            {
                if (!_fileDict.ContainsKey(fileName))
                {
                    var modName = fileName.Split('_')[0];
                    _fileDict.Add(fileName, modName);
                }
            }

            foreach (var file in _fileDict)
            {
                var fileName = file.Key;
                var modName = file.Value;

                if (_uniqueFileDict.ContainsKey(modName))
                {
                    if (CompareModVersion(fileName,_uniqueFileDict[modName]) > 0)
                    {
                        _uniqueFileDict[modName] = fileName;
                    }
                }
                else
                {
                    _uniqueFileDict.Add(modName, fileName);
                }
            }

            var dt = new DataTable();
            dt.Columns.Add("Mark", typeof(bool));
            dt.Columns.Add("MD5", typeof(string));
            dt.Columns.Add("Name", typeof(string));

            foreach (var file in _fileDict)
            {
                var fileName = file.Key;
                var modName = file.Value;

                var dr = dt.NewRow();
                dr["Mark"] = !_uniqueFileDict.ContainsValue(fileName);
                dr["MD5"] = modName;
                dr["Name"] = fileName;
                dt.Rows.Add(dr);
            }

            dataGridViewFiles.DataSource = dt;
            dataGridViewFiles.Columns[1].ReadOnly = true;
            dataGridViewFiles.Columns[2].ReadOnly = true;
            dataGridViewFiles.AutoResizeColumns();
        }

        private int CompareModVersion(string fileName1, string fileName2)
        {
            try
            {
                var version1 = fileName1.Split('_')[1].Split('.');
                var version2 = fileName2.Split('_')[1].Split('.');

                for (int i = 0; i < version1.Length; i++)
                {
                    if (version1[i] == version2[i])
                    {
                        continue;
                    }

                    if (int.Parse(version1[i]) > int.Parse(version2[i]))
                    {
                        return 1;
                    }

                    return -1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                var msg = "Error:\r\n" + ex.Message;
                listBoxLog.Items.Add(msg);
                return 0;
            }
        }
    }
}