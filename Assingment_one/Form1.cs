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
            int lastC = 0;

            // Loop through the images pixels
            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    avg += C_gray;
                    
                    //check color
                    lastC = C_gray;

                }
            }
            int tmp = avg / (f_image.Width * f_image.Height);
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
            textBox1.Text = tmp.ToString();
        }
        public void Con_Stre()
        {
            int p = 0;
            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
                    //p = Calslope(C_gray);
                    p = Calslope2(C_gray);
                    image.SetPixel(i, j, Color.FromArgb(p, p, p));

                }
            }
            pictureBox2.Image = image;
          
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image, 1);
            chart(f_image, 2);
        }
        public int Calslope(int m)
        {
            if(m >= 150)
            {
               // return m = (105 * m) / 55 - 50;
                return 255;
                //return m = (105 * m - 50) / 55;
            }
            else if(m <= 100 )
            {
                //return m = (50 / 150) * m + 50;
                //return m = (50 * m) / 150 + 100;
                //return m = (50 * m + 100) / 150;
                //return m = (50 * m - 100) / 150;
                return 0;
            }
            else
            {
                //return m = m * 2;
                //return m = (255 *( m - 255)) / 150;
                return m = (m - 100) * ((255 / (150 - 100)) + 0);

            }
           
            
        }
        public int Calslope2(int m)
        {
            if (m > 150)
            {
                // return m = (105 * m) / 55 - 50;
                //return m = (m - 150) * ((255 / (255 - 150)) + 0);
                //return m = (105 * m - 50) / 55;
                return m = ((55 / 105) * m) + (255 - ((55 / 105) * 255));
            }
            else if (m >= 100)
            {
                //return m = (50 / 150) * m + 50;
                //return m = (50 * m) / 150 + 100;
                //return m = (50 * m + 100) / 150;
                //return m = (50 * m - 100) / 150;
                //return m = (m - 0) * ((100 / (100 - 0)) + 0);
                return m = ((150 / 50) * m) + (200 - ((150 / 50) * 150));
            }
            else
            {
                //return m = m * 2;
                //return m = (255 *( m - 255)) / 150;
                //return m = (m - 100) * ((255 / (150 - 100)) + 0);
                return m = ((50 / 100) * m) + (50 - ((50 / 100) * 100));
            }


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
                    if (C_gray <= 100)
                    {
                        image.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else if (C_gray >= 200)
                    {
                        image.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        p = 255 * (C_gray - min) / R;
                        image.SetPixel(i, j, Color.FromArgb(p, p, p));
                    }
                }
            }

            pictureBox2.Image = image;
            textBox1.Text = min.ToString();
            textBox2.Text = max.ToString();
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
            Pow_law();
            //int c = 0;
            //double a = Convert.ToDouble(textBox2.Text);
            ////search min.max
            //int max = 0;
            //int min = 255;
            //int R = 0;
            //int p = 0;
            //for (int i = 0; i < f_image.Width; i++)
            //{
            //    for (int j = 0; j < f_image.Height; j++)
            //    {

            //        Color PixelColor = f_image.GetPixel(i, j);
            //        int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
            //        if (C_gray > max)
            //        {
            //            max = C_gray;
            //        }
            //        else if (C_gray < min)
            //        {
            //            min = C_gray;
            //        }

            //    }
            //}
            //for (int i = 0; i < f_image.Width; i++)
            //{
            //    for (int j = 0; j < f_image.Height; j++)
            //    {

            //        Color PixelColor = f_image.GetPixel(i, j);
            //        int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;
            //        //C_gray = ((C_gray - min) / (max - min)) * 255;
            //        //  C_gray = C_gray + 255 / 2;
            //        //c = (int)(Math.Abs(C_gray - Math.Pow(C_gray, 1.5)));
            //        //c = (int)(Math.Abs(255 *Math.Pow(C_gray / 255, 5)));
            //        //c = (int)(1*Math.Log(1 + C_gray));
            //        c = (int)(Math.Pow(C_gray, 1 / a));
            //        //c = c - min;
            //        //c = 255 * c / max;
            //        if (c >= 255)
            //            c = 255;
            //        //if (c < min)
            //        //    c = c + 255 / 2;
            //        //c = c + 255 / 2;
            //        //c = ((c - min) / (max - min)) * 255;

            //        image.SetPixel(i, j, Color.FromArgb(c, c, c));

            //    }
            //}

            //textBox1.Text = c.ToString();
            //pictureBox2.Image = image;
            //this.chart1.Series["Series1"].Points.Clear();
            //this.chart2.Series["Series1"].Points.Clear();
            //chart(image, 1);
            //chart(f_image, 2);


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void HIT_Click(object sender, EventArgs e)
        {

            int[] arrCo = new int[256];
            double[] arrNco = new double[256];

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
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Pow_law();
            Con_Stre();
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
                    x = (f_image.Width - 1) + x;
                    arr[x, y] = C_gray;
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
            arrCo = null;
            arrNco = null;

        }

        private void ro90_Click(object sender, EventArgs e)
        {
            Rotation270();
        }

        private void ro270_Click(object sender, EventArgs e)
        {
            Rotation90();
        }

        public void Pow_law()
        {
            int c = 0;
            int[] arr = new int[f_image.Height * f_image.Width];
            double a = Convert.ToDouble(textBox2.Text);
            int max = 0;
            int min = 255;
            int p = 0;

            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {

                    Color PixelColor = f_image.GetPixel(i, j);
                    int C_gray = (int)(PixelColor.R + PixelColor.G + PixelColor.B) / 3;

                    arr[p] = (int)(Math.Pow(C_gray, a));
                    if (arr[p] > max)
                    {
                        max = arr[p];
                    }
                    else if (arr[p] < min)
                    {
                        min = arr[p];
                    }
                    //image.SetPixel(i, j, Color.FromArgb(arr[p], arr[p], arr[p]));
                    p++;

                }
            }


            p = 0;
            for (int i = 0; i < f_image.Width; i++)
            {
                for (int j = 0; j < f_image.Height; j++)
                {


                    c = (arr[p] * 255 / max);
                    if (c < 0)
                        c = c * -1;
                    p++;
                    image.SetPixel(i, j, Color.FromArgb(c, c, c));

                }
            }
            textBox1.Text = min.ToString();
            textBox3.Text = max.ToString();
            pictureBox2.Image = image;
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            chart(image, 1);
            chart(f_image, 2);
        }
    }
}
