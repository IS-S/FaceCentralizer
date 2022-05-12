using System.Drawing;

namespace FC.Core
{
    public interface IFaceFinder
    {
        public Rectangle[] Find(byte[] bitmap);
    }
}
