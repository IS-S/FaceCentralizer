
using FC.Core;
using System.Drawing;
using System.IO;
using System;

namespace FC.DataProvider
{
    public class PhotoProvider : IPhotoProvider
    {
        public byte[] Get(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] imgByte = new byte[fs.Length];
                fs.Read(imgByte, 0, Convert.ToInt32(fs.Length));
                return imgByte;
            }
/*
            Mat image = CvInvoke.Imread(path,Emgu.CV.CvEnum.ImreadModes.Color) ;

            byte[] imgByte = new byte[image.NumberOfChannels * image.Cols * image.Rows];

            return imgByte;
*/
        }

#pragma warning disable CA1416 // Validate platform compatibility

        public Bitmap GetBitmap(string path)
        {
            Bitmap image = (Bitmap)Image.FromFile(path);

            return image;
        }

        public void Post(Bitmap imageDataBig, Bitmap imageDataSmall, string path)
        {
            //        C:/Users/i.sumin/Pictures/test2.jpg

            path.LastIndexOf("/");
            var fileName = path.Substring(path.LastIndexOf("/")+1).Split(".")[0];


            imageDataBig.Save("C:/Users/i.sumin/Pictures/PHFORTEST/" + fileName + "OutputB.jpg", format: System.Drawing.Imaging.ImageFormat.Jpeg);
            imageDataSmall.Save("C:/Users/i.sumin/Pictures/PHFORTEST/" + fileName + "OutputS.jpg", format: System.Drawing.Imaging.ImageFormat.Jpeg);

#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}
