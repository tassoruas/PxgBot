namespace PxgBot
{
    partial class Main
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
            this.tmrUpdateInfo = new System.Windows.Forms.Timer(this.components);
            this.tmrTest = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrUpdateInfo
            // 
            this.tmrUpdateInfo.Enabled = true;
            this.tmrUpdateInfo.Interval = 500;
            this.tmrUpdateInfo.Tick += new System.EventHandler(this.tmrUpdateInfo_Tick);
            // 
            // tmrTest
            // 
            this.tmrTest.Enabled = true;
            this.tmrTest.Interval = 5000;
            this.tmrTest.Tick += new System.EventHandler(this.tmrTest_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(364, 465);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Main";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrUpdateInfo;
        private System.Windows.Forms.Timer tmrTest;
    }
}

