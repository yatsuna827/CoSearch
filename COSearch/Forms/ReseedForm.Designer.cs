namespace COSearch.Forms
{
    partial class ReseedForm
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
            this.currentSeedBox = new COSearch.SeedBox();
            this.newSeedBox = new COSearch.SeedBox();
            this.label2 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentSeedBox
            // 
            this.currentSeedBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentSeedBox.Location = new System.Drawing.Point(12, 12);
            this.currentSeedBox.MaxLength = 8;
            this.currentSeedBox.Name = "currentSeedBox";
            this.currentSeedBox.ReadOnly = true;
            this.currentSeedBox.Size = new System.Drawing.Size(100, 22);
            this.currentSeedBox.TabIndex = 26;
            this.currentSeedBox.Text = "E6C6E208";
            this.currentSeedBox.ZeroPadding = false;
            // 
            // newSeedBox
            // 
            this.newSeedBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newSeedBox.Location = new System.Drawing.Point(141, 12);
            this.newSeedBox.MaxLength = 8;
            this.newSeedBox.Name = "newSeedBox";
            this.newSeedBox.Size = new System.Drawing.Size(100, 22);
            this.newSeedBox.TabIndex = 27;
            this.newSeedBox.Text = "E6C6E208";
            this.newSeedBox.ZeroPadding = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 67;
            this.label2.Text = "→";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(141, 40);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 35);
            this.okButton.TabIndex = 68;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OnClick__OkButton);
            // 
            // ReseedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 87);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newSeedBox);
            this.Controls.Add(this.currentSeedBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReseedForm";
            this.ShowIcon = false;
            this.Text = "基準seedの更新";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SeedBox currentSeedBox;
        private SeedBox newSeedBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okButton;
    }
}