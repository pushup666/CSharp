namespace ReadVideoInfo
{
    partial class ReadVideoInfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSave = new System.Windows.Forms.Button();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.buttonClearList = new System.Windows.Forms.Button();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.checkedListBoxFileName = new System.Windows.Forms.CheckedListBox();
            this.buttonReadVideoCreationTime = new System.Windows.Forms.Button();
            this.buttonAutoBitrate = new System.Windows.Forms.Button();
            this.checkBoxSaveToRam = new System.Windows.Forms.CheckBox();
            this.comboBoxVideoCodec = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(923, 353);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 31;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(468, 12);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(530, 324);
            this.richTextBoxOutput.TabIndex = 29;
            this.richTextBoxOutput.Text = "";
            this.richTextBoxOutput.WordWrap = false;
            // 
            // buttonClearList
            // 
            this.buttonClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearList.Location = new System.Drawing.Point(174, 353);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearList.TabIndex = 24;
            this.buttonClearList.Text = "清空";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.ButtonClearList_Click);
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFolder.Location = new System.Drawing.Point(93, 353);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFolder.TabIndex = 23;
            this.buttonAddFolder.Text = "添加文件夹";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.ButtonAddFolder_Click);
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFile.Location = new System.Drawing.Point(12, 353);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFile.TabIndex = 22;
            this.buttonAddFile.Text = "添加文件";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.ButtonAddFile_Click);
            // 
            // checkedListBoxFileName
            // 
            this.checkedListBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxFileName.FormattingEnabled = true;
            this.checkedListBoxFileName.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxFileName.Name = "checkedListBoxFileName";
            this.checkedListBoxFileName.Size = new System.Drawing.Size(435, 324);
            this.checkedListBoxFileName.TabIndex = 21;
            // 
            // buttonReadVideoCreationTime
            // 
            this.buttonReadVideoCreationTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadVideoCreationTime.AutoSize = true;
            this.buttonReadVideoCreationTime.Location = new System.Drawing.Point(468, 353);
            this.buttonReadVideoCreationTime.Name = "buttonReadVideoCreationTime";
            this.buttonReadVideoCreationTime.Size = new System.Drawing.Size(87, 23);
            this.buttonReadVideoCreationTime.TabIndex = 32;
            this.buttonReadVideoCreationTime.Text = "读取创建时间";
            this.buttonReadVideoCreationTime.UseVisualStyleBackColor = true;
            this.buttonReadVideoCreationTime.Click += new System.EventHandler(this.ButtonReadVideoCreationTime_Click);
            // 
            // buttonAutoBitrate
            // 
            this.buttonAutoBitrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoBitrate.AutoSize = true;
            this.buttonAutoBitrate.Location = new System.Drawing.Point(561, 353);
            this.buttonAutoBitrate.Name = "buttonAutoBitrate";
            this.buttonAutoBitrate.Size = new System.Drawing.Size(135, 23);
            this.buttonAutoBitrate.TabIndex = 33;
            this.buttonAutoBitrate.Text = "根据尺寸预估合理码率";
            this.buttonAutoBitrate.UseVisualStyleBackColor = true;
            this.buttonAutoBitrate.Click += new System.EventHandler(this.ButtonAutoBitrate_Click);
            // 
            // checkBoxSaveToRam
            // 
            this.checkBoxSaveToRam.AutoSize = true;
            this.checkBoxSaveToRam.Location = new System.Drawing.Point(278, 356);
            this.checkBoxSaveToRam.Name = "checkBoxSaveToRam";
            this.checkBoxSaveToRam.Size = new System.Drawing.Size(78, 16);
            this.checkBoxSaveToRam.TabIndex = 34;
            this.checkBoxSaveToRam.Text = "SaveToRam";
            this.checkBoxSaveToRam.UseVisualStyleBackColor = true;
            // 
            // comboBoxVideoCodec
            // 
            this.comboBoxVideoCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideoCodec.FormattingEnabled = true;
            this.comboBoxVideoCodec.Items.AddRange(new object[] {
            "h264_qsv",
            "hevc_nvenc"});
            this.comboBoxVideoCodec.Location = new System.Drawing.Point(702, 354);
            this.comboBoxVideoCodec.Name = "comboBoxVideoCodec";
            this.comboBoxVideoCodec.Size = new System.Drawing.Size(94, 20);
            this.comboBoxVideoCodec.TabIndex = 35;
            // 
            // ReadVideoInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 387);
            this.Controls.Add(this.comboBoxVideoCodec);
            this.Controls.Add(this.checkBoxSaveToRam);
            this.Controls.Add(this.buttonAutoBitrate);
            this.Controls.Add(this.buttonReadVideoCreationTime);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.buttonClearList);
            this.Controls.Add(this.buttonAddFolder);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.checkedListBoxFileName);
            this.Name = "ReadVideoInfo";
            this.Text = "ReadVideoInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.CheckedListBox checkedListBoxFileName;
        private System.Windows.Forms.Button buttonReadVideoCreationTime;
        private System.Windows.Forms.Button buttonAutoBitrate;
        private System.Windows.Forms.CheckBox checkBoxSaveToRam;
        private System.Windows.Forms.ComboBox comboBoxVideoCodec;
    }
}

