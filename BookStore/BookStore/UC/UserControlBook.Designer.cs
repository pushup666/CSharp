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
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.checkBoxUseFilter = new System.Windows.Forms.CheckBox();
            this.buttonReplace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookList)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(578, 48);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 25;
            this.buttonRemove.Text = "删除";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(497, 49);
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
            this.comboBoxRate.Location = new System.Drawing.Point(288, 51);
            this.comboBoxRate.Name = "comboBoxRate";
            this.comboBoxRate.Size = new System.Drawing.Size(165, 20);
            this.comboBoxRate.TabIndex = 23;
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(253, 54);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(29, 12);
            this.labelRate.TabIndex = 22;
            this.labelRate.Text = "评分";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(55, 51);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(165, 21);
            this.textBoxNote.TabIndex = 21;
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(20, 54);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(29, 12);
            this.labelNote.TabIndex = 20;
            this.labelNote.Text = "备注";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(530, 14);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(165, 21);
            this.textBoxAuthor.TabIndex = 19;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(495, 17);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(29, 12);
            this.labelAuthor.TabIndex = 18;
            this.labelAuthor.Text = "作者";
            // 
            // textBoxAlias
            // 
            this.textBoxAlias.Location = new System.Drawing.Point(288, 14);
            this.textBoxAlias.Name = "textBoxAlias";
            this.textBoxAlias.Size = new System.Drawing.Size(165, 21);
            this.textBoxAlias.TabIndex = 17;
            // 
            // labelAlias
            // 
            this.labelAlias.AutoSize = true;
            this.labelAlias.Location = new System.Drawing.Point(253, 17);
            this.labelAlias.Name = "labelAlias";
            this.labelAlias.Size = new System.Drawing.Size(29, 12);
            this.labelAlias.TabIndex = 16;
            this.labelAlias.Text = "别名";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(55, 14);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(165, 21);
            this.textBoxTitle.TabIndex = 15;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(20, 17);
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
            this.dataGridViewBookList.Size = new System.Drawing.Size(880, 381);
            this.dataGridViewBookList.TabIndex = 13;
            this.dataGridViewBookList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewBook_CellClick);
            this.dataGridViewBookList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewBook_CellDoubleClick);
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
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(777, 14);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(120, 21);
            this.textBoxFilter.TabIndex = 28;
            // 
            // checkBoxUseFilter
            // 
            this.checkBoxUseFilter.AutoSize = true;
            this.checkBoxUseFilter.Location = new System.Drawing.Point(723, 16);
            this.checkBoxUseFilter.Name = "checkBoxUseFilter";
            this.checkBoxUseFilter.Size = new System.Drawing.Size(48, 16);
            this.checkBoxUseFilter.TabIndex = 29;
            this.checkBoxUseFilter.Text = "过滤";
            this.checkBoxUseFilter.UseVisualStyleBackColor = true;
            // 
            // buttonReplace
            // 
            this.buttonReplace.Location = new System.Drawing.Point(821, 48);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(75, 23);
            this.buttonReplace.TabIndex = 30;
            this.buttonReplace.Text = "替换标题";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.ButtonReplace_Click);
            // 
            // UserControlBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonReplace);
            this.Controls.Add(this.checkBoxUseFilter);
            this.Controls.Add(this.textBoxFilter);
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
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.CheckBox checkBoxUseFilter;
        private System.Windows.Forms.Button buttonReplace;
    }
}
