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
using System.IO;

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
            open.Title = "Open Image";

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

        Size newSize = new Size(360, 360);

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image, newSize);
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

        static int blockSize = 6;

        private void skinColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Extracting RGBs
            Bitmap hand = new Bitmap(pictureBox1.Image, newSize);
            Bitmap skinDetect = new Bitmap(hand.Width, hand.Height);
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
                        skinDetect.SetPixel(i, j, pixel);
                    }
                }
            }
            pictureBox2.Image = new Bitmap(skinDetect);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            Grayscale filter = new Grayscale(0.2125, 0.71254, 0.0721);
            Bitmap grayImage = filter.Apply(skinDetect);
            Threshold filter2 = new Threshold(100);
            Bitmap filteredImage = filter2.Apply(grayImage);
            Closing close = new Closing();
            close.ApplyInPlace(filteredImage);
            Opening open = new Opening();
            open.ApplyInPlace(filteredImage);
            // create filter for the filtered image
            ExtractBiggestBlob filter3 = new ExtractBiggestBlob();
            // apply the filter
            Bitmap biggestBlobsImage = filter3.Apply(filteredImage);
            AForge.IntPoint a = filter3.BlobPosition;
            Console.WriteLine(a);

            //Biggest blob for old extracted skin image
            ExtractBiggestBlob filter4 = new ExtractBiggestBlob();
            Bitmap skinBlob = new Bitmap(skinDetect);
            //apply filter
            Bitmap biggestSkinBlob = filter4.Apply(skinBlob);

            //Skin color for largest blob
            Bitmap one = new Bitmap(biggestSkinBlob);
            Bitmap two = new Bitmap(biggestBlobsImage);

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

                    // This mask is logically AND with original image to extract only the palm which is required for feature extraction. 
                    two.SetPixel(i, j, Color.FromArgb(redOne & redTwo, greenOne & greenTwo, blueOne & blueTwo));
                }
            }

            //Getting a grayscae image from the recolored image
            Bitmap getGrayImage = filter.Apply(two);
            // create filter
            CannyEdgeDetector filter1 = new CannyEdgeDetector();
            filter1.LowThreshold = 0;
            filter1.HighThreshold = 0;
            filter1.GaussianSigma = 1.4;
            // apply the filter
            Bitmap cannyEdgeImage = filter1.Apply(getGrayImage);

            Bitmap resizeImage = new Bitmap(360, 360);
            using (var graphics = Graphics.FromImage(resizeImage))
                graphics.DrawImage(cannyEdgeImage, 0, 0, 360, 360);

            pictureBox3.Image = new Bitmap(resizeImage);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            int x, y;
            //Image to obtain blocks for
            Bitmap imageWithBlock = new Bitmap(resizeImage);
            Console.WriteLine("Width = " + resizeImage.Width + " Height = " + resizeImage.Height);
            int imageHeightSize = resizeImage.Height / blockSize;
            int imageWidthSize = resizeImage.Width / blockSize;
            Console.WriteLine("Width = " + imageWidthSize + " Height = " + imageHeightSize);

            List<int> featureVector = new List<int>();

            double totalPixelCount = 0;

            for (i = 0; i < blockSize; i++)
            {
                for (j = 0; j < blockSize; j++)
                {
                    int whiteEdgeCount = 0, blackEdgeCount = 0;
                    for (x = i * imageWidthSize; x < (i * imageWidthSize) + imageWidthSize; x++)
                    {
                        for (y = j * imageHeightSize; y < (j * imageHeightSize) + imageHeightSize; y++)
                        {
                            // To count the edges in the range
                            Color singlePixel = imageWithBlock.GetPixel(x, y);

                            int red = singlePixel.R;
                            int green = singlePixel.G;
                            int blue = singlePixel.B;

                            if (singlePixel != Color.FromArgb(Color.Black.ToArgb()))
                            {
                                whiteEdgeCount++;
                            }
                            else
                            {
                                blackEdgeCount++;
                            }
                        }
                    }
                    //Console.WriteLine("White = " + whiteEdgeCount + "    Black = " + blackEdgeCount);
                    //Add value to total count
                    totalPixelCount += whiteEdgeCount;
                    // whiteCount = edges in range
                    featureVector.Add(whiteEdgeCount);
                }
            }
            //Calculate Normalization and add the value to the featureNormVector
            List<double> featureNormVector = new List<double>();

            //Total Pixel Count
            //Console.WriteLine(totalPixelCount);

            //Normalization
            for (i = 0; i < featureVector.Count; i++)
            {
                double normalizedValue = featureVector[i] / totalPixelCount;
                Console.WriteLine(normalizedValue);
                featureNormVector.Add(normalizedValue);
            }
        }
        //Bitmap list
        List<Bitmap> bitmapList = new List<Bitmap>();

        private Bitmap performSkinExtract(Bitmap picture)
        {
            //Extracting RGBs
            Bitmap hand = new Bitmap(picture);
            Bitmap skinDetect = new Bitmap(hand.Width, hand.Height);
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
                        skinDetect.SetPixel(i, j, pixel);
                    }
                }
            }
            return skinDetect;
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            List<String> imagesList = new List<String>();
            int i, j;

            DialogResult result = folderDialog.ShowDialog();
            
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                DirectoryInfo directoryName = new DirectoryInfo(folderDialog.SelectedPath);
                //Console.WriteLine(directoryName);
                FileInfo[] imagesData = directoryName.GetFiles("*.jpg");
                //System.Windows.Forms.MessageBox.Show("Files found: " + imagesData.Length.ToString(), "Message");

                //Console.WriteLine(imagesData.Length);
                for (i = 0; i < imagesData.Length; i++)
                {
                    //Image path
                    imagesList.Add(String.Format(@"{0}\{1}", directoryName, imagesData[i].Name));
                    //Console.WriteLine(String.Format(@"{0}\{1}", directoryName, imagesData[i].Name));
                }
            }

            List<Bitmap> bitmapList = new List<Bitmap>();

            foreach (var path in imagesList)
            {
                Bitmap img = new Bitmap(path);
                bitmapList.Add(img);
            }

            List<List<double>> features = new List<List<double>>();
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"G:\Saarthi\TrainingFile.txt", append: true);
            String alphabets = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (var image in bitmapList)
            {
                List<double> feature = automateFeatureNormalizationExtraction(image);
                features.Add(feature);
            }

            //Converting 2D List to a 2D Array
            double[][] featuresArray = features.Select(a => a.ToArray()).ToArray();

            //Creating and writing to that file
            for (i = 0; i < featuresArray.Length; i++)
                for (j = 0; j < featuresArray.Length; j++)
                    ;//System.IO.File.WriteAllLines(@"G:\Saarthi\TrainingFile.txt", featuresArray[i][j].ToString());
            string fileName = @"G:\Saarthi\TrainingFile.txt";

            try
            {
                // Check if file already exists. If yes, delete it. 
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file 
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private List<double> automateFeatureNormalizationExtraction(Bitmap rawBitmapData)
        {
            Bitmap afterSkinOnly = performSkinExtract(rawBitmapData);

            Grayscale filter = new Grayscale(0.2125, 0.71254, 0.0721);
            Bitmap grayImage = filter.Apply(afterSkinOnly);
            Threshold filter2 = new Threshold(100);
            Bitmap filteredImage = filter2.Apply(grayImage);
            Closing close = new Closing();
            close.ApplyInPlace(filteredImage);
            Opening open = new Opening();
            open.ApplyInPlace(filteredImage);
            // create filter for the filtered image
            ExtractBiggestBlob filter3 = new ExtractBiggestBlob();
            // apply the filter
            Bitmap biggestBlobsImage = filter3.Apply(filteredImage);
            AForge.IntPoint a = filter3.BlobPosition;
            //Console.WriteLine(a);

            //Biggest blob for old extracted skin image
            ExtractBiggestBlob filter4 = new ExtractBiggestBlob();
            Bitmap skinBlob = new Bitmap(afterSkinOnly);
            //apply filter
            Bitmap biggestSkinBlob = filter4.Apply(skinBlob);

            //Skin color for largest blob
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

                    // This mask is logically AND with original image to extract only the palm which is required for feature extraction. 
                    two.SetPixel(i, j, Color.FromArgb(redOne & redTwo, greenOne & greenTwo, blueOne & blueTwo));
                }
            }

            //Getting a grayscae image from the recolored image
            Bitmap getGrayImage = filter.Apply(two);
            // create filter
            CannyEdgeDetector filter1 = new CannyEdgeDetector();
            filter1.LowThreshold = 0;
            filter1.HighThreshold = 0;
            filter1.GaussianSigma = 1.4;
            // apply the filter
            Bitmap cannyEdgeImage = filter1.Apply(getGrayImage);

            Bitmap resizeImage = new Bitmap(360, 360);
            using (var graphics = Graphics.FromImage(resizeImage))
                graphics.DrawImage(cannyEdgeImage, 0, 0, 360, 360);

            pictureBox3.Image = new Bitmap(resizeImage);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            int x, y;
            //Image to obtain blocks for
            Bitmap imageWithBlock = new Bitmap(resizeImage);
            //Console.WriteLine("Width = " + resizeImage.Width + " Height = " + resizeImage.Height);
            int imageHeightSize = resizeImage.Height / blockSize;
            int imageWidthSize = resizeImage.Width / blockSize;
            //Console.WriteLine("Width = " + imageWidthSize + " Height = " + imageHeightSize);

            List<int> featureVector = new List<int>();

            double totalPixelCount = 0;

            for (i = 0; i < blockSize; i++)
            {
                for (j = 0; j < blockSize; j++)
                {
                    int whiteEdgeCount = 0, blackEdgeCount = 0;
                    for (x = i * imageWidthSize; x < (i * imageWidthSize) + imageWidthSize; x++)
                    {
                        for (y = j * imageHeightSize; y < (j * imageHeightSize) + imageHeightSize; y++)
                        {
                            // To count the edges in the range
                            Color singlePixel = imageWithBlock.GetPixel(x, y);

                            int red = singlePixel.R;
                            int green = singlePixel.G;
                            int blue = singlePixel.B;

                            if (singlePixel != Color.FromArgb(Color.Black.ToArgb()))
                            {
                                whiteEdgeCount++;
                            }
                            else
                            {
                                blackEdgeCount++;
                            }
                        }
                    }
                    //Console.WriteLine("White = " + whiteEdgeCount + "    Black = " + blackEdgeCount);
                    //Add value to total count
                    totalPixelCount += whiteEdgeCount;
                    // whiteCount = edges in range
                    featureVector.Add(whiteEdgeCount);
                }
            }
            //Calculate Normalization and add the value to the featureNormVector
            List<double> featureNormVector = new List<double>();

            //Total Pixel Count
            //Console.WriteLine(totalPixelCount);

            //Normalization
            for (i = 0; i < featureVector.Count; i++)
            {
                double normalizedValue = featureVector[i] / totalPixelCount;
                Console.WriteLine(normalizedValue);
                featureNormVector.Add(normalizedValue);
            }
            Console.WriteLine("Total count of norm(individual)=" + i);
            return featureNormVector;
        }

    }
}


