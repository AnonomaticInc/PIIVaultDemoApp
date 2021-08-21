
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPassThrough));
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.bLoadEnvironment = new System.Windows.Forms.Button();
            this.bEditEnvironment = new System.Windows.Forms.Button();
            this.bNewEnvironment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEnvironments = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.step1LoadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step2DefineSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step3ViewResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tpSchema.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchema)).BeginInit();
            this.tpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.tpSettings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpData);
            this.tabControl1.Controls.Add(this.tpSchema);
            this.tabControl1.Controls.Add(this.tpResults);
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1174, 636);
            this.tabControl1.TabIndex = 0;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(-4, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.Size = new System.Drawing.Size(1150, 602);
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
            "Phone Number",
            "Phone Type (Home/Cell/Work)",
            "Email Address)",
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
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 3);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 25;
            this.dgvResult.Size = new System.Drawing.Size(1160, 602);
            this.dgvResult.TabIndex = 0;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.bLoadEnvironment);
            this.tpSettings.Controls.Add(this.bEditEnvironment);
            this.tpSettings.Controls.Add(this.bNewEnvironment);
            this.tpSettings.Controls.Add(this.label1);
            this.tpSettings.Controls.Add(this.cboEnvironments);
            this.tpSettings.Location = new System.Drawing.Point(4, 24);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1166, 608);
            this.tpSettings.TabIndex = 3;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // bLoadEnvironment
            // 
            this.bLoadEnvironment.Location = new System.Drawing.Point(243, 90);
            this.bLoadEnvironment.Name = "bLoadEnvironment";
            this.bLoadEnvironment.Size = new System.Drawing.Size(75, 23);
            this.bLoadEnvironment.TabIndex = 4;
            this.bLoadEnvironment.Text = "Load";
            this.bLoadEnvironment.UseVisualStyleBackColor = true;
            this.bLoadEnvironment.Click += new System.EventHandler(this.bLoadEnvironment_Click);
            // 
            // bEditEnvironment
            // 
            this.bEditEnvironment.Location = new System.Drawing.Point(132, 90);
            this.bEditEnvironment.Name = "bEditEnvironment";
            this.bEditEnvironment.Size = new System.Drawing.Size(75, 23);
            this.bEditEnvironment.TabIndex = 3;
            this.bEditEnvironment.Text = "Edit";
            this.bEditEnvironment.UseVisualStyleBackColor = true;
            this.bEditEnvironment.Click += new System.EventHandler(this.bEditEnvironment_Click);
            // 
            // bNewEnvironment
            // 
            this.bNewEnvironment.Location = new System.Drawing.Point(21, 90);
            this.bNewEnvironment.Name = "bNewEnvironment";
            this.bNewEnvironment.Size = new System.Drawing.Size(75, 23);
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
            this.label1.Size = new System.Drawing.Size(179, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vault Profile Environments";
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.step1LoadDataToolStripMenuItem,
            this.step2DefineSchemaToolStripMenuItem,
            this.step3ViewResultsToolStripMenuItem});
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewComboBoxColumn Group;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RedactData;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.ComboBox cboEnvironments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bLoadEnvironment;
        private System.Windows.Forms.Button bEditEnvironment;
        private System.Windows.Forms.Button bNewEnvironment;
    }
}

