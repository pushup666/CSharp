﻿namespace BookStore
{
    partial class BookStore
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
            // BookStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonImportBooks);
            this.Name = "BookStore";
            this.Text = "BookStore";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonImportBooks;
    }
}

