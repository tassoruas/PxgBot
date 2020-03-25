namespace PxgBot
{
    partial class HUD
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
            this.tmrGetInfo = new System.Windows.Forms.Timer(this.components);
            this.lblMonsterHP = new System.Windows.Forms.Label();
            this.lblCharacterHP = new System.Windows.Forms.Label();
            this.lblPosZ = new System.Windows.Forms.Label();
            this.lblPosY = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrGetInfo
            // 
            this.tmrGetInfo.Enabled = true;
            this.tmrGetInfo.Interval = 5000;
            // 
            // lblMonsterHP
            // 
            this.lblMonsterHP.AutoSize = true;
            this.lblMonsterHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterHP.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMonsterHP.Location = new System.Drawing.Point(12, 33);
            this.lblMonsterHP.Name = "lblMonsterHP";
            this.lblMonsterHP.Size = new System.Drawing.Size(119, 24);
            this.lblMonsterHP.TabIndex = 9;
            this.lblMonsterHP.Text = "Monster HP: ";
            // 
            // lblCharacterHP
            // 
            this.lblCharacterHP.AutoSize = true;
            this.lblCharacterHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacterHP.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCharacterHP.Location = new System.Drawing.Point(12, 9);
            this.lblCharacterHP.Name = "lblCharacterHP";
            this.lblCharacterHP.Size = new System.Drawing.Size(132, 24);
            this.lblCharacterHP.TabIndex = 8;
            this.lblCharacterHP.Text = "Character HP: ";
            // 
            // lblPosZ
            // 
            this.lblPosZ.AutoSize = true;
            this.lblPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosZ.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPosZ.Location = new System.Drawing.Point(14, 105);
            this.lblPosZ.Name = "lblPosZ";
            this.lblPosZ.Size = new System.Drawing.Size(69, 24);
            this.lblPosZ.TabIndex = 7;
            this.lblPosZ.Text = "Pos Z: ";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosY.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPosY.Location = new System.Drawing.Point(12, 81);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(69, 24);
            this.lblPosY.TabIndex = 6;
            this.lblPosY.Text = "Pos Y: ";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosX.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPosX.Location = new System.Drawing.Point(12, 57);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(71, 24);
            this.lblPosX.TabIndex = 5;
            this.lblPosX.Text = "Pos X: ";
            // 
            // HUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(241, 154);
            this.Controls.Add(this.lblMonsterHP);
            this.Controls.Add(this.lblCharacterHP);
            this.Controls.Add(this.lblPosZ);
            this.Controls.Add(this.lblPosY);
            this.Controls.Add(this.lblPosX);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HUD";
            this.ShowIcon = false;
            this.Text = "HUD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrGetInfo;
        private System.Windows.Forms.Label lblMonsterHP;
        private System.Windows.Forms.Label lblCharacterHP;
        private System.Windows.Forms.Label lblPosZ;
        private System.Windows.Forms.Label lblPosY;
        private System.Windows.Forms.Label lblPosX;
    }
}