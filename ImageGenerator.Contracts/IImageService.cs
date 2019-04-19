using System;
using System.Drawing;
using ImageGenerator.Abstractions;


namespace ImageGenerator.Contracts.Services
{
    public interface IImageService
    {
        IImage Resize(IImage image, Size resolution);

        void SaveImage(IImage image, OutputDescriptor outputDescriptor);

        IImage LoadImage(byte[] data);

    }
}
