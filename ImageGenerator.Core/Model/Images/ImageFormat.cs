using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenerator.Core.Model
{
    public class ImageFormat
    {
        public System.Drawing.Imaging.ImageFormat Format { get; set; }
        public string ImageExtension { get; set; }

        public static implicit operator ImageGenerator.Core.Model.ImageFormat
            (System.Drawing.Imaging.ImageFormat imageFormat)
        {
            return new ImageGenerator.Core.Model.ImageFormat()
            {
                Format = imageFormat
            };
        }
    }
}
