using System.Drawing;


namespace FC.Core
{
    public interface IPhotoProvider
    {
        public byte[] Get(string path);
        public Bitmap GetBitmap(string path);
        public void Post(Bitmap imageDataBig, Bitmap imageDataSmall, string path);
    }
}
