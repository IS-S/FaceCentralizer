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
            Rectangle[] faces = classifier.DetectMultiScale(imgGray, 1.1, 10, new Size(width: 20, height: 20), Size.Empty);
            
            return faces;

        }
    }
}
