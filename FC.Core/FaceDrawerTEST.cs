using System.Drawing;


namespace FC.Core
{
    public class FaceDrawerTEST : IFaceDrawerTEST
    {
        public void Draw(Bitmap bitmap, Rectangle face)
        {

#pragma warning disable CA1416 // Validate platform compatibility

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    graphics.DrawRectangle(pen, face);

                }
            }
#pragma warning restore CA1416 // Validate platform compatibility

        }
    }
}

