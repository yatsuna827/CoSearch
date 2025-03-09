namespace COSearch
{
    partial class SearchGapsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.forcedAdvancesBox = new System.Windows.Forms.NumericUpDown();
            this.label91 = new System.Windows.Forms.Label();
            this.calcButton = new System.Windows.Forms.Button();
            this.maxFrameBox = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.targetSeedBox = new COSearch.SeedBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.currentSeedBox = new COSearch.SeedBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statBoxS = new System.Windows.Forms.NumericUpDown();
            this.statBoxD = new System.Windows.Forms.NumericUpDown();
            this.statBoxC = new System.Windows.Forms.NumericUpDown();
            this.statBoxB = new System.Windows.Forms.NumericUpDown();
            this.statBoxA = new System.Windows.Forms.NumericUpDown();
            this.statBoxH = new System.Windows.Forms.NumericUpDown();
            this.checkStatS = new System.Windows.Forms.CheckBox();
            this.checkStatD = new System.Windows.Forms.CheckBox();
            this.checkStatC = new System.Windows.Forms.CheckBox();
            this.checkStatB = new System.Windows.Forms.CheckBox();
            this.checkStatA = new System.Windows.Forms.CheckBox();
            this.checkStatH = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.forcedAdvancesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFrameBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxH)).BeginInit();
            this.SuspendLayout();
            // 
            // forcedAdvancesBox
            // 
            this.forcedAdvancesBox.Location = new System.Drawing.Point(84, 78);
            this.forcedAdvancesBox.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.forcedAdvancesBox.Name = "forcedAdvancesBox";
            this.forcedAdvancesBox.ReadOnly = true;
            this.forcedAdvancesBox.Size = new System.Drawing.Size(88, 19);
            this.forcedAdvancesBox.TabIndex = 358;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(25, 80);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(53, 12);
            this.label91.TabIndex = 357;
            this.label91.Text = "強制消費";
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(96, 296);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(75, 23);
            this.calcButton.TabIndex = 348;
            this.calcButton.Text = "計算";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.Click__CalcButton);
            // 
            // maxFrameBox
            // 
            this.maxFrameBox.Location = new System.Drawing.Point(104, 103);
            this.maxFrameBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxFrameBox.Name = "maxFrameBox";
            this.maxFrameBox.Size = new System.Drawing.Size(68, 19);
            this.maxFrameBox.TabIndex = 347;
            this.maxFrameBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxFrameBox.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 346;
            this.label9.Text = "検索範囲";
            // 
            // targetSeedBox
            // 
            this.targetSeedBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetSeedBox.Location = new System.Drawing.Point(84, 50);
            this.targetSeedBox.MaxLength = 8;
            this.targetSeedBox.Name = "targetSeedBox";
            this.targetSeedBox.ReadOnly = true;
            this.targetSeedBox.Size = new System.Drawing.Size(100, 22);
            this.targetSeedBox.TabIndex = 362;
            this.targetSeedBox.Text = "B27AE396";
            this.targetSeedBox.ZeroPadding = false;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(15, 54);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(63, 12);
            this.label61.TabIndex = 361;
            this.label61.Text = "目標のseed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 359;
            this.label1.Text = "現在のseed";
            // 
            // currentSeedBox
            // 
            this.currentSeedBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentSeedBox.Location = new System.Drawing.Point(84, 22);
            this.currentSeedBox.MaxLength = 8;
            this.currentSeedBox.Name = "currentSeedBox";
            this.currentSeedBox.ReadOnly = true;
            this.currentSeedBox.Size = new System.Drawing.Size(100, 22);
            this.currentSeedBox.TabIndex = 360;
            this.currentSeedBox.Text = "E6C6E208";
            this.currentSeedBox.ZeroPadding = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 363;
            this.label2.Text = "±";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(190, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(596, 304);
            this.dataGridView1.TabIndex = 426;
            // 
            // statBoxS
            // 
            this.statBoxS.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxS.Location = new System.Drawing.Point(83, 268);
            this.statBoxS.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxS.Name = "statBoxS";
            this.statBoxS.Size = new System.Drawing.Size(88, 22);
            this.statBoxS.TabIndex = 432;
            this.statBoxS.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxS.Validated += new System.EventHandler(this.OnValidated__StatBoxS);
            // 
            // statBoxD
            // 
            this.statBoxD.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxD.Location = new System.Drawing.Point(83, 240);
            this.statBoxD.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxD.Name = "statBoxD";
            this.statBoxD.Size = new System.Drawing.Size(88, 22);
            this.statBoxD.TabIndex = 431;
            this.statBoxD.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxD.Validated += new System.EventHandler(this.OnValidated__StatBoxD);
            // 
            // statBoxC
            // 
            this.statBoxC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxC.Location = new System.Drawing.Point(83, 212);
            this.statBoxC.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxC.Name = "statBoxC";
            this.statBoxC.Size = new System.Drawing.Size(88, 22);
            this.statBoxC.TabIndex = 430;
            this.statBoxC.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxC.Validated += new System.EventHandler(this.OnValidated__StatBoxC);
            // 
            // statBoxB
            // 
            this.statBoxB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxB.Location = new System.Drawing.Point(83, 184);
            this.statBoxB.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxB.Name = "statBoxB";
            this.statBoxB.Size = new System.Drawing.Size(88, 22);
            this.statBoxB.TabIndex = 429;
            this.statBoxB.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxB.Validated += new System.EventHandler(this.OnValidated__StatBoxB);
            // 
            // statBoxA
            // 
            this.statBoxA.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxA.Location = new System.Drawing.Point(83, 156);
            this.statBoxA.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxA.Name = "statBoxA";
            this.statBoxA.Size = new System.Drawing.Size(88, 22);
            this.statBoxA.TabIndex = 428;
            this.statBoxA.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxA.Validated += new System.EventHandler(this.OnValidated__StatBoxA);
            // 
            // statBoxH
            // 
            this.statBoxH.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statBoxH.Location = new System.Drawing.Point(83, 128);
            this.statBoxH.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.statBoxH.Name = "statBoxH";
            this.statBoxH.Size = new System.Drawing.Size(88, 22);
            this.statBoxH.TabIndex = 427;
            this.statBoxH.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            this.statBoxH.Validated += new System.EventHandler(this.OnValidated__StatBoxH);
            // 
            // checkStatS
            // 
            this.checkStatS.AutoSize = true;
            this.checkStatS.Location = new System.Drawing.Point(45, 270);
            this.checkStatS.Name = "checkStatS";
            this.checkStatS.Size = new System.Drawing.Size(31, 16);
            this.checkStatS.TabIndex = 438;
            this.checkStatS.TabStop = false;
            this.checkStatS.Text = "S";
            this.checkStatS.UseVisualStyleBackColor = true;
            // 
            // checkStatD
            // 
            this.checkStatD.AutoSize = true;
            this.checkStatD.Location = new System.Drawing.Point(45, 242);
            this.checkStatD.Name = "checkStatD";
            this.checkStatD.Size = new System.Drawing.Size(32, 16);
            this.checkStatD.TabIndex = 437;
            this.checkStatD.TabStop = false;
            this.checkStatD.Text = "D";
            this.checkStatD.UseVisualStyleBackColor = true;
            // 
            // checkStatC
            // 
            this.checkStatC.AutoSize = true;
            this.checkStatC.Location = new System.Drawing.Point(45, 214);
            this.checkStatC.Name = "checkStatC";
            this.checkStatC.Size = new System.Drawing.Size(32, 16);
            this.checkStatC.TabIndex = 436;
            this.checkStatC.TabStop = false;
            this.checkStatC.Text = "C";
            this.checkStatC.UseVisualStyleBackColor = true;
            // 
            // checkStatB
            // 
            this.checkStatB.AutoSize = true;
            this.checkStatB.Location = new System.Drawing.Point(45, 186);
            this.checkStatB.Name = "checkStatB";
            this.checkStatB.Size = new System.Drawing.Size(32, 16);
            this.checkStatB.TabIndex = 435;
            this.checkStatB.TabStop = false;
            this.checkStatB.Text = "B";
            this.checkStatB.UseVisualStyleBackColor = true;
            // 
            // checkStatA
            // 
            this.checkStatA.AutoSize = true;
            this.checkStatA.Location = new System.Drawing.Point(45, 158);
            this.checkStatA.Name = "checkStatA";
            this.checkStatA.Size = new System.Drawing.Size(32, 16);
            this.checkStatA.TabIndex = 434;
            this.checkStatA.TabStop = false;
            this.checkStatA.Text = "A";
            this.checkStatA.UseVisualStyleBackColor = true;
            // 
            // checkStatH
            // 
            this.checkStatH.AutoSize = true;
            this.checkStatH.Location = new System.Drawing.Point(45, 130);
            this.checkStatH.Name = "checkStatH";
            this.checkStatH.Size = new System.Drawing.Size(32, 16);
            this.checkStatH.TabIndex = 433;
            this.checkStatH.TabStop = false;
            this.checkStatH.Text = "H";
            this.checkStatH.UseVisualStyleBackColor = true;
            // 
            // SearchGapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 328);
            this.Controls.Add(this.statBoxS);
            this.Controls.Add(this.statBoxD);
            this.Controls.Add(this.statBoxC);
            this.Controls.Add(this.statBoxB);
            this.Controls.Add(this.statBoxA);
            this.Controls.Add(this.statBoxH);
            this.Controls.Add(this.checkStatS);
            this.Controls.Add(this.checkStatD);
            this.Controls.Add(this.checkStatC);
            this.Controls.Add(this.checkStatB);
            this.Controls.Add(this.checkStatA);
            this.Controls.Add(this.checkStatH);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentSeedBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetSeedBox);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.forcedAdvancesBox);
            this.Controls.Add(this.label91);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.maxFrameBox);
            this.Controls.Add(this.label9);
            this.Name = "SearchGapsForm";
            this.Text = "SearchGapsForm";
            ((System.ComponentModel.ISupportInitialize)(this.forcedAdvancesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFrameBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statBoxH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown forcedAdvancesBox;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.NumericUpDown maxFrameBox;
        private System.Windows.Forms.Label label9;
        private SeedBox targetSeedBox;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label1;
        private SeedBox currentSeedBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown statBoxS;
        private System.Windows.Forms.NumericUpDown statBoxD;
        private System.Windows.Forms.NumericUpDown statBoxC;
        private System.Windows.Forms.NumericUpDown statBoxB;
        private System.Windows.Forms.NumericUpDown statBoxA;
        private System.Windows.Forms.NumericUpDown statBoxH;
        private System.Windows.Forms.CheckBox checkStatS;
        private System.Windows.Forms.CheckBox checkStatD;
        private System.Windows.Forms.CheckBox checkStatC;
        private System.Windows.Forms.CheckBox checkStatB;
        private System.Windows.Forms.CheckBox checkStatA;
        private System.Windows.Forms.CheckBox checkStatH;
    }
}