using System;
using System.Drawing;
using System.IO;
using ImageGenerator.Abstractions;
using ImageGenerator.Contracts.Services;
using ImageGenerator.Exceptions;
using ImageGenerator.Services.Utils;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ImageGenerator.Services
{
    public class ImageService : IImageService
    {
       
        public Abstractions.IImage Resize(Abstractions.IImage image, Size resolution)
        {
            var resizedImage = ((ImageAdapter)image).Image.Clone();

            resizedImage.Mutate(c => c.Resize(resolution.Width, resolution.Height));

            return new ImageAdapter(resizedImage);
        }

        public void SaveImage(Abstractions.IImage image, OutputDescriptor outputDescriptor)
        {
            var outputFormat = outputDescriptor.ImageFormat ?? Abstractions.ImageEncoder.Png;
            string pathWithExtension = string.Concat(outputDescriptor.Path, outputFormat.GetExtension());
            if (!outputDescriptor.OverwriteFile && File.Exists(pathWithExtension))
                throw new FileAlreadyExistsException(pathWithExtension);

            var sixImage = ((ImageAdapter)image).Image;
            sixImage.Save(pathWithExtension, outputFormat.Format.ToIImageEncoder());
        }

        public Abstractions.IImage LoadImage(byte[] data)
        {
            return new ImageAdapter(SixLabors.ImageSharp.Image.Load(data));
        }

    }
}
