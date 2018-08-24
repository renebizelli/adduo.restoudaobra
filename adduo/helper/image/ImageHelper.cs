using adduo.basetype;
using adduo.pattern;
using ImageMagick;
using System;
using System.IO;

namespace adduo.helper.image
{
    public class ImageHelper : IImageHelper
    {
        public static ImageHelper Instance
        {
            get { return Singleton<ImageHelper>.Instance; }
        }

        public BaseReturn Resize(ImageResizeDTO dto)
        {
            var result = new BaseReturn();

            try
            {
                using (var image = new MagickImage(dto.Source))
                {
                    image.Resize(dto.Width, dto.Height);
                    image.Strip();
                    image.Write(dto.FullDestination);
                }

                if (dto.DeleteSource)
                {
                    File.Delete(dto.Source);
                }

                result.Ok();
            }
            catch (Exception ex)
            {
                result.AddMessage("[error]", ex.Message);
            }

            return result;
        }

        public BaseReturn Crop(ImageCropDTO dto)
        {
            var result = new BaseReturn();

            try
            {
                using (var image = new MagickImage(dto.Source))
                {
                    image.Crop(dto.Width, dto.Height);
                    image.Write(dto.FullDestination);
                }

                if (dto.DeleteSource)
                {
                    File.Delete(dto.Source);
                }

                result.Ok();
            }
            catch (Exception ex)
            {
                result.AddMessage("[error]", ex.Message);

            }

            return result;
        }

        public BaseReturn Validation(ImageValidationDTO dto)
        {
            var result = new BaseReturn();

            try
            {
                using (var image = new MagickImage(dto.Source))
                {
                    if (dto.Type.Equals(ImageValidationDTO.type.absolue) &&
                        image.Width.Equals(dto.Width) &&
                        image.Height.Equals(dto.Height))
                    {
                        result.Ok();
                    }
                    else if (dto.Type.Equals(ImageValidationDTO.type.relative) &&
                        image.Width <= dto.Width &&
                        image.Height <= dto.Height)
                    {
                        result.Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                result.AddMessage("[error]", ex.Message);
            }

            return result;
        }

        private void CreateDirectory(ImageBaseHelperDTO dto)
        {
            if (!Directory.Exists(dto.DirectoryDestination))
            {
                Directory.CreateDirectory(dto.DirectoryDestination);
            }
        }
    }
}
