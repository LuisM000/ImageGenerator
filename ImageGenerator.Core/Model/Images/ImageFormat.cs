using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGenerator.Core.Utils;

namespace ImageGenerator.Core.Model
{
    public class ImageFormat
    {
        public ImageFormat(){}

        public ImageFormat(string extension)
        {
            this.Format = ImageFormatExtension.GetImageFormat(extension);
            this.ImageExtension = extension;
        }

       
        public System.Drawing.Imaging.ImageFormat Format { get; set; }
        public string ImageExtension { get; set; }

        public string GetExtension()
        {
            if (!string.IsNullOrEmpty(this.ImageExtension))
                return this.ImageExtension;
            if (Format != null)
                return this.Format.GetExtension();
            return "png";
        }

        public static implicit operator ImageGenerator.Core.Model.ImageFormat
            (System.Drawing.Imaging.ImageFormat imageFormat)
        {
            return new ImageGenerator.Core.Model.ImageFormat()
            {
                Format = imageFormat
            };
        }



    }
}
