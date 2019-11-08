namespace LiuMovie
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIconNew = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripnotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBoxFileName = new System.Windows.Forms.CheckedListBox();
            this.buttonClearList = new System.Windows.Forms.Button();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.contextMenuStripnotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconNew
            // 
            this.notifyIconNew.ContextMenuStrip = this.contextMenuStripnotify;
            this.notifyIconNew.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconNew.Icon")));
            this.notifyIconNew.Text = "ssf";
            this.notifyIconNew.DoubleClick += new System.EventHandler(this.NotifyIconNew_DoubleClick);
            // 
            // contextMenuStripnotify
            // 
            this.contextMenuStripnotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NextToolStripMenuItem});
            this.contextMenuStripnotify.Name = "contextMenuStripnotify";
            this.contextMenuStripnotify.Size = new System.Drawing.Size(113, 26);
            // 
            // NextToolStripMenuItem
            // 
            this.NextToolStripMenuItem.Name = "NextToolStripMenuItem";
            this.NextToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.NextToolStripMenuItem.Text = "下一个";
            this.NextToolStripMenuItem.Click += new System.EventHandler(this.NextToolStripMenuItem_Click);
            // 
            // checkedListBoxFileName
            // 
            this.checkedListBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxFileName.FormattingEnabled = true;
            this.checkedListBoxFileName.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxFileName.Name = "checkedListBoxFileName";
            this.checkedListBoxFileName.Size = new System.Drawing.Size(435, 324);
            this.checkedListBoxFileName.TabIndex = 22;
            // 
            // buttonClearList
            // 
            this.buttonClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearList.Location = new System.Drawing.Point(453, 54);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(77, 23);
            this.buttonClearList.TabIndex = 26;
            this.buttonClearList.Text = "清空";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.ButtonClearList_Click);
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFile.Location = new System.Drawing.Point(453, 12);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(77, 23);
            this.buttonAddFile.TabIndex = 25;
            this.buttonAddFile.Text = "添加文件";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.ButtonAddFile_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 407);
            this.Controls.Add(this.buttonClearList);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.checkedListBoxFileName);
            this.Name = "Main";
            this.Text = "Main";
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.contextMenuStripnotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripnotify;
        private System.Windows.Forms.ToolStripMenuItem NextToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBoxFileName;
        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.Button buttonAddFile;
    }
}

