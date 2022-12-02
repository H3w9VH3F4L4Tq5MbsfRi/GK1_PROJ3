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
            this.colorTrackBar = new System.Windows.Forms.TrackBar();
            this.colorTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lenaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lenagrayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lasVegasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lewandowskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            this.originalImageGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPbox)).BeginInit();
            this.uncertaintyGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uncertaintyPbox)).BeginInit();
            this.popularityGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popularityPbox)).BeginInit();
            this.kmeansGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kmeansPbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTrackBar)).BeginInit();
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
            this.tableLayoutPanel.Controls.Add(this.colorTrackBar, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.colorTextBox, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(684, 537);
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
            this.originalImageGbox.Size = new System.Drawing.Size(336, 239);
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
            this.originalPbox.Size = new System.Drawing.Size(330, 219);
            this.originalPbox.TabIndex = 0;
            this.originalPbox.TabStop = false;
            // 
            // uncertaintyGbox
            // 
            this.uncertaintyGbox.AutoSize = true;
            this.uncertaintyGbox.Controls.Add(this.uncertaintyPbox);
            this.uncertaintyGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uncertaintyGbox.Location = new System.Drawing.Point(345, 2);
            this.uncertaintyGbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uncertaintyGbox.Name = "uncertaintyGbox";
            this.uncertaintyGbox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uncertaintyGbox.Size = new System.Drawing.Size(336, 239);
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
            this.uncertaintyPbox.Size = new System.Drawing.Size(330, 219);
            this.uncertaintyPbox.TabIndex = 0;
            this.uncertaintyPbox.TabStop = false;
            // 
            // popularityGbox
            // 
            this.popularityGbox.Controls.Add(this.popularityPbox);
            this.popularityGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popularityGbox.Location = new System.Drawing.Point(3, 245);
            this.popularityGbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.popularityGbox.Name = "popularityGbox";
            this.popularityGbox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.popularityGbox.Size = new System.Drawing.Size(336, 239);
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
            this.popularityPbox.Size = new System.Drawing.Size(330, 219);
            this.popularityPbox.TabIndex = 0;
            this.popularityPbox.TabStop = false;
            // 
            // kmeansGbox
            // 
            this.kmeansGbox.Controls.Add(this.kmeansPbox);
            this.kmeansGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kmeansGbox.Location = new System.Drawing.Point(345, 245);
            this.kmeansGbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kmeansGbox.Name = "kmeansGbox";
            this.kmeansGbox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kmeansGbox.Size = new System.Drawing.Size(336, 239);
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
            this.kmeansPbox.Size = new System.Drawing.Size(330, 219);
            this.kmeansPbox.TabIndex = 0;
            this.kmeansPbox.TabStop = false;
            // 
            // colorTrackBar
            // 
            this.colorTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorTrackBar.LargeChange = 1;
            this.colorTrackBar.Location = new System.Drawing.Point(345, 489);
            this.colorTrackBar.Minimum = 1;
            this.colorTrackBar.Name = "colorTrackBar";
            this.colorTrackBar.Size = new System.Drawing.Size(336, 45);
            this.colorTrackBar.TabIndex = 8;
            this.colorTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.colorTrackBar.Value = 3;
            this.colorTrackBar.ValueChanged += new System.EventHandler(this.colorTrackBar_ValueChanged);
            // 
            // colorTextBox
            // 
            this.colorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.colorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colorTextBox.Enabled = false;
            this.colorTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colorTextBox.Location = new System.Drawing.Point(3, 500);
            this.colorTextBox.Name = "colorTextBox";
            this.colorTextBox.ReadOnly = true;
            this.colorTextBox.Size = new System.Drawing.Size(336, 22);
            this.colorTextBox.TabIndex = 9;
            this.colorTextBox.Text = "Color palette limited to 64 colors.";
            this.colorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.loadDefaultToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(684, 24);
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
            // loadDefaultToolStripMenuItem
            // 
            this.loadDefaultToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lenaToolStripMenuItem,
            this.lenagrayscaleToolStripMenuItem,
            this.beachToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.lasVegasToolStripMenuItem,
            this.lewandowskiToolStripMenuItem});
            this.loadDefaultToolStripMenuItem.Name = "loadDefaultToolStripMenuItem";
            this.loadDefaultToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.loadDefaultToolStripMenuItem.Text = "Load default";
            // 
            // lenaToolStripMenuItem
            // 
            this.lenaToolStripMenuItem.Name = "lenaToolStripMenuItem";
            this.lenaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.lenaToolStripMenuItem.Text = "Lena";
            this.lenaToolStripMenuItem.Click += new System.EventHandler(this.lenaToolStripMenuItem_Click);
            // 
            // lenagrayscaleToolStripMenuItem
            // 
            this.lenagrayscaleToolStripMenuItem.Name = "lenagrayscaleToolStripMenuItem";
            this.lenagrayscaleToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.lenagrayscaleToolStripMenuItem.Text = "Lena (grayscale)";
            this.lenagrayscaleToolStripMenuItem.Click += new System.EventHandler(this.lenagrayscaleToolStripMenuItem_Click);
            // 
            // beachToolStripMenuItem
            // 
            this.beachToolStripMenuItem.Name = "beachToolStripMenuItem";
            this.beachToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.beachToolStripMenuItem.Text = "Beach";
            this.beachToolStripMenuItem.Click += new System.EventHandler(this.beachToolStripMenuItem_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.colorsToolStripMenuItem.Text = "Colors";
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // lasVegasToolStripMenuItem
            // 
            this.lasVegasToolStripMenuItem.Name = "lasVegasToolStripMenuItem";
            this.lasVegasToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.lasVegasToolStripMenuItem.Text = "Las Vegas";
            this.lasVegasToolStripMenuItem.Click += new System.EventHandler(this.lasVegasToolStripMenuItem_Click);
            // 
            // lewandowskiToolStripMenuItem
            // 
            this.lewandowskiToolStripMenuItem.Name = "lewandowskiToolStripMenuItem";
            this.lewandowskiToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.lewandowskiToolStripMenuItem.Text = "Lewandowski 🇵🇱";
            this.lewandowskiToolStripMenuItem.Click += new System.EventHandler(this.lewandowskiToolStripMenuItem_Click);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(500, 500);
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
            ((System.ComponentModel.ISupportInitialize)(this.colorTrackBar)).EndInit();
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
        private TrackBar colorTrackBar;
        private TextBox colorTextBox;
        private ToolStripMenuItem loadDefaultToolStripMenuItem;
        private ToolStripMenuItem lenaToolStripMenuItem;
        private ToolStripMenuItem lenagrayscaleToolStripMenuItem;
        private ToolStripMenuItem beachToolStripMenuItem;
        private ToolStripMenuItem colorsToolStripMenuItem;
        private ToolStripMenuItem lasVegasToolStripMenuItem;
        private ToolStripMenuItem lewandowskiToolStripMenuItem;
    }
}