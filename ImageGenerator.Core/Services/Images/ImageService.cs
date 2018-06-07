using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ImageGenerator.Core.Model;
using ImageGenerator.Core.Utils;


namespace ImageGenerator.Core.Services
{
    public class ImageService : IImageService
    {
        
        public Image Resize(Image image, Size resolution)
        {
            var destRect = new Rectangle(0, 0, resolution.Width, resolution.Height);
            var resizedImage = new Bitmap(resolution.Width, resolution.Height);

            resizedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return resizedImage;
        }

        public void SaveImage(Image image, OutputDescriptor outputDescriptor)
        {
            var outputFormat = outputDescriptor.ImageFormat ??
                               System.Drawing.Imaging.ImageFormat.Png;
            string pathWithExtension = string.Concat(outputDescriptor.Path, outputFormat.GetExtension());
            if (!outputDescriptor.OverwriteFile && File.Exists(pathWithExtension))
                throw new FileAlreadyExistsException(pathWithExtension);
            image.Save(pathWithExtension, outputFormat);
        }
        
    }
}
