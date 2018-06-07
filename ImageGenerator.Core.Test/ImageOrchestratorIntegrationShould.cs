using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ImageGenerator.Core.Model;
using ImageGenerator.Core.Services;
using ImageGenerator.Core.Test.Builders;
using Xunit;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace ImageGenerator.Core.Test
{
    public class ImageOrchestratorIntegrationShould
    {
        private ImageOrchestrator imageOrchestrator;

        public ImageOrchestratorIntegrationShould()
        {
            imageOrchestrator = new ImageOrchestrator(new FolderGenerator(), new ImageService());
            if(Directory.Exists("output"))
                Directory.Delete("output",true);
            if (Directory.Exists("output2"))
                Directory.Delete("output2", true);
            if (Directory.Exists("output3"))
                Directory.Delete("output3", true);
        }

        [Fact]
        public void Creates_Folder_Resize_And_Save_Image()
        {
            ImageOutputProperties imageOutputProperties = new ImageOutputPropertiesBuilder().
                WithRelativeFolderPath("output").
                WithResolution(new Size(20, 20)).
                WithFormat(ImageFormat.Png);

            ImageProperties imageProperties = new ImageProperties()
            {
                Image = this.GivenAnImage(),
                FileName = "image",
                ImageOutputProperties = new List<ImageOutputProperties>() { imageOutputProperties }
            };

            imageOrchestrator.Generate(imageProperties);

            string outputImagePath = string.Concat(Directory.GetCurrentDirectory(), "\\output\\image.png");
            Assert.True(File.Exists(outputImagePath));
        }


        [Fact]
        public void Creates__Multiple_Folder_Resize_And_Save_Image()
        {
            ImageOutputProperties imageOutputProperties = new ImageOutputPropertiesBuilder().
                WithRelativeFolderPath("output").
                WithResolution(new Size(20, 20)).
                WithFormat(ImageFormat.Png);
            ImageOutputProperties otherImageOutputProperties = new ImageOutputPropertiesBuilder().
                WithRelativeFolderPath("output2").
                WithResolution(new Size(30, 40)).
                WithFormat(ImageFormat.Png);

            ImageProperties imageProperties = new ImageProperties()
            {
                Image = this.GivenAnImage(),
                FileName = "image",
                ImageOutputProperties = new List<ImageOutputProperties>() { imageOutputProperties, otherImageOutputProperties }
            };

            imageOrchestrator.Generate(imageProperties);

            string outputImagePath = string.Concat(Directory.GetCurrentDirectory(), "\\output\\image.png");
            string otherOutputImagePath = string.Concat(Directory.GetCurrentDirectory(), "\\output2\\image.png");

            Assert.True(File.Exists(outputImagePath));
            Assert.True(File.Exists(otherOutputImagePath));
        }


       [Fact]
        public void Creates_Multiple_Files_With_Different_Name_In_Same_Folder()
        {
            ImageOutputProperties imageOutputProperties = new ImageOutputPropertiesBuilder().
                WithRelativeFolderPath("output3").
                WithResolution(new Size(20, 20)).
                WithFormat(ImageFormat.Png);
            ImageOutputProperties imageOutputPropertiesInSameFolder = new ImageOutputPropertiesBuilder().
                AddSuffixName("Dummy").
                WithRelativeFolderPath("output3").
                WithResolution(new Size(80, 80)).
                WithFormat(ImageFormat.Png);

            ImageProperties imageProperties = new ImageProperties()
            {
                Image = this.GivenAnImage(),
                FileName = "image",
                ImageOutputProperties = new List<ImageOutputProperties>() { imageOutputProperties, imageOutputPropertiesInSameFolder }
            };

            imageOrchestrator.Generate(imageProperties);

            string outputImagePath = string.Concat(Directory.GetCurrentDirectory(), "\\output3\\image.png");
            string outputImagePathWithSuffix = string.Concat(Directory.GetCurrentDirectory(), "\\output3\\imageDummy.png");

            Assert.True(File.Exists(outputImagePath));
            Assert.True(File.Exists(outputImagePathWithSuffix));
        }





        private byte[] GivenAnImage()
        {
            return File.ReadAllBytes("Resources\\Dummy_image.png");
        }

        private string GivenAPath(string fileName)
        {
            return string.Concat(Directory.GetCurrentDirectory(), "\\", fileName);
        }

    }
}
