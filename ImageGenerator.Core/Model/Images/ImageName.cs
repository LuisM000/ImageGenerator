using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenerator.Core.Model
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
