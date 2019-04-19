using System;
using ImageGenerator.Abstractions;

namespace ImageGenerator.Utils
{
    public static class ImageEncoderExtensions
    {
        public static ImageEncoder GetImageFormat(string extension)
        {
            switch (extension?.ToLower())
            {
                case ".bmp":
                    return ImageEncoder.Bmp;

                case ".gif":
                    return ImageEncoder.Gif;
                                 
                case ".jpg":
                    return ImageEncoder.Jpg;

                case ".jpeg":
                    return ImageEncoder.Jpeg;

                case ".png":
                    return ImageEncoder.Png;
            }

            throw new ArgumentException(nameof(extension));
        }
    }
}
