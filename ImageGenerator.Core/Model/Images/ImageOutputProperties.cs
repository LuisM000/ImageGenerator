using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ImageGenerator.Core.Model;


namespace ImageGenerator.Core.Model
{
    public class ImageOutputProperties
    {
        public FolderPath FolderPath { get; set; }
        public ImageFormat ImageFormat { get; set; }
        
        public ImageName ImageName { get; set; }
        public ImageDimensions ImageDimensions { get; set; }

        public bool OverwriteFile { get; set; }


        public Size GetResolution(Image image)
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
            return string.Concat(this.GetFolderPath(), 
                this.GetImageName(originalName));
        }

        public string GetFolderPath()
        {
            if (this.FolderPath == null)
                return string.Concat(Directory.GetCurrentDirectory(),"\\");

            return this.FolderPath.GetFolderPath();
        }

    }
}
