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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.open = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Thresholding = new System.Windows.Forms.Button();
            this.ContrastStretching = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.POW_LAW = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.HIT = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.ro90 = new System.Windows.Forms.Button();
            this.ro270 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
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
            this.textBox1.Location = new System.Drawing.Point(433, 345);
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
            // HIT
            // 
            this.HIT.Location = new System.Drawing.Point(703, 256);
            this.HIT.Name = "HIT";
            this.HIT.Size = new System.Drawing.Size(75, 23);
            this.HIT.TabIndex = 9;
            this.HIT.Text = "HIT";
            this.HIT.UseVisualStyleBackColor = true;
            this.HIT.Click += new System.EventHandler(this.HIT_Click);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(49, 429);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(664, 144);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(49, 579);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(664, 135);
            this.chart2.TabIndex = 10;
            this.chart2.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(719, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ro90
            // 
            this.ro90.Location = new System.Drawing.Point(537, 399);
            this.ro90.Name = "ro90";
            this.ro90.Size = new System.Drawing.Size(75, 23);
            this.ro90.TabIndex = 12;
            this.ro90.Text = "90";
            this.ro90.UseVisualStyleBackColor = true;
            this.ro90.Click += new System.EventHandler(this.ro90_Click);
            // 
            // ro270
            // 
            this.ro270.Location = new System.Drawing.Point(638, 399);
            this.ro270.Name = "ro270";
            this.ro270.Size = new System.Drawing.Size(75, 23);
            this.ro270.TabIndex = 13;
            this.ro270.Text = "270";
            this.ro270.UseVisualStyleBackColor = true;
            this.ro270.Click += new System.EventHandler(this.ro270_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 746);
            this.Controls.Add(this.ro270);
            this.Controls.Add(this.ro90);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.HIT);
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
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
        private System.Windows.Forms.Button HIT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ro90;
        private System.Windows.Forms.Button ro270;
    }
}

