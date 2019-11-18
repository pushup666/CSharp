namespace OpenWild
{
    partial class OpenWildForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonNewPlayer = new System.Windows.Forms.Button();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.timerPlayerInfoUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonNewPlayer
            // 
            this.buttonNewPlayer.Location = new System.Drawing.Point(12, 12);
            this.buttonNewPlayer.Name = "buttonNewPlayer";
            this.buttonNewPlayer.Size = new System.Drawing.Size(75, 23);
            this.buttonNewPlayer.TabIndex = 0;
            this.buttonNewPlayer.Text = "New Player";
            this.buttonNewPlayer.UseVisualStyleBackColor = true;
            this.buttonNewPlayer.Click += new System.EventHandler(this.ButtonNewPlayer_Click);
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(93, 12);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStartStop.TabIndex = 1;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.ButtonStartStop_Click);
            // 
            // timerPlayerInfoUpdate
            // 
            this.timerPlayerInfoUpdate.Tick += new System.EventHandler(this.timerPlayerInfoUpdate_Tick);
            // 
            // OpenWildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.buttonNewPlayer);
            this.Name = "OpenWildForm";
            this.Text = "OpenWildForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNewPlayer;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Timer timerPlayerInfoUpdate;
    }
}

