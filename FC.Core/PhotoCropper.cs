using System.Drawing;
using System;

namespace FC.Core
{
    public class PhotoCropper : IPhotoCropper
    {

        public Tuple<Bitmap, Bitmap> Crop(Bitmap bitmap, Rectangle face)
        {
#pragma warning disable CA1416 // Validate platform compatibility


            int[] sides = { bitmap.Height - face.Bottom, bitmap.Height - (bitmap.Height - face.Top), bitmap.Width - face.Right, bitmap.Width - (bitmap.Width - face.Left) };

            int result = sides[0];

            foreach(int variable in sides)
            {
                if(result > variable)
                {
                    result = variable;
                }
            }

            int side = 0;

            switch(Array.IndexOf(sides, result))
            {
                case 0:
                    side = (bitmap.Height - face.Bottom) * 2 + face.Height;
                    break;
                case 1:
                    side = (bitmap.Height - (bitmap.Height - face.Top)) * 2 + face.Height;
                    break;
                case 2:
                    side = (bitmap.Width - face.Right) * 2 + face.Width;
                    break;
                case 3:
                    side = bitmap.Width - (bitmap.Width - face.Left) + face.Width;
                    break;
            }

            int centerX = face.Left + (face.Right - face.Left) / 2;
            int centerY = face.Top + (face.Bottom - face.Top) / 2;
            int newRectX = centerX - side / 2;
            int newRectY = centerY - side / 2;

            Rectangle toCrop = new Rectangle(newRectX, newRectY, side, side);

            bitmap = bitmap.Clone(toCrop, bitmap.PixelFormat);

            Bitmap bitmapBig = new Bitmap(bitmap, new Size(144, 144));
            Bitmap bitmapSmall = new Bitmap(bitmap, new Size(48, 48));



            return Tuple.Create(bitmapBig, bitmapSmall);
#pragma warning restore CA1416 // Validate platform compatibility

        }
    }
}
