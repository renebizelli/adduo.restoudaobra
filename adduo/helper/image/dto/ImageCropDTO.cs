using System;

namespace adduo.helper.image
{
    [Serializable]
    public class ImageCropDTO : ImageBaseHelperDTO
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public ImageCropDTO(string source, string directoryDestination, string fileDestination, int x, int y, int width, int height, bool deletesource) :
            base(source, directoryDestination, fileDestination, width, height, deletesource)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
