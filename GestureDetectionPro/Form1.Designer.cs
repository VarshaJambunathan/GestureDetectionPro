namespace GestureDetectionPro
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bWUsingAForgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largestBlobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockAndMarshalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockDMAUnsafeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parallelPlus3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recolorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.skinColorToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.processingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // skinColorToolStripMenuItem
            // 
            this.skinColorToolStripMenuItem.Name = "skinColorToolStripMenuItem";
            this.skinColorToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.skinColorToolStripMenuItem.Text = "Skin Color";
            this.skinColorToolStripMenuItem.Click += new System.EventHandler(this.skinColorToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleToolStripMenuItem,
            this.grayscaleToolStripMenuItem1,
            this.bWUsingAForgeToolStripMenuItem,
            this.largestBlobToolStripMenuItem,
            this.recolorToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.grayscaleToolStripMenuItem.Text = "Black and White";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem1
            // 
            this.grayscaleToolStripMenuItem1.Name = "grayscaleToolStripMenuItem1";
            this.grayscaleToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.grayscaleToolStripMenuItem1.Text = "Grayscale";
            this.grayscaleToolStripMenuItem1.Click += new System.EventHandler(this.grayscaleToolStripMenuItem1_Click);
            // 
            // bWUsingAForgeToolStripMenuItem
            // 
            this.bWUsingAForgeToolStripMenuItem.Name = "bWUsingAForgeToolStripMenuItem";
            this.bWUsingAForgeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.bWUsingAForgeToolStripMenuItem.Text = "BW using AForge";
            this.bWUsingAForgeToolStripMenuItem.Click += new System.EventHandler(this.bWUsingAForgeToolStripMenuItem_Click);
            // 
            // largestBlobToolStripMenuItem
            // 
            this.largestBlobToolStripMenuItem.Name = "largestBlobToolStripMenuItem";
            this.largestBlobToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.largestBlobToolStripMenuItem.Text = "Largest Blob";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 354);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(320, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 300);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(626, 28);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(300, 300);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setGetToolStripMenuItem,
            this.unlockAndMarshalToolStripMenuItem,
            this.lockDMAUnsafeToolStripMenuItem,
            this.parallelPlus3ToolStripMenuItem});
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.processingToolStripMenuItem.Text = "Processing";
            this.processingToolStripMenuItem.Click += new System.EventHandler(this.processingToolStripMenuItem_Click);
            // 
            // setGetToolStripMenuItem
            // 
            this.setGetToolStripMenuItem.Name = "setGetToolStripMenuItem";
            this.setGetToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.setGetToolStripMenuItem.Text = "Set and Get";
            // 
            // unlockAndMarshalToolStripMenuItem
            // 
            this.unlockAndMarshalToolStripMenuItem.Name = "unlockAndMarshalToolStripMenuItem";
            this.unlockAndMarshalToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.unlockAndMarshalToolStripMenuItem.Text = "Lock and marshal";
            this.unlockAndMarshalToolStripMenuItem.Click += new System.EventHandler(this.unlockAndMarshalToolStripMenuItem_Click);
            // 
            // lockDMAUnsafeToolStripMenuItem
            // 
            this.lockDMAUnsafeToolStripMenuItem.Name = "lockDMAUnsafeToolStripMenuItem";
            this.lockDMAUnsafeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.lockDMAUnsafeToolStripMenuItem.Text = "Lock DMA Unsafe";
            // 
            // parallelPlus3ToolStripMenuItem
            // 
            this.parallelPlus3ToolStripMenuItem.Name = "parallelPlus3ToolStripMenuItem";
            this.parallelPlus3ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.parallelPlus3ToolStripMenuItem.Text = "Parallel plus 3";
            this.parallelPlus3ToolStripMenuItem.Click += new System.EventHandler(this.parallelPlus3ToolStripMenuItem_Click);
            // 
            // recolorToolStripMenuItem
            // 
            this.recolorToolStripMenuItem.Name = "recolorToolStripMenuItem";
            this.recolorToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.recolorToolStripMenuItem.Text = "recolor";
            this.recolorToolStripMenuItem.Click += new System.EventHandler(this.recolorToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 382);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skinColorToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bWUsingAForgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largestBlobToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockAndMarshalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockDMAUnsafeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parallelPlus3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recolorToolStripMenuItem;
    }
}

