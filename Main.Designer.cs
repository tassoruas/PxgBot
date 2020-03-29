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
            this.tmrUpdateGUI = new System.Windows.Forms.Timer(this.components);
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPokemon = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbReviveHotkey = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCooldownF9 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCooldownF8 = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCooldownF7 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCooldownF6 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCooldownF5 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCooldownF4 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCooldownF3 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCooldownF2 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCooldownF1 = new System.Windows.Forms.NumericUpDown();
            this.chbSpellF9 = new System.Windows.Forms.CheckBox();
            this.chbSpellF8 = new System.Windows.Forms.CheckBox();
            this.chbSpellF7 = new System.Windows.Forms.CheckBox();
            this.chbSpellF6 = new System.Windows.Forms.CheckBox();
            this.chbSpellF5 = new System.Windows.Forms.CheckBox();
            this.chbSpellF4 = new System.Windows.Forms.CheckBox();
            this.chbSpellF3 = new System.Windows.Forms.CheckBox();
            this.chbSpellF2 = new System.Windows.Forms.CheckBox();
            this.chbSpellF1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHpToRevive = new System.Windows.Forms.NumericUpDown();
            this.chbAutoRevive = new System.Windows.Forms.CheckBox();
            this.tabCavebot = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabAttacker = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnRemoveMonsterAttack = new System.Windows.Forms.Button();
            this.btnAddMonsterAttack = new System.Windows.Forms.Button();
            this.listMonstersToAttack = new System.Windows.Forms.ListBox();
            this.listAvailableMonsters = new System.Windows.Forms.ListBox();
            this.btnCavebotAttack = new System.Windows.Forms.Button();
            this.btnStartCavebot = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.pnlSettings.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPokemon.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHpToRevive)).BeginInit();
            this.tabCavebot.SuspendLayout();
            this.tabAttacker.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrUpdateInfo
            // 
            this.tmrUpdateInfo.Enabled = true;
            this.tmrUpdateInfo.Interval = 750;
            this.tmrUpdateInfo.Tick += new System.EventHandler(this.tmrUpdateInfo_Tick);
            // 
            // tmrTest
            // 
            this.tmrTest.Enabled = true;
            this.tmrTest.Interval = 2500;
            this.tmrTest.Tick += new System.EventHandler(this.tmrTest_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(27, 408);
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
            this.label2.Location = new System.Drawing.Point(29, 428);
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
            this.label3.Location = new System.Drawing.Point(47, 448);
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
            this.label4.Location = new System.Drawing.Point(47, 468);
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
            this.label5.Location = new System.Drawing.Point(48, 488);
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
            this.label6.Location = new System.Drawing.Point(28, 508);
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
            this.label7.Location = new System.Drawing.Point(28, 528);
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
            this.lblPokeHP.Location = new System.Drawing.Point(112, 408);
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
            this.lblCharHP.Location = new System.Drawing.Point(112, 428);
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
            this.lblPosX.Location = new System.Drawing.Point(112, 448);
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
            this.lblPosY.Location = new System.Drawing.Point(112, 468);
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
            this.lblDestinY.Location = new System.Drawing.Point(112, 528);
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
            this.lblDestinX.Location = new System.Drawing.Point(112, 508);
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
            this.lblPosZ.Location = new System.Drawing.Point(112, 488);
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
            this.lblIsAttacking.Location = new System.Drawing.Point(112, 548);
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
            this.label11.Location = new System.Drawing.Point(22, 548);
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
            this.lblIsFishing.Location = new System.Drawing.Point(112, 568);
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
            this.label9.Location = new System.Drawing.Point(38, 568);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Fishing: ";
            // 
            // tmrUpdateGUI
            // 
            this.tmrUpdateGUI.Enabled = true;
            this.tmrUpdateGUI.Interval = 60000;
            this.tmrUpdateGUI.Tick += new System.EventHandler(this.tmrUpdateGUI_Tick);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(23, 330);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(107, 23);
            this.btnSettings.TabIndex = 26;
            this.btnSettings.Text = "Settings >>";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.panel1);
            this.pnlSettings.Controls.Add(this.tabControl1);
            this.pnlSettings.Location = new System.Drawing.Point(166, 157);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(294, 525);
            this.pnlSettings.TabIndex = 27;
            this.pnlSettings.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPokemon);
            this.tabControl1.Controls.Add(this.tabCavebot);
            this.tabControl1.Controls.Add(this.tabAttacker);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(294, 525);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPokemon
            // 
            this.tabPokemon.Controls.Add(this.groupBox2);
            this.tabPokemon.Location = new System.Drawing.Point(4, 22);
            this.tabPokemon.Name = "tabPokemon";
            this.tabPokemon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPokemon.Size = new System.Drawing.Size(286, 499);
            this.tabPokemon.TabIndex = 2;
            this.tabPokemon.Text = "Pokemon";
            this.tabPokemon.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.cmbReviveHotkey);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtCooldownF9);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtCooldownF8);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtCooldownF7);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtCooldownF6);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtCooldownF5);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtCooldownF4);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtCooldownF3);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtCooldownF2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtCooldownF1);
            this.groupBox2.Controls.Add(this.chbSpellF9);
            this.groupBox2.Controls.Add(this.chbSpellF8);
            this.groupBox2.Controls.Add(this.chbSpellF7);
            this.groupBox2.Controls.Add(this.chbSpellF6);
            this.groupBox2.Controls.Add(this.chbSpellF5);
            this.groupBox2.Controls.Add(this.chbSpellF4);
            this.groupBox2.Controls.Add(this.chbSpellF3);
            this.groupBox2.Controls.Add(this.chbSpellF2);
            this.groupBox2.Controls.Add(this.chbSpellF1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtHpToRevive);
            this.groupBox2.Controls.Add(this.chbAutoRevive);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 449);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pokemon";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(2, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 13);
            this.label22.TabIndex = 31;
            this.label22.Text = "Revive item hotkey: ";
            // 
            // cmbReviveHotkey
            // 
            this.cmbReviveHotkey.FormattingEnabled = true;
            this.cmbReviveHotkey.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.cmbReviveHotkey.Location = new System.Drawing.Point(112, 77);
            this.cmbReviveHotkey.Name = "cmbReviveHotkey";
            this.cmbReviveHotkey.Size = new System.Drawing.Size(121, 21);
            this.cmbReviveHotkey.TabIndex = 30;
            this.cmbReviveHotkey.SelectedValueChanged += new System.EventHandler(this.cmbReviveHotkey_SelectedValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(109, 306);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "Cooldown: ";
            // 
            // txtCooldownF9
            // 
            this.txtCooldownF9.Enabled = false;
            this.txtCooldownF9.Location = new System.Drawing.Point(175, 304);
            this.txtCooldownF9.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtCooldownF9.Name = "txtCooldownF9";
            this.txtCooldownF9.Size = new System.Drawing.Size(58, 20);
            this.txtCooldownF9.TabIndex = 28;
            this.txtCooldownF9.ValueChanged += new System.EventHandler(this.txtCooldownF9_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(109, 283);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "Cooldown: ";
            // 
            // txtCooldownF8
            // 
            this.txtCooldownF8.Enabled = false;
            this.txtCooldownF8.Location = new System.Drawing.Point(175, 281);
            this.txtCooldownF8.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtCooldownF8.Name = "txtCooldownF8";
            this.txtCooldownF8.Size = new System.Drawing.Size(58, 20);
            this.txtCooldownF8.TabIndex = 26;
            this.txtCooldownF8.ValueChanged += new System.EventHandler(this.txtCooldownF8_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(109, 260);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Cooldown: ";
            // 
            // txtCooldownF7
            // 
            this.txtCooldownF7.Enabled = false;
            this.txtCooldownF7.Location = new System.Drawing.Point(175, 258);
            this.txtCooldownF7.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtCooldownF7.Name = "txtCooldownF7";
            this.txtCooldownF7.Size = new System.Drawing.Size(58, 20);
            this.txtCooldownF7.TabIndex = 24;
            this.txtCooldownF7.ValueChanged += new System.EventHandler(this.txtCooldownF7_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(109, 237);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Cooldown: ";
            // 
            // txtCooldownF6
            // 
            this.txtCooldownF6.Enabled = false;
            this.txtCooldownF6.Location = new System.Drawing.Point(175, 235);
            this.txtCooldownF6.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtCooldownF6.Name = "txtCooldownF6";
            this.txtCooldownF6.Size = new System.Drawing.Size(58, 20);
            this.txtCooldownF6.TabIndex = 22;
            this.txtCooldownF6.ValueChanged += new System.EventHandler(this.txtCooldownF6_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(109, 214);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Cooldown: ";
            // 
            // txtCooldownF5
            // 
            this.txtCooldownF5.Enabled = false;
            this.txtCooldownF5.Location = new System.Drawing.Point(175, 212);
            this.txtCooldownF5.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtCooldownF5.Name = "txtCooldownF5";
            this.txtCooldownF5.Size = new System.Drawing.Size(58, 20);
            this.txtCooldownF5.TabIndex = 20;
            this.txtCooldownF5.ValueChanged += new System.EventHandler(this.txtCooldownF5_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(109, 190);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Cooldown: ";
            // 
            // txtCooldownF4
            // 
            this.txtCooldownF4.Enabled = false;
            this.txtCooldownF4.Location = new System.Drawing.Point(175, 188);
            this.txtCooldownF4.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtCooldownF4.Name = "txtCooldownF4";
            this.txtCooldownF4.Size = new System.Drawing.Size(58, 20);
            this.txtCooldownF4.TabIndex = 18;
            this.txtCooldownF4.ValueChanged += new System.EventHandler(this.txtCooldownF4_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(109, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Cooldown: ";
            // 
            // txtCooldownF3
            // 
            this.txtCooldownF3.Enabled = false;
            this.txtCooldownF3.Location = new System.Drawing.Point(175, 166);
            this.txtCooldownF3.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtCooldownF3.Name = "txtCooldownF3";
            this.txtCooldownF3.Size = new System.Drawing.Size(58, 20);
            this.txtCooldownF3.TabIndex = 16;
            this.txtCooldownF3.ValueChanged += new System.EventHandler(this.txtCooldownF3_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(109, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Cooldown: ";
            // 
            // txtCooldownF2
            // 
            this.txtCooldownF2.Enabled = false;
            this.txtCooldownF2.Location = new System.Drawing.Point(175, 143);
            this.txtCooldownF2.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtCooldownF2.Name = "txtCooldownF2";
            this.txtCooldownF2.Size = new System.Drawing.Size(58, 20);
            this.txtCooldownF2.TabIndex = 14;
            this.txtCooldownF2.ValueChanged += new System.EventHandler(this.txtCooldownF2_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(109, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Cooldown: ";
            // 
            // txtCooldownF1
            // 
            this.txtCooldownF1.Enabled = false;
            this.txtCooldownF1.Location = new System.Drawing.Point(175, 120);
            this.txtCooldownF1.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtCooldownF1.Name = "txtCooldownF1";
            this.txtCooldownF1.Size = new System.Drawing.Size(58, 20);
            this.txtCooldownF1.TabIndex = 12;
            this.txtCooldownF1.ValueChanged += new System.EventHandler(this.txtCooldownF1_ValueChanged);
            // 
            // chbSpellF9
            // 
            this.chbSpellF9.AutoSize = true;
            this.chbSpellF9.Location = new System.Drawing.Point(6, 305);
            this.chbSpellF9.Name = "chbSpellF9";
            this.chbSpellF9.Size = new System.Drawing.Size(38, 17);
            this.chbSpellF9.TabIndex = 11;
            this.chbSpellF9.Text = "F9";
            this.chbSpellF9.UseVisualStyleBackColor = true;
            this.chbSpellF9.CheckedChanged += new System.EventHandler(this.chbSpellF9_CheckedChanged);
            // 
            // chbSpellF8
            // 
            this.chbSpellF8.AutoSize = true;
            this.chbSpellF8.Location = new System.Drawing.Point(6, 282);
            this.chbSpellF8.Name = "chbSpellF8";
            this.chbSpellF8.Size = new System.Drawing.Size(38, 17);
            this.chbSpellF8.TabIndex = 10;
            this.chbSpellF8.Text = "F8";
            this.chbSpellF8.UseVisualStyleBackColor = true;
            this.chbSpellF8.CheckedChanged += new System.EventHandler(this.chbSpellF8_CheckedChanged);
            // 
            // chbSpellF7
            // 
            this.chbSpellF7.AutoSize = true;
            this.chbSpellF7.Location = new System.Drawing.Point(6, 259);
            this.chbSpellF7.Name = "chbSpellF7";
            this.chbSpellF7.Size = new System.Drawing.Size(38, 17);
            this.chbSpellF7.TabIndex = 9;
            this.chbSpellF7.Text = "F7";
            this.chbSpellF7.UseVisualStyleBackColor = true;
            this.chbSpellF7.CheckedChanged += new System.EventHandler(this.chbSpellF7_CheckedChanged);
            // 
            // chbSpellF6
            // 
            this.chbSpellF6.AutoSize = true;
            this.chbSpellF6.Location = new System.Drawing.Point(6, 236);
            this.chbSpellF6.Name = "chbSpellF6";
            this.chbSpellF6.Size = new System.Drawing.Size(38, 17);
            this.chbSpellF6.TabIndex = 8;
            this.chbSpellF6.Text = "F6";
            this.chbSpellF6.UseVisualStyleBackColor = true;
            this.chbSpellF6.CheckedChanged += new System.EventHandler(this.chbSpellF6_CheckedChanged);
            // 
            // chbSpellF5
            // 
            this.chbSpellF5.AutoSize = true;
            this.chbSpellF5.Location = new System.Drawing.Point(6, 213);
            this.chbSpellF5.Name = "chbSpellF5";
            this.chbSpellF5.Size = new System.Drawing.Size(38, 17);
            this.chbSpellF5.TabIndex = 7;
            this.chbSpellF5.Text = "F5";
            this.chbSpellF5.UseVisualStyleBackColor = true;
            this.chbSpellF5.CheckedChanged += new System.EventHandler(this.chbSpellF5_CheckedChanged);
            // 
            // chbSpellF4
            // 
            this.chbSpellF4.AutoSize = true;
            this.chbSpellF4.Location = new System.Drawing.Point(6, 190);
            this.chbSpellF4.Name = "chbSpellF4";
            this.chbSpellF4.Size = new System.Drawing.Size(38, 17);
            this.chbSpellF4.TabIndex = 6;
            this.chbSpellF4.Text = "F4";
            this.chbSpellF4.UseVisualStyleBackColor = true;
            this.chbSpellF4.CheckedChanged += new System.EventHandler(this.chbSpellF4_CheckedChanged);
            // 
            // chbSpellF3
            // 
            this.chbSpellF3.AutoSize = true;
            this.chbSpellF3.Location = new System.Drawing.Point(6, 167);
            this.chbSpellF3.Name = "chbSpellF3";
            this.chbSpellF3.Size = new System.Drawing.Size(38, 17);
            this.chbSpellF3.TabIndex = 5;
            this.chbSpellF3.Text = "F3";
            this.chbSpellF3.UseVisualStyleBackColor = true;
            this.chbSpellF3.CheckedChanged += new System.EventHandler(this.chbSpellF3_CheckedChanged);
            // 
            // chbSpellF2
            // 
            this.chbSpellF2.AutoSize = true;
            this.chbSpellF2.Location = new System.Drawing.Point(6, 144);
            this.chbSpellF2.Name = "chbSpellF2";
            this.chbSpellF2.Size = new System.Drawing.Size(38, 17);
            this.chbSpellF2.TabIndex = 4;
            this.chbSpellF2.Text = "F2";
            this.chbSpellF2.UseVisualStyleBackColor = true;
            this.chbSpellF2.CheckedChanged += new System.EventHandler(this.chbSpellF2_CheckedChanged);
            // 
            // chbSpellF1
            // 
            this.chbSpellF1.AutoSize = true;
            this.chbSpellF1.Location = new System.Drawing.Point(6, 121);
            this.chbSpellF1.Name = "chbSpellF1";
            this.chbSpellF1.Size = new System.Drawing.Size(38, 17);
            this.chbSpellF1.TabIndex = 3;
            this.chbSpellF1.Text = "F1";
            this.chbSpellF1.UseVisualStyleBackColor = true;
            this.chbSpellF1.CheckedChanged += new System.EventHandler(this.chbSpellF1_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 39);
            this.label8.TabIndex = 2;
            this.label8.Text = "HP to revive: \r\n(0 means \r\nwhen dead)";
            // 
            // txtHpToRevive
            // 
            this.txtHpToRevive.Enabled = false;
            this.txtHpToRevive.Location = new System.Drawing.Point(175, 26);
            this.txtHpToRevive.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtHpToRevive.Name = "txtHpToRevive";
            this.txtHpToRevive.Size = new System.Drawing.Size(58, 20);
            this.txtHpToRevive.TabIndex = 1;
            this.txtHpToRevive.ValueChanged += new System.EventHandler(this.txtHpToRevive_ValueChanged);
            // 
            // chbAutoRevive
            // 
            this.chbAutoRevive.AutoSize = true;
            this.chbAutoRevive.Location = new System.Drawing.Point(6, 27);
            this.chbAutoRevive.Name = "chbAutoRevive";
            this.chbAutoRevive.Size = new System.Drawing.Size(85, 17);
            this.chbAutoRevive.TabIndex = 0;
            this.chbAutoRevive.Text = "Auto Revive";
            this.chbAutoRevive.UseVisualStyleBackColor = true;
            this.chbAutoRevive.CheckedChanged += new System.EventHandler(this.chbAutoRevive_CheckedChanged);
            // 
            // tabCavebot
            // 
            this.tabCavebot.Controls.Add(this.groupBox1);
            this.tabCavebot.Location = new System.Drawing.Point(4, 22);
            this.tabCavebot.Name = "tabCavebot";
            this.tabCavebot.Size = new System.Drawing.Size(286, 499);
            this.tabCavebot.TabIndex = 3;
            this.tabCavebot.Text = "Cavebot";
            this.tabCavebot.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 453);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cavebot";
            // 
            // tabAttacker
            // 
            this.tabAttacker.Controls.Add(this.groupBox3);
            this.tabAttacker.Location = new System.Drawing.Point(4, 22);
            this.tabAttacker.Name = "tabAttacker";
            this.tabAttacker.Size = new System.Drawing.Size(286, 499);
            this.tabAttacker.TabIndex = 4;
            this.tabAttacker.Text = "Attacker";
            this.tabAttacker.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.btnRemoveMonsterAttack);
            this.groupBox3.Controls.Add(this.btnAddMonsterAttack);
            this.groupBox3.Controls.Add(this.listMonstersToAttack);
            this.groupBox3.Controls.Add(this.listAvailableMonsters);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 453);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attacker";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "Available monsters: ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(166, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "Monsters to attack: ";
            // 
            // btnRemoveMonsterAttack
            // 
            this.btnRemoveMonsterAttack.Location = new System.Drawing.Point(126, 163);
            this.btnRemoveMonsterAttack.Name = "btnRemoveMonsterAttack";
            this.btnRemoveMonsterAttack.Size = new System.Drawing.Size(37, 23);
            this.btnRemoveMonsterAttack.TabIndex = 3;
            this.btnRemoveMonsterAttack.Text = "<";
            this.btnRemoveMonsterAttack.UseVisualStyleBackColor = true;
            this.btnRemoveMonsterAttack.Click += new System.EventHandler(this.btnRemoveMonsterAttack_Click);
            // 
            // btnAddMonsterAttack
            // 
            this.btnAddMonsterAttack.Location = new System.Drawing.Point(126, 134);
            this.btnAddMonsterAttack.Name = "btnAddMonsterAttack";
            this.btnAddMonsterAttack.Size = new System.Drawing.Size(37, 23);
            this.btnAddMonsterAttack.TabIndex = 2;
            this.btnAddMonsterAttack.Text = ">";
            this.btnAddMonsterAttack.UseVisualStyleBackColor = true;
            this.btnAddMonsterAttack.Click += new System.EventHandler(this.btnAddMonsterAttack_Click);
            // 
            // listMonstersToAttack
            // 
            this.listMonstersToAttack.FormattingEnabled = true;
            this.listMonstersToAttack.Location = new System.Drawing.Point(169, 47);
            this.listMonstersToAttack.Name = "listMonstersToAttack";
            this.listMonstersToAttack.Size = new System.Drawing.Size(105, 264);
            this.listMonstersToAttack.TabIndex = 1;
            // 
            // listAvailableMonsters
            // 
            this.listAvailableMonsters.FormattingEnabled = true;
            this.listAvailableMonsters.Location = new System.Drawing.Point(6, 47);
            this.listAvailableMonsters.Name = "listAvailableMonsters";
            this.listAvailableMonsters.Size = new System.Drawing.Size(105, 264);
            this.listAvailableMonsters.TabIndex = 0;
            // 
            // btnCavebotAttack
            // 
            this.btnCavebotAttack.BackgroundImage = global::PxgBot.Properties.Resources.Attack;
            this.btnCavebotAttack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCavebotAttack.Location = new System.Drawing.Point(23, 247);
            this.btnCavebotAttack.Name = "btnCavebotAttack";
            this.btnCavebotAttack.Size = new System.Drawing.Size(107, 77);
            this.btnCavebotAttack.TabIndex = 25;
            this.btnCavebotAttack.Text = "Attacker: Stopped";
            this.btnCavebotAttack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCavebotAttack.UseVisualStyleBackColor = true;
            this.btnCavebotAttack.Click += new System.EventHandler(this.btnCavebotAttack_Click);
            // 
            // btnStartCavebot
            // 
            this.btnStartCavebot.BackgroundImage = global::PxgBot.Properties.Resources.Hunting_512;
            this.btnStartCavebot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartCavebot.Location = new System.Drawing.Point(23, 157);
            this.btnStartCavebot.Name = "btnStartCavebot";
            this.btnStartCavebot.Size = new System.Drawing.Size(107, 84);
            this.btnStartCavebot.TabIndex = 22;
            this.btnStartCavebot.Text = "Cavebot: Stopped";
            this.btnStartCavebot.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStartCavebot.UseVisualStyleBackColor = true;
            this.btnStartCavebot.Click += new System.EventHandler(this.btnStartCavebot_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnSaveSettings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnSaveSettings.Location = new System.Drawing.Point(89, 6);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(114, 29);
            this.btnSaveSettings.TabIndex = 0;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(787, 979);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnCavebotAttack);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PXG Bot";
            this.TopMost = true;
            this.pnlSettings.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPokemon.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCooldownF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHpToRevive)).EndInit();
            this.tabCavebot.ResumeLayout(false);
            this.tabAttacker.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrUpdateInfo;
        private System.Windows.Forms.Timer tmrTest;
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
        private System.Windows.Forms.Timer tmrUpdateGUI;
        private System.Windows.Forms.Button btnCavebotAttack;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPokemon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbAutoRevive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtHpToRevive;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown txtCooldownF1;
        private System.Windows.Forms.CheckBox chbSpellF9;
        private System.Windows.Forms.CheckBox chbSpellF8;
        private System.Windows.Forms.CheckBox chbSpellF7;
        private System.Windows.Forms.CheckBox chbSpellF6;
        private System.Windows.Forms.CheckBox chbSpellF5;
        private System.Windows.Forms.CheckBox chbSpellF4;
        private System.Windows.Forms.CheckBox chbSpellF3;
        private System.Windows.Forms.CheckBox chbSpellF2;
        private System.Windows.Forms.CheckBox chbSpellF1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown txtCooldownF3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown txtCooldownF2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown txtCooldownF9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown txtCooldownF8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown txtCooldownF7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown txtCooldownF6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown txtCooldownF5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown txtCooldownF4;
        private System.Windows.Forms.TabPage tabCavebot;
        private System.Windows.Forms.TabPage tabAttacker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnRemoveMonsterAttack;
        private System.Windows.Forms.Button btnAddMonsterAttack;
        private System.Windows.Forms.ListBox listMonstersToAttack;
        private System.Windows.Forms.ListBox listAvailableMonsters;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbReviveHotkey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}

