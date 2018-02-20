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
        }
    }
}
