using System.Drawing;
using System.Drawing.Imaging;
using ImageGenerator.Core.Model;

namespace ImageGenerator.Core.Services
{
    public interface IImageService
    {
        Image Resize(Image image, Size resolution);

        void SaveImage(Image image, OutputDescriptor outputDescriptor);

    }
}
