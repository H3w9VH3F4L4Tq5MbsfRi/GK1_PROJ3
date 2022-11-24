namespace WinFormsApp1
{
    partial class Form1
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.originalImageGbox = new System.Windows.Forms.GroupBox();
            this.originalImagePbox = new System.Windows.Forms.PictureBox();
            this.uncertaintyGbox = new System.Windows.Forms.GroupBox();
            this.uncertaintyPbox = new System.Windows.Forms.PictureBox();
            this.popularityGbox = new System.Windows.Forms.GroupBox();
            this.popularityPbox = new System.Windows.Forms.PictureBox();
            this.kmeansGbox = new System.Windows.Forms.GroupBox();
            this.kmeansPbox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel.SuspendLayout();
            this.originalImageGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalImagePbox)).BeginInit();
            this.uncertaintyGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uncertaintyPbox)).BeginInit();
            this.popularityGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popularityPbox)).BeginInit();
            this.kmeansGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kmeansPbox)).BeginInit();
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
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // originalImageGbox
            // 
            this.originalImageGbox.AutoSize = true;
            this.originalImageGbox.Controls.Add(this.originalImagePbox);
            this.originalImageGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalImageGbox.Location = new System.Drawing.Point(3, 3);
            this.originalImageGbox.Name = "originalImageGbox";
            this.originalImageGbox.Size = new System.Drawing.Size(394, 219);
            this.originalImageGbox.TabIndex = 4;
            this.originalImageGbox.TabStop = false;
            this.originalImageGbox.Text = "Original image";
            // 
            // originalImagePbox
            // 
            this.originalImagePbox.BackColor = System.Drawing.Color.Red;
            this.originalImagePbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalImagePbox.Location = new System.Drawing.Point(3, 23);
            this.originalImagePbox.Name = "originalImagePbox";
            this.originalImagePbox.Size = new System.Drawing.Size(388, 193);
            this.originalImagePbox.TabIndex = 0;
            this.originalImagePbox.TabStop = false;
            // 
            // uncertaintyGbox
            // 
            this.uncertaintyGbox.AutoSize = true;
            this.uncertaintyGbox.Controls.Add(this.uncertaintyPbox);
            this.uncertaintyGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uncertaintyGbox.Location = new System.Drawing.Point(403, 3);
            this.uncertaintyGbox.Name = "uncertaintyGbox";
            this.uncertaintyGbox.Size = new System.Drawing.Size(394, 219);
            this.uncertaintyGbox.TabIndex = 5;
            this.uncertaintyGbox.TabStop = false;
            this.uncertaintyGbox.Text = "Propagation of uncertainty";
            // 
            // uncertaintyPbox
            // 
            this.uncertaintyPbox.BackColor = System.Drawing.Color.Lime;
            this.uncertaintyPbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uncertaintyPbox.Location = new System.Drawing.Point(3, 23);
            this.uncertaintyPbox.Name = "uncertaintyPbox";
            this.uncertaintyPbox.Size = new System.Drawing.Size(388, 193);
            this.uncertaintyPbox.TabIndex = 0;
            this.uncertaintyPbox.TabStop = false;
            // 
            // popularityGbox
            // 
            this.popularityGbox.Controls.Add(this.popularityPbox);
            this.popularityGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popularityGbox.Location = new System.Drawing.Point(3, 228);
            this.popularityGbox.Name = "popularityGbox";
            this.popularityGbox.Size = new System.Drawing.Size(394, 219);
            this.popularityGbox.TabIndex = 6;
            this.popularityGbox.TabStop = false;
            this.popularityGbox.Text = "Popularity algorithm";
            // 
            // popularityPbox
            // 
            this.popularityPbox.BackColor = System.Drawing.Color.Yellow;
            this.popularityPbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popularityPbox.Location = new System.Drawing.Point(3, 23);
            this.popularityPbox.Name = "popularityPbox";
            this.popularityPbox.Size = new System.Drawing.Size(388, 193);
            this.popularityPbox.TabIndex = 0;
            this.popularityPbox.TabStop = false;
            // 
            // kmeansGbox
            // 
            this.kmeansGbox.Controls.Add(this.kmeansPbox);
            this.kmeansGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kmeansGbox.Location = new System.Drawing.Point(403, 228);
            this.kmeansGbox.Name = "kmeansGbox";
            this.kmeansGbox.Size = new System.Drawing.Size(394, 219);
            this.kmeansGbox.TabIndex = 7;
            this.kmeansGbox.TabStop = false;
            this.kmeansGbox.Text = "K-means algorithm";
            // 
            // kmeansPbox
            // 
            this.kmeansPbox.BackColor = System.Drawing.Color.Cyan;
            this.kmeansPbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kmeansPbox.Location = new System.Drawing.Point(3, 23);
            this.kmeansPbox.Name = "kmeansPbox";
            this.kmeansPbox.Size = new System.Drawing.Size(388, 193);
            this.kmeansPbox.TabIndex = 0;
            this.kmeansPbox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.originalImageGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalImagePbox)).EndInit();
            this.uncertaintyGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uncertaintyPbox)).EndInit();
            this.popularityGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popularityPbox)).EndInit();
            this.kmeansGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kmeansPbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private GroupBox originalImageGbox;
        private PictureBox originalImagePbox;
        private GroupBox uncertaintyGbox;
        private PictureBox uncertaintyPbox;
        private GroupBox popularityGbox;
        private PictureBox popularityPbox;
        private GroupBox kmeansGbox;
        private PictureBox kmeansPbox;
    }
}