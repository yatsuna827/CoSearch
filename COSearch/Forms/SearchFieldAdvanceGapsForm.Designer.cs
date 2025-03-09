namespace COSearch
{
    partial class SearchFieldAdvanceGapsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.blinkFramesBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statBoxS = new System.Windows.Forms.NumericUpDown();
            this.currentSeedBox = new COSearch.SeedBox();
            this.statBoxD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.statBoxC = new System.Windows.Forms.NumericUpDown();
            this.targetSeedBox = new COSearch.SeedBox();
            this.statBoxB = new System.Windows.Forms.NumericUpDown();
            this.label61 = new System.Windows.Forms.Label();
            this.statBoxA = new System.Windows.Forms.NumericUpDown();
            this.forcedAdvancesBox = new System.Windows.Forms.NumericUpDown();
            this.statBoxH = new System.Windows.Forms.NumericUpDown();
            this.label91 = new System.Windows.Forms.Label();
            this.checkStatS = new System.Windows.Forms.CheckBox();
            this.label87 = new System.Windows.Forms.Label();
            this.coolTimeBox = new System.Windows.Forms.NumericUpDown();
            this.checkStatD = new System.Windows.Forms.CheckBox();
            this.label88 = new System.Windows.Forms.Label();
            this.checkStatC = new System.Windows.Forms.CheckBox();
            this.checkStatB = new System.Windows.Forms.CheckBox();
            this.checkStatA = new System.Windows.Forms.CheckBox();
            this.checkStatH = new System.Windows.Forms.CheckBox();
            this.calcButton = new System.Windows.Forms.Button();
            this.fieldAdvanceErrorFramesBox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.framesBox = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.blinkErrorFramesBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.blinkFramesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forcedAdvancesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coolTimeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldAdvanceErrorFramesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.framesBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blinkErrorFramesBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 405;
            this.label3.Text = "待機";
            // 
            // blinkFramesBox
            // 
            this.blinkFramesBox.Location = new System.Drawing.Point(67, 18);
            this.blinkFramesBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.blinkFramesBox.Name = "blinkFramesBox";
            this.blinkFramesBox.ReadOnly = true;
            this.blinkFramesBox.Size = new System.Drawing.Size(68, 19);
            this.blinkFramesBox.TabIndex = 406;
            this.blinkFramesBox.TabStop = false;
            this.blinkFramesBox.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 12);
            this.label4.TabIndex = 407;
            this.label4.Text = "F";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 404;
            this.label2.Text = "±";
            // 
            // statBoxS
            // 
            this.statBoxS.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxS.Location = new System.Drawing.Point(86, 427);
            this.statBoxS.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxS.Name = "statBoxS";
            this.statBoxS.Size = new System.Drawing.Size(88, 22);
            this.statBoxS.TabIndex = 60;
            this.statBoxS.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxS.Validated += new System.EventHandler(this.OnValidated__StatBoxS);
            // 
            // currentSeedBox
            // 
            this.currentSeedBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentSeedBox.Location = new System.Drawing.Point(86, 17);
            this.currentSeedBox.MaxLength = 8;
            this.currentSeedBox.Name = "currentSeedBox";
            this.currentSeedBox.ReadOnly = true;
            this.currentSeedBox.Size = new System.Drawing.Size(100, 22);
            this.currentSeedBox.TabIndex = 401;
            this.currentSeedBox.TabStop = false;
            this.currentSeedBox.Text = "E6C6E208";
            this.currentSeedBox.ZeroPadding = false;
            // 
            // statBoxD
            // 
            this.statBoxD.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxD.Location = new System.Drawing.Point(86, 399);
            this.statBoxD.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxD.Name = "statBoxD";
            this.statBoxD.Size = new System.Drawing.Size(88, 22);
            this.statBoxD.TabIndex = 50;
            this.statBoxD.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxD.Validated += new System.EventHandler(this.OnValidated__StatBoxD);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 400;
            this.label1.Text = "現在のseed";
            // 
            // statBoxC
            // 
            this.statBoxC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxC.Location = new System.Drawing.Point(86, 371);
            this.statBoxC.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxC.Name = "statBoxC";
            this.statBoxC.Size = new System.Drawing.Size(88, 22);
            this.statBoxC.TabIndex = 40;
            this.statBoxC.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxC.Validated += new System.EventHandler(this.OnValidated__StatBoxC);
            // 
            // targetSeedBox
            // 
            this.targetSeedBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetSeedBox.Location = new System.Drawing.Point(86, 45);
            this.targetSeedBox.MaxLength = 8;
            this.targetSeedBox.Name = "targetSeedBox";
            this.targetSeedBox.ReadOnly = true;
            this.targetSeedBox.Size = new System.Drawing.Size(100, 22);
            this.targetSeedBox.TabIndex = 403;
            this.targetSeedBox.TabStop = false;
            this.targetSeedBox.Text = "B27AE396";
            this.targetSeedBox.ZeroPadding = false;
            // 
            // statBoxB
            // 
            this.statBoxB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxB.Location = new System.Drawing.Point(86, 343);
            this.statBoxB.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxB.Name = "statBoxB";
            this.statBoxB.Size = new System.Drawing.Size(88, 22);
            this.statBoxB.TabIndex = 30;
            this.statBoxB.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxB.Validated += new System.EventHandler(this.OnValidated__StatBoxB);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(17, 49);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(63, 12);
            this.label61.TabIndex = 402;
            this.label61.Text = "目標のseed";
            // 
            // statBoxA
            // 
            this.statBoxA.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxA.Location = new System.Drawing.Point(86, 315);
            this.statBoxA.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxA.Name = "statBoxA";
            this.statBoxA.Size = new System.Drawing.Size(88, 22);
            this.statBoxA.TabIndex = 20;
            this.statBoxA.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxA.Validated += new System.EventHandler(this.OnValidated__StatBoxA);
            // 
            // forcedAdvancesBox
            // 
            this.forcedAdvancesBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forcedAdvancesBox.Location = new System.Drawing.Point(86, 73);
            this.forcedAdvancesBox.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.forcedAdvancesBox.Name = "forcedAdvancesBox";
            this.forcedAdvancesBox.ReadOnly = true;
            this.forcedAdvancesBox.Size = new System.Drawing.Size(88, 22);
            this.forcedAdvancesBox.TabIndex = 100;
            this.forcedAdvancesBox.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            // 
            // statBoxH
            // 
            this.statBoxH.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxH.Location = new System.Drawing.Point(86, 287);
            this.statBoxH.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxH.Name = "statBoxH";
            this.statBoxH.Size = new System.Drawing.Size(88, 22);
            this.statBoxH.TabIndex = 10;
            this.statBoxH.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxH.Validated += new System.EventHandler(this.OnValidated__StatBoxH);
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(27, 76);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(53, 12);
            this.label91.TabIndex = 398;
            this.label91.Text = "強制消費";
            // 
            // checkStatS
            // 
            this.checkStatS.AutoSize = true;
            this.checkStatS.Location = new System.Drawing.Point(48, 429);
            this.checkStatS.Name = "checkStatS";
            this.checkStatS.Size = new System.Drawing.Size(31, 16);
            this.checkStatS.TabIndex = 381;
            this.checkStatS.TabStop = false;
            this.checkStatS.Text = "S";
            this.checkStatS.UseVisualStyleBackColor = true;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(30, 104);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(50, 12);
            this.label87.TabIndex = 395;
            this.label87.Text = "瞬き間隔";
            // 
            // coolTimeBox
            // 
            this.coolTimeBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coolTimeBox.Location = new System.Drawing.Point(86, 101);
            this.coolTimeBox.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.coolTimeBox.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.coolTimeBox.Name = "coolTimeBox";
            this.coolTimeBox.Size = new System.Drawing.Size(68, 22);
            this.coolTimeBox.TabIndex = 110;
            this.coolTimeBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.coolTimeBox.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            // 
            // checkStatD
            // 
            this.checkStatD.AutoSize = true;
            this.checkStatD.Location = new System.Drawing.Point(48, 401);
            this.checkStatD.Name = "checkStatD";
            this.checkStatD.Size = new System.Drawing.Size(32, 16);
            this.checkStatD.TabIndex = 380;
            this.checkStatD.TabStop = false;
            this.checkStatD.Text = "D";
            this.checkStatD.UseVisualStyleBackColor = true;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(160, 104);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(12, 12);
            this.label88.TabIndex = 397;
            this.label88.Text = "F";
            // 
            // checkStatC
            // 
            this.checkStatC.AutoSize = true;
            this.checkStatC.Location = new System.Drawing.Point(48, 373);
            this.checkStatC.Name = "checkStatC";
            this.checkStatC.Size = new System.Drawing.Size(32, 16);
            this.checkStatC.TabIndex = 379;
            this.checkStatC.TabStop = false;
            this.checkStatC.Text = "C";
            this.checkStatC.UseVisualStyleBackColor = true;
            // 
            // checkStatB
            // 
            this.checkStatB.AutoSize = true;
            this.checkStatB.Location = new System.Drawing.Point(48, 345);
            this.checkStatB.Name = "checkStatB";
            this.checkStatB.Size = new System.Drawing.Size(32, 16);
            this.checkStatB.TabIndex = 378;
            this.checkStatB.TabStop = false;
            this.checkStatB.Text = "B";
            this.checkStatB.UseVisualStyleBackColor = true;
            // 
            // checkStatA
            // 
            this.checkStatA.AutoSize = true;
            this.checkStatA.Location = new System.Drawing.Point(48, 317);
            this.checkStatA.Name = "checkStatA";
            this.checkStatA.Size = new System.Drawing.Size(32, 16);
            this.checkStatA.TabIndex = 377;
            this.checkStatA.TabStop = false;
            this.checkStatA.Text = "A";
            this.checkStatA.UseVisualStyleBackColor = true;
            // 
            // checkStatH
            // 
            this.checkStatH.AutoSize = true;
            this.checkStatH.Location = new System.Drawing.Point(48, 289);
            this.checkStatH.Name = "checkStatH";
            this.checkStatH.Size = new System.Drawing.Size(32, 16);
            this.checkStatH.TabIndex = 376;
            this.checkStatH.TabStop = false;
            this.checkStatH.Text = "H";
            this.checkStatH.UseVisualStyleBackColor = true;
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(86, 455);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(88, 28);
            this.calcButton.TabIndex = 70;
            this.calcButton.Text = "計算";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.Click__CalcButton);
            // 
            // fieldAdvanceErrorFramesBox
            // 
            this.fieldAdvanceErrorFramesBox.Location = new System.Drawing.Point(91, 43);
            this.fieldAdvanceErrorFramesBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.fieldAdvanceErrorFramesBox.Name = "fieldAdvanceErrorFramesBox";
            this.fieldAdvanceErrorFramesBox.Size = new System.Drawing.Size(44, 19);
            this.fieldAdvanceErrorFramesBox.TabIndex = 130;
            this.fieldAdvanceErrorFramesBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fieldAdvanceErrorFramesBox.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 419;
            this.label8.Text = "待機";
            // 
            // framesBox
            // 
            this.framesBox.Location = new System.Drawing.Point(67, 18);
            this.framesBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.framesBox.Name = "framesBox";
            this.framesBox.ReadOnly = true;
            this.framesBox.Size = new System.Drawing.Size(68, 19);
            this.framesBox.TabIndex = 420;
            this.framesBox.TabStop = false;
            this.framesBox.Value = new decimal(new int[] {
            345,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(141, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 12);
            this.label10.TabIndex = 421;
            this.label10.Text = "F";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 12);
            this.label9.TabIndex = 422;
            this.label9.Text = "F";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.blinkErrorFramesBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.blinkFramesBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(19, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 73);
            this.groupBox1.TabIndex = 423;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "瞬き";
            // 
            // blinkErrorFramesBox
            // 
            this.blinkErrorFramesBox.Location = new System.Drawing.Point(91, 43);
            this.blinkErrorFramesBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.blinkErrorFramesBox.Name = "blinkErrorFramesBox";
            this.blinkErrorFramesBox.Size = new System.Drawing.Size(44, 19);
            this.blinkErrorFramesBox.TabIndex = 120;
            this.blinkErrorFramesBox.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 12);
            this.label5.TabIndex = 425;
            this.label5.Text = "F";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 424;
            this.label6.Text = "±";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 419;
            this.label11.Text = "検索範囲";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.framesBox);
            this.groupBox2.Controls.Add(this.fieldAdvanceErrorFramesBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(19, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 73);
            this.groupBox2.TabIndex = 424;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "不定消費";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 420;
            this.label12.Text = "検索範囲";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(192, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(596, 466);
            this.dataGridView1.TabIndex = 425;
            // 
            // SearchFieldAdvanceGapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statBoxS);
            this.Controls.Add(this.currentSeedBox);
            this.Controls.Add(this.statBoxD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statBoxC);
            this.Controls.Add(this.targetSeedBox);
            this.Controls.Add(this.statBoxB);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.statBoxA);
            this.Controls.Add(this.forcedAdvancesBox);
            this.Controls.Add(this.statBoxH);
            this.Controls.Add(this.label91);
            this.Controls.Add(this.checkStatS);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.coolTimeBox);
            this.Controls.Add(this.checkStatD);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.checkStatC);
            this.Controls.Add(this.checkStatB);
            this.Controls.Add(this.checkStatA);
            this.Controls.Add(this.checkStatH);
            this.Controls.Add(this.calcButton);
            this.Name = "SearchFieldAdvanceGapsForm";
            this.Text = "SearchFieldAdvanceGapsForm";
            ((System.ComponentModel.ISupportInitialize)(this.blinkFramesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forcedAdvancesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coolTimeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldAdvanceErrorFramesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.framesBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blinkErrorFramesBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown blinkFramesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown statBoxS;
        private SeedBox currentSeedBox;
        private System.Windows.Forms.NumericUpDown statBoxD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown statBoxC;
        private SeedBox targetSeedBox;
        private System.Windows.Forms.NumericUpDown statBoxB;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.NumericUpDown statBoxA;
        private System.Windows.Forms.NumericUpDown forcedAdvancesBox;
        private System.Windows.Forms.NumericUpDown statBoxH;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.CheckBox checkStatS;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.NumericUpDown coolTimeBox;
        private System.Windows.Forms.CheckBox checkStatD;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.CheckBox checkStatC;
        private System.Windows.Forms.CheckBox checkStatB;
        private System.Windows.Forms.CheckBox checkStatA;
        private System.Windows.Forms.CheckBox checkStatH;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.NumericUpDown fieldAdvanceErrorFramesBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown framesBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown blinkErrorFramesBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}