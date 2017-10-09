﻿namespace Txt2PdfConvert
{
    partial class Txt2Pdf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.checkedListBoxFileName = new System.Windows.Forms.CheckedListBox();
            this.buttonClearList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(12, 223);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFile.TabIndex = 0;
            this.buttonAddFile.Text = "添加文件";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.ButtonAddFileClick);
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Location = new System.Drawing.Point(116, 223);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFolder.TabIndex = 1;
            this.buttonAddFolder.Text = "添加文件夹";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.ButtonAddFolderClick);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(527, 223);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 2;
            this.buttonConvert.Text = "转换";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.ButtonConvertClick);
            // 
            // checkedListBoxFileName
            // 
            this.checkedListBoxFileName.FormattingEnabled = true;
            this.checkedListBoxFileName.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxFileName.Name = "checkedListBoxFileName";
            this.checkedListBoxFileName.Size = new System.Drawing.Size(590, 196);
            this.checkedListBoxFileName.TabIndex = 4;
            // 
            // buttonClearList
            // 
            this.buttonClearList.Location = new System.Drawing.Point(222, 223);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearList.TabIndex = 5;
            this.buttonClearList.Text = "清空";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.ButtonClearListClick);
            // 
            // Txt2Pdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 258);
            this.Controls.Add(this.buttonClearList);
            this.Controls.Add(this.checkedListBoxFileName);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonAddFolder);
            this.Controls.Add(this.buttonAddFile);
            this.Name = "Txt2Pdf";
            this.Text = "Txt2Pdf";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.CheckedListBox checkedListBoxFileName;
        private System.Windows.Forms.Button buttonClearList;
    }
}