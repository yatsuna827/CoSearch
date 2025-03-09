namespace COSearch
{
    partial class BlinkWatcher
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
            this.button1 = new System.Windows.Forms.Button();
            this.blankDGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown21 = new System.Windows.Forms.NumericUpDown();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.errorRangeBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.seedBox2 = new COSearch.SeedBox();
            this.seedBox1 = new COSearch.SeedBox();
            ((System.ComponentModel.ISupportInitialize)(this.blankDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRangeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "観測開始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // blankDGV
            // 
            this.blankDGV.AllowUserToAddRows = false;
            this.blankDGV.AllowUserToDeleteRows = false;
            this.blankDGV.AllowUserToResizeColumns = false;
            this.blankDGV.AllowUserToResizeRows = false;
            this.blankDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blankDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.blankDGV.Location = new System.Drawing.Point(10, 11);
            this.blankDGV.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.blankDGV.Name = "blankDGV";
            this.blankDGV.ReadOnly = true;
            this.blankDGV.RowHeadersVisible = false;
            this.blankDGV.RowHeadersWidth = 82;
            this.blankDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.blankDGV.RowTemplate.Height = 20;
            this.blankDGV.Size = new System.Drawing.Size(111, 317);
            this.blankDGV.TabIndex = 52;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column1.Width = 24;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Blank";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column2.Width = 64;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 194);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(354, 134);
            this.textBox1.TabIndex = 54;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(379, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 56;
            this.button2.Text = "タイマー";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(395, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 26);
            this.button3.TabIndex = 57;
            this.button3.Text = "テスト用";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 58;
            this.label1.Text = "基準";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 59;
            this.label2.Text = "目標";
            // 
            // numericUpDown21
            // 
            this.numericUpDown21.Location = new System.Drawing.Point(379, 97);
            this.numericUpDown21.Name = "numericUpDown21";
            this.numericUpDown21.Size = new System.Drawing.Size(54, 19);
            this.numericUpDown21.TabIndex = 60;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(441, 97);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(12, 12);
            this.label67.TabIndex = 61;
            this.label67.Text = "F";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(320, 99);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(53, 12);
            this.label66.TabIndex = 62;
            this.label66.Text = "制動時間";
            // 
            // errorRangeBox
            // 
            this.errorRangeBox.Location = new System.Drawing.Point(175, 97);
            this.errorRangeBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.errorRangeBox.Name = "errorRangeBox";
            this.errorRangeBox.Size = new System.Drawing.Size(54, 19);
            this.errorRangeBox.TabIndex = 63;
            this.errorRangeBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 12);
            this.label3.TabIndex = 64;
            this.label3.Text = "F";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 65;
            this.label4.Text = "誤差";
            // 
            // seedBox2
            // 
            this.seedBox2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedBox2.Location = new System.Drawing.Point(379, 12);
            this.seedBox2.MaxLength = 8;
            this.seedBox2.Name = "seedBox2";
            this.seedBox2.Size = new System.Drawing.Size(100, 22);
            this.seedBox2.TabIndex = 55;
            this.seedBox2.Text = "0";
            this.seedBox2.ZeroPadding = false;
            // 
            // seedBox1
            // 
            this.seedBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedBox1.Location = new System.Drawing.Point(175, 12);
            this.seedBox1.MaxLength = 8;
            this.seedBox1.Name = "seedBox1";
            this.seedBox1.Size = new System.Drawing.Size(100, 22);
            this.seedBox1.TabIndex = 53;
            this.seedBox1.Text = "F85B6830";
            this.seedBox1.ZeroPadding = false;
            // 
            // BlinkWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 340);
            this.Controls.Add(this.errorRangeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown21);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.seedBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.seedBox1);
            this.Controls.Add(this.blankDGV);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "BlinkWatcher";
            this.Text = "BlinkWatcher";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BlinkWatcher_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.blankDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRangeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView blankDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private SeedBox seedBox1;
        private System.Windows.Forms.TextBox textBox1;
        private SeedBox seedBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown21;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.NumericUpDown errorRangeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}