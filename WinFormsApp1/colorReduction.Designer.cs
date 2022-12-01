namespace WinFormsApp1
{
    partial class form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.originalImageGbox = new System.Windows.Forms.GroupBox();
            this.originalPbox = new System.Windows.Forms.PictureBox();
            this.uncertaintyGbox = new System.Windows.Forms.GroupBox();
            this.uncertaintyPbox = new System.Windows.Forms.PictureBox();
            this.popularityGbox = new System.Windows.Forms.GroupBox();
            this.popularityPbox = new System.Windows.Forms.PictureBox();
            this.kmeansGbox = new System.Windows.Forms.GroupBox();
            this.kmeansPbox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            this.originalImageGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPbox)).BeginInit();
            this.uncertaintyGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uncertaintyPbox)).BeginInit();
            this.popularityGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popularityPbox)).BeginInit();
            this.kmeansGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kmeansPbox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.originalImageGbox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.uncertaintyGbox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.popularityGbox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.kmeansGbox, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(700, 537);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // originalImageGbox
            // 
            this.originalImageGbox.AutoSize = true;
            this.originalImageGbox.Controls.Add(this.originalPbox);
            this.originalImageGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalImageGbox.Location = new System.Drawing.Point(3, 2);
            this.originalImageGbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.originalImageGbox.Name = "originalImageGbox";
            this.originalImageGbox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.originalImageGbox.Size = new System.Drawing.Size(344, 264);
            this.originalImageGbox.TabIndex = 4;
            this.originalImageGbox.TabStop = false;
            this.originalImageGbox.Text = "Original image";
            // 
            // originalPbox
            // 
            this.originalPbox.BackColor = System.Drawing.Color.Red;
            this.originalPbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalPbox.Location = new System.Drawing.Point(3, 18);
            this.originalPbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.originalPbox.Name = "originalPbox";
            this.originalPbox.Size = new System.Drawing.Size(338, 244);
            this.originalPbox.TabIndex = 0;
            this.originalPbox.TabStop = false;
            // 
            // uncertaintyGbox
            // 
            this.uncertaintyGbox.AutoSize = true;
            this.uncertaintyGbox.Controls.Add(this.uncertaintyPbox);
            this.uncertaintyGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uncertaintyGbox.Location = new System.Drawing.Point(353, 2);
            this.uncertaintyGbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uncertaintyGbox.Name = "uncertaintyGbox";
            this.uncertaintyGbox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uncertaintyGbox.Size = new System.Drawing.Size(344, 264);
            this.uncertaintyGbox.TabIndex = 5;
            this.uncertaintyGbox.TabStop = false;
            this.uncertaintyGbox.Text = "Propagation of uncertainty";
            // 
            // uncertaintyPbox
            // 
            this.uncertaintyPbox.BackColor = System.Drawing.Color.Lime;
            this.uncertaintyPbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uncertaintyPbox.Location = new System.Drawing.Point(3, 18);
            this.uncertaintyPbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uncertaintyPbox.Name = "uncertaintyPbox";
            this.uncertaintyPbox.Size = new System.Drawing.Size(338, 244);
            this.uncertaintyPbox.TabIndex = 0;
            this.uncertaintyPbox.TabStop = false;
            // 
            // popularityGbox
            // 
            this.popularityGbox.Controls.Add(this.popularityPbox);
            this.popularityGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popularityGbox.Location = new System.Drawing.Point(3, 270);
            this.popularityGbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.popularityGbox.Name = "popularityGbox";
            this.popularityGbox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.popularityGbox.Size = new System.Drawing.Size(344, 265);
            this.popularityGbox.TabIndex = 6;
            this.popularityGbox.TabStop = false;
            this.popularityGbox.Text = "Popularity algorithm";
            // 
            // popularityPbox
            // 
            this.popularityPbox.BackColor = System.Drawing.Color.Yellow;
            this.popularityPbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popularityPbox.Location = new System.Drawing.Point(3, 18);
            this.popularityPbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.popularityPbox.Name = "popularityPbox";
            this.popularityPbox.Size = new System.Drawing.Size(338, 245);
            this.popularityPbox.TabIndex = 0;
            this.popularityPbox.TabStop = false;
            // 
            // kmeansGbox
            // 
            this.kmeansGbox.Controls.Add(this.kmeansPbox);
            this.kmeansGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kmeansGbox.Location = new System.Drawing.Point(353, 270);
            this.kmeansGbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kmeansGbox.Name = "kmeansGbox";
            this.kmeansGbox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kmeansGbox.Size = new System.Drawing.Size(344, 265);
            this.kmeansGbox.TabIndex = 7;
            this.kmeansGbox.TabStop = false;
            this.kmeansGbox.Text = "K-means algorithm";
            // 
            // kmeansPbox
            // 
            this.kmeansPbox.BackColor = System.Drawing.Color.Cyan;
            this.kmeansPbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kmeansPbox.Location = new System.Drawing.Point(3, 18);
            this.kmeansPbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kmeansPbox.Name = "kmeansPbox";
            this.kmeansPbox.Size = new System.Drawing.Size(338, 245);
            this.kmeansPbox.TabIndex = 0;
            this.kmeansPbox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.kValueToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(700, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.loadImageToolStripMenuItem.Text = "Load image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // kValueToolStripMenuItem
            // 
            this.kValueToolStripMenuItem.Name = "kValueToolStripMenuItem";
            this.kValueToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.kValueToolStripMenuItem.Text = "k = 12";
            this.kValueToolStripMenuItem.Click += new System.EventHandler(this.kValueToolStripMenuItem_Click);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 561);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(352, 235);
            this.Name = "form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color reduction";
            this.Resize += new System.EventHandler(this.form_Resize);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.originalImageGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalPbox)).EndInit();
            this.uncertaintyGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uncertaintyPbox)).EndInit();
            this.popularityGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popularityPbox)).EndInit();
            this.kmeansGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kmeansPbox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private GroupBox originalImageGbox;
        private PictureBox originalPbox;
        private GroupBox uncertaintyGbox;
        private PictureBox uncertaintyPbox;
        private GroupBox popularityGbox;
        private PictureBox popularityPbox;
        private GroupBox kmeansGbox;
        private PictureBox kmeansPbox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem loadImageToolStripMenuItem;
        private ToolStripMenuItem kValueToolStripMenuItem;
    }
}