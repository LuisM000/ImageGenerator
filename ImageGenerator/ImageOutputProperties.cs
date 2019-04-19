using System;
using System.Drawing;
using System.IO;
using ImageGenerator.Abstractions;

namespace ImageGenerator
{
    public class ImageOutputProperties
    {
        public FolderPath FolderPath { get; set; }
        public ImageFormat ImageFormat { get; set; }

        public ImageName ImageName { get; set; }
        public ImageDimensions ImageDimensions { get; set; }

        public bool OverwriteFile { get; set; }


        public Size GetResolution(IImage image)
        {
            if (image == null || this.ImageDimensions == null)
                return Size.Empty;

            return ImageDimensions.GetResolution(new Size(image.Width, image.Height));
        }

        public string GetImageName(string originalName)
        {
            if (ImageName == null)
                return originalName;

            return this.ImageName.GetImageName(originalName);
        }

        public string GetFullPath(string originalName)
        {
            return Path.Combine(this.GetFolderPath(),
                this.GetImageName(originalName));
        }

        public string GetFolderPath()
        {
            if (this.FolderPath == null)
                return string.Concat(Directory.GetCurrentDirectory(),Path.DirectorySeparatorChar);

            return this.FolderPath.GetFolderPath();
        }

    }
}