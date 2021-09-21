
namespace PIIVaultDemoApp
{
    partial class FormPassThrough
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPassThrough));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpInstructions = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tpData = new System.Windows.Forms.TabPage();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.tpSchema = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSchema = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RedactData = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bRestoreSchema = new System.Windows.Forms.Button();
            this.bSaveSchema = new System.Windows.Forms.Button();
            this.tpResults = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.bSourceOpen = new System.Windows.Forms.Button();
            this.bSourceSave = new System.Windows.Forms.Button();
            this.labelSourceQuery = new System.Windows.Forms.Label();
            this.tbSourceSQL = new System.Windows.Forms.TextBox();
            this.tbSourcePassword = new System.Windows.Forms.TextBox();
            this.tbSourceUser = new System.Windows.Forms.TextBox();
            this.tbSourceDatabase = new System.Windows.Forms.TextBox();
            this.tbSourceSource = new System.Windows.Forms.TextBox();
            this.labelSourcePassword = new System.Windows.Forms.Label();
            this.labelSourceUser = new System.Windows.Forms.Label();
            this.labelSourceDatabase = new System.Windows.Forms.Label();
            this.labelSourceSource = new System.Windows.Forms.Label();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.bPurgeProfiles = new System.Windows.Forms.Button();
            this.bLoadEnvironment = new System.Windows.Forms.Button();
            this.bEditEnvironment = new System.Windows.Forms.Button();
            this.bNewEnvironment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEnvironments = new System.Windows.Forms.ComboBox();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.tpReidentify = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bReidentify = new System.Windows.Forms.Button();
            this.bPopulatePolyIds = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvPolyIds = new System.Windows.Forms.DataGridView();
            this.PolyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvReidentified = new System.Windows.Forms.DataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.step1LoadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step2DefineSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step3ViewResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tpInstructions.SuspendLayout();
            this.tpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tpSchema.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchema)).BeginInit();
            this.tpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.tpSettings.SuspendLayout();
            this.tpReidentify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolyIds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReidentified)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpInstructions);
            this.tabControl1.Controls.Add(this.tpData);
            this.tabControl1.Controls.Add(this.tpSchema);
            this.tabControl1.Controls.Add(this.tpResults);
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Controls.Add(this.tpReidentify);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1174, 636);
            this.tabControl1.TabIndex = 0;
            // 
            // tpInstructions
            // 
            this.tpInstructions.Controls.Add(this.richTextBox1);
            this.tpInstructions.Location = new System.Drawing.Point(4, 24);
            this.tpInstructions.Name = "tpInstructions";
            this.tpInstructions.Padding = new System.Windows.Forms.Padding(3);
            this.tpInstructions.Size = new System.Drawing.Size(1166, 608);
            this.tpInstructions.TabIndex = 5;
            this.tpInstructions.Text = "How to Use";
            this.tpInstructions.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1160, 602);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.dgvData);
            this.tpData.Location = new System.Drawing.Point(4, 24);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(1166, 608);
            this.tpData.TabIndex = 0;
            this.tpData.Text = "Data";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 3);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.Size = new System.Drawing.Size(1160, 602);
            this.dgvData.TabIndex = 0;
            // 
            // tpSchema
            // 
            this.tpSchema.Controls.Add(this.panel2);
            this.tpSchema.Controls.Add(this.panel1);
            this.tpSchema.Controls.Add(this.bRestoreSchema);
            this.tpSchema.Controls.Add(this.bSaveSchema);
            this.tpSchema.Location = new System.Drawing.Point(4, 24);
            this.tpSchema.Name = "tpSchema";
            this.tpSchema.Padding = new System.Windows.Forms.Padding(3);
            this.tpSchema.Size = new System.Drawing.Size(1166, 608);
            this.tpSchema.TabIndex = 1;
            this.tpSchema.Text = "Schema";
            this.tpSchema.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(6, 505);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1157, 100);
            this.panel2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1151, 90);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSchema);
            this.panel1.Location = new System.Drawing.Point(6, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 466);
            this.panel1.TabIndex = 3;
            // 
            // dgvSchema
            // 
            this.dgvSchema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnType,
            this.Group,
            this.RedactData});
            this.dgvSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchema.Location = new System.Drawing.Point(0, 0);
            this.dgvSchema.Name = "dgvSchema";
            this.dgvSchema.RowTemplate.Height = 25;
            this.dgvSchema.Size = new System.Drawing.Size(1157, 466);
            this.dgvSchema.TabIndex = 0;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Column Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Column Type";
            this.ColumnType.Items.AddRange(new object[] {
            "Non-PII Data Field",
            "Unique Key to Individual",
            "First Name",
            "Last Name",
            "Middle Name",
            "Date of Birth",
            "Gender",
            "Organization Name",
            "Phone Number",
            "Phone Type (Home/Cell/Work)",
            "Email Address",
            "Type of Address",
            "Address Line 1",
            "Address Line 2",
            "Address Line 3",
            "Address Line 4",
            "City",
            "State / State Code",
            "Zip / Postal Code",
            "County",
            "Country",
            "Additional Key Type (SSN/DL#/Etc.)",
            "Additional Key Value"});
            this.ColumnType.Name = "ColumnType";
            // 
            // Group
            // 
            this.Group.HeaderText = "Grouping";
            this.Group.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.Group.Name = "Group";
            // 
            // RedactData
            // 
            this.RedactData.HeaderText = "Redact Data";
            this.RedactData.Name = "RedactData";
            // 
            // bRestoreSchema
            // 
            this.bRestoreSchema.Location = new System.Drawing.Point(106, 3);
            this.bRestoreSchema.Name = "bRestoreSchema";
            this.bRestoreSchema.Size = new System.Drawing.Size(108, 23);
            this.bRestoreSchema.TabIndex = 2;
            this.bRestoreSchema.Text = "Restore Schema";
            this.bRestoreSchema.UseVisualStyleBackColor = true;
            this.bRestoreSchema.Click += new System.EventHandler(this.bRestoreSchema_Click);
            // 
            // bSaveSchema
            // 
            this.bSaveSchema.Location = new System.Drawing.Point(3, 3);
            this.bSaveSchema.Name = "bSaveSchema";
            this.bSaveSchema.Size = new System.Drawing.Size(97, 23);
            this.bSaveSchema.TabIndex = 1;
            this.bSaveSchema.Text = "Save Schema";
            this.bSaveSchema.UseVisualStyleBackColor = true;
            this.bSaveSchema.Click += new System.EventHandler(this.bSaveSchema_Click);
            // 
            // tpResults
            // 
            this.tpResults.Controls.Add(this.dgvResult);
            this.tpResults.Location = new System.Drawing.Point(4, 24);
            this.tpResults.Name = "tpResults";
            this.tpResults.Padding = new System.Windows.Forms.Padding(3);
            this.tpResults.Size = new System.Drawing.Size(1166, 608);
            this.tpResults.TabIndex = 2;
            this.tpResults.Text = "View Results";
            this.tpResults.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 3);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 25;
            this.dgvResult.Size = new System.Drawing.Size(1160, 602);
            this.dgvResult.TabIndex = 0;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.bSourceOpen);
            this.tpSettings.Controls.Add(this.bSourceSave);
            this.tpSettings.Controls.Add(this.labelSourceQuery);
            this.tpSettings.Controls.Add(this.tbSourceSQL);
            this.tpSettings.Controls.Add(this.tbSourcePassword);
            this.tpSettings.Controls.Add(this.tbSourceUser);
            this.tpSettings.Controls.Add(this.tbSourceDatabase);
            this.tpSettings.Controls.Add(this.tbSourceSource);
            this.tpSettings.Controls.Add(this.labelSourcePassword);
            this.tpSettings.Controls.Add(this.labelSourceUser);
            this.tpSettings.Controls.Add(this.labelSourceDatabase);
            this.tpSettings.Controls.Add(this.labelSourceSource);
            this.tpSettings.Controls.Add(this.cbSource);
            this.tpSettings.Controls.Add(this.labelSource);
            this.tpSettings.Controls.Add(this.bPurgeProfiles);
            this.tpSettings.Controls.Add(this.bLoadEnvironment);
            this.tpSettings.Controls.Add(this.bEditEnvironment);
            this.tpSettings.Controls.Add(this.bNewEnvironment);
            this.tpSettings.Controls.Add(this.label1);
            this.tpSettings.Controls.Add(this.cboEnvironments);
            this.tpSettings.Controls.Add(this.gbSource);
            this.tpSettings.Location = new System.Drawing.Point(4, 24);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1166, 608);
            this.tpSettings.TabIndex = 3;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // bSourceOpen
            // 
            this.bSourceOpen.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bSourceOpen.Location = new System.Drawing.Point(21, 246);
            this.bSourceOpen.Name = "bSourceOpen";
            this.bSourceOpen.Size = new System.Drawing.Size(75, 30);
            this.bSourceOpen.TabIndex = 20;
            this.bSourceOpen.Text = "Open";
            this.bSourceOpen.UseVisualStyleBackColor = true;
            this.bSourceOpen.Click += new System.EventHandler(this.bSourceOpen_Click);
            // 
            // bSourceSave
            // 
            this.bSourceSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bSourceSave.Location = new System.Drawing.Point(132, 246);
            this.bSourceSave.Name = "bSourceSave";
            this.bSourceSave.Size = new System.Drawing.Size(75, 30);
            this.bSourceSave.TabIndex = 19;
            this.bSourceSave.Text = "Save";
            this.bSourceSave.UseVisualStyleBackColor = true;
            this.bSourceSave.Click += new System.EventHandler(this.bSourceSave_Click);
            // 
            // labelSourceQuery
            // 
            this.labelSourceQuery.AutoSize = true;
            this.labelSourceQuery.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSourceQuery.Location = new System.Drawing.Point(713, 181);
            this.labelSourceQuery.Name = "labelSourceQuery";
            this.labelSourceQuery.Size = new System.Drawing.Size(48, 19);
            this.labelSourceQuery.TabIndex = 17;
            this.labelSourceQuery.Text = "Query";
            // 
            // tbSourceSQL
            // 
            this.tbSourceSQL.Location = new System.Drawing.Point(713, 203);
            this.tbSourceSQL.Multiline = true;
            this.tbSourceSQL.Name = "tbSourceSQL";
            this.tbSourceSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSourceSQL.Size = new System.Drawing.Size(426, 216);
            this.tbSourceSQL.TabIndex = 16;
            // 
            // tbSourcePassword
            // 
            this.tbSourcePassword.Location = new System.Drawing.Point(372, 363);
            this.tbSourcePassword.Name = "tbSourcePassword";
            this.tbSourcePassword.Size = new System.Drawing.Size(307, 23);
            this.tbSourcePassword.TabIndex = 15;
            this.tbSourcePassword.UseSystemPasswordChar = true;
            // 
            // tbSourceUser
            // 
            this.tbSourceUser.Location = new System.Drawing.Point(372, 308);
            this.tbSourceUser.Name = "tbSourceUser";
            this.tbSourceUser.Size = new System.Drawing.Size(307, 23);
            this.tbSourceUser.TabIndex = 14;
            // 
            // tbSourceDatabase
            // 
            this.tbSourceDatabase.Location = new System.Drawing.Point(372, 253);
            this.tbSourceDatabase.Name = "tbSourceDatabase";
            this.tbSourceDatabase.Size = new System.Drawing.Size(307, 23);
            this.tbSourceDatabase.TabIndex = 13;
            // 
            // tbSourceSource
            // 
            this.tbSourceSource.Location = new System.Drawing.Point(372, 198);
            this.tbSourceSource.Name = "tbSourceSource";
            this.tbSourceSource.Size = new System.Drawing.Size(307, 23);
            this.tbSourceSource.TabIndex = 12;
            // 
            // labelSourcePassword
            // 
            this.labelSourcePassword.AutoSize = true;
            this.labelSourcePassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSourcePassword.Location = new System.Drawing.Point(243, 366);
            this.labelSourcePassword.Name = "labelSourcePassword";
            this.labelSourcePassword.Size = new System.Drawing.Size(71, 19);
            this.labelSourcePassword.TabIndex = 11;
            this.labelSourcePassword.Text = "Password";
            // 
            // labelSourceUser
            // 
            this.labelSourceUser.AutoSize = true;
            this.labelSourceUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSourceUser.Location = new System.Drawing.Point(243, 310);
            this.labelSourceUser.Name = "labelSourceUser";
            this.labelSourceUser.Size = new System.Drawing.Size(55, 19);
            this.labelSourceUser.TabIndex = 10;
            this.labelSourceUser.Text = "User Id";
            // 
            // labelSourceDatabase
            // 
            this.labelSourceDatabase.AutoSize = true;
            this.labelSourceDatabase.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSourceDatabase.Location = new System.Drawing.Point(243, 254);
            this.labelSourceDatabase.Name = "labelSourceDatabase";
            this.labelSourceDatabase.Size = new System.Drawing.Size(71, 19);
            this.labelSourceDatabase.TabIndex = 9;
            this.labelSourceDatabase.Text = "Database";
            // 
            // labelSourceSource
            // 
            this.labelSourceSource.AutoSize = true;
            this.labelSourceSource.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSourceSource.Location = new System.Drawing.Point(243, 198);
            this.labelSourceSource.Name = "labelSourceSource";
            this.labelSourceSource.Size = new System.Drawing.Size(87, 19);
            this.labelSourceSource.TabIndex = 8;
            this.labelSourceSource.Text = "Data Source";
            // 
            // cbSource
            // 
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Items.AddRange(new object[] {
            "CSV",
            "SQL Server",
            "Teradata"});
            this.cbSource.Location = new System.Drawing.Point(21, 195);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(186, 23);
            this.cbSource.TabIndex = 7;
            this.cbSource.SelectedIndexChanged += new System.EventHandler(this.cbSource_SelectedIndexChanged);
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSource.Location = new System.Drawing.Point(21, 172);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(87, 19);
            this.labelSource.TabIndex = 6;
            this.labelSource.Text = "Data Source";
            // 
            // bPurgeProfiles
            // 
            this.bPurgeProfiles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bPurgeProfiles.Location = new System.Drawing.Point(434, 47);
            this.bPurgeProfiles.Name = "bPurgeProfiles";
            this.bPurgeProfiles.Size = new System.Drawing.Size(203, 31);
            this.bPurgeProfiles.TabIndex = 5;
            this.bPurgeProfiles.Text = "Purge All Profiles";
            this.bPurgeProfiles.UseVisualStyleBackColor = true;
            this.bPurgeProfiles.Click += new System.EventHandler(this.bPurgeProfiles_Click);
            // 
            // bLoadEnvironment
            // 
            this.bLoadEnvironment.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bLoadEnvironment.Location = new System.Drawing.Point(243, 90);
            this.bLoadEnvironment.Name = "bLoadEnvironment";
            this.bLoadEnvironment.Size = new System.Drawing.Size(75, 30);
            this.bLoadEnvironment.TabIndex = 4;
            this.bLoadEnvironment.Text = "Load";
            this.bLoadEnvironment.UseVisualStyleBackColor = true;
            this.bLoadEnvironment.Click += new System.EventHandler(this.bLoadEnvironment_Click);
            // 
            // bEditEnvironment
            // 
            this.bEditEnvironment.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bEditEnvironment.Location = new System.Drawing.Point(132, 90);
            this.bEditEnvironment.Name = "bEditEnvironment";
            this.bEditEnvironment.Size = new System.Drawing.Size(75, 30);
            this.bEditEnvironment.TabIndex = 3;
            this.bEditEnvironment.Text = "Edit";
            this.bEditEnvironment.UseVisualStyleBackColor = true;
            this.bEditEnvironment.Click += new System.EventHandler(this.bEditEnvironment_Click);
            // 
            // bNewEnvironment
            // 
            this.bNewEnvironment.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bNewEnvironment.Location = new System.Drawing.Point(21, 90);
            this.bNewEnvironment.Name = "bNewEnvironment";
            this.bNewEnvironment.Size = new System.Drawing.Size(75, 30);
            this.bNewEnvironment.TabIndex = 2;
            this.bNewEnvironment.Text = "New";
            this.bNewEnvironment.UseVisualStyleBackColor = true;
            this.bNewEnvironment.Click += new System.EventHandler(this.bNewEnvironment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "PII Vault Environments";
            // 
            // cboEnvironments
            // 
            this.cboEnvironments.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboEnvironments.FormattingEnabled = true;
            this.cboEnvironments.Location = new System.Drawing.Point(21, 47);
            this.cboEnvironments.Name = "cboEnvironments";
            this.cboEnvironments.Size = new System.Drawing.Size(335, 23);
            this.cboEnvironments.TabIndex = 0;
            // 
            // gbSource
            // 
            this.gbSource.Location = new System.Drawing.Point(231, 168);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(929, 257);
            this.gbSource.TabIndex = 18;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source Parameters";
            // 
            // tpReidentify
            // 
            this.tpReidentify.Controls.Add(this.splitContainer1);
            this.tpReidentify.Location = new System.Drawing.Point(4, 24);
            this.tpReidentify.Name = "tpReidentify";
            this.tpReidentify.Padding = new System.Windows.Forms.Padding(3);
            this.tpReidentify.Size = new System.Drawing.Size(1166, 608);
            this.tpReidentify.TabIndex = 4;
            this.tpReidentify.Text = "Re-Identify";
            this.tpReidentify.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bReidentify);
            this.splitContainer1.Panel1.Controls.Add(this.bPopulatePolyIds);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1160, 602);
            this.splitContainer1.SplitterDistance = 45;
            this.splitContainer1.TabIndex = 0;
            // 
            // bReidentify
            // 
            this.bReidentify.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bReidentify.Location = new System.Drawing.Point(168, 3);
            this.bReidentify.Name = "bReidentify";
            this.bReidentify.Size = new System.Drawing.Size(132, 34);
            this.bReidentify.TabIndex = 1;
            this.bReidentify.Text = "Re-Identify";
            this.bReidentify.UseVisualStyleBackColor = true;
            this.bReidentify.Click += new System.EventHandler(this.bReidentify_Click);
            // 
            // bPopulatePolyIds
            // 
            this.bPopulatePolyIds.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bPopulatePolyIds.Location = new System.Drawing.Point(5, 3);
            this.bPopulatePolyIds.Name = "bPopulatePolyIds";
            this.bPopulatePolyIds.Size = new System.Drawing.Size(143, 34);
            this.bPopulatePolyIds.TabIndex = 0;
            this.bPopulatePolyIds.Text = "Populate Poly IDs";
            this.bPopulatePolyIds.UseVisualStyleBackColor = true;
            this.bPopulatePolyIds.Click += new System.EventHandler(this.bPopulatePolyIds_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvPolyIds);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvReidentified);
            this.splitContainer2.Size = new System.Drawing.Size(1160, 553);
            this.splitContainer2.SplitterDistance = 272;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvPolyIds
            // 
            this.dgvPolyIds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPolyIds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPolyIds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PolyId});
            this.dgvPolyIds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPolyIds.Location = new System.Drawing.Point(0, 0);
            this.dgvPolyIds.Name = "dgvPolyIds";
            this.dgvPolyIds.RowTemplate.Height = 25;
            this.dgvPolyIds.Size = new System.Drawing.Size(272, 553);
            this.dgvPolyIds.TabIndex = 0;
            // 
            // PolyId
            // 
            this.PolyId.HeaderText = "Poly-Anonymous ID";
            this.PolyId.Name = "PolyId";
            // 
            // dgvReidentified
            // 
            this.dgvReidentified.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReidentified.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.Gender,
            this.Address1,
            this.City,
            this.State,
            this.Zip,
            this.Phone,
            this.Email});
            this.dgvReidentified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReidentified.Location = new System.Drawing.Point(0, 0);
            this.dgvReidentified.Name = "dgvReidentified";
            this.dgvReidentified.RowTemplate.Height = 25;
            this.dgvReidentified.Size = new System.Drawing.Size(884, 553);
            this.dgvReidentified.TabIndex = 0;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            // 
            // Address1
            // 
            this.Address1.HeaderText = "Address";
            this.Address1.Name = "Address1";
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            // 
            // Zip
            // 
            this.Zip.HeaderText = "Zip Code";
            this.Zip.Name = "Zip";
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.step1LoadDataToolStripMenuItem,
            this.step2DefineSchemaToolStripMenuItem,
            this.step3ViewResultsToolStripMenuItem,
            this.saveResultsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1199, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // step1LoadDataToolStripMenuItem
            // 
            this.step1LoadDataToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.step1LoadDataToolStripMenuItem.Name = "step1LoadDataToolStripMenuItem";
            this.step1LoadDataToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.step1LoadDataToolStripMenuItem.Text = "Step 1: Load Data";
            this.step1LoadDataToolStripMenuItem.Click += new System.EventHandler(this.step1LoadDataToolStripMenuItem_Click);
            // 
            // step2DefineSchemaToolStripMenuItem
            // 
            this.step2DefineSchemaToolStripMenuItem.Name = "step2DefineSchemaToolStripMenuItem";
            this.step2DefineSchemaToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.step2DefineSchemaToolStripMenuItem.Text = "Step 2: Define Schema";
            this.step2DefineSchemaToolStripMenuItem.Click += new System.EventHandler(this.step2DefineSchemaToolStripMenuItem_Click);
            // 
            // step3ViewResultsToolStripMenuItem
            // 
            this.step3ViewResultsToolStripMenuItem.Name = "step3ViewResultsToolStripMenuItem";
            this.step3ViewResultsToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.step3ViewResultsToolStripMenuItem.Text = "Step 3: View Results";
            this.step3ViewResultsToolStripMenuItem.Click += new System.EventHandler(this.step3ViewResultsToolStripMenuItem_Click);
            // 
            // saveResultsToolStripMenuItem
            // 
            this.saveResultsToolStripMenuItem.Name = "saveResultsToolStripMenuItem";
            this.saveResultsToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.saveResultsToolStripMenuItem.Text = "Save Results";
            this.saveResultsToolStripMenuItem.Click += new System.EventHandler(this.saveResultsToolStripMenuItem_Click);
            // 
            // FormPassThrough
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPassThrough";
            this.Text = "PII Vault - Pass Through Anonymization";
            this.tabControl1.ResumeLayout(false);
            this.tpInstructions.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.tpSchema.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchema)).EndInit();
            this.tpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.tpReidentify.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolyIds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReidentified)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.TabPage tpSchema;
        private System.Windows.Forms.TabPage tpResults;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem step1LoadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step2DefineSchemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step3ViewResultsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridView dgvSchema;
        private System.Windows.Forms.Button bRestoreSchema;
        private System.Windows.Forms.Button bSaveSchema;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.ComboBox cboEnvironments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bLoadEnvironment;
        private System.Windows.Forms.Button bEditEnvironment;
        private System.Windows.Forms.Button bNewEnvironment;
        private System.Windows.Forms.Button bPurgeProfiles;
        private System.Windows.Forms.TabPage tpReidentify;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bReidentify;
        private System.Windows.Forms.Button bPopulatePolyIds;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvPolyIds;
        private System.Windows.Forms.DataGridViewTextBoxColumn PolyId;
        private System.Windows.Forms.DataGridView dgvReidentified;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address1;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.ToolStripMenuItem saveResultsToolStripMenuItem;
        private System.Windows.Forms.TabPage tpInstructions;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelSourcePassword;
        private System.Windows.Forms.Label labelSourceUser;
        private System.Windows.Forms.Label labelSourceDatabase;
        private System.Windows.Forms.Label labelSourceSource;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelSourceQuery;
        private System.Windows.Forms.TextBox tbSourceSQL;
        private System.Windows.Forms.TextBox tbSourcePassword;
        private System.Windows.Forms.TextBox tbSourceUser;
        private System.Windows.Forms.TextBox tbSourceDatabase;
        private System.Windows.Forms.TextBox tbSourceSource;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewComboBoxColumn Group;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RedactData;
        private System.Windows.Forms.Button bSourceOpen;
        private System.Windows.Forms.Button bSourceSave;
    }
}

