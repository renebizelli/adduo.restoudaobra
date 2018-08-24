using System.IO;

namespace adduo.helper.image
{
    public abstract class ImageBaseHelperDTO
    {
        public string Source { get; private set; }
        public string DirectoryDestination { get; private set; }
        public string FileDestination { get; private set; }
        public string FullDestination { get { return Path.Combine(DirectoryDestination, FileDestination); } }
        public bool DeleteSource { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ImageBaseHelperDTO(string source, string directoryDestination, string fileDestination, int width, int height, bool deletesource)
        {
            Source = source;
            DirectoryDestination = directoryDestination;
            FileDestination = fileDestination;
            DeleteSource = deletesource;
            Width = width;
            Height = height;
        }

        public ImageBaseHelperDTO(string source, int width, int height) : this(source, string.Empty, string.Empty, width, height, false)
        {
        }
    }
}
