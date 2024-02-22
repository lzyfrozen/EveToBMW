namespace EveToBMW
{
    partial class Menu
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
            menuStrip1 = new MenuStrip();
            bMW11JToolStripMenuItem = new ToolStripMenuItem();
            bMW4110ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { bMW11JToolStripMenuItem, bMW4110ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // bMW11JToolStripMenuItem
            // 
            bMW11JToolStripMenuItem.Name = "bMW11JToolStripMenuItem";
            bMW11JToolStripMenuItem.Size = new Size(92, 24);
            bMW11JToolStripMenuItem.Text = "BMW-11J";
            bMW11JToolStripMenuItem.Click += bMW11JToolStripMenuItem_Click;
            // 
            // bMW4110ToolStripMenuItem
            // 
            bMW4110ToolStripMenuItem.Name = "bMW4110ToolStripMenuItem";
            bMW4110ToolStripMenuItem.Size = new Size(104, 24);
            bMW4110ToolStripMenuItem.Text = "BMW-4110";
            bMW4110ToolStripMenuItem.Click += bMW4110ToolStripMenuItem_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem bMW11JToolStripMenuItem;
        private ToolStripMenuItem bMW4110ToolStripMenuItem;
    }
}