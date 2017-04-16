using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GestureDetectionPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //public class ExtractBiggestBlob 


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.InitialDirectory = @"G:\Saarthi";
            open.Title = "Select an Image";

            open.CheckFileExists = true;
            open.CheckPathExists = true;

            open.DefaultExt = "jpg";
            open.FilterIndex = 2;
            open.RestoreDirectory = true;

            open.ReadOnlyChecked = true;
            open.ShowReadOnly = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                // Create a new Bitmap object from the picture file on disk,
                // and assign that to the PictureBox.Image property
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        int max(int x, int y, int z)
        {
            if (x > y && x > z)
                return x;
            else if (y > x && y > z)
                return y;
            else
                return z;
        }

        int min(int x, int y, int z)
        {
            if (x < y && x < z)
                return x;
            else if (y < x && y < z)
                return y;
            else
                return z;
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image, new Size(300,300));
            int width = bmp.Width;
            int height = bmp.Height;
            int[] arr = new int[225];
            int i = 0;
            Color p;

            //Grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    avg = avg < 128 ? 0 : 255;     // Converting gray pixels to either pure black or pure white
                    bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            pictureBox3.Image = bmp;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void grayscaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int width = bmp.Width;
            int height = bmp.Height;
            int[] arr = new int[225];
            int i = 0;
            Color p;

            //Grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            pictureBox3.Image = bmp;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void skinColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Extracting RGBs
            Bitmap hand = new Bitmap(pictureBox1.Image);
            Bitmap skindetect = new Bitmap(hand.Width, hand.Height);
            //Bitmap blackWhite = new Bitmap(hand.Width, hand.Height);

            Color black = Color.Black;
            //Color white = Color.White;

            int i, j;
            for (i = 0; i < hand.Width; i++)
            {
                for (j = 0; j < hand.Height; j++)
                {
                    Color pixel = hand.GetPixel(i, j);

                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;



                    /* (R, G, B) is classified as skin if: 
                        R > 95 and G > 40 and B > 20 and 
                        max {R, G, B} – min{R, G, B} > 15 and 
                        |R – G| > 15 and R > G and R > B
                    */
                    if ((red > 95 && green > 40 && blue > 20) && (max(red, green, blue) - min(red, green, blue) > 15)
                        && Math.Abs(red - green) > 15 && red > green && red > blue)
                    {
                        //Console.WriteLine("Success");
                        skindetect.SetPixel(i, j, pixel);
                        //blackWhite.SetPixel(i, j, white);
                    }
                    else
                    {
                        //skindetect.SetPixel(i, j, black);
                        //blackWhite.SetPixel(i, j, black);
                    }

                }
            }

            pictureBox2.Image = new Bitmap(skindetect);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            //pictureBox3.Image = new Bitmap(blackWhite);
            //pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void bWUsingAForgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grayscale filter = new Grayscale(0.2125, 0.71254, 0.0721);
            Bitmap grayImage = filter.Apply((Bitmap)pictureBox2.Image);
            Threshold filter2 = new Threshold(100);
            Bitmap filtered = filter2.Apply(grayImage);
            Closing close = new Closing();
            close.ApplyInPlace(filtered);
            Opening open = new Opening();
            open.ApplyInPlace(filtered);
            // create filter for the filtered image
            ExtractBiggestBlob filter3 = new ExtractBiggestBlob();
            // apply the filter
            Bitmap biggestBlobsImage = filter3.Apply(filtered);
            AForge.IntPoint a = filter3.BlobPosition;
            Console.WriteLine(a);

            //Biggest blob for old extracted sskin image
            ExtractBiggestBlob filter4 = new ExtractBiggestBlob();
            Bitmap skinBlob = new Bitmap(pictureBox2.Image);
            //apply filter
            Bitmap biggestSkinBlob = filter4.Apply(skinBlob);
            pictureBox2.Image = new Bitmap(biggestSkinBlob);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            //Skin color for largest blob
            // This mask is logically AND with original image to extract only the palm which is required for feature extraction. 
            Bitmap one = new Bitmap(biggestSkinBlob);
            Bitmap two = new Bitmap(biggestBlobsImage);

            int i, j;
            for (i = 0; i < two.Width; i++)
            {
                for (j = 0; j < two.Height; j++)
                {
                    Color pixelOne = one.GetPixel(i, j);
                    Color pixelTwo = two.GetPixel(i, j);

                    int redOne = pixelOne.R;
                    int greenOne = pixelOne.G;
                    int blueOne = pixelOne.B;

                    int redTwo = pixelTwo.R;
                    int greenTwo = pixelTwo.G;
                    int blueTwo = pixelTwo.B;

                    two.SetPixel(i, j, Color.FromArgb(redOne & redTwo, greenOne & greenTwo, blueOne & blueTwo));

                }
            }
            pictureBox3.Image = new Bitmap(two);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void processingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unlockAndMarshalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap processedBitmap = new Bitmap(pictureBox2.Image);
            BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

            int bytesPerPixel = Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * processedBitmap.Height;
            byte[] pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;

            for (int y = 0; y < heightInPixels; y++)
            {
                int currentLine = y * bitmapData.Stride;
                for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                {
                    int oldBlue = pixels[currentLine + x];
                    int oldGreen = pixels[currentLine + x + 1];
                    int oldRed = pixels[currentLine + x + 2];

                    // calculate new pixel value
                    pixels[currentLine + x] = (byte)oldBlue;
                    pixels[currentLine + x + 1] = (byte)oldGreen;
                    pixels[currentLine + x + 2] = (byte)oldRed;
                }
            }

            // copy modified bytes back
            Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
            processedBitmap.UnlockBits(bitmapData);
            pictureBox3.Image = new Bitmap(processedBitmap);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

        }


        private void parallelPlus3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap processedBitmap = new Bitmap(pictureBox2.Image);
            /*
             * unsafe
            {
                BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        currentLine[x] = (byte)oldBlue;
                        currentLine[x + 1] = (byte)oldGreen;
                        currentLine[x + 2] = (byte)oldRed;
                    }
                });
                processedBitmap.UnlockBits(bitmapData);
            }
            */
        }

        private void recolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }
    }
}

