namespace BookStore.UC
{
    partial class UserControlVersion
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewVersionList = new System.Windows.Forms.DataGridView();
            this.richTextBoxVersionContent = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.blankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addHeadBlankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blankLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBlankLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBlankLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreBlankLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllBlankLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortLongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.short2LongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.long2ShortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EtcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewVersionList
            // 
            this.dataGridViewVersionList.AllowUserToAddRows = false;
            this.dataGridViewVersionList.AllowUserToDeleteRows = false;
            this.dataGridViewVersionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVersionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVersionList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewVersionList.Name = "dataGridViewVersionList";
            this.dataGridViewVersionList.ReadOnly = true;
            this.dataGridViewVersionList.RowTemplate.Height = 23;
            this.dataGridViewVersionList.Size = new System.Drawing.Size(195, 476);
            this.dataGridViewVersionList.TabIndex = 0;
            this.dataGridViewVersionList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewVersionList_CellClick);
            this.dataGridViewVersionList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewVersionList_CellDoubleClick);
            // 
            // richTextBoxVersionContent
            // 
            this.richTextBoxVersionContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxVersionContent.DetectUrls = false;
            this.richTextBoxVersionContent.Font = new System.Drawing.Font("微软雅黑 Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxVersionContent.Location = new System.Drawing.Point(0, 28);
            this.richTextBoxVersionContent.Name = "richTextBoxVersionContent";
            this.richTextBoxVersionContent.Size = new System.Drawing.Size(702, 448);
            this.richTextBoxVersionContent.TabIndex = 1;
            this.richTextBoxVersionContent.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 482);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewVersionList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.menuStripMain);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxVersionContent);
            this.splitContainer1.Size = new System.Drawing.Size(901, 476);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 3;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blankToolStripMenuItem,
            this.blankLineToolStripMenuItem,
            this.shortLongToolStripMenuItem,
            this.EtcToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(702, 25);
            this.menuStripMain.TabIndex = 14;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // blankToolStripMenuItem
            // 
            this.blankToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trimLineToolStripMenuItem,
            this.addHeadBlankToolStripMenuItem});
            this.blankToolStripMenuItem.Name = "blankToolStripMenuItem";
            this.blankToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.blankToolStripMenuItem.Text = "空白";
            // 
            // trimLineToolStripMenuItem
            // 
            this.trimLineToolStripMenuItem.Name = "trimLineToolStripMenuItem";
            this.trimLineToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.trimLineToolStripMenuItem.Text = "去首尾空白";
            this.trimLineToolStripMenuItem.Click += new System.EventHandler(this.TrimLineToolStripMenuItem_Click);
            // 
            // addHeadBlankToolStripMenuItem
            // 
            this.addHeadBlankToolStripMenuItem.Name = "addHeadBlankToolStripMenuItem";
            this.addHeadBlankToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addHeadBlankToolStripMenuItem.Text = "加首空白";
            this.addHeadBlankToolStripMenuItem.Click += new System.EventHandler(this.AddHeadBlankToolStripMenuItem_Click);
            // 
            // blankLineToolStripMenuItem
            // 
            this.blankLineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeBlankLineToolStripMenuItem,
            this.addBlankLineToolStripMenuItem,
            this.restoreBlankLineToolStripMenuItem,
            this.removeAllBlankLineToolStripMenuItem});
            this.blankLineToolStripMenuItem.Name = "blankLineToolStripMenuItem";
            this.blankLineToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.blankLineToolStripMenuItem.Text = "空白行";
            // 
            // removeBlankLineToolStripMenuItem
            // 
            this.removeBlankLineToolStripMenuItem.Name = "removeBlankLineToolStripMenuItem";
            this.removeBlankLineToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeBlankLineToolStripMenuItem.Text = "去空白行";
            this.removeBlankLineToolStripMenuItem.Click += new System.EventHandler(this.RemoveBlankLineToolStripMenuItem_Click);
            // 
            // addBlankLineToolStripMenuItem
            // 
            this.addBlankLineToolStripMenuItem.Name = "addBlankLineToolStripMenuItem";
            this.addBlankLineToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addBlankLineToolStripMenuItem.Text = "增空白行";
            this.addBlankLineToolStripMenuItem.Click += new System.EventHandler(this.AddBlankLineToolStripMenuItem_Click);
            // 
            // restoreBlankLineToolStripMenuItem
            // 
            this.restoreBlankLineToolStripMenuItem.Name = "restoreBlankLineToolStripMenuItem";
            this.restoreBlankLineToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.restoreBlankLineToolStripMenuItem.Text = "还原空白行";
            this.restoreBlankLineToolStripMenuItem.Click += new System.EventHandler(this.RestoreBlankLineToolStripMenuItem_Click);
            // 
            // removeAllBlankLineToolStripMenuItem
            // 
            this.removeAllBlankLineToolStripMenuItem.Name = "removeAllBlankLineToolStripMenuItem";
            this.removeAllBlankLineToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeAllBlankLineToolStripMenuItem.Text = "去空白行（全部）";
            this.removeAllBlankLineToolStripMenuItem.Click += new System.EventHandler(this.RemoveAllBlankLineToolStripMenuItem_Click);
            // 
            // shortLongToolStripMenuItem
            // 
            this.shortLongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.short2LongToolStripMenuItem,
            this.long2ShortToolStripMenuItem});
            this.shortLongToolStripMenuItem.Name = "shortLongToolStripMenuItem";
            this.shortLongToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.shortLongToolStripMenuItem.Text = "长短行";
            // 
            // short2LongToolStripMenuItem
            // 
            this.short2LongToolStripMenuItem.Name = "short2LongToolStripMenuItem";
            this.short2LongToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.short2LongToolStripMenuItem.Text = "短行变长行";
            this.short2LongToolStripMenuItem.Click += new System.EventHandler(this.Short2LongToolStripMenuItem_Click);
            // 
            // long2ShortToolStripMenuItem
            // 
            this.long2ShortToolStripMenuItem.Name = "long2ShortToolStripMenuItem";
            this.long2ShortToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.long2ShortToolStripMenuItem.Text = "长行变短行";
            this.long2ShortToolStripMenuItem.Click += new System.EventHandler(this.Long2ShortToolStripMenuItem_Click);
            // 
            // EtcToolStripMenuItem
            // 
            this.EtcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.compareToolStripMenuItem});
            this.EtcToolStripMenuItem.Name = "EtcToolStripMenuItem";
            this.EtcToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.EtcToolStripMenuItem.Text = "其他";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "保存";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.removeToolStripMenuItem.Text = "删除";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.replaceToolStripMenuItem.Text = "替换";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.ReplaceToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.compareToolStripMenuItem.Text = "对比";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.CompareToolStripMenuItem_Click);
            // 
            // UserControlVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Name = "UserControlVersion";
            this.Size = new System.Drawing.Size(913, 482);
            this.Load += new System.EventHandler(this.UserControlVersion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersionList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVersionList;
        private System.Windows.Forms.RichTextBox richTextBoxVersionContent;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem blankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trimLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addHeadBlankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blankLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBlankLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBlankLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreBlankLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shortLongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem short2LongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem long2ShortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EtcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllBlankLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
    }
}
