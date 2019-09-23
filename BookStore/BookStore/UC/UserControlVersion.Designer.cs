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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.dataGridViewVersionList.Size = new System.Drawing.Size(195, 429);
            this.dataGridViewVersionList.TabIndex = 0;
            this.dataGridViewVersionList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewVersionList_CellClick);
            // 
            // richTextBoxVersionContent
            // 
            this.richTextBoxVersionContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxVersionContent.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxVersionContent.Name = "richTextBoxVersionContent";
            this.richTextBoxVersionContent.Size = new System.Drawing.Size(702, 429);
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
            this.splitContainer1.Location = new System.Drawing.Point(9, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewVersionList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxVersionContent);
            this.splitContainer1.Size = new System.Drawing.Size(901, 429);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 3;
            // 
            // UserControlVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Name = "UserControlVersion";
            this.Size = new System.Drawing.Size(913, 482);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersionList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVersionList;
        private System.Windows.Forms.RichTextBox richTextBoxVersionContent;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
