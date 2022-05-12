
using System.Drawing;

namespace FC.Core
{
    public class FaceCentralizer : IFaceCentralizer
    {
        private readonly IPhotoProvider _photoprovider;
        private readonly IFaceFinder _facefinder;
        private readonly IFaceDrawerTEST _facedrawertest;
        private readonly IPhotoCropper _photocropper;
        private readonly IFaceSelector _faceselector;

        private byte[] bytemap;
        private Bitmap bitmap;


        public FaceCentralizer(IPhotoProvider photoprovider, IFaceFinder facefinder, IPhotoCropper photocropper, IFaceDrawerTEST facedrawertest, IFaceSelector faceselector)
        {
            _photoprovider = photoprovider;
            _facefinder = facefinder;
            _facedrawertest = facedrawertest;
            _photocropper = photocropper;
            _faceselector = faceselector;
        }

        public string Centralize(string path)
        {

            bytemap = _photoprovider.Get(path);

            Rectangle[] faces =_facefinder.Find(bytemap);

            if(faces.Length == 0)
            {
                return "Empty faces array";
            }
            
            bitmap = _photoprovider.GetBitmap(path);

            var face = _faceselector.Select(faces);

            _facedrawertest.Draw(bitmap, face);

#pragma warning disable CA1416 // Validate platform compatibility
            var result = _photocropper.Crop(bitmap, face);

            bitmap.Dispose();

            Bitmap bitmapBig = result.Item1;
            Bitmap bitmapSmall = result.Item2;

#pragma warning restore CA1416 // Validate platform compatibility

            _photoprovider.Post(bitmapBig, bitmapSmall, path);

            return "success";

        }

    }
}
