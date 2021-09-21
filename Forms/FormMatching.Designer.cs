
namespace PIIVaultDemoApp.Forms
{
    partial class FormMatching
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bTestSave = new System.Windows.Forms.Button();
            this.bTestLoad = new System.Windows.Forms.Button();
            this.bTestNew = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvTests = new System.Windows.Forms.DataGridView();
            this.tbTestExpression = new System.Windows.Forms.TextBox();
            this.tpRunMatch = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.labelMatchCount = new System.Windows.Forms.Label();
            this.bBuildList = new System.Windows.Forms.Button();
            this.bRunTests = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvTestsToRun = new System.Windows.Forms.DataGridView();
            this.RunTest = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTestResults = new System.Windows.Forms.DataGridView();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.bMatchTests = new System.Windows.Forms.Button();
            this.tbMatchTests = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bSaveMatchResults = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).BeginInit();
            this.tpRunMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsToRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestResults)).BeginInit();
            this.tpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpRunMatch);
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Location = new System.Drawing.Point(3, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1195, 585);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1187, 551);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Match Tests";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.bTestSave);
            this.splitContainer1.Panel1.Controls.Add(this.bTestLoad);
            this.splitContainer1.Panel1.Controls.Add(this.bTestNew);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Size = new System.Drawing.Size(1181, 545);
            this.splitContainer1.SplitterDistance = 41;
            this.splitContainer1.TabIndex = 0;
            // 
            // bTestSave
            // 
            this.bTestSave.Location = new System.Drawing.Point(166, 5);
            this.bTestSave.Name = "bTestSave";
            this.bTestSave.Size = new System.Drawing.Size(75, 31);
            this.bTestSave.TabIndex = 2;
            this.bTestSave.Text = "Save";
            this.bTestSave.UseVisualStyleBackColor = true;
            this.bTestSave.Click += new System.EventHandler(this.bTestSave_Click);
            // 
            // bTestLoad
            // 
            this.bTestLoad.Location = new System.Drawing.Point(4, 5);
            this.bTestLoad.Name = "bTestLoad";
            this.bTestLoad.Size = new System.Drawing.Size(75, 32);
            this.bTestLoad.TabIndex = 1;
            this.bTestLoad.Text = "Load";
            this.bTestLoad.UseVisualStyleBackColor = true;
            this.bTestLoad.Click += new System.EventHandler(this.bTestLoad_Click);
            // 
            // bTestNew
            // 
            this.bTestNew.Location = new System.Drawing.Point(85, 5);
            this.bTestNew.Name = "bTestNew";
            this.bTestNew.Size = new System.Drawing.Size(75, 32);
            this.bTestNew.TabIndex = 0;
            this.bTestNew.Text = "New";
            this.bTestNew.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvTests);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.tbTestExpression);
            this.splitContainer4.Size = new System.Drawing.Size(1181, 505);
            this.splitContainer4.SplitterDistance = 334;
            this.splitContainer4.TabIndex = 1;
            // 
            // dgvTests
            // 
            this.dgvTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTests.Location = new System.Drawing.Point(0, 0);
            this.dgvTests.Name = "dgvTests";
            this.dgvTests.RowTemplate.Height = 25;
            this.dgvTests.Size = new System.Drawing.Size(334, 505);
            this.dgvTests.TabIndex = 0;
            this.dgvTests.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTests_RowEnter);
            // 
            // tbTestExpression
            // 
            this.tbTestExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTestExpression.Location = new System.Drawing.Point(0, 0);
            this.tbTestExpression.Multiline = true;
            this.tbTestExpression.Name = "tbTestExpression";
            this.tbTestExpression.Size = new System.Drawing.Size(843, 505);
            this.tbTestExpression.TabIndex = 0;
            this.tbTestExpression.TextChanged += new System.EventHandler(this.tbTestExpression_TextChanged);
            // 
            // tpRunMatch
            // 
            this.tpRunMatch.Controls.Add(this.splitContainer2);
            this.tpRunMatch.Location = new System.Drawing.Point(4, 30);
            this.tpRunMatch.Name = "tpRunMatch";
            this.tpRunMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tpRunMatch.Size = new System.Drawing.Size(1187, 551);
            this.tpRunMatch.TabIndex = 1;
            this.tpRunMatch.Text = "Run Match Tests";
            this.tpRunMatch.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.bSaveMatchResults);
            this.splitContainer2.Panel1.Controls.Add(this.labelMatchCount);
            this.splitContainer2.Panel1.Controls.Add(this.bBuildList);
            this.splitContainer2.Panel1.Controls.Add(this.bRunTests);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1181, 545);
            this.splitContainer2.SplitterDistance = 49;
            this.splitContainer2.TabIndex = 0;
            // 
            // labelMatchCount
            // 
            this.labelMatchCount.AutoSize = true;
            this.labelMatchCount.Location = new System.Drawing.Point(764, 15);
            this.labelMatchCount.Name = "labelMatchCount";
            this.labelMatchCount.Size = new System.Drawing.Size(0, 21);
            this.labelMatchCount.TabIndex = 2;
            // 
            // bBuildList
            // 
            this.bBuildList.Location = new System.Drawing.Point(4, 5);
            this.bBuildList.Name = "bBuildList";
            this.bBuildList.Size = new System.Drawing.Size(144, 41);
            this.bBuildList.TabIndex = 1;
            this.bBuildList.Text = "Build List";
            this.bBuildList.UseVisualStyleBackColor = true;
            this.bBuildList.Click += new System.EventHandler(this.bBuildList_Click);
            // 
            // bRunTests
            // 
            this.bRunTests.Location = new System.Drawing.Point(154, 5);
            this.bRunTests.Name = "bRunTests";
            this.bRunTests.Size = new System.Drawing.Size(137, 42);
            this.bRunTests.TabIndex = 0;
            this.bRunTests.Text = "Run Tests";
            this.bRunTests.UseVisualStyleBackColor = true;
            this.bRunTests.Click += new System.EventHandler(this.bRunTests_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvTestsToRun);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvTestResults);
            this.splitContainer3.Size = new System.Drawing.Size(1181, 492);
            this.splitContainer3.SplitterDistance = 393;
            this.splitContainer3.TabIndex = 0;
            // 
            // dgvTestsToRun
            // 
            this.dgvTestsToRun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTestsToRun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestsToRun.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RunTest,
            this.TestName});
            this.dgvTestsToRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestsToRun.Location = new System.Drawing.Point(0, 0);
            this.dgvTestsToRun.Name = "dgvTestsToRun";
            this.dgvTestsToRun.RowTemplate.Height = 25;
            this.dgvTestsToRun.Size = new System.Drawing.Size(393, 492);
            this.dgvTestsToRun.TabIndex = 0;
            // 
            // RunTest
            // 
            this.RunTest.HeaderText = "RunTest";
            this.RunTest.Name = "RunTest";
            this.RunTest.Width = 70;
            // 
            // TestName
            // 
            this.TestName.HeaderText = "Test Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 107;
            // 
            // dgvTestResults
            // 
            this.dgvTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestResults.Location = new System.Drawing.Point(0, 0);
            this.dgvTestResults.Name = "dgvTestResults";
            this.dgvTestResults.RowTemplate.Height = 25;
            this.dgvTestResults.Size = new System.Drawing.Size(784, 492);
            this.dgvTestResults.TabIndex = 0;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.bMatchTests);
            this.tpSettings.Controls.Add(this.tbMatchTests);
            this.tpSettings.Controls.Add(this.label1);
            this.tpSettings.Location = new System.Drawing.Point(4, 30);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1187, 551);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // bMatchTests
            // 
            this.bMatchTests.Location = new System.Drawing.Point(844, 65);
            this.bMatchTests.Name = "bMatchTests";
            this.bMatchTests.Size = new System.Drawing.Size(75, 29);
            this.bMatchTests.TabIndex = 2;
            this.bMatchTests.Text = "Find";
            this.bMatchTests.UseVisualStyleBackColor = true;
            this.bMatchTests.Click += new System.EventHandler(this.bMatchTests_Click);
            // 
            // tbMatchTests
            // 
            this.tbMatchTests.Location = new System.Drawing.Point(22, 65);
            this.tbMatchTests.Name = "tbMatchTests";
            this.tbMatchTests.Size = new System.Drawing.Size(816, 29);
            this.tbMatchTests.TabIndex = 1;
            this.tbMatchTests.Text = "C:\\Users\\MatthewFleck\\Anonomatic\\Anonomatic - Development - Documents\\Testing\\Mat" +
    "ching\\Matching Tests.csv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tests File (CSV)";
            // 
            // bSaveMatchResults
            // 
            this.bSaveMatchResults.Location = new System.Drawing.Point(297, 5);
            this.bSaveMatchResults.Name = "bSaveMatchResults";
            this.bSaveMatchResults.Size = new System.Drawing.Size(137, 42);
            this.bSaveMatchResults.TabIndex = 3;
            this.bSaveMatchResults.Text = "Save Results";
            this.bSaveMatchResults.UseVisualStyleBackColor = true;
            this.bSaveMatchResults.Click += new System.EventHandler(this.bSaveMatchResults_Click);
            // 
            // FormMatching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 627);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMatching";
            this.Text = "Anonymous Data Matching";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).EndInit();
            this.tpRunMatch.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsToRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestResults)).EndInit();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tpRunMatch;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.Button bMatchTests;
        private System.Windows.Forms.TextBox tbMatchTests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bTestSave;
        private System.Windows.Forms.Button bTestLoad;
        private System.Windows.Forms.Button bTestNew;
        private System.Windows.Forms.DataGridView dgvTests;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button bRunTests;
        private System.Windows.Forms.DataGridView dgvTestsToRun;
        private System.Windows.Forms.DataGridView dgvTestResults;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RunTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.Button bBuildList;
        private System.Windows.Forms.Label labelMatchCount;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TextBox tbTestExpression;
        private System.Windows.Forms.Button bSaveMatchResults;
    }
}