
using FC.Core;
using System.Drawing;
using System.IO;
using System;
using System.Drawing.Imaging;

namespace FC.DataProvider
{
    public class PhotoProvider : IPhotoProvider
    {
        public byte[] Get(string path)
        {
            Image img = Image.FromFile(path);

            var o = checkPropertyItem(path);

            switch (o)
            {
                case 2:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    break;
                case 3:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    break;
                case 4:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    break;
                case 5:
                    img.RotateFlip(RotateFlipType.Rotate90FlipX);
                    break;
                case 6:
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 7:
                    img.RotateFlip(RotateFlipType.Rotate90FlipY);
                    break;
                case 8:
                    img.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    break;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }

            /*
             * C:/Users/i.sumin/Pictures/PHFORTEST/106140.jpeg
                        using (FileStream fs = File.OpenRead(path))
                        {
                            byte[] imgByte = new byte[fs.Length];
                            fs.Read(imgByte, 0, Convert.ToInt32(fs.Length));
                            return imgByte;
                        }

                        Mat image = CvInvoke.Imread(path,Emgu.CV.CvEnum.ImreadModes.Color) ;

                        byte[] imgByte = new byte[image.NumberOfChannels * image.Cols * image.Rows];

                        return imgByte;
            */

        }

#pragma warning disable CA1416 // Validate platform compatibility

        public Bitmap GetBitmap(string path)
        {
            Bitmap img = (Bitmap)Image.FromFile(path);

            var o = checkPropertyItem(path);

            switch (o)
            {
                case 2:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    break;
                case 3:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    break;
                case 4:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    break;
                case 5:
                    img.RotateFlip(RotateFlipType.Rotate90FlipX);
                    break;
                case 6:
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 7:
                    img.RotateFlip(RotateFlipType.Rotate90FlipY);
                    break;
                case 8:
                    img.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    break;
            }

            return img;
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
        public void Post(Bitmap imageDataSmall, string path, int count)
        {
            path.LastIndexOf("/");
            var fileName = path.Substring(path.LastIndexOf("/") + 1).Split(".")[0];

            imageDataSmall.Save("C:/Users/i.sumin/Pictures/PHFORTEST/" + fileName + count.ToString() + "OutputS.jpg", format: System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private int checkPropertyItem(string path)
        {
            Image img = Image.FromFile(path);

            try
            {
                var item = img.GetPropertyItem(0x0112);

                byte o = item.Value[0];

                return o;
            }
            catch
            {
                return 0;
            }
        }
    }
}
