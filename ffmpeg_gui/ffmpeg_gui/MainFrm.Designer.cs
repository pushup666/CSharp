namespace ffmpeg_gui
{
    partial class MainFrm
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
            this.buttonClearList = new System.Windows.Forms.Button();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.checkedListBoxFileName = new System.Windows.Forms.CheckedListBox();
            this.buttonAudio = new System.Windows.Forms.Button();
            this.buttonVideo = new System.Windows.Forms.Button();
            this.buttonPackage = new System.Windows.Forms.Button();
            this.buttonSeparate = new System.Windows.Forms.Button();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.buttonAll = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClearList
            // 
            this.buttonClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearList.Location = new System.Drawing.Point(174, 243);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearList.TabIndex = 12;
            this.buttonClearList.Text = "清空";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.ButtonClearListClick);
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFolder.Location = new System.Drawing.Point(93, 243);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFolder.TabIndex = 11;
            this.buttonAddFolder.Text = "添加文件夹";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.ButtonAddFolderClick);
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFile.Location = new System.Drawing.Point(12, 243);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFile.TabIndex = 10;
            this.buttonAddFile.Text = "添加文件";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.ButtonAddFileClick);
            // 
            // checkedListBoxFileName
            // 
            this.checkedListBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxFileName.FormattingEnabled = true;
            this.checkedListBoxFileName.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxFileName.Name = "checkedListBoxFileName";
            this.checkedListBoxFileName.Size = new System.Drawing.Size(435, 196);
            this.checkedListBoxFileName.TabIndex = 9;
            // 
            // buttonAudio
            // 
            this.buttonAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAudio.Location = new System.Drawing.Point(468, 243);
            this.buttonAudio.Name = "buttonAudio";
            this.buttonAudio.Size = new System.Drawing.Size(75, 23);
            this.buttonAudio.TabIndex = 14;
            this.buttonAudio.Text = "音频";
            this.buttonAudio.UseVisualStyleBackColor = true;
            this.buttonAudio.Click += new System.EventHandler(this.ButtonAudioClick);
            // 
            // buttonVideo
            // 
            this.buttonVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVideo.Location = new System.Drawing.Point(549, 243);
            this.buttonVideo.Name = "buttonVideo";
            this.buttonVideo.Size = new System.Drawing.Size(75, 23);
            this.buttonVideo.TabIndex = 15;
            this.buttonVideo.Text = "视频";
            this.buttonVideo.UseVisualStyleBackColor = true;
            this.buttonVideo.Click += new System.EventHandler(this.ButtonVideoClick);
            // 
            // buttonPackage
            // 
            this.buttonPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPackage.Location = new System.Drawing.Point(630, 243);
            this.buttonPackage.Name = "buttonPackage";
            this.buttonPackage.Size = new System.Drawing.Size(75, 23);
            this.buttonPackage.TabIndex = 16;
            this.buttonPackage.Text = "打包";
            this.buttonPackage.UseVisualStyleBackColor = true;
            this.buttonPackage.Click += new System.EventHandler(this.ButtonPackageClick);
            // 
            // buttonSeparate
            // 
            this.buttonSeparate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSeparate.Location = new System.Drawing.Point(792, 243);
            this.buttonSeparate.Name = "buttonSeparate";
            this.buttonSeparate.Size = new System.Drawing.Size(75, 23);
            this.buttonSeparate.TabIndex = 17;
            this.buttonSeparate.Text = "分离";
            this.buttonSeparate.UseVisualStyleBackColor = true;
            this.buttonSeparate.Click += new System.EventHandler(this.ButtonSeparateClick);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(468, 12);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(530, 196);
            this.richTextBoxOutput.TabIndex = 18;
            this.richTextBoxOutput.Text = "";
            this.richTextBoxOutput.WordWrap = false;
            // 
            // buttonAll
            // 
            this.buttonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAll.Location = new System.Drawing.Point(711, 243);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(75, 23);
            this.buttonAll.TabIndex = 19;
            this.buttonAll.Text = "一键转换";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(923, 243);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 290);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.buttonSeparate);
            this.Controls.Add(this.buttonPackage);
            this.Controls.Add(this.buttonVideo);
            this.Controls.Add(this.buttonAudio);
            this.Controls.Add(this.buttonClearList);
            this.Controls.Add(this.buttonAddFolder);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.checkedListBoxFileName);
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.CheckedListBox checkedListBoxFileName;
        private System.Windows.Forms.Button buttonAudio;
        private System.Windows.Forms.Button buttonVideo;
        private System.Windows.Forms.Button buttonPackage;
        private System.Windows.Forms.Button buttonSeparate;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonSave;
    }
}