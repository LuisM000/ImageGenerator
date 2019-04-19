using System;
using ImageGenerator.Abstractions;
using ImageGenerator.Utils;

namespace ImageGenerator
{
    public class ImageFormat
    {
        public ImageFormat() { }

        public ImageFormat(string extension)
        {
            this.Format = ImageEncoderExtensions.GetImageFormat(extension);
            this.ImageExtension = extension;
        }


        public ImageEncoder Format { get; set; }
        public string ImageExtension { get; set; }

        public string GetExtension()
        {
            if (!string.IsNullOrEmpty(this.ImageExtension))
                return this.ImageExtension;
            if (Format != null)
                return this.Format.GetExtension();
            return ".png";
        }


        public static implicit operator ImageFormat
           (Abstractions.ImageEncoder imageFormat)
        {
            return new ImageFormat()
            {
                Format = imageFormat
            };
        }
    }
}