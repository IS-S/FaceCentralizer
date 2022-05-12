using System.Drawing;

namespace FC.Core
{
    public class FaceSelector : IFaceSelector
    {
        public Rectangle Select(Rectangle[] faces)
        {

            int counter = 0, index = 0;
            
            if (faces.Length >= 2)
            {
                float a = 0, b = 0;
                foreach (Rectangle face in faces)
                {
                    a = face.Width * face.Height;
                    if (a > b)
                    {
                        b = a;
                        index = counter;
                    }
                    counter++;
                }
            }

            return faces[index];

        }
    }
}
