using System;

namespace adduo.helper.image
{
    [Serializable]
    public class ImageResizeDTO : ImageBaseHelperDTO
    {
        public ImageResizeDTO(string source, string directoryDestination, string fileDestination, int width, int height, bool deletesource) : 
            base(source, directoryDestination, fileDestination, width, height, deletesource)
        {

        }
    }
}
