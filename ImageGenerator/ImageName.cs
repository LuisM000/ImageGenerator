using System;
using System.IO;

namespace ImageGenerator
{
    public class ImageName
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }

        public string GetImageName(string originalName)
        {
            return string.Concat(this.Prefix, originalName, this.Suffix);
        }
    }
}
