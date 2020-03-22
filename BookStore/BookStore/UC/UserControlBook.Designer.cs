namespace BookStore.UC
{
    partial class UserControlBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
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
            this.dataGridViewBookList = new System.Windows.Forms.DataGridView();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxTitleFilter = new System.Windows.Forms.TextBox();
            this.checkBoxUseFilter = new System.Windows.Forms.CheckBox();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.labelRowCount = new System.Windows.Forms.Label();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.labelCurrentPage = new System.Windows.Forms.Label();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonPrevPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.panelPage = new System.Windows.Forms.Panel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.labelRateFilter = new System.Windows.Forms.Label();
            this.labelLengthFilter = new System.Windows.Forms.Label();
            this.labelTitleFilter = new System.Windows.Forms.Label();
            this.textBoxLengthFilter = new System.Windows.Forms.TextBox();
            this.comboBoxRateFilter = new System.Windows.Forms.ComboBox();
            this.comboBoxOrderBy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookList)).BeginInit();
            this.panelPage.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(822, 11);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 25;
            this.buttonRemove.Text = "删除";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(741, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 24;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
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
            this.comboBoxRate.Location = new System.Drawing.Point(661, 13);
            this.comboBoxRate.Name = "comboBoxRate";
            this.comboBoxRate.Size = new System.Drawing.Size(45, 20);
            this.comboBoxRate.TabIndex = 23;
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(623, 16);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(29, 12);
            this.labelRate.TabIndex = 22;
            this.labelRate.Text = "评分";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(529, 14);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(85, 21);
            this.textBoxNote.TabIndex = 21;
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(491, 17);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(29, 12);
            this.labelNote.TabIndex = 20;
            this.labelNote.Text = "备注";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(397, 14);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(85, 21);
            this.textBoxAuthor.TabIndex = 19;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(359, 17);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(29, 12);
            this.labelAuthor.TabIndex = 18;
            this.labelAuthor.Text = "作者";
            // 
            // textBoxAlias
            // 
            this.textBoxAlias.Location = new System.Drawing.Point(265, 13);
            this.textBoxAlias.Name = "textBoxAlias";
            this.textBoxAlias.Size = new System.Drawing.Size(85, 21);
            this.textBoxAlias.TabIndex = 17;
            // 
            // labelAlias
            // 
            this.labelAlias.AutoSize = true;
            this.labelAlias.Location = new System.Drawing.Point(227, 16);
            this.labelAlias.Name = "labelAlias";
            this.labelAlias.Size = new System.Drawing.Size(29, 12);
            this.labelAlias.TabIndex = 16;
            this.labelAlias.Text = "别名";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(53, 14);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(165, 21);
            this.textBoxTitle.TabIndex = 15;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(15, 17);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(29, 12);
            this.labelTitle.TabIndex = 14;
            this.labelTitle.Text = "标题";
            // 
            // dataGridViewBookList
            // 
            this.dataGridViewBookList.AllowUserToAddRows = false;
            this.dataGridViewBookList.AllowUserToDeleteRows = false;
            this.dataGridViewBookList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBookList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBookList.Location = new System.Drawing.Point(17, 88);
            this.dataGridViewBookList.Name = "dataGridViewBookList";
            this.dataGridViewBookList.ReadOnly = true;
            this.dataGridViewBookList.RowTemplate.Height = 23;
            this.dataGridViewBookList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBookList.Size = new System.Drawing.Size(880, 348);
            this.dataGridViewBookList.TabIndex = 13;
            this.dataGridViewBookList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewBook_CellClick);
            this.dataGridViewBookList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewBook_CellDoubleClick);
            this.dataGridViewBookList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewBookList_KeyDown);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(740, 48);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 26;
            this.buttonExport.Text = "选中导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(659, 49);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 27;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // textBoxTitleFilter
            // 
            this.textBoxTitleFilter.Location = new System.Drawing.Point(116, 10);
            this.textBoxTitleFilter.Name = "textBoxTitleFilter";
            this.textBoxTitleFilter.Size = new System.Drawing.Size(91, 21);
            this.textBoxTitleFilter.TabIndex = 28;
            // 
            // checkBoxUseFilter
            // 
            this.checkBoxUseFilter.AutoSize = true;
            this.checkBoxUseFilter.Location = new System.Drawing.Point(3, 11);
            this.checkBoxUseFilter.Name = "checkBoxUseFilter";
            this.checkBoxUseFilter.Size = new System.Drawing.Size(48, 16);
            this.checkBoxUseFilter.TabIndex = 29;
            this.checkBoxUseFilter.Text = "过滤";
            this.checkBoxUseFilter.UseVisualStyleBackColor = true;
            // 
            // buttonReplace
            // 
            this.buttonReplace.Location = new System.Drawing.Point(822, 49);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(75, 23);
            this.buttonReplace.TabIndex = 30;
            this.buttonReplace.Text = "替换标题";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.ButtonReplace_Click);
            // 
            // labelRowCount
            // 
            this.labelRowCount.AutoSize = true;
            this.labelRowCount.Location = new System.Drawing.Point(3, 13);
            this.labelRowCount.Name = "labelRowCount";
            this.labelRowCount.Size = new System.Drawing.Size(41, 12);
            this.labelRowCount.TabIndex = 31;
            this.labelRowCount.Text = "总行数";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Location = new System.Drawing.Point(140, 13);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(53, 12);
            this.labelPageSize.TabIndex = 32;
            this.labelPageSize.Text = "每页行数";
            // 
            // labelCurrentPage
            // 
            this.labelCurrentPage.AutoSize = true;
            this.labelCurrentPage.Location = new System.Drawing.Point(289, 13);
            this.labelCurrentPage.Name = "labelCurrentPage";
            this.labelCurrentPage.Size = new System.Drawing.Size(53, 12);
            this.labelCurrentPage.TabIndex = 33;
            this.labelCurrentPage.Text = "当前页数";
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(620, 8);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(75, 23);
            this.buttonNextPage.TabIndex = 37;
            this.buttonNextPage.Text = "下一页";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.ButtonNextPage_Click);
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(701, 8);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(75, 23);
            this.buttonLastPage.TabIndex = 36;
            this.buttonLastPage.Text = "末页";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.ButtonLastPage_Click);
            // 
            // buttonPrevPage
            // 
            this.buttonPrevPage.Location = new System.Drawing.Point(539, 8);
            this.buttonPrevPage.Name = "buttonPrevPage";
            this.buttonPrevPage.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevPage.TabIndex = 35;
            this.buttonPrevPage.Text = "上一页";
            this.buttonPrevPage.UseVisualStyleBackColor = true;
            this.buttonPrevPage.Click += new System.EventHandler(this.ButtonPrevPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(458, 8);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(75, 23);
            this.buttonFirstPage.TabIndex = 34;
            this.buttonFirstPage.Text = "首页";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.ButtonFirstPage_Click);
            // 
            // panelPage
            // 
            this.panelPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPage.Controls.Add(this.labelRowCount);
            this.panelPage.Controls.Add(this.buttonLastPage);
            this.panelPage.Controls.Add(this.buttonNextPage);
            this.panelPage.Controls.Add(this.labelPageSize);
            this.panelPage.Controls.Add(this.labelCurrentPage);
            this.panelPage.Controls.Add(this.buttonPrevPage);
            this.panelPage.Controls.Add(this.buttonFirstPage);
            this.panelPage.Location = new System.Drawing.Point(17, 442);
            this.panelPage.Name = "panelPage";
            this.panelPage.Size = new System.Drawing.Size(880, 37);
            this.panelPage.TabIndex = 38;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.comboBoxOrderBy);
            this.panelFilter.Controls.Add(this.labelRateFilter);
            this.panelFilter.Controls.Add(this.labelLengthFilter);
            this.panelFilter.Controls.Add(this.labelTitleFilter);
            this.panelFilter.Controls.Add(this.textBoxLengthFilter);
            this.panelFilter.Controls.Add(this.comboBoxRateFilter);
            this.panelFilter.Controls.Add(this.textBoxTitleFilter);
            this.panelFilter.Controls.Add(this.checkBoxUseFilter);
            this.panelFilter.Location = new System.Drawing.Point(17, 41);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(597, 41);
            this.panelFilter.TabIndex = 39;
            // 
            // labelRateFilter
            // 
            this.labelRateFilter.AutoSize = true;
            this.labelRateFilter.Location = new System.Drawing.Point(227, 13);
            this.labelRateFilter.Name = "labelRateFilter";
            this.labelRateFilter.Size = new System.Drawing.Size(53, 12);
            this.labelRateFilter.TabIndex = 34;
            this.labelRateFilter.Text = "评分过滤";
            // 
            // labelLengthFilter
            // 
            this.labelLengthFilter.AutoSize = true;
            this.labelLengthFilter.Location = new System.Drawing.Point(351, 13);
            this.labelLengthFilter.Name = "labelLengthFilter";
            this.labelLengthFilter.Size = new System.Drawing.Size(53, 12);
            this.labelLengthFilter.TabIndex = 33;
            this.labelLengthFilter.Text = "长度过滤";
            // 
            // labelTitleFilter
            // 
            this.labelTitleFilter.AutoSize = true;
            this.labelTitleFilter.Location = new System.Drawing.Point(57, 13);
            this.labelTitleFilter.Name = "labelTitleFilter";
            this.labelTitleFilter.Size = new System.Drawing.Size(53, 12);
            this.labelTitleFilter.TabIndex = 32;
            this.labelTitleFilter.Text = "标题过滤";
            // 
            // textBoxLengthFilter
            // 
            this.textBoxLengthFilter.Location = new System.Drawing.Point(410, 10);
            this.textBoxLengthFilter.Name = "textBoxLengthFilter";
            this.textBoxLengthFilter.Size = new System.Drawing.Size(85, 21);
            this.textBoxLengthFilter.TabIndex = 31;
            // 
            // comboBoxRateFilter
            // 
            this.comboBoxRateFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRateFilter.FormattingEnabled = true;
            this.comboBoxRateFilter.Items.AddRange(new object[] {
            "",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxRateFilter.Location = new System.Drawing.Point(286, 10);
            this.comboBoxRateFilter.Name = "comboBoxRateFilter";
            this.comboBoxRateFilter.Size = new System.Drawing.Size(45, 20);
            this.comboBoxRateFilter.TabIndex = 30;
            // 
            // comboBoxOrderBy
            // 
            this.comboBoxOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderBy.FormattingEnabled = true;
            this.comboBoxOrderBy.Items.AddRange(new object[] {
            "Title",
            "Rate",
            "Length",
            "ModifyDate"});
            this.comboBoxOrderBy.Location = new System.Drawing.Point(512, 10);
            this.comboBoxOrderBy.Name = "comboBoxOrderBy";
            this.comboBoxOrderBy.Size = new System.Drawing.Size(72, 20);
            this.comboBoxOrderBy.TabIndex = 35;
            // 
            // UserControlBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelPage);
            this.Controls.Add(this.buttonReplace);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxRate);
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.textBoxAlias);
            this.Controls.Add(this.labelAlias);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewBookList);
            this.Name = "UserControlBook";
            this.Size = new System.Drawing.Size(913, 482);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookList)).EndInit();
            this.panelPage.ResumeLayout(false);
            this.panelPage.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxRate;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox textBoxAlias;
        private System.Windows.Forms.Label labelAlias;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridViewBookList;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBoxTitleFilter;
        private System.Windows.Forms.CheckBox checkBoxUseFilter;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.Label labelRowCount;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Label labelCurrentPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonPrevPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Panel panelPage;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.TextBox textBoxLengthFilter;
        private System.Windows.Forms.ComboBox comboBoxRateFilter;
        private System.Windows.Forms.Label labelRateFilter;
        private System.Windows.Forms.Label labelLengthFilter;
        private System.Windows.Forms.Label labelTitleFilter;
        private System.Windows.Forms.ComboBox comboBoxOrderBy;
    }
}
