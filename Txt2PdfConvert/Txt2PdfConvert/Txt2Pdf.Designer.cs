namespace Txt2PdfConvert
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
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.checkBoxUTF8 = new System.Windows.Forms.CheckBox();
            this.checkBoxReverse = new System.Windows.Forms.CheckBox();
            this.buttonConvertAg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(12, 12);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFile.TabIndex = 0;
            this.buttonAddFile.Text = "添加文件";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.ButtonAddFileClick);
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Location = new System.Drawing.Point(94, 12);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFolder.TabIndex = 1;
            this.buttonAddFolder.Text = "添加文件夹";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.ButtonAddFolderClick);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvert.Location = new System.Drawing.Point(561, 12);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 2;
            this.buttonConvert.Text = "Txt2Pdf";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.ButtonConvertClick);
            // 
            // checkedListBoxFileName
            // 
            this.checkedListBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxFileName.FormattingEnabled = true;
            this.checkedListBoxFileName.Location = new System.Drawing.Point(12, 44);
            this.checkedListBoxFileName.Name = "checkedListBoxFileName";
            this.checkedListBoxFileName.Size = new System.Drawing.Size(712, 212);
            this.checkedListBoxFileName.TabIndex = 4;
            // 
            // buttonClearList
            // 
            this.buttonClearList.Location = new System.Drawing.Point(175, 12);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearList.TabIndex = 5;
            this.buttonClearList.Text = "清空";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.ButtonClearListClick);
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Items.AddRange(new object[] {
            "iPhone 14 +",
            "iPhone 8",
            "iPad Pro 11"});
            this.comboBoxDevice.Location = new System.Drawing.Point(277, 14);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(121, 20);
            this.comboBoxDevice.TabIndex = 6;
            // 
            // checkBoxUTF8
            // 
            this.checkBoxUTF8.AutoSize = true;
            this.checkBoxUTF8.Location = new System.Drawing.Point(429, 16);
            this.checkBoxUTF8.Name = "checkBoxUTF8";
            this.checkBoxUTF8.Size = new System.Drawing.Size(54, 16);
            this.checkBoxUTF8.TabIndex = 7;
            this.checkBoxUTF8.Text = "UTF-8";
            this.checkBoxUTF8.UseVisualStyleBackColor = true;
            // 
            // checkBoxReverse
            // 
            this.checkBoxReverse.AutoSize = true;
            this.checkBoxReverse.Location = new System.Drawing.Point(489, 16);
            this.checkBoxReverse.Name = "checkBoxReverse";
            this.checkBoxReverse.Size = new System.Drawing.Size(48, 16);
            this.checkBoxReverse.TabIndex = 8;
            this.checkBoxReverse.Text = "反色";
            this.checkBoxReverse.UseVisualStyleBackColor = true;
            // 
            // buttonConvertAg
            // 
            this.buttonConvertAg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvertAg.Location = new System.Drawing.Point(649, 12);
            this.buttonConvertAg.Name = "buttonConvertAg";
            this.buttonConvertAg.Size = new System.Drawing.Size(75, 23);
            this.buttonConvertAg.TabIndex = 9;
            this.buttonConvertAg.Text = "Pdf2Txt";
            this.buttonConvertAg.UseVisualStyleBackColor = true;
            this.buttonConvertAg.Click += new System.EventHandler(this.ButtonConvertAg_Click);
            // 
            // Txt2Pdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 268);
            this.Controls.Add(this.buttonConvertAg);
            this.Controls.Add(this.checkBoxReverse);
            this.Controls.Add(this.checkBoxUTF8);
            this.Controls.Add(this.comboBoxDevice);
            this.Controls.Add(this.buttonClearList);
            this.Controls.Add(this.checkedListBoxFileName);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonAddFolder);
            this.Controls.Add(this.buttonAddFile);
            this.Name = "Txt2Pdf";
            this.Text = "Txt2Pdf";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.CheckedListBox checkedListBoxFileName;
        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.CheckBox checkBoxUTF8;
        private System.Windows.Forms.CheckBox checkBoxReverse;
        private System.Windows.Forms.Button buttonConvertAg;
    }
}