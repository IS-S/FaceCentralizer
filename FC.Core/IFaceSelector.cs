using System.Drawing;

namespace FC.Core
{
    public interface IFaceSelector
    {
        public Rectangle Select(Rectangle[] faces);
    }
}
