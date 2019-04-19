using System;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;



namespace ImageGenerator.Services.Utils
{
    public static class ImageEncoderExtensions
    {
        public static SixLabors.ImageSharp.Formats.IImageEncoder ToIImageEncoder(this Abstractions.ImageEncoder imageEncoder)
        {
            if (imageEncoder == Abstractions.ImageEncoder.Png)
                return new PngEncoder();            
            else if (imageEncoder == Abstractions.ImageEncoder.Bmp)
                return new BmpEncoder();
            else if (imageEncoder == Abstractions.ImageEncoder.Jpeg)
                return new JpegEncoder();
            else if (imageEncoder == Abstractions.ImageEncoder.Gif)
                return new GifEncoder();
            else if (imageEncoder == Abstractions.ImageEncoder.Jpg)
                return new JpegEncoder();

            throw new ArgumentException(nameof(imageEncoder));
        }
    }
}
