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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLineList
            // 
            this.dataGridViewLineList.AllowUserToAddRows = false;
            this.dataGridViewLineList.AllowUserToDeleteRows = false;
            this.dataGridViewLineList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLineList.Location = new System.Drawing.Point(3, 56);
            this.dataGridViewLineList.Name = "dataGridViewLineList";
            this.dataGridViewLineList.ReadOnly = true;
            this.dataGridViewLineList.RowTemplate.Height = 23;
            this.dataGridViewLineList.Size = new System.Drawing.Size(907, 423);
            this.dataGridViewLineList.TabIndex = 0;
            // 
            // UserControlLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewLineList);
            this.Name = "UserControlLine";
            this.Size = new System.Drawing.Size(913, 482);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLineList;
    }
}
