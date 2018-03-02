using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGenerator.Core.Model;

namespace ImageGenerator.Core.Services
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
