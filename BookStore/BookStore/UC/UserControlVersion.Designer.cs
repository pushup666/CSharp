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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersionList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVersionList
            // 
            this.dataGridViewVersionList.AllowUserToAddRows = false;
            this.dataGridViewVersionList.AllowUserToDeleteRows = false;
            this.dataGridViewVersionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVersionList.Location = new System.Drawing.Point(14, 57);
            this.dataGridViewVersionList.Name = "dataGridViewVersionList";
            this.dataGridViewVersionList.ReadOnly = true;
            this.dataGridViewVersionList.RowTemplate.Height = 23;
            this.dataGridViewVersionList.Size = new System.Drawing.Size(240, 408);
            this.dataGridViewVersionList.TabIndex = 0;
            // 
            // richTextBoxVersionContent
            // 
            this.richTextBoxVersionContent.Location = new System.Drawing.Point(276, 57);
            this.richTextBoxVersionContent.Name = "richTextBoxVersionContent";
            this.richTextBoxVersionContent.Size = new System.Drawing.Size(615, 408);
            this.richTextBoxVersionContent.TabIndex = 1;
            this.richTextBoxVersionContent.Text = "";
            // 
            // UserControlVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxVersionContent);
            this.Controls.Add(this.dataGridViewVersionList);
            this.Name = "UserControlVersion";
            this.Size = new System.Drawing.Size(913, 482);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersionList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVersionList;
        private System.Windows.Forms.RichTextBox richTextBoxVersionContent;
    }
}
