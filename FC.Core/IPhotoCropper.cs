using System.Drawing;
using System;

namespace FC.Core
{
    public interface IPhotoCropper
    {
        public Tuple<Bitmap, Bitmap> Crop(Bitmap bitmap, Rectangle face);
    }
}
