using System;
using System.Drawing;
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
            Image resizedImage = new Bitmap(image, resolution);
            return resizedImage;
        }

        public void SaveImage(Image image, OutputDescriptor outputDescriptor)
        {
            var outputFormat = outputDescriptor.ImageFormat ?? ImageFormat.Png;
            string pathWithExtension = string.Concat(outputDescriptor.Path, outputFormat.GetExtension());
            if (!outputDescriptor.OverwriteFile && File.Exists(pathWithExtension))
                throw new FileAlreadyExistsException(pathWithExtension);
            image.Save(pathWithExtension, outputFormat);
        }
        
    }
}
