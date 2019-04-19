using System;
namespace ImageGenerator
{
    public class OutputDescriptor
    {
        public string Path { get; }
        public ImageFormat ImageFormat { get; }
        public bool OverwriteFile { get; }

        public OutputDescriptor(ImageProperties imageProperties, ImageOutputProperties imageOutputProperties)
        {
            this.Path = imageOutputProperties.GetFullPath(imageProperties.FileName);
            this.ImageFormat = imageOutputProperties.ImageFormat;
            this.OverwriteFile = imageOutputProperties.OverwriteFile;
        }

        public OutputDescriptor(string path, ImageFormat imageFormat, bool overwriteFile = true)
        {
            this.Path = path;
            this.ImageFormat = imageFormat;
            this.OverwriteFile = overwriteFile;
        }
    }
}
