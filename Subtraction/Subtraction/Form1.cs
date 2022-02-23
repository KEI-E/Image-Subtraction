using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subtraction
{
    public partial class Form1 : Form
    {
        Bitmap imageB, imageA, resultImage;

        private void loadImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            imageB = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = imageB;
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            imageA = new Bitmap(openFileDialog2.FileName);
            pictureBox2.Image = imageA;
        }

        private void loadBg_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();

        }

        private void subtract_Click(object sender, EventArgs e)
        {
            resultImage = new Bitmap(imageB.Width, imageB.Height);

            Color myGreen = Color.FromArgb(0, 0, 255);
            int greyGreen = (myGreen.R + myGreen.G + myGreen.B) / 3;
            int threshold = 50;

            //Explore all pixel
            for (int i = 0; i < imageB.Width; i++)
                for (int j = 0; j < imageB.Height; j++)
                {
                    Color pixel = imageB.GetPixel(i, j);
                    Color backPixel = imageA.GetPixel(i, j);
                    int grey = (pixel.R + pixel.R + pixel.B) / 3;
                    int subtractValue = Math.Abs(grey - greyGreen);

                    if(subtractValue > threshold)
                        resultImage.SetPixel(i, j, backPixel);
                    else
                        resultImage.SetPixel(i, j, pixel);
                }

            pictureBox3.Image = resultImage;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
