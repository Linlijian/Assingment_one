using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assingment_one
{
    public partial class Form1 : Form
    {
        private Bitmap f_image = null;  //input image
        public Bitmap image;       //output image
        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileImage = new OpenFileDialog();
            OpenFileImage.Filter = "bitmap (*.bmp)|*.bmp";
            OpenFileImage.FilterIndex = 1;
            if (OpenFileImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (f_image != null)
                        f_image.Dispose();
                    f_image = (Bitmap)Bitmap.FromFile(OpenFileImage.FileName, false);

                }
                catch (Exception)
                {
                    MessageBox.Show("Can not open file”, “File Error");
                }
            }
            image = new Bitmap(f_image.Width, f_image.Height);


            pictureBox1.Image = f_image;
            chart(f_image, 2);
        }

        private void Thresholding_Click(object sender, EventArgs e)
        {
            //threshold
            int avg = 0;
            int sum = 0;
            int lastC = 0;

            // Loop through the images pixels
            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    avg += C_gray;
                    sum += 1;

                    //check color
                    lastC = C_gray;

                }
            }
            int tmp = avg / sum;
            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    if (C_gray >= tmp)
                    {
                        image.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        image.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }

                }
            }
            pictureBox2.Image = image;
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image,1);
            chart(f_image,2);
        }

        private void ContrastStretching_Click(object sender, EventArgs e)
        {
            //search min.max
            int max = 0;
            int min = 255;
            int R = 0;
            int p = 0;
            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    if (C_gray > max)
                    {
                        max = C_gray;
                    }
                    else if (C_gray < min)
                    {
                        min = C_gray;
                    }

                }
            }
            R = max - min;

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    if (C_gray <= min)
                    {
                        image.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else if (C_gray >= max)
                    {
                        image.SetPixel(i, j, Color.FromArgb(max, max, max));
                    }
                    else
                    {
                        p = 255 * (C_gray - min) / R;
                        image.SetPixel(i, j, Color.FromArgb(p, p, p));
                    }
                }
            }

            pictureBox2.Image = image;
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image,1);
            chart(f_image,2);
        }

        private void a()
        {
            int a1 = 4;
            double aa = 5;
            
            double a = (a1 / aa);
            textBox2.Text = a.ToString();
            int q = (int)(Math.Round(a, MidpointRounding.AwayFromZero));
            textBox1.Text = q.ToString();
        }

        //POW_LAW
        private void button1_Click(object sender, EventArgs e)
        {
            int c = 0;
            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;

                    c = (int)(Math.Abs(C_gray - Math.Pow(C_gray, 2)));
                    //c = (int)(1*Math.Log(1 + C_gray));

                    if (c >= 255)
                        c = 255;

                     image.SetPixel(i, j, Color.FromArgb(c, c, c));
                    
                }
            }

            textBox1.Text = c.ToString();
            pictureBox2.Image = image;
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image,1);
            chart(f_image,2);


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void HIT_Click(object sender, EventArgs e)
        {

            int[] arrCo = new int[255];
            double[] arrNco = new double[255];

            double a = 0;
            double max = f_image.Width * f_image.Height;

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    if (C_gray >= 254)
                        C_gray = 254;
                    arrCo[C_gray] += 1;

                }
            }

            for (int i = 0; i < arrCo.Length; i++)
            {
                if(i!=0)
                    arrCo[i] = arrCo[i] + arrCo[i-1];
            }

            for (int i = 0; i < arrCo.Length; i++)
            {
                arrNco[i] = (arrCo[i] / max) * 255;
            }

            for (int i = 0; i < arrNco.Length; i++)
            {
                arrCo[i] = (int)(Math.Round(arrNco[i], MidpointRounding.AwayFromZero));
            }


            for (int i = 0; i < arrCo.Length; i++)
            {
                this.chart1.Series["Series1"].Points.AddXY(i, arrCo[i]);
            }

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    image.SetPixel(i, j, Color.FromArgb(arrCo[C_gray], arrCo[C_gray], arrCo[C_gray]));

                }
            }
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image, 1);
            chart(f_image, 2);
            pictureBox2.Image = image;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            a();
            chart1.Series["Series1"].Points.AddXY("a", 25);
            chart1.Series["Series1"].Points.AddXY("4111", 31);
            chart1.Series["Series1"].Points.AddXY("r", 31);
        }

        public void chart(Bitmap image,int c)
        {
            int[] arrCo = new int[255];
            int[] arrNco = new int[255];

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {

                    Color PixelColor = image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    if (C_gray >= 254)
                        C_gray = 254;
                    arrCo[C_gray] += 1;

                }
            }
            if (c == 1)
            {
                for (int i = 0; i < arrCo.Length; i++)
                {
                    this.chart1.Series["Series1"].Points.AddXY(i, arrCo[i]);
                }
            }
            else
            {
                for (int i = 0; i < arrCo.Length; i++)
                {
                    this.chart2.Series["Series1"].Points.AddXY(i, arrCo[i]);
                }
            }
           // this.chart1.Series["Series1"].Points.Clear();
           // this.chart2.Series["Series1"].Points.Clear();
            arrCo = null;
            arrNco = null;

        }
    }
}
