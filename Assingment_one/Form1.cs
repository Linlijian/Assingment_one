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
        public Bitmap tmp_image;       //output image

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
            tmp_image = new Bitmap(f_image.Width, f_image.Height);


            pictureBox1.Image = f_image;
            chart(f_image, 2);
        }


        //Thresholding
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
            chart(image, 1);
            chart(f_image, 2);
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
            chart(image, 1);
            chart(f_image, 2);
        }

        private void Vertical()
        {

            int[,] arr = new int[f_image.Height, f_image.Width];
            int x, y = 0;

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    y = (-i * 1) + (j * 0);
                    x = (i * 0) + (j * 1);
                    y = (f_image.Width - 1) + y;
                    arr[y, x] = C_gray;

                    //image.SetPixel(i, j, Color.FromArgb(c, c, c));

                }
            }

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {






                    image.SetPixel(i, j, Color.FromArgb(arr[i, j], arr[i, j], arr[i, j]));

                }


            }
            pictureBox2.Image = image;
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image, 1);
            chart(f_image, 2);
        }

        //POW_LAW
        private void button1_Click(object sender, EventArgs e)
        {
            int c = 0;
            double a = Convert.ToDouble(textBox2.Text);
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
            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    //C_gray = ((C_gray - min) / (max - min)) * 255;
                    //  C_gray = C_gray + 255 / 2;
                    //c = (int)(Math.Abs(C_gray - Math.Pow(C_gray, 1.5)));
                    //c = (int)(Math.Abs(255 *Math.Pow(C_gray / 255, 5)));
                    //c = (int)(1*Math.Log(1 + C_gray));
                    c = (int)(Math.Pow(C_gray, 1/a ));
                    //c = c - min;
                    //c = 255 * c / max;
                    if (c >= 255)
                        c = 255;
                    //if (c < min)
                    //    c = c + 255 / 2;
                    //c = c + 255 / 2;
                    //c = ((c - min) / (max - min)) * 255;

                    image.SetPixel(i, j, Color.FromArgb(c, c, c));

                }
            }

            textBox1.Text = c.ToString();
            pictureBox2.Image = image;
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image, 1);
            chart(f_image, 2);


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
                if (i != 0)
                    arrCo[i] = arrCo[i] + arrCo[i - 1];
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
        int rr = 1;
        private void button1_Click_1(object sender, EventArgs e)
        {


            //Vertical();
            //Rotation270();
            Rotation90();
            //aaa();
            rr += 1;
        }

        public void Rotation90()
        {

            int[,] arr = new int[f_image.Height, f_image.Width];
            int x, y = 0;

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    y = (i * 1) + (j * 0);
                    x = (i * 0) + (-j * 1);
                    // y = (f_image.Width - 1) + y;
                    x = (f_image.Width - 1) + x;
                    arr[x, y] = C_gray;

                    //image.SetPixel(i, j, Color.FromArgb(c, c, c));

                }
            }

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {





                    image.SetPixel(i, j, Color.FromArgb(arr[i, j], arr[i, j], arr[i, j]));
                    //image.SetPixel(i, j, Color.FromArgb(arr[j, i], arr[j, i], arr[j, i]));

                }


            }
            pictureBox2.Image = image;
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image, 1);
            chart(f_image, 2);
        }

        public void Rotation270()
        {

            int[,] arr = new int[f_image.Height, f_image.Width];
            int x, y = 0;

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    y = (-i * 1) + (j * 0);
                    x = (i * 0) + (j * 1);
                    y = (f_image.Width - 1) + y;
                    arr[y, x] = C_gray;

                    //image.SetPixel(i, j, Color.FromArgb(c, c, c));

                }
            }

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {






                    image.SetPixel(i, j, Color.FromArgb(arr[j, i], arr[j, i], arr[j, i]));

                }


            }
            pictureBox2.Image = image;
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image, 1);
            chart(f_image, 2);
        }


        public void chart(Bitmap image, int c)
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
        public void aaa()
        {

            for (int y = 0; y < f_image.Width; y++)
            {
                for (int x = 0; x < f_image.Height; x++)
                {

                    Color PixelColor = f_image.GetPixel(y, x);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    // arrCo[xy] = C_gray;
                    image.SetPixel(x, y, Color.FromArgb(C_gray, C_gray, C_gray));
                    // image.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    //xy++;
                }
            }
            pictureBox2.Image = image;
        }

        private void ro90_Click(object sender, EventArgs e)
        {
            Rotation90();
        }

        private void ro270_Click(object sender, EventArgs e)
        {
            Rotation270();
        }
    }
}
