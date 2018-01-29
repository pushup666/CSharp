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
            this.radioButtonMini2 = new System.Windows.Forms.RadioButton();
            this.radioButton5s = new System.Windows.Forms.RadioButton();
            this.buttonSplit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(10, 233);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFile.TabIndex = 0;
            this.buttonAddFile.Text = "添加文件";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.ButtonAddFileClick);
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Location = new System.Drawing.Point(91, 233);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFolder.TabIndex = 1;
            this.buttonAddFolder.Text = "添加文件夹";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.ButtonAddFolderClick);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(527, 214);
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
            this.buttonClearList.Location = new System.Drawing.Point(172, 233);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearList.TabIndex = 5;
            this.buttonClearList.Text = "清空";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.ButtonClearListClick);
            // 
            // radioButtonMini2
            // 
            this.radioButtonMini2.AutoSize = true;
            this.radioButtonMini2.Checked = true;
            this.radioButtonMini2.Location = new System.Drawing.Point(393, 221);
            this.radioButtonMini2.Name = "radioButtonMini2";
            this.radioButtonMini2.Size = new System.Drawing.Size(83, 16);
            this.radioButtonMini2.TabIndex = 6;
            this.radioButtonMini2.TabStop = true;
            this.radioButtonMini2.Text = "iPad mini2";
            this.radioButtonMini2.UseVisualStyleBackColor = true;
            // 
            // radioButton5s
            // 
            this.radioButton5s.AutoSize = true;
            this.radioButton5s.Location = new System.Drawing.Point(393, 243);
            this.radioButton5s.Name = "radioButton5s";
            this.radioButton5s.Size = new System.Drawing.Size(77, 16);
            this.radioButton5s.TabIndex = 7;
            this.radioButton5s.Text = "iPhone 5s";
            this.radioButton5s.UseVisualStyleBackColor = true;
            // 
            // buttonSplit
            // 
            this.buttonSplit.Location = new System.Drawing.Point(528, 243);
            this.buttonSplit.Name = "buttonSplit";
            this.buttonSplit.Size = new System.Drawing.Size(75, 23);
            this.buttonSplit.TabIndex = 8;
            this.buttonSplit.Text = "分割";
            this.buttonSplit.UseVisualStyleBackColor = true;
            this.buttonSplit.Click += new System.EventHandler(this.buttonSplit_Click);
            // 
            // Txt2Pdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 276);
            this.Controls.Add(this.buttonSplit);
            this.Controls.Add(this.radioButton5s);
            this.Controls.Add(this.radioButtonMini2);
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
        private System.Windows.Forms.RadioButton radioButtonMini2;
        private System.Windows.Forms.RadioButton radioButton5s;
        private System.Windows.Forms.Button buttonSplit;
    }
}