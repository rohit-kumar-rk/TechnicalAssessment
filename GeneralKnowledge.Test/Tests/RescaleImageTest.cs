using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            // TODO
            // Grab an image from a public URL and write a function that rescales the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)

            int maxWidth = 1200;
            int maxHeight = 1600;
            string filePath = @"D:\TestingImage";
            string inputFile = @"D:\TestingImage\test1.jpg";

            Bitmap image = new Bitmap(Path.Combine(filePath, inputFile));

            var res = resizeImage(image, maxWidth, maxHeight);
            var fileName = "OutputFile" + DateTime.Now.Date.ToString("ddMMyyyyThhMMss") + ".jpg";
            res.Save(Path.Combine(filePath, fileName));

            Console.WriteLine("\nImage Resized");
        }

        public static Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }
    }
}
