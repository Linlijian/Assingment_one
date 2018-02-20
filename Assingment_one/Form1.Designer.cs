namespace Assingment_one
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
            this.open = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Thresholding = new System.Windows.Forms.Button();
            this.ContrastStretching = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.POW_LAW = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(703, 44);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 0;
            this.open.Text = "open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(26, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(304, 44);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // Thresholding
            // 
            this.Thresholding.Location = new System.Drawing.Point(699, 159);
            this.Thresholding.Name = "Thresholding";
            this.Thresholding.Size = new System.Drawing.Size(95, 23);
            this.Thresholding.TabIndex = 4;
            this.Thresholding.Text = "Thresholding";
            this.Thresholding.UseVisualStyleBackColor = true;
            this.Thresholding.Click += new System.EventHandler(this.Thresholding_Click);
            // 
            // ContrastStretching
            // 
            this.ContrastStretching.Location = new System.Drawing.Point(687, 188);
            this.ContrastStretching.Name = "ContrastStretching";
            this.ContrastStretching.Size = new System.Drawing.Size(107, 24);
            this.ContrastStretching.TabIndex = 5;
            this.ContrastStretching.Text = "Contrast stretching";
            this.ContrastStretching.UseVisualStyleBackColor = true;
            this.ContrastStretching.Click += new System.EventHandler(this.ContrastStretching_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(659, 274);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // POW_LAW
            // 
            this.POW_LAW.Location = new System.Drawing.Point(702, 330);
            this.POW_LAW.Name = "POW_LAW";
            this.POW_LAW.Size = new System.Drawing.Size(75, 23);
            this.POW_LAW.TabIndex = 7;
            this.POW_LAW.Text = "POW_LAW";
            this.POW_LAW.UseVisualStyleBackColor = true;
            this.POW_LAW.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(550, 345);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 388);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.POW_LAW);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ContrastStretching);
            this.Controls.Add(this.Thresholding);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.open);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Thresholding;
        private System.Windows.Forms.Button ContrastStretching;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button POW_LAW;
        private System.Windows.Forms.TextBox textBox2;
    }
}

