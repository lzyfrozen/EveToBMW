namespace EveToBMW
{
    partial class ExcelToJsonBy4110
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
            btnChoice = new Button();
            tbFile = new TextBox();
            chkFormat = new CheckBox();
            btnExcelToJson = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            btnQueryDB = new Button();
            btnSendBMW = new Button();
            tabMessageBox = new TabControl();
            tabPageOutput = new TabPage();
            tbContext = new TextBox();
            tabPageEveJson = new TabPage();
            tbEveJson = new TextBox();
            tabPageBmwJson = new TabPage();
            tbBmwJson = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tabMessageBox.SuspendLayout();
            tabPageOutput.SuspendLayout();
            tabPageEveJson.SuspendLayout();
            tabPageBmwJson.SuspendLayout();
            SuspendLayout();
            // 
            // btnChoice
            // 
            btnChoice.Location = new Point(12, 16);
            btnChoice.Margin = new Padding(3, 4, 3, 4);
            btnChoice.Name = "btnChoice";
            btnChoice.Size = new Size(94, 29);
            btnChoice.TabIndex = 0;
            btnChoice.Text = "选择文件";
            btnChoice.UseVisualStyleBackColor = true;
            btnChoice.Click += btnChoice_Click;
            // 
            // tbFile
            // 
            tbFile.Location = new Point(112, 18);
            tbFile.Margin = new Padding(3, 4, 3, 4);
            tbFile.Name = "tbFile";
            tbFile.Size = new Size(385, 27);
            tbFile.TabIndex = 1;
            // 
            // chkFormat
            // 
            chkFormat.AutoSize = true;
            chkFormat.Location = new Point(513, 21);
            chkFormat.Margin = new Padding(3, 4, 3, 4);
            chkFormat.Name = "chkFormat";
            chkFormat.Size = new Size(83, 24);
            chkFormat.TabIndex = 2;
            chkFormat.Text = "Format";
            chkFormat.UseVisualStyleBackColor = true;
            // 
            // btnExcelToJson
            // 
            btnExcelToJson.Location = new Point(603, 16);
            btnExcelToJson.Margin = new Padding(3, 4, 3, 4);
            btnExcelToJson.Name = "btnExcelToJson";
            btnExcelToJson.Size = new Size(114, 29);
            btnExcelToJson.TabIndex = 3;
            btnExcelToJson.Text = "Excel转Json";
            btnExcelToJson.UseVisualStyleBackColor = true;
            btnExcelToJson.Click += btnExcelToJson_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tabMessageBox, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 586F));
            tableLayoutPanel1.Size = new Size(944, 653);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnQueryDB);
            panel1.Controls.Add(btnSendBMW);
            panel1.Controls.Add(btnExcelToJson);
            panel1.Controls.Add(btnChoice);
            panel1.Controls.Add(chkFormat);
            panel1.Controls.Add(tbFile);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 4);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(938, 51);
            panel1.TabIndex = 0;
            // 
            // btnQueryDB
            // 
            btnQueryDB.Location = new Point(728, 16);
            btnQueryDB.Margin = new Padding(4);
            btnQueryDB.Name = "btnQueryDB";
            btnQueryDB.Size = new Size(96, 29);
            btnQueryDB.TabIndex = 5;
            btnQueryDB.Text = "QueryDB";
            btnQueryDB.UseVisualStyleBackColor = true;
            btnQueryDB.Click += btnQueryDB_Click;
            // 
            // btnSendBMW
            // 
            btnSendBMW.Location = new Point(833, 16);
            btnSendBMW.Margin = new Padding(3, 4, 3, 4);
            btnSendBMW.Name = "btnSendBMW";
            btnSendBMW.Size = new Size(90, 29);
            btnSendBMW.TabIndex = 4;
            btnSendBMW.Text = "发送";
            btnSendBMW.UseVisualStyleBackColor = true;
            btnSendBMW.Click += btnSendBMW_Click;
            // 
            // tabMessageBox
            // 
            tabMessageBox.Controls.Add(tabPageOutput);
            tabMessageBox.Controls.Add(tabPageEveJson);
            tabMessageBox.Controls.Add(tabPageBmwJson);
            tabMessageBox.Dock = DockStyle.Fill;
            tabMessageBox.Location = new Point(4, 63);
            tabMessageBox.Margin = new Padding(4);
            tabMessageBox.Name = "tabMessageBox";
            tabMessageBox.SelectedIndex = 0;
            tabMessageBox.Size = new Size(936, 586);
            tabMessageBox.TabIndex = 5;
            // 
            // tabPageOutput
            // 
            tabPageOutput.Controls.Add(tbContext);
            tabPageOutput.Location = new Point(4, 29);
            tabPageOutput.Margin = new Padding(4);
            tabPageOutput.Name = "tabPageOutput";
            tabPageOutput.Padding = new Padding(4);
            tabPageOutput.Size = new Size(928, 553);
            tabPageOutput.TabIndex = 1;
            tabPageOutput.Text = "输出";
            tabPageOutput.UseVisualStyleBackColor = true;
            // 
            // tbContext
            // 
            tbContext.Dock = DockStyle.Fill;
            tbContext.Location = new Point(4, 4);
            tbContext.Margin = new Padding(3, 4, 3, 4);
            tbContext.Multiline = true;
            tbContext.Name = "tbContext";
            tbContext.ScrollBars = ScrollBars.Both;
            tbContext.Size = new Size(920, 545);
            tbContext.TabIndex = 1;
            // 
            // tabPageEveJson
            // 
            tabPageEveJson.Controls.Add(tbEveJson);
            tabPageEveJson.Location = new Point(4, 29);
            tabPageEveJson.Margin = new Padding(4);
            tabPageEveJson.Name = "tabPageEveJson";
            tabPageEveJson.Padding = new Padding(4);
            tabPageEveJson.Size = new Size(928, 553);
            tabPageEveJson.TabIndex = 2;
            tabPageEveJson.Text = "EveJson";
            tabPageEveJson.UseVisualStyleBackColor = true;
            // 
            // tbEveJson
            // 
            tbEveJson.Dock = DockStyle.Fill;
            tbEveJson.Location = new Point(4, 4);
            tbEveJson.Margin = new Padding(4);
            tbEveJson.Multiline = true;
            tbEveJson.Name = "tbEveJson";
            tbEveJson.ScrollBars = ScrollBars.Both;
            tbEveJson.Size = new Size(920, 545);
            tbEveJson.TabIndex = 0;
            // 
            // tabPageBmwJson
            // 
            tabPageBmwJson.Controls.Add(tbBmwJson);
            tabPageBmwJson.Location = new Point(4, 29);
            tabPageBmwJson.Margin = new Padding(4);
            tabPageBmwJson.Name = "tabPageBmwJson";
            tabPageBmwJson.Padding = new Padding(4);
            tabPageBmwJson.Size = new Size(928, 553);
            tabPageBmwJson.TabIndex = 3;
            tabPageBmwJson.Text = "BmwJson";
            tabPageBmwJson.UseVisualStyleBackColor = true;
            // 
            // tbBmwJson
            // 
            tbBmwJson.Dock = DockStyle.Fill;
            tbBmwJson.Location = new Point(4, 4);
            tbBmwJson.Margin = new Padding(4);
            tbBmwJson.Multiline = true;
            tbBmwJson.Name = "tbBmwJson";
            tbBmwJson.ScrollBars = ScrollBars.Both;
            tbBmwJson.Size = new Size(920, 545);
            tbBmwJson.TabIndex = 0;
            // 
            // ExcelToJsonBy4110
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 653);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ExcelToJsonBy4110";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ExcelToJsonBy4110";
            Load += ExcelToJson_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabMessageBox.ResumeLayout(false);
            tabPageOutput.ResumeLayout(false);
            tabPageOutput.PerformLayout();
            tabPageEveJson.ResumeLayout(false);
            tabPageEveJson.PerformLayout();
            tabPageBmwJson.ResumeLayout(false);
            tabPageBmwJson.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnChoice;
        private TextBox tbFile;
        private CheckBox chkFormat;
        private Button btnExcelToJson;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnSendBMW;
        private TextBox tbContext;
        private TabControl tabMessageBox;
        private TabPage tabPageOutput;
        private TabPage tabPageEveJson;
        private TabPage tabPageBmwJson;
        private Button btnQueryDB;
        private TextBox tbEveJson;
        private TextBox tbBmwJson;
    }
}