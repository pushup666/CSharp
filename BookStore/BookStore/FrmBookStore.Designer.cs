namespace BookStore
{
    partial class FrmBookStore
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
            this.buttonImportBooks = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonVacuum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonImportBooks
            // 
            this.buttonImportBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImportBooks.Location = new System.Drawing.Point(713, 12);
            this.buttonImportBooks.Name = "buttonImportBooks";
            this.buttonImportBooks.Size = new System.Drawing.Size(75, 23);
            this.buttonImportBooks.TabIndex = 0;
            this.buttonImportBooks.Text = "导入";
            this.buttonImportBooks.UseVisualStyleBackColor = true;
            this.buttonImportBooks.Click += new System.EventHandler(this.ButtonImportBooks_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Location = new System.Drawing.Point(12, 41);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(941, 459);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.TabControlMain_ControlRemoved);
            this.tabControlMain.DoubleClick += new System.EventHandler(this.TabControlMain_DoubleClick);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Location = new System.Drawing.Point(794, 12);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "全部导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // buttonVacuum
            // 
            this.buttonVacuum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVacuum.Location = new System.Drawing.Point(875, 12);
            this.buttonVacuum.Name = "buttonVacuum";
            this.buttonVacuum.Size = new System.Drawing.Size(75, 23);
            this.buttonVacuum.TabIndex = 3;
            this.buttonVacuum.Text = "释放空间";
            this.buttonVacuum.UseVisualStyleBackColor = true;
            this.buttonVacuum.Click += new System.EventHandler(this.ButtonVacuum_Click);
            // 
            // FrmBookStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 512);
            this.Controls.Add(this.buttonVacuum);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonImportBooks);
            this.Name = "FrmBookStore";
            this.Text = "BookStore";
            this.Load += new System.EventHandler(this.FrmBookStore_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonImportBooks;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonVacuum;
    }
}

