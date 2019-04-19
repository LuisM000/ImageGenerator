using System;
using System.ComponentModel;

namespace ImageGenerator.Abstractions
{
    [TypeConverterAttribute(typeof(ImageEncoderConverter))]
    public abstract class ImageEncoder
    {
        private readonly static ImageEncoder png = new Png();
        private readonly static ImageEncoder jpeg = new Jpeg();
        private readonly static ImageEncoder jpg = new Jpg();
        private readonly static ImageEncoder gif = new Gif();
        private readonly static ImageEncoder bmp = new Bmp();

        public static ImageEncoder Png => png;
        public static ImageEncoder Jpeg => jpeg;
        public static ImageEncoder Jpg => jpg;
        public static ImageEncoder Gif => gif;
        public static ImageEncoder Bmp => bmp;


        public abstract string GetExtension();

    }

    public class Png : ImageEncoder
    {
        public override string GetExtension()
        {
            return ".png";
        }
    }

    public class Jpeg : ImageEncoder
    {
        public override string GetExtension()
        {
            return ".jpeg";
        }
    }

    public class Jpg : ImageEncoder
    {
        public override string GetExtension()
        {
            return ".jpg";
        }
    }

    public class Gif : ImageEncoder
    {
        public override string GetExtension()
        {
            return ".gif";
        }
    }

    public class Tiff : ImageEncoder
    {
        public override string GetExtension()
        {
            return ".tiff";
        }
    }

    public class Bmp : ImageEncoder
    {
        public override string GetExtension()
        {
            return ".bmp";
        }
    }
}
