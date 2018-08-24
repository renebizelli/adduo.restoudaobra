namespace adduo.helper.image
{
    public class ImageValidationDTO : ImageBaseHelperDTO
    {
        public enum type {
            relative,
            absolue
        }

        public type Type{ get; private set; }

        public ImageValidationDTO(string source, int width, int height, type type) : base(source, width, height)
        {
            Type = type;
        }
    }
}
