using System;
using ImageGenerator.Abstractions;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageGenerator.Services.Utils
{
    public class ImageAdapter : IImage
    {
        private readonly SixLabors.ImageSharp.Image<Rgba32> image;

        public ImageAdapter(SixLabors.ImageSharp.Image<Rgba32> image)
        {
            this.image = image;
        }

        public int Width => image.Width;

        public int Height => image.Height;

        public SixLabors.ImageSharp.Image<Rgba32> Image => image;

        public void Dispose()
        {
            image.Dispose();
        }
    }
}
