
namespace BiliSave
{
    partial class BiliSaveMain
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
            this.labelPathLoad = new System.Windows.Forms.Label();
            this.textBoxPathLoad = new System.Windows.Forms.TextBox();
            this.textBoxPathSave = new System.Windows.Forms.TextBox();
            this.labelPathSave = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPathLoad
            // 
            this.labelPathLoad.AutoSize = true;
            this.labelPathLoad.Location = new System.Drawing.Point(12, 9);
            this.labelPathLoad.Name = "labelPathLoad";
            this.labelPathLoad.Size = new System.Drawing.Size(53, 12);
            this.labelPathLoad.TabIndex = 0;
            this.labelPathLoad.Text = "PathLoad";
            // 
            // textBoxPathLoad
            // 
            this.textBoxPathLoad.Location = new System.Drawing.Point(71, 6);
            this.textBoxPathLoad.Name = "textBoxPathLoad";
            this.textBoxPathLoad.Size = new System.Drawing.Size(717, 21);
            this.textBoxPathLoad.TabIndex = 1;
            // 
            // textBoxPathSave
            // 
            this.textBoxPathSave.Location = new System.Drawing.Point(71, 33);
            this.textBoxPathSave.Name = "textBoxPathSave";
            this.textBoxPathSave.Size = new System.Drawing.Size(717, 21);
            this.textBoxPathSave.TabIndex = 3;
            // 
            // labelPathSave
            // 
            this.labelPathSave.AutoSize = true;
            this.labelPathSave.Location = new System.Drawing.Point(12, 36);
            this.labelPathSave.Name = "labelPathSave";
            this.labelPathSave.Size = new System.Drawing.Size(53, 12);
            this.labelPathSave.TabIndex = 2;
            this.labelPathSave.Text = "PathSave";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 415);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "加载";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // BiliSaveMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxPathSave);
            this.Controls.Add(this.labelPathSave);
            this.Controls.Add(this.textBoxPathLoad);
            this.Controls.Add(this.labelPathLoad);
            this.Name = "BiliSaveMain";
            this.Text = "BiliSaveMain";
            this.Load += new System.EventHandler(this.BiliSaveMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPathLoad;
        private System.Windows.Forms.TextBox textBoxPathLoad;
        private System.Windows.Forms.TextBox textBoxPathSave;
        private System.Windows.Forms.Label labelPathSave;
        private System.Windows.Forms.Button buttonLoad;
    }
}