using System;
using System.Collections.Generic;

namespace ImageGenerator
{
    public class ImageProperties
    {
        public byte[] Image { get; set; }
        public string FileName { get; set; }

        public IList<ImageOutputProperties> ImageOutputProperties { get; set; }
    }
}
