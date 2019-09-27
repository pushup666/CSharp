namespace BookStore.UC
{
    partial class UserControlLine
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
            this.dataGridViewLineList = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLineList
            // 
            this.dataGridViewLineList.AllowUserToAddRows = false;
            this.dataGridViewLineList.AllowUserToDeleteRows = false;
            this.dataGridViewLineList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLineList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLineList.Location = new System.Drawing.Point(3, 32);
            this.dataGridViewLineList.Name = "dataGridViewLineList";
            this.dataGridViewLineList.ReadOnly = true;
            this.dataGridViewLineList.RowTemplate.Height = 23;
            this.dataGridViewLineList.Size = new System.Drawing.Size(907, 447);
            this.dataGridViewLineList.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(3, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(94, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // UserControlLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridViewLineList);
            this.Name = "UserControlLine";
            this.Size = new System.Drawing.Size(913, 482);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLineList;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
    }
}
