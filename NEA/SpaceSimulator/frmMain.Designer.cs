namespace SpaceSimulator
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
            this.tmrPhysics = new System.Windows.Forms.Timer(this.components);
            this.pbxFrame = new System.Windows.Forms.PictureBox();
            this.tmrRender = new System.Windows.Forms.Timer(this.components);
            this.lblFps = new System.Windows.Forms.Label();
            this.lblTps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrPhysics
            // 
            this.tmrPhysics.Tick += new System.EventHandler(this.tmrPhysics_Tick);
            // 
            // pbxFrame
            // 
            this.pbxFrame.Location = new System.Drawing.Point(0, 0);
            this.pbxFrame.Name = "pbxFrame";
            this.pbxFrame.Size = new System.Drawing.Size(940, 500);
            this.pbxFrame.TabIndex = 0;
            this.pbxFrame.TabStop = false;
            // 
            // tmrRender
            // 
            this.tmrRender.Tick += new System.EventHandler(this.tmrRender_Tick);
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblFps.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFps.Location = new System.Drawing.Point(868, 467);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(54, 25);
            this.lblFps.TabIndex = 1;
            this.lblFps.Text = "0 fps";
            // 
            // lblTps
            // 
            this.lblTps.AutoSize = true;
            this.lblTps.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTps.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTps.Location = new System.Drawing.Point(868, 442);
            this.lblTps.Name = "lblTps";
            this.lblTps.Size = new System.Drawing.Size(54, 25);
            this.lblTps.TabIndex = 2;
            this.lblTps.Text = "0 tps";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.lblTps);
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.pbxFrame);
            this.Name = "frmMain";
            this.Text = "Space Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.pbxFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrPhysics;
        private System.Windows.Forms.PictureBox pbxFrame;
        private System.Windows.Forms.Timer tmrRender;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.Label lblTps;
    }
}

