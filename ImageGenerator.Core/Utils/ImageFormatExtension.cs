using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenerator.Core.Utils
{
    public static class ImageFormatExtension
    {
        public static string GetExtension(this ImageFormat imageFormat)
        {
            string extension = string.Empty;
            var imageCodecInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(x => x.FormatID == imageFormat?.Guid);
            if (imageCodecInfo != null)
            {
                extension=Path.GetExtension(imageCodecInfo.FilenameExtension);
            }
            return extension;
        }

        public static ImageFormat GetImageFormat(string extension)
        {
            switch (extension?.ToLower())
            {
                case ".bmp":
                    return ImageFormat.Bmp;

                case ".gif":
                    return ImageFormat.Gif;

                case ".ico":
                    return ImageFormat.Icon;

                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;

                case ".png":
                    return ImageFormat.Png;

                case ".tif":
                case ".tiff":
                    return ImageFormat.Tiff;

                case ".wmf":
                    return ImageFormat.Wmf;

                default:
                    return null;
            }
        }
    }


   
}
