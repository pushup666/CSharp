namespace BookStore
{
    partial class BookStoreFrm
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
            this.tabPageBook = new System.Windows.Forms.TabPage();
            this.userControlBook1 = new BookStore.UC.UserControlBook();
            this.tabControlMain.SuspendLayout();
            this.tabPageBook.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonImportBooks
            // 
            this.buttonImportBooks.Location = new System.Drawing.Point(12, 12);
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
            this.tabControlMain.Controls.Add(this.tabPageBook);
            this.tabControlMain.Location = new System.Drawing.Point(12, 41);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(941, 459);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.DoubleClick += new System.EventHandler(this.TabControlMain_DoubleClick);
            // 
            // tabPageBook
            // 
            this.tabPageBook.Controls.Add(this.userControlBook1);
            this.tabPageBook.Location = new System.Drawing.Point(4, 22);
            this.tabPageBook.Name = "tabPageBook";
            this.tabPageBook.Size = new System.Drawing.Size(933, 433);
            this.tabPageBook.TabIndex = 1;
            this.tabPageBook.Text = "Book";
            this.tabPageBook.UseVisualStyleBackColor = true;
            // 
            // userControlBook1
            // 
            this.userControlBook1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlBook1.Location = new System.Drawing.Point(0, 0);
            this.userControlBook1.Name = "userControlBook1";
            this.userControlBook1.Size = new System.Drawing.Size(933, 433);
            this.userControlBook1.TabIndex = 0;
            // 
            // BookStoreFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 512);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonImportBooks);
            this.Name = "BookStoreFrm";
            this.Text = "BookStoreFrm";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageBook.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonImportBooks;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageBook;
        private BookStore.UC.UserControlBook userControlBook1;
    }
}

