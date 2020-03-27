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
            this.btnGetBattleList = new System.Windows.Forms.Button();
            this.txtTests = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPokeHP = new System.Windows.Forms.Label();
            this.lblCharHP = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.lblPosY = new System.Windows.Forms.Label();
            this.lblDestinY = new System.Windows.Forms.Label();
            this.lblDestinX = new System.Windows.Forms.Label();
            this.lblPosZ = new System.Windows.Forms.Label();
            this.lblIsAttacking = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblIsFishing = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStartCavebot = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.tmrUpdateGUI = new System.Windows.Forms.Timer(this.components);
            this.btnCavebotAttack = new System.Windows.Forms.Button();
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
            this.tmrTest.Interval = 2500;
            this.tmrTest.Tick += new System.EventHandler(this.tmrTest_Tick);
            // 
            // btnGetBattleList
            // 
            this.btnGetBattleList.Location = new System.Drawing.Point(4, 213);
            this.btnGetBattleList.Name = "btnGetBattleList";
            this.btnGetBattleList.Size = new System.Drawing.Size(143, 23);
            this.btnGetBattleList.TabIndex = 1;
            this.btnGetBattleList.Text = "GetBattleList";
            this.btnGetBattleList.UseVisualStyleBackColor = true;
            this.btnGetBattleList.Click += new System.EventHandler(this.btnGetBattleList_Click);
            // 
            // txtTests
            // 
            this.txtTests.Location = new System.Drawing.Point(153, 155);
            this.txtTests.Name = "txtTests";
            this.txtTests.Size = new System.Drawing.Size(117, 230);
            this.txtTests.TabIndex = 2;
            this.txtTests.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(16, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Poke HP: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(18, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Char HP: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(36, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pos X: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(36, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pos Y: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(37, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pos Z: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(17, 506);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Destin X: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(17, 526);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Destin Y: ";
            // 
            // lblPokeHP
            // 
            this.lblPokeHP.AutoSize = true;
            this.lblPokeHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPokeHP.ForeColor = System.Drawing.Color.Red;
            this.lblPokeHP.Location = new System.Drawing.Point(101, 406);
            this.lblPokeHP.Name = "lblPokeHP";
            this.lblPokeHP.Size = new System.Drawing.Size(18, 20);
            this.lblPokeHP.TabIndex = 10;
            this.lblPokeHP.Text = "0";
            // 
            // lblCharHP
            // 
            this.lblCharHP.AutoSize = true;
            this.lblCharHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharHP.ForeColor = System.Drawing.Color.Red;
            this.lblCharHP.Location = new System.Drawing.Point(101, 426);
            this.lblCharHP.Name = "lblCharHP";
            this.lblCharHP.Size = new System.Drawing.Size(18, 20);
            this.lblCharHP.TabIndex = 11;
            this.lblCharHP.Text = "0";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosX.ForeColor = System.Drawing.Color.Red;
            this.lblPosX.Location = new System.Drawing.Point(101, 446);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(18, 20);
            this.lblPosX.TabIndex = 12;
            this.lblPosX.Text = "0";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosY.ForeColor = System.Drawing.Color.Red;
            this.lblPosY.Location = new System.Drawing.Point(101, 466);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(18, 20);
            this.lblPosY.TabIndex = 13;
            this.lblPosY.Text = "0";
            // 
            // lblDestinY
            // 
            this.lblDestinY.AutoSize = true;
            this.lblDestinY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinY.ForeColor = System.Drawing.Color.Red;
            this.lblDestinY.Location = new System.Drawing.Point(101, 526);
            this.lblDestinY.Name = "lblDestinY";
            this.lblDestinY.Size = new System.Drawing.Size(18, 20);
            this.lblDestinY.TabIndex = 16;
            this.lblDestinY.Text = "0";
            // 
            // lblDestinX
            // 
            this.lblDestinX.AutoSize = true;
            this.lblDestinX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinX.ForeColor = System.Drawing.Color.Red;
            this.lblDestinX.Location = new System.Drawing.Point(101, 506);
            this.lblDestinX.Name = "lblDestinX";
            this.lblDestinX.Size = new System.Drawing.Size(18, 20);
            this.lblDestinX.TabIndex = 15;
            this.lblDestinX.Text = "0";
            // 
            // lblPosZ
            // 
            this.lblPosZ.AutoSize = true;
            this.lblPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosZ.ForeColor = System.Drawing.Color.Red;
            this.lblPosZ.Location = new System.Drawing.Point(101, 486);
            this.lblPosZ.Name = "lblPosZ";
            this.lblPosZ.Size = new System.Drawing.Size(18, 20);
            this.lblPosZ.TabIndex = 14;
            this.lblPosZ.Text = "0";
            // 
            // lblIsAttacking
            // 
            this.lblIsAttacking.AutoSize = true;
            this.lblIsAttacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsAttacking.ForeColor = System.Drawing.Color.Red;
            this.lblIsAttacking.Location = new System.Drawing.Point(101, 546);
            this.lblIsAttacking.Name = "lblIsAttacking";
            this.lblIsAttacking.Size = new System.Drawing.Size(18, 20);
            this.lblIsAttacking.TabIndex = 19;
            this.lblIsAttacking.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(11, 546);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Attacking: ";
            // 
            // lblIsFishing
            // 
            this.lblIsFishing.AutoSize = true;
            this.lblIsFishing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsFishing.ForeColor = System.Drawing.Color.Red;
            this.lblIsFishing.Location = new System.Drawing.Point(101, 566);
            this.lblIsFishing.Name = "lblIsFishing";
            this.lblIsFishing.Size = new System.Drawing.Size(18, 20);
            this.lblIsFishing.TabIndex = 21;
            this.lblIsFishing.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(27, 566);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Fishing: ";
            // 
            // btnStartCavebot
            // 
            this.btnStartCavebot.Location = new System.Drawing.Point(4, 155);
            this.btnStartCavebot.Name = "btnStartCavebot";
            this.btnStartCavebot.Size = new System.Drawing.Size(143, 23);
            this.btnStartCavebot.TabIndex = 22;
            this.btnStartCavebot.Text = "Cavebot: False";
            this.btnStartCavebot.UseVisualStyleBackColor = true;
            this.btnStartCavebot.Click += new System.EventHandler(this.btnStartCavebot_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(4, 242);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(143, 23);
            this.btnTest.TabIndex = 23;
            this.btnTest.Text = "Write on memory";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tmrUpdateGUI
            // 
            this.tmrUpdateGUI.Enabled = true;
            this.tmrUpdateGUI.Interval = 30000;
            this.tmrUpdateGUI.Tick += new System.EventHandler(this.tmrUpdateGUI_Tick);
            // 
            // btnCavebotAttack
            // 
            this.btnCavebotAttack.Location = new System.Drawing.Point(4, 184);
            this.btnCavebotAttack.Name = "btnCavebotAttack";
            this.btnCavebotAttack.Size = new System.Drawing.Size(143, 23);
            this.btnCavebotAttack.TabIndex = 25;
            this.btnCavebotAttack.Text = "Attacker: False";
            this.btnCavebotAttack.UseVisualStyleBackColor = true;
            this.btnCavebotAttack.Click += new System.EventHandler(this.btnCavebotAttack_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(360, 613);
            this.Controls.Add(this.btnCavebotAttack);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnStartCavebot);
            this.Controls.Add(this.lblIsFishing);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblIsAttacking);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblDestinY);
            this.Controls.Add(this.lblDestinX);
            this.Controls.Add(this.lblPosZ);
            this.Controls.Add(this.lblPosY);
            this.Controls.Add(this.lblPosX);
            this.Controls.Add(this.lblCharHP);
            this.Controls.Add(this.lblPokeHP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTests);
            this.Controls.Add(this.btnGetBattleList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrUpdateInfo;
        private System.Windows.Forms.Timer tmrTest;
        private System.Windows.Forms.Button btnGetBattleList;
        private System.Windows.Forms.RichTextBox txtTests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPokeHP;
        private System.Windows.Forms.Label lblCharHP;
        private System.Windows.Forms.Label lblPosX;
        private System.Windows.Forms.Label lblPosY;
        private System.Windows.Forms.Label lblDestinY;
        private System.Windows.Forms.Label lblDestinX;
        private System.Windows.Forms.Label lblPosZ;
        private System.Windows.Forms.Label lblIsAttacking;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblIsFishing;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnStartCavebot;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Timer tmrUpdateGUI;
        private System.Windows.Forms.Button btnCavebotAttack;
    }
}

