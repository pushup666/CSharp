
namespace BookSplit
{
    partial class BookSplit
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
            this.buttonOpen = new System.Windows.Forms.Button();
            this.dataGridViewLineList = new System.Windows.Forms.DataGridView();
            this.numericUpDownMaxLength = new System.Windows.Forms.NumericUpDown();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonReload = new System.Windows.Forms.Button();
            this.buttonFile = new System.Windows.Forms.Button();
            this.buttonFolder = new System.Windows.Forms.Button();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLength)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(12, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "打开";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // dataGridViewLineList
            // 
            this.dataGridViewLineList.AllowUserToAddRows = false;
            this.dataGridViewLineList.AllowUserToDeleteRows = false;
            this.dataGridViewLineList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLineList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLineList.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewLineList.Name = "dataGridViewLineList";
            this.dataGridViewLineList.ReadOnly = true;
            this.dataGridViewLineList.RowTemplate.Height = 23;
            this.dataGridViewLineList.Size = new System.Drawing.Size(776, 397);
            this.dataGridViewLineList.TabIndex = 5;
            this.dataGridViewLineList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.DataGridViewLineList_RowStateChanged);
            // 
            // numericUpDownMaxLength
            // 
            this.numericUpDownMaxLength.Location = new System.Drawing.Point(508, 12);
            this.numericUpDownMaxLength.Name = "numericUpDownMaxLength";
            this.numericUpDownMaxLength.Size = new System.Drawing.Size(37, 21);
            this.numericUpDownMaxLength.TabIndex = 9;
            this.numericUpDownMaxLength.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(551, 12);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 7;
            this.buttonFilter.Text = "过滤";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
            // 
            // buttonReload
            // 
            this.buttonReload.Location = new System.Drawing.Point(93, 12);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(75, 23);
            this.buttonReload.TabIndex = 11;
            this.buttonReload.Text = "重载";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.ButtonReload_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(632, 12);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(75, 23);
            this.buttonFile.TabIndex = 12;
            this.buttonFile.Text = "文件";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.ButtonFile_Click);
            // 
            // buttonFolder
            // 
            this.buttonFolder.Location = new System.Drawing.Point(713, 12);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonFolder.TabIndex = 13;
            this.buttonFolder.Text = "文件夹";
            this.buttonFolder.UseVisualStyleBackColor = true;
            this.buttonFolder.Click += new System.EventHandler(this.ButtonFolder_Click);
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Items.AddRange(new object[] {
            "^第.+章.*$",
            "^第.+卷.*$",
            "^第.+部.*$"});
            this.comboBoxFilter.Location = new System.Drawing.Point(401, 12);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(101, 20);
            this.comboBoxFilter.TabIndex = 14;
            this.comboBoxFilter.Text = "^第.+章.*$";
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Location = new System.Drawing.Point(174, 12);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteRow.TabIndex = 15;
            this.buttonDeleteRow.Text = "删除行";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.ButtonDeleteRow_Click);
            // 
            // BookSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDeleteRow);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.buttonFolder);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.numericUpDownMaxLength);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.dataGridViewLineList);
            this.Controls.Add(this.buttonOpen);
            this.Name = "BookSplit";
            this.Text = "BookSplit";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.DataGridView dataGridViewLineList;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxLength;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Button buttonFolder;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.Button buttonDeleteRow;
    }
}