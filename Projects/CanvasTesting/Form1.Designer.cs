namespace CanvasTesting
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.pbxFrame = new System.Windows.Forms.PictureBox();
            this.tmrTick = new System.Windows.Forms.Timer(this.components);
            this.btnToggle = new System.Windows.Forms.Button();
            this.tbxHz = new System.Windows.Forms.TextBox();
            this.tmrElapsed = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxFrame
            // 
            this.pbxFrame.Location = new System.Drawing.Point(12, 12);
            this.pbxFrame.Name = "pbxFrame";
            this.pbxFrame.Size = new System.Drawing.Size(1240, 628);
            this.pbxFrame.TabIndex = 0;
            this.pbxFrame.TabStop = false;
            // 
            // tmrTick
            // 
            this.tmrTick.Interval = 1;
            this.tmrTick.Tick += new System.EventHandler(this.tmrTick_Tick);
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(12, 646);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(75, 23);
            this.btnToggle.TabIndex = 1;
            this.btnToggle.Text = "Toggle";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // tbxHz
            // 
            this.tbxHz.Location = new System.Drawing.Point(124, 646);
            this.tbxHz.Name = "tbxHz";
            this.tbxHz.Size = new System.Drawing.Size(100, 20);
            this.tbxHz.TabIndex = 2;
            // 
            // tmrElapsed
            // 
            this.tmrElapsed.Interval = 1000;
            this.tmrElapsed.Tick += new System.EventHandler(this.tmrElapsed_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tbxHz);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.pbxFrame);
            this.Name = "frmMain";
            this.Text = "Main Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pbxFrame;
        private System.Windows.Forms.Timer tmrTick;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.TextBox tbxHz;
        private System.Windows.Forms.Timer tmrElapsed;
    }
}

