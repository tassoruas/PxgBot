namespace PxgBot.Forms
{
    partial class FrmWaypoint
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbActionTypes = new System.Windows.Forms.ComboBox();
            this.txtX = new System.Windows.Forms.NumericUpDown();
            this.txtY = new System.Windows.Forms.NumericUpDown();
            this.txtZ = new System.Windows.Forms.NumericUpDown();
            this.btnNW = new System.Windows.Forms.Button();
            this.btnN = new System.Windows.Forms.Button();
            this.btnNE = new System.Windows.Forms.Button();
            this.btnE = new System.Windows.Forms.Button();
            this.btnP = new System.Windows.Forms.Button();
            this.btnW = new System.Windows.Forms.Button();
            this.btnSE = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.btnSW = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZ)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(154, 98);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Action Type: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Position: ";
            // 
            // cmbActionTypes
            // 
            this.cmbActionTypes.FormattingEnabled = true;
            this.cmbActionTypes.Location = new System.Drawing.Point(80, 67);
            this.cmbActionTypes.Name = "cmbActionTypes";
            this.cmbActionTypes.Size = new System.Drawing.Size(186, 21);
            this.cmbActionTypes.TabIndex = 4;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(80, 42);
            this.txtX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(58, 20);
            this.txtX.TabIndex = 5;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(144, 42);
            this.txtY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(58, 20);
            this.txtY.TabIndex = 6;
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(208, 42);
            this.txtZ.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(58, 20);
            this.txtZ.TabIndex = 7;
            // 
            // btnNW
            // 
            this.btnNW.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNW.Location = new System.Drawing.Point(281, 14);
            this.btnNW.Name = "btnNW";
            this.btnNW.Size = new System.Drawing.Size(27, 25);
            this.btnNW.TabIndex = 8;
            this.btnNW.Text = "NW";
            this.btnNW.UseVisualStyleBackColor = true;
            this.btnNW.Click += new System.EventHandler(this.btnNW_Click);
            // 
            // btnN
            // 
            this.btnN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN.Location = new System.Drawing.Point(314, 14);
            this.btnN.Name = "btnN";
            this.btnN.Size = new System.Drawing.Size(27, 25);
            this.btnN.TabIndex = 9;
            this.btnN.Text = "N";
            this.btnN.UseVisualStyleBackColor = true;
            this.btnN.Click += new System.EventHandler(this.btnN_Click);
            // 
            // btnNE
            // 
            this.btnNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNE.Location = new System.Drawing.Point(347, 14);
            this.btnNE.Name = "btnNE";
            this.btnNE.Size = new System.Drawing.Size(27, 25);
            this.btnNE.TabIndex = 10;
            this.btnNE.Text = "NE";
            this.btnNE.UseVisualStyleBackColor = true;
            this.btnNE.Click += new System.EventHandler(this.btnNE_Click);
            // 
            // btnE
            // 
            this.btnE.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnE.Location = new System.Drawing.Point(347, 44);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(27, 25);
            this.btnE.TabIndex = 13;
            this.btnE.Text = "E";
            this.btnE.UseVisualStyleBackColor = true;
            this.btnE.Click += new System.EventHandler(this.btnE_Click);
            // 
            // btnP
            // 
            this.btnP.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnP.Location = new System.Drawing.Point(314, 44);
            this.btnP.Name = "btnP";
            this.btnP.Size = new System.Drawing.Size(27, 25);
            this.btnP.TabIndex = 12;
            this.btnP.Text = "P";
            this.btnP.UseVisualStyleBackColor = true;
            this.btnP.Click += new System.EventHandler(this.btnP_Click);
            // 
            // btnW
            // 
            this.btnW.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnW.Location = new System.Drawing.Point(281, 44);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(27, 25);
            this.btnW.TabIndex = 11;
            this.btnW.Text = "W";
            this.btnW.UseVisualStyleBackColor = true;
            this.btnW.Click += new System.EventHandler(this.btnW_Click);
            // 
            // btnSE
            // 
            this.btnSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSE.Location = new System.Drawing.Point(347, 75);
            this.btnSE.Name = "btnSE";
            this.btnSE.Size = new System.Drawing.Size(27, 25);
            this.btnSE.TabIndex = 16;
            this.btnSE.Text = "SE";
            this.btnSE.UseVisualStyleBackColor = true;
            this.btnSE.Click += new System.EventHandler(this.btnSE_Click);
            // 
            // btnS
            // 
            this.btnS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnS.Location = new System.Drawing.Point(314, 75);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(27, 25);
            this.btnS.TabIndex = 15;
            this.btnS.Text = "S";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnSW
            // 
            this.btnSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSW.Location = new System.Drawing.Point(281, 75);
            this.btnSW.Name = "btnSW";
            this.btnSW.Size = new System.Drawing.Size(27, 25);
            this.btnSW.TabIndex = 14;
            this.btnSW.Text = "SW";
            this.btnSW.UseVisualStyleBackColor = true;
            this.btnSW.Click += new System.EventHandler(this.btnSW_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(186, 20);
            this.txtName.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Name: ";
            // 
            // FrmWaypoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 128);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSE);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnSW);
            this.Controls.Add(this.btnE);
            this.Controls.Add(this.btnP);
            this.Controls.Add(this.btnW);
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.btnN);
            this.Controls.Add(this.btnNW);
            this.Controls.Add(this.txtZ);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.cmbActionTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWaypoint";
            this.ShowIcon = false;
            this.Text = "Waypoint";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmWaypoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbActionTypes;
        private System.Windows.Forms.NumericUpDown txtX;
        private System.Windows.Forms.NumericUpDown txtY;
        private System.Windows.Forms.NumericUpDown txtZ;
        private System.Windows.Forms.Button btnNW;
        private System.Windows.Forms.Button btnN;
        private System.Windows.Forms.Button btnNE;
        private System.Windows.Forms.Button btnE;
        private System.Windows.Forms.Button btnP;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.Button btnSE;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnSW;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
    }
}