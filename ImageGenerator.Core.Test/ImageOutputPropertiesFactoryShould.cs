

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using ImageGenerator.Core.Model;
using ImageGenerator.Core.Utils;
using Xunit;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace ImageGenerator.Core.Test
{
    public class ImageOutputPropertiesFactoryShould
    {
        [Fact]
        public void CreateImageFormat_FromJson()
        {
            string imageFormatJson = "{\"ImageFormat\":{\"Format\":\"Png\"}}";

            var imageOutputProperties = ImageOutputPropertiesFactory.CreateFromJson(imageFormatJson);

            Assert.Equal(ImageFormat.Png, imageOutputProperties.ImageFormat.Format);
        }
    }
}