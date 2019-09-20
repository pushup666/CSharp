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
            this.comboBoxRate = new System.Windows.Forms.ComboBox();
            this.labelRate = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.textBoxAlias = new System.Windows.Forms.TextBox();
            this.labelAlias = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridViewBook = new System.Windows.Forms.DataGridView();
            this.tabControlMain.SuspendLayout();
            this.tabPageBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).BeginInit();
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
            // 
            // tabPageBook
            // 
            this.tabPageBook.Controls.Add(this.comboBoxRate);
            this.tabPageBook.Controls.Add(this.labelRate);
            this.tabPageBook.Controls.Add(this.textBoxNote);
            this.tabPageBook.Controls.Add(this.labelNote);
            this.tabPageBook.Controls.Add(this.textBoxAuthor);
            this.tabPageBook.Controls.Add(this.labelAuthor);
            this.tabPageBook.Controls.Add(this.textBoxAlias);
            this.tabPageBook.Controls.Add(this.labelAlias);
            this.tabPageBook.Controls.Add(this.textBoxTitle);
            this.tabPageBook.Controls.Add(this.labelTitle);
            this.tabPageBook.Controls.Add(this.dataGridViewBook);
            this.tabPageBook.Location = new System.Drawing.Point(4, 22);
            this.tabPageBook.Name = "tabPageBook";
            this.tabPageBook.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBook.Size = new System.Drawing.Size(933, 433);
            this.tabPageBook.TabIndex = 0;
            this.tabPageBook.Text = "Book";
            this.tabPageBook.UseVisualStyleBackColor = true;
            // 
            // comboBoxRate
            // 
            this.comboBoxRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRate.FormattingEnabled = true;
            this.comboBoxRate.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxRate.Location = new System.Drawing.Point(531, 46);
            this.comboBoxRate.Name = "comboBoxRate";
            this.comboBoxRate.Size = new System.Drawing.Size(165, 20);
            this.comboBoxRate.TabIndex = 10;
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(484, 49);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(29, 12);
            this.labelRate.TabIndex = 9;
            this.labelRate.Text = "评分";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(56, 46);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(398, 21);
            this.textBoxNote.TabIndex = 8;
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(9, 49);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(29, 12);
            this.labelNote.TabIndex = 7;
            this.labelNote.Text = "备注";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(531, 6);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(165, 21);
            this.textBoxAuthor.TabIndex = 6;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(484, 9);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(29, 12);
            this.labelAuthor.TabIndex = 5;
            this.labelAuthor.Text = "作者";
            // 
            // textBoxAlias
            // 
            this.textBoxAlias.Location = new System.Drawing.Point(289, 6);
            this.textBoxAlias.Name = "textBoxAlias";
            this.textBoxAlias.Size = new System.Drawing.Size(165, 21);
            this.textBoxAlias.TabIndex = 4;
            // 
            // labelAlias
            // 
            this.labelAlias.AutoSize = true;
            this.labelAlias.Location = new System.Drawing.Point(242, 9);
            this.labelAlias.Name = "labelAlias";
            this.labelAlias.Size = new System.Drawing.Size(29, 12);
            this.labelAlias.TabIndex = 3;
            this.labelAlias.Text = "别名";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(56, 6);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(165, 21);
            this.textBoxTitle.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(9, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(29, 12);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "标题";
            // 
            // dataGridViewBook
            // 
            this.dataGridViewBook.AllowUserToAddRows = false;
            this.dataGridViewBook.AllowUserToDeleteRows = false;
            this.dataGridViewBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBook.Location = new System.Drawing.Point(6, 73);
            this.dataGridViewBook.Name = "dataGridViewBook";
            this.dataGridViewBook.ReadOnly = true;
            this.dataGridViewBook.RowTemplate.Height = 23;
            this.dataGridViewBook.Size = new System.Drawing.Size(921, 354);
            this.dataGridViewBook.TabIndex = 0;
            this.dataGridViewBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewBook_CellClick);
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
            this.tabPageBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonImportBooks;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageBook;
        private System.Windows.Forms.DataGridView dataGridViewBook;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox textBoxAlias;
        private System.Windows.Forms.Label labelAlias;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.ComboBox comboBoxRate;
    }
}

