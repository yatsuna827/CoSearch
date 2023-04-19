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
            this.seedBox1 = new COSearch.SeedBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.blankDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
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
            // seedBox1
            // 
            this.seedBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedBox1.Location = new System.Drawing.Point(125, 12);
            this.seedBox1.MaxLength = 8;
            this.seedBox1.Name = "seedBox1";
            this.seedBox1.Size = new System.Drawing.Size(100, 22);
            this.seedBox1.TabIndex = 53;
            this.seedBox1.Text = "0";
            this.seedBox1.ZeroPadding = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 112);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(354, 216);
            this.textBox1.TabIndex = 54;
            // 
            // BlinkWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 340);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.seedBox1);
            this.Controls.Add(this.blankDGV);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "BlinkWatcher";
            this.Text = "BlinkWatcher";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BlinkWatcher_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.blankDGV)).EndInit();
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
    }
}