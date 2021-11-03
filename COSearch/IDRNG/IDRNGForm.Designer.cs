namespace COSearch.IDRNG
{
    partial class IDRNGForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.enterCriteriaPage = new System.Windows.Forms.TabPage();
            this.criteriaPage = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcFramePage = new System.Windows.Forms.TabPage();
            this.maxIndexBox2 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.maxIndexBox1 = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcAdvancePage = new System.Windows.Forms.TabPage();
            this.calcGapPage = new System.Windows.Forms.TabPage();
            this.seedBox1 = new COSearch.SeedBox();
            this.tabControl1.SuspendLayout();
            this.criteriaPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.calcFramePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxIndexBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxIndexBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.enterCriteriaPage);
            this.tabControl1.Controls.Add(this.criteriaPage);
            this.tabControl1.Controls.Add(this.calcFramePage);
            this.tabControl1.Controls.Add(this.calcAdvancePage);
            this.tabControl1.Controls.Add(this.calcGapPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 721);
            this.tabControl1.TabIndex = 0;
            // 
            // enterCriteriaPage
            // 
            this.enterCriteriaPage.Location = new System.Drawing.Point(4, 22);
            this.enterCriteriaPage.Name = "enterCriteriaPage";
            this.enterCriteriaPage.Padding = new System.Windows.Forms.Padding(3);
            this.enterCriteriaPage.Size = new System.Drawing.Size(774, 695);
            this.enterCriteriaPage.TabIndex = 0;
            this.enterCriteriaPage.Text = "条件指定";
            this.enterCriteriaPage.UseVisualStyleBackColor = true;
            // 
            // criteriaPage
            // 
            this.criteriaPage.Controls.Add(this.dataGridView2);
            this.criteriaPage.Location = new System.Drawing.Point(4, 22);
            this.criteriaPage.Name = "criteriaPage";
            this.criteriaPage.Size = new System.Drawing.Size(774, 695);
            this.criteriaPage.TabIndex = 4;
            this.criteriaPage.Text = "条件一覧";
            this.criteriaPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16});
            this.dataGridView2.Location = new System.Drawing.Point(31, 41);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(725, 201);
            this.dataGridView2.TabIndex = 0;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ID条件";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "性格";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "個体値";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "めざパタイプ";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "めざパ威力";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "性格";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "個体値";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "めざパタイプ";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "めざパ威力";
            this.Column16.Name = "Column16";
            // 
            // calcFramePage
            // 
            this.calcFramePage.Controls.Add(this.maxIndexBox2);
            this.calcFramePage.Controls.Add(this.checkBox1);
            this.calcFramePage.Controls.Add(this.button1);
            this.calcFramePage.Controls.Add(this.maxIndexBox1);
            this.calcFramePage.Controls.Add(this.dataGridView1);
            this.calcFramePage.Controls.Add(this.seedBox1);
            this.calcFramePage.Location = new System.Drawing.Point(4, 22);
            this.calcFramePage.Name = "calcFramePage";
            this.calcFramePage.Padding = new System.Windows.Forms.Padding(3);
            this.calcFramePage.Size = new System.Drawing.Size(774, 695);
            this.calcFramePage.TabIndex = 1;
            this.calcFramePage.Text = "seed検索";
            this.calcFramePage.UseVisualStyleBackColor = true;
            // 
            // maxIndexBox2
            // 
            this.maxIndexBox2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxIndexBox2.Location = new System.Drawing.Point(6, 62);
            this.maxIndexBox2.Name = "maxIndexBox2";
            this.maxIndexBox2.Size = new System.Drawing.Size(100, 22);
            this.maxIndexBox2.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 119);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "自動検索";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "検索";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // maxIndexBox1
            // 
            this.maxIndexBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxIndexBox1.Location = new System.Drawing.Point(6, 34);
            this.maxIndexBox1.Name = "maxIndexBox1";
            this.maxIndexBox1.Size = new System.Drawing.Size(100, 22);
            this.maxIndexBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column7,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(112, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(610, 327);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "seed";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "フレーム";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "消費数";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "TID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "SID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "性格";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "性格";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // calcAdvancePage
            // 
            this.calcAdvancePage.Location = new System.Drawing.Point(4, 22);
            this.calcAdvancePage.Name = "calcAdvancePage";
            this.calcAdvancePage.Size = new System.Drawing.Size(774, 695);
            this.calcAdvancePage.TabIndex = 3;
            this.calcAdvancePage.Text = "消費数調整";
            this.calcAdvancePage.UseVisualStyleBackColor = true;
            // 
            // calcGapPage
            // 
            this.calcGapPage.Location = new System.Drawing.Point(4, 22);
            this.calcGapPage.Name = "calcGapPage";
            this.calcGapPage.Size = new System.Drawing.Size(774, 695);
            this.calcGapPage.TabIndex = 2;
            this.calcGapPage.Text = "ズレ調整";
            this.calcGapPage.UseVisualStyleBackColor = true;
            // 
            // seedBox1
            // 
            this.seedBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedBox1.Location = new System.Drawing.Point(6, 6);
            this.seedBox1.MaxLength = 8;
            this.seedBox1.Name = "seedBox1";
            this.seedBox1.Size = new System.Drawing.Size(100, 22);
            this.seedBox1.TabIndex = 0;
            this.seedBox1.Text = "0";
            this.seedBox1.ZeroPadding = false;
            // 
            // IDRNGForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 745);
            this.Controls.Add(this.tabControl1);
            this.Name = "IDRNGForm";
            this.Text = "IDRNGForm";
            this.tabControl1.ResumeLayout(false);
            this.criteriaPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.calcFramePage.ResumeLayout(false);
            this.calcFramePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxIndexBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxIndexBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage enterCriteriaPage;
        private System.Windows.Forms.TabPage calcFramePage;
        private System.Windows.Forms.TabPage calcAdvancePage;
        private System.Windows.Forms.TabPage calcGapPage;
        private System.Windows.Forms.NumericUpDown maxIndexBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SeedBox seedBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown maxIndexBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TabPage criteriaPage;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
    }
}