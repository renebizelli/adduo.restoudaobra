using adduo.basetype;
using System;
using System.Collections.Generic;
using System.Text;

namespace adduo.helper.image
{
    public interface IImageHelper
    {
        BaseReturn Resize(ImageResizeDTO dto);
        BaseReturn Crop(ImageCropDTO dto);
        BaseReturn Validation(ImageValidationDTO dto);
    }
}
