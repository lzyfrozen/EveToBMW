namespace EveToBMW
{
    partial class ExcelToJson
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
            this.btnChoice = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.chkFormat = new System.Windows.Forms.CheckBox();
            this.btnExcelToJson = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQueryDB = new System.Windows.Forms.Button();
            this.btnSendBMW = new System.Windows.Forms.Button();
            this.tabMessageBox = new System.Windows.Forms.TabControl();
            this.tabPageOutput = new System.Windows.Forms.TabPage();
            this.tbContext = new System.Windows.Forms.TextBox();
            this.tabPageEveJson = new System.Windows.Forms.TabPage();
            this.tbEveJson = new System.Windows.Forms.TextBox();
            this.tabPageBmwJson = new System.Windows.Forms.TabPage();
            this.tbBmwJson = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabMessageBox.SuspendLayout();
            this.tabPageOutput.SuspendLayout();
            this.tabPageEveJson.SuspendLayout();
            this.tabPageBmwJson.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChoice
            // 
            this.btnChoice.Location = new System.Drawing.Point(12, 16);
            this.btnChoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Size = new System.Drawing.Size(94, 29);
            this.btnChoice.TabIndex = 0;
            this.btnChoice.Text = "选择文件";
            this.btnChoice.UseVisualStyleBackColor = true;
            this.btnChoice.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(112, 18);
            this.tbFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(385, 27);
            this.tbFile.TabIndex = 1;
            // 
            // chkFormat
            // 
            this.chkFormat.AutoSize = true;
            this.chkFormat.Location = new System.Drawing.Point(513, 21);
            this.chkFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkFormat.Name = "chkFormat";
            this.chkFormat.Size = new System.Drawing.Size(83, 24);
            this.chkFormat.TabIndex = 2;
            this.chkFormat.Text = "Format";
            this.chkFormat.UseVisualStyleBackColor = true;
            // 
            // btnExcelToJson
            // 
            this.btnExcelToJson.Location = new System.Drawing.Point(603, 16);
            this.btnExcelToJson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcelToJson.Name = "btnExcelToJson";
            this.btnExcelToJson.Size = new System.Drawing.Size(114, 29);
            this.btnExcelToJson.TabIndex = 3;
            this.btnExcelToJson.Text = "Excel转Json";
            this.btnExcelToJson.UseVisualStyleBackColor = true;
            this.btnExcelToJson.Click += new System.EventHandler(this.btnExcelToJson_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabMessageBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 586F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 653);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQueryDB);
            this.panel1.Controls.Add(this.btnSendBMW);
            this.panel1.Controls.Add(this.btnExcelToJson);
            this.panel1.Controls.Add(this.btnChoice);
            this.panel1.Controls.Add(this.chkFormat);
            this.panel1.Controls.Add(this.tbFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 51);
            this.panel1.TabIndex = 0;
            // 
            // btnQueryDB
            // 
            this.btnQueryDB.Location = new System.Drawing.Point(728, 16);
            this.btnQueryDB.Margin = new System.Windows.Forms.Padding(4);
            this.btnQueryDB.Name = "btnQueryDB";
            this.btnQueryDB.Size = new System.Drawing.Size(96, 29);
            this.btnQueryDB.TabIndex = 5;
            this.btnQueryDB.Text = "QueryDB";
            this.btnQueryDB.UseVisualStyleBackColor = true;
            this.btnQueryDB.Click += new System.EventHandler(this.btnQueryDB_Click);
            // 
            // btnSendBMW
            // 
            this.btnSendBMW.Location = new System.Drawing.Point(833, 16);
            this.btnSendBMW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSendBMW.Name = "btnSendBMW";
            this.btnSendBMW.Size = new System.Drawing.Size(90, 29);
            this.btnSendBMW.TabIndex = 4;
            this.btnSendBMW.Text = "发送";
            this.btnSendBMW.UseVisualStyleBackColor = true;
            this.btnSendBMW.Click += new System.EventHandler(this.btnSendBMW_Click);
            // 
            // tabMessageBox
            // 
            this.tabMessageBox.Controls.Add(this.tabPageOutput);
            this.tabMessageBox.Controls.Add(this.tabPageEveJson);
            this.tabMessageBox.Controls.Add(this.tabPageBmwJson);
            this.tabMessageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMessageBox.Location = new System.Drawing.Point(4, 63);
            this.tabMessageBox.Margin = new System.Windows.Forms.Padding(4);
            this.tabMessageBox.Name = "tabMessageBox";
            this.tabMessageBox.SelectedIndex = 0;
            this.tabMessageBox.Size = new System.Drawing.Size(936, 586);
            this.tabMessageBox.TabIndex = 5;
            // 
            // tabPageOutput
            // 
            this.tabPageOutput.Controls.Add(this.tbContext);
            this.tabPageOutput.Location = new System.Drawing.Point(4, 29);
            this.tabPageOutput.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageOutput.Name = "tabPageOutput";
            this.tabPageOutput.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageOutput.Size = new System.Drawing.Size(928, 553);
            this.tabPageOutput.TabIndex = 1;
            this.tabPageOutput.Text = "输出";
            this.tabPageOutput.UseVisualStyleBackColor = true;
            // 
            // tbContext
            // 
            this.tbContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContext.Location = new System.Drawing.Point(4, 4);
            this.tbContext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbContext.Multiline = true;
            this.tbContext.Name = "tbContext";
            this.tbContext.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbContext.Size = new System.Drawing.Size(920, 545);
            this.tbContext.TabIndex = 1;
            // 
            // tabPageEveJson
            // 
            this.tabPageEveJson.Controls.Add(this.tbEveJson);
            this.tabPageEveJson.Location = new System.Drawing.Point(4, 29);
            this.tabPageEveJson.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageEveJson.Name = "tabPageEveJson";
            this.tabPageEveJson.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageEveJson.Size = new System.Drawing.Size(928, 553);
            this.tabPageEveJson.TabIndex = 2;
            this.tabPageEveJson.Text = "EveJson";
            this.tabPageEveJson.UseVisualStyleBackColor = true;
            // 
            // tbEveJson
            // 
            this.tbEveJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEveJson.Location = new System.Drawing.Point(4, 4);
            this.tbEveJson.Margin = new System.Windows.Forms.Padding(4);
            this.tbEveJson.Multiline = true;
            this.tbEveJson.Name = "tbEveJson";
            this.tbEveJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbEveJson.Size = new System.Drawing.Size(920, 545);
            this.tbEveJson.TabIndex = 0;
            // 
            // tabPageBmwJson
            // 
            this.tabPageBmwJson.Controls.Add(this.tbBmwJson);
            this.tabPageBmwJson.Location = new System.Drawing.Point(4, 29);
            this.tabPageBmwJson.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageBmwJson.Name = "tabPageBmwJson";
            this.tabPageBmwJson.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageBmwJson.Size = new System.Drawing.Size(928, 553);
            this.tabPageBmwJson.TabIndex = 3;
            this.tabPageBmwJson.Text = "BmwJson";
            this.tabPageBmwJson.UseVisualStyleBackColor = true;
            // 
            // tbBmwJson
            // 
            this.tbBmwJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBmwJson.Location = new System.Drawing.Point(4, 4);
            this.tbBmwJson.Margin = new System.Windows.Forms.Padding(4);
            this.tbBmwJson.Multiline = true;
            this.tbBmwJson.Name = "tbBmwJson";
            this.tbBmwJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbBmwJson.Size = new System.Drawing.Size(920, 545);
            this.tbBmwJson.TabIndex = 0;
            // 
            // ExcelToJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 653);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ExcelToJson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExcelToJson";
            this.Load += new System.EventHandler(this.ExcelToJson_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMessageBox.ResumeLayout(false);
            this.tabPageOutput.ResumeLayout(false);
            this.tabPageOutput.PerformLayout();
            this.tabPageEveJson.ResumeLayout(false);
            this.tabPageEveJson.PerformLayout();
            this.tabPageBmwJson.ResumeLayout(false);
            this.tabPageBmwJson.PerformLayout();
            this.ResumeLayout(false);

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