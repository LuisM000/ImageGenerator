using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenerator.Core.Model
{
    public class ImageProperties
    {
        public byte[] Image { get; set; }
        public string FileName { get; set; }

        public Image GetImage()
        {
            using (var ms = new MemoryStream(Image))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }
        public IList<ImageOutputProperties> ImageOutputProperties { get; set; }


    }
}
