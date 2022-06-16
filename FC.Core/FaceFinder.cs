using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;


namespace FC.Core
{
    public class FaceFinder : IFaceFinder
    {
        public Rectangle[] Find(byte[] bytemap)
        {

            Mat imageMat = new Mat();

            CvInvoke.Imdecode(bytemap, Emgu.CV.CvEnum.ImreadModes.Unchanged, imageMat);

            var imgGray = new UMat();

            CvInvoke.CvtColor(imageMat, imgGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

            CascadeClassifier classifier = new CascadeClassifier("C:/Users/i.sumin/source/repos/PhotoHubFaceCentralizer/FC.Core/cascades/haarcascade_frontalface_default.xml");

            double scaleSelector = 1.2;
            int neighbours = 5;


            
            Rectangle[] faces = classifier.DetectMultiScale(imgGray, scaleSelector, neighbours, new Size(width: 60, height: 60), Size.Empty);

            while (faces.Length < 1)
            {
                scaleSelector = scaleSelector - 0.02;

                if (scaleSelector <= 1.015)
                {
                    break;
                }
                if (neighbours <= 10)
                {
                    neighbours++;
                }

                faces = classifier.DetectMultiScale(imgGray, scaleSelector, neighbours, new Size(width: 60, height: 60), Size.Empty);

            }
            return faces;
        }
    }
}
