using System;
using ImageGenerator.Abstractions;
using ImageGenerator.Services.Utils;
using ImageGenerator.Utils;
using Xunit;

namespace ImageGenerator.Test.ServicesTest
{
    public class ImageOutputPropertiesFactoryShould
    {
        [Fact]
        public void CreateImageFormat_FromJson()
        {
            string imageFormatJson = "{\"ImageFormat\":{\"Format\":\"Png\"}}";

            var imageOutputProperties = ImageOutputPropertiesFactory.CreateFromJson(imageFormatJson);

            Assert.Equal(ImageEncoder.Png, imageOutputProperties.ImageFormat.Format);
        }
    }
}