namespace COSearch
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_FindTarget = new System.Windows.Forms.TabPage();
            this.tabControl_p2 = new System.Windows.Forms.TabControl();
            this.tabPage_FindTarget_FromNearby = new System.Windows.Forms.TabPage();
            this.findTargetFromNearbyCriteriaArea = new COSearch.FindTargetCriteriaArea();
            this.CalcButton_FindTarget_FromNearBy = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.maxAdvances_FindTarget_FromNearBy = new System.Windows.Forms.NumericUpDown();
            this.minAdvances_FindTarget_FromNearBy = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.currentSeedBox_FindTarget_FromNearby = new COSearch.SeedBox();
            this.tabPage_FindTarget_FromSeed = new System.Windows.Forms.TabPage();
            this.findTargetFromSeedCriteriaArea = new COSearch.FindTargetCriteriaArea();
            this.checkDeduplication = new System.Windows.Forms.CheckBox();
            this.calcButton_FindTarget_FromSeed = new System.Windows.Forms.Button();
            this.tabPage_ListUp = new System.Windows.Forms.TabPage();
            this.label87 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label88 = new System.Windows.Forms.Label();
            this.advanceModeBox_ListUp = new System.Windows.Forms.ComboBox();
            this.calcButton_ListUp = new System.Windows.Forms.Button();
            this.maxFrameBox_ListUp = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.currentSeedBox_ListUp = new COSearch.SeedBox();
            this.forcedAdvancesBox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.darkPokemonBox = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SIDBox = new System.Windows.Forms.NumericUpDown();
            this.TIDBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkAfterEnding = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starterRNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage_FindTarget.SuspendLayout();
            this.tabControl_p2.SuspendLayout();
            this.tabPage_FindTarget_FromNearby.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxAdvances_FindTarget_FromNearBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minAdvances_FindTarget_FromNearBy)).BeginInit();
            this.tabPage_FindTarget_FromSeed.SuspendLayout();
            this.tabPage_ListUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFrameBox_ListUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forcedAdvancesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SIDBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIDBox)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_FindTarget);
            this.tabControl1.Controls.Add(this.tabPage_ListUp);
            this.tabControl1.Location = new System.Drawing.Point(16, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 488);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // tabPage_FindTarget
            // 
            this.tabPage_FindTarget.Controls.Add(this.tabControl_p2);
            this.tabPage_FindTarget.Location = new System.Drawing.Point(4, 22);
            this.tabPage_FindTarget.Name = "tabPage_FindTarget";
            this.tabPage_FindTarget.Size = new System.Drawing.Size(768, 462);
            this.tabPage_FindTarget.TabIndex = 6;
            this.tabPage_FindTarget.Text = "目標個体を探す";
            this.tabPage_FindTarget.UseVisualStyleBackColor = true;
            // 
            // tabControl_p2
            // 
            this.tabControl_p2.Controls.Add(this.tabPage_FindTarget_FromNearby);
            this.tabControl_p2.Controls.Add(this.tabPage_FindTarget_FromSeed);
            this.tabControl_p2.Location = new System.Drawing.Point(16, 15);
            this.tabControl_p2.Name = "tabControl_p2";
            this.tabControl_p2.SelectedIndex = 0;
            this.tabControl_p2.Size = new System.Drawing.Size(737, 428);
            this.tabControl_p2.TabIndex = 354;
            // 
            // tabPage_FindTarget_FromNearby
            // 
            this.tabPage_FindTarget_FromNearby.Controls.Add(this.findTargetFromNearbyCriteriaArea);
            this.tabPage_FindTarget_FromNearby.Controls.Add(this.CalcButton_FindTarget_FromNearBy);
            this.tabPage_FindTarget_FromNearby.Controls.Add(this.label5);
            this.tabPage_FindTarget_FromNearby.Controls.Add(this.maxAdvances_FindTarget_FromNearBy);
            this.tabPage_FindTarget_FromNearby.Controls.Add(this.minAdvances_FindTarget_FromNearBy);
            this.tabPage_FindTarget_FromNearby.Controls.Add(this.label4);
            this.tabPage_FindTarget_FromNearby.Controls.Add(this.label11);
            this.tabPage_FindTarget_FromNearby.Controls.Add(this.currentSeedBox_FindTarget_FromNearby);
            this.tabPage_FindTarget_FromNearby.Location = new System.Drawing.Point(4, 22);
            this.tabPage_FindTarget_FromNearby.Name = "tabPage_FindTarget_FromNearby";
            this.tabPage_FindTarget_FromNearby.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FindTarget_FromNearby.Size = new System.Drawing.Size(729, 402);
            this.tabPage_FindTarget_FromNearby.TabIndex = 0;
            this.tabPage_FindTarget_FromNearby.Text = "現在位置付近から探す";
            this.tabPage_FindTarget_FromNearby.UseVisualStyleBackColor = true;
            // 
            // findTargetFromNearbyCriteriaArea
            // 
            this.findTargetFromNearbyCriteriaArea.Location = new System.Drawing.Point(25, 72);
            this.findTargetFromNearbyCriteriaArea.Name = "findTargetFromNearbyCriteriaArea";
            this.findTargetFromNearbyCriteriaArea.Size = new System.Drawing.Size(480, 195);
            this.findTargetFromNearbyCriteriaArea.TabIndex = 355;
            // 
            // CalcButton_FindTarget_FromNearBy
            // 
            this.CalcButton_FindTarget_FromNearBy.Location = new System.Drawing.Point(430, 273);
            this.CalcButton_FindTarget_FromNearBy.Name = "CalcButton_FindTarget_FromNearBy";
            this.CalcButton_FindTarget_FromNearBy.Size = new System.Drawing.Size(75, 23);
            this.CalcButton_FindTarget_FromNearBy.TabIndex = 357;
            this.CalcButton_FindTarget_FromNearBy.Text = "計算";
            this.CalcButton_FindTarget_FromNearBy.UseVisualStyleBackColor = true;
            this.CalcButton_FindTarget_FromNearBy.Click += new System.EventHandler(this.Click__CalcButton_FindTarget_FromNearBy);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 356;
            this.label5.Text = "～";
            // 
            // maxAdvances_FindTarget_FromNearBy
            // 
            this.maxAdvances_FindTarget_FromNearBy.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxAdvances_FindTarget_FromNearBy.Location = new System.Drawing.Point(208, 44);
            this.maxAdvances_FindTarget_FromNearBy.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.maxAdvances_FindTarget_FromNearBy.Name = "maxAdvances_FindTarget_FromNearBy";
            this.maxAdvances_FindTarget_FromNearBy.Size = new System.Drawing.Size(100, 22);
            this.maxAdvances_FindTarget_FromNearBy.TabIndex = 355;
            this.maxAdvances_FindTarget_FromNearBy.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // minAdvances_FindTarget_FromNearBy
            // 
            this.minAdvances_FindTarget_FromNearBy.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minAdvances_FindTarget_FromNearBy.Location = new System.Drawing.Point(82, 44);
            this.minAdvances_FindTarget_FromNearBy.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.minAdvances_FindTarget_FromNearBy.Name = "minAdvances_FindTarget_FromNearBy";
            this.minAdvances_FindTarget_FromNearBy.Size = new System.Drawing.Size(100, 22);
            this.minAdvances_FindTarget_FromNearBy.TabIndex = 350;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 12);
            this.label4.TabIndex = 340;
            this.label4.Text = "現在のseed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 349;
            this.label11.Text = "検索範囲";
            // 
            // currentSeedBox_FindTarget_FromNearby
            // 
            this.currentSeedBox_FindTarget_FromNearby.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentSeedBox_FindTarget_FromNearby.Location = new System.Drawing.Point(82, 16);
            this.currentSeedBox_FindTarget_FromNearby.MaxLength = 8;
            this.currentSeedBox_FindTarget_FromNearby.Name = "currentSeedBox_FindTarget_FromNearby";
            this.currentSeedBox_FindTarget_FromNearby.Size = new System.Drawing.Size(100, 22);
            this.currentSeedBox_FindTarget_FromNearby.TabIndex = 341;
            this.currentSeedBox_FindTarget_FromNearby.Text = "3ED5720F";
            this.currentSeedBox_FindTarget_FromNearby.ZeroPadding = false;
            // 
            // tabPage_FindTarget_FromSeed
            // 
            this.tabPage_FindTarget_FromSeed.Controls.Add(this.findTargetFromSeedCriteriaArea);
            this.tabPage_FindTarget_FromSeed.Controls.Add(this.checkDeduplication);
            this.tabPage_FindTarget_FromSeed.Controls.Add(this.calcButton_FindTarget_FromSeed);
            this.tabPage_FindTarget_FromSeed.Location = new System.Drawing.Point(4, 22);
            this.tabPage_FindTarget_FromSeed.Name = "tabPage_FindTarget_FromSeed";
            this.tabPage_FindTarget_FromSeed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FindTarget_FromSeed.Size = new System.Drawing.Size(729, 402);
            this.tabPage_FindTarget_FromSeed.TabIndex = 1;
            this.tabPage_FindTarget_FromSeed.Text = "目標seedから探す";
            this.tabPage_FindTarget_FromSeed.UseVisualStyleBackColor = true;
            // 
            // findTargetFromSeedCriteriaArea
            // 
            this.findTargetFromSeedCriteriaArea.Location = new System.Drawing.Point(15, 54);
            this.findTargetFromSeedCriteriaArea.Name = "findTargetFromSeedCriteriaArea";
            this.findTargetFromSeedCriteriaArea.Size = new System.Drawing.Size(480, 195);
            this.findTargetFromSeedCriteriaArea.TabIndex = 356;
            // 
            // checkDeduplication
            // 
            this.checkDeduplication.AutoSize = true;
            this.checkDeduplication.Checked = true;
            this.checkDeduplication.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDeduplication.Location = new System.Drawing.Point(16, 20);
            this.checkDeduplication.Name = "checkDeduplication";
            this.checkDeduplication.Size = new System.Drawing.Size(117, 16);
            this.checkDeduplication.TabIndex = 32;
            this.checkDeduplication.Text = "同一個体をまとめる";
            this.checkDeduplication.UseVisualStyleBackColor = true;
            // 
            // calcButton_FindTarget_FromSeed
            // 
            this.calcButton_FindTarget_FromSeed.Location = new System.Drawing.Point(420, 255);
            this.calcButton_FindTarget_FromSeed.Name = "calcButton_FindTarget_FromSeed";
            this.calcButton_FindTarget_FromSeed.Size = new System.Drawing.Size(75, 23);
            this.calcButton_FindTarget_FromSeed.TabIndex = 28;
            this.calcButton_FindTarget_FromSeed.Text = "計算";
            this.calcButton_FindTarget_FromSeed.UseVisualStyleBackColor = true;
            this.calcButton_FindTarget_FromSeed.Click += new System.EventHandler(this.Click__CalcButton_FindTarget_FromSeed);
            // 
            // tabPage_ListUp
            // 
            this.tabPage_ListUp.Controls.Add(this.label87);
            this.tabPage_ListUp.Controls.Add(this.numericUpDown2);
            this.tabPage_ListUp.Controls.Add(this.label88);
            this.tabPage_ListUp.Controls.Add(this.advanceModeBox_ListUp);
            this.tabPage_ListUp.Controls.Add(this.calcButton_ListUp);
            this.tabPage_ListUp.Controls.Add(this.maxFrameBox_ListUp);
            this.tabPage_ListUp.Controls.Add(this.label9);
            this.tabPage_ListUp.Controls.Add(this.label10);
            this.tabPage_ListUp.Controls.Add(this.currentSeedBox_ListUp);
            this.tabPage_ListUp.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ListUp.Name = "tabPage_ListUp";
            this.tabPage_ListUp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ListUp.Size = new System.Drawing.Size(768, 462);
            this.tabPage_ListUp.TabIndex = 1;
            this.tabPage_ListUp.Text = "リスト表示";
            this.tabPage_ListUp.UseVisualStyleBackColor = true;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(58, 70);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(26, 12);
            this.label87.TabIndex = 340;
            this.label87.Text = "瞬き";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(90, 68);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(68, 19);
            this.numericUpDown2.TabIndex = 341;
            this.numericUpDown2.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(164, 70);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(12, 12);
            this.label88.TabIndex = 342;
            this.label88.Text = "F";
            // 
            // advanceModeBox_ListUp
            // 
            this.advanceModeBox_ListUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.advanceModeBox_ListUp.FormattingEnabled = true;
            this.advanceModeBox_ListUp.Items.AddRange(new object[] {
            "通常",
            "パイラタウン",
            "パイラの洞窟",
            "ダークポケモン研究所B2F",
            "ダークポケモン研究所B3F",
            "町外れのスタンド",
            "連続戦闘(敵の瞬きあり)",
            "連続戦闘(敵の瞬きなし)"});
            this.advanceModeBox_ListUp.Location = new System.Drawing.Point(41, 41);
            this.advanceModeBox_ListUp.Name = "advanceModeBox_ListUp";
            this.advanceModeBox_ListUp.Size = new System.Drawing.Size(149, 20);
            this.advanceModeBox_ListUp.TabIndex = 23;
            this.ToolTip.SetToolTip(this.advanceModeBox_ListUp, "seedリストの計算方法を指定します");
            this.advanceModeBox_ListUp.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged__AdvanceModeBox_ListUp);
            // 
            // calcButton_ListUp
            // 
            this.calcButton_ListUp.Location = new System.Drawing.Point(115, 121);
            this.calcButton_ListUp.Name = "calcButton_ListUp";
            this.calcButton_ListUp.Size = new System.Drawing.Size(75, 23);
            this.calcButton_ListUp.TabIndex = 18;
            this.calcButton_ListUp.Text = "計算";
            this.calcButton_ListUp.UseVisualStyleBackColor = true;
            this.calcButton_ListUp.Click += new System.EventHandler(this.Click__CalcButton_ListUp);
            // 
            // maxFrameBox_ListUp
            // 
            this.maxFrameBox_ListUp.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxFrameBox_ListUp.Location = new System.Drawing.Point(90, 93);
            this.maxFrameBox_ListUp.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.maxFrameBox_ListUp.Name = "maxFrameBox_ListUp";
            this.maxFrameBox_ListUp.Size = new System.Drawing.Size(100, 22);
            this.maxFrameBox_ListUp.TabIndex = 14;
            this.maxFrameBox_ListUp.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxFrameBox_ListUp.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "表示件数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "現在のseed";
            // 
            // currentSeedBox_ListUp
            // 
            this.currentSeedBox_ListUp.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentSeedBox_ListUp.Location = new System.Drawing.Point(90, 13);
            this.currentSeedBox_ListUp.MaxLength = 8;
            this.currentSeedBox_ListUp.Name = "currentSeedBox_ListUp";
            this.currentSeedBox_ListUp.Size = new System.Drawing.Size(100, 22);
            this.currentSeedBox_ListUp.TabIndex = 339;
            this.currentSeedBox_ListUp.Text = "3ED5720F";
            this.currentSeedBox_ListUp.ZeroPadding = false;
            // 
            // forcedAdvancesBox
            // 
            this.forcedAdvancesBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forcedAdvancesBox.Location = new System.Drawing.Point(171, 53);
            this.forcedAdvancesBox.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.forcedAdvancesBox.Name = "forcedAdvancesBox";
            this.forcedAdvancesBox.Size = new System.Drawing.Size(88, 22);
            this.forcedAdvancesBox.TabIndex = 352;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 351;
            this.label8.Text = "強制消費";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 12);
            this.label7.TabIndex = 345;
            this.label7.Text = "ポケモン";
            // 
            // darkPokemonBox
            // 
            this.darkPokemonBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.darkPokemonBox.FormattingEnabled = true;
            this.darkPokemonBox.Location = new System.Drawing.Point(16, 53);
            this.darkPokemonBox.Name = "darkPokemonBox";
            this.darkPokemonBox.Size = new System.Drawing.Size(149, 20);
            this.darkPokemonBox.TabIndex = 343;
            this.darkPokemonBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged__DarkPokemonBox);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(200, 21);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(23, 12);
            this.label28.TabIndex = 332;
            this.label28.Text = "SID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 331;
            this.label2.Text = "TID";
            // 
            // SIDBox
            // 
            this.SIDBox.Location = new System.Drawing.Point(226, 19);
            this.SIDBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SIDBox.Name = "SIDBox";
            this.SIDBox.Size = new System.Drawing.Size(56, 19);
            this.SIDBox.TabIndex = 100001;
            this.SIDBox.Value = new decimal(new int[] {
            19547,
            0,
            0,
            0});
            this.SIDBox.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            // 
            // TIDBox
            // 
            this.TIDBox.Location = new System.Drawing.Point(138, 19);
            this.TIDBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.TIDBox.Name = "TIDBox";
            this.TIDBox.Size = new System.Drawing.Size(56, 19);
            this.TIDBox.TabIndex = 100000;
            this.TIDBox.Enter += new System.EventHandler(this.NumericUpDown_SelectValue);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.comboBox5);
            this.groupBox5.Controls.Add(this.TIDBox);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.SIDBox);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Location = new System.Drawing.Point(487, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(297, 49);
            this.groupBox5.TabIndex = 333;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "セーブデータ情報";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(8, 18);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(98, 20);
            this.comboBox5.TabIndex = 333;
            this.comboBox5.TabStop = false;
            // 
            // checkAfterEnding
            // 
            this.checkAfterEnding.AutoSize = true;
            this.checkAfterEnding.Location = new System.Drawing.Point(265, 55);
            this.checkAfterEnding.Name = "checkAfterEnding";
            this.checkAfterEnding.Size = new System.Drawing.Size(60, 16);
            this.checkAfterEnding.TabIndex = 353;
            this.checkAfterEnding.Text = "クリア後";
            this.checkAfterEnding.UseVisualStyleBackColor = true;
            this.checkAfterEnding.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.メニューToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 354;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // メニューToolStripMenuItem
            // 
            this.メニューToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.starterRNGToolStripMenuItem});
            this.メニューToolStripMenuItem.Name = "メニューToolStripMenuItem";
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.メニューToolStripMenuItem.Text = "メニュー";
            // 
            // starterRNGToolStripMenuItem
            // 
            this.starterRNGToolStripMenuItem.Name = "starterRNGToolStripMenuItem";
            this.starterRNGToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.starterRNGToolStripMenuItem.Text = "ID調整";
            this.starterRNGToolStripMenuItem.Click += new System.EventHandler(this.OnClick__StarterRNGToolStripMenuItem);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 582);
            this.Controls.Add(this.checkAfterEnding);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.forcedAdvancesBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.darkPokemonBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(2000, 621);
            this.MinimumSize = new System.Drawing.Size(816, 621);
            this.Name = "MainForm";
            this.Text = "COSearch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_FindTarget.ResumeLayout(false);
            this.tabControl_p2.ResumeLayout(false);
            this.tabPage_FindTarget_FromNearby.ResumeLayout(false);
            this.tabPage_FindTarget_FromNearby.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxAdvances_FindTarget_FromNearBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minAdvances_FindTarget_FromNearBy)).EndInit();
            this.tabPage_FindTarget_FromSeed.ResumeLayout(false);
            this.tabPage_FindTarget_FromSeed.PerformLayout();
            this.tabPage_ListUp.ResumeLayout(false);
            this.tabPage_ListUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFrameBox_ListUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forcedAdvancesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SIDBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIDBox)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_ListUp;
        private System.Windows.Forms.Button calcButton_ListUp;
        private System.Windows.Forms.NumericUpDown maxFrameBox_ListUp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SIDBox;
        private System.Windows.Forms.NumericUpDown TIDBox;
        private System.Windows.Forms.Button calcButton_FindTarget_FromSeed;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.CheckBox checkDeduplication;
        private System.Windows.Forms.ComboBox advanceModeBox_ListUp;
        private SeedBox currentSeedBox_ListUp;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.TabPage tabPage_FindTarget;
        private System.Windows.Forms.NumericUpDown forcedAdvancesBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown minAdvances_FindTarget_FromNearBy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox darkPokemonBox;
        private SeedBox currentSeedBox_FindTarget_FromNearby;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl_p2;
        private System.Windows.Forms.TabPage tabPage_FindTarget_FromNearby;
        private System.Windows.Forms.TabPage tabPage_FindTarget_FromSeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown maxAdvances_FindTarget_FromNearBy;
        private System.Windows.Forms.Button CalcButton_FindTarget_FromNearBy;
        private FindTargetCriteriaArea findTargetFromNearbyCriteriaArea;
        private FindTargetCriteriaArea findTargetFromSeedCriteriaArea;
        private System.Windows.Forms.CheckBox checkAfterEnding;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem メニューToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starterRNGToolStripMenuItem;
    }
}

