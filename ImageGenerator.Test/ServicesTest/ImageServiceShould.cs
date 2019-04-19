using System;
using System.Drawing;
using System.IO;
using ImageGenerator.Abstractions;
using ImageGenerator.Exceptions;
using ImageGenerator.Services;
using ImageGenerator.Services.Utils;
using ImageGenerator.Test.Builders;
using SixLabors.ImageSharp;
using Xunit;

namespace ImageGenerator.Test.ServicesTest
{
    public class ImageServiceShould
    {
        private readonly ImageService imageService;

        public ImageServiceShould()
        {
            imageService = new ImageService();
        }

        [Fact]
        public void Resize_An_Image()
        {
            var image = this.GivenAnImage();
            Size newImageSize = new Size(20, 40);

            var resizedImage = imageService.Resize(image, newImageSize);

            Assert.Equal(newImageSize.Width, resizedImage.Width);
            Assert.Equal(newImageSize.Height, resizedImage.Height);
        }

        [Fact]
        public void Throw_Exception_When_Resize_A_Null_Image()
        {
            Action resizeAction = () => imageService.Resize(null, new Size(20, 40));

            Assert.Throws<NullReferenceException>(resizeAction);
        }


        [Fact]
        public void Throw_Exception_When_Resize_Image_With_Empty_Size()
        {
            var image = this.GivenAnImage();
            Size emptySize = Size.Empty;

            Action resizeAction = () => imageService.Resize(image, emptySize);

            Assert.Throws<ArgumentOutOfRangeException>(resizeAction);
        }

        [Fact]
        public void Save_Image_In_Folder_With_Format()
        {
            var image = this.GivenAnImage();
            string imagePath = this.GivenAPath("imageSaved");            

            var outputDescriptor = new OutputDescriptor(imagePath, Abstractions.ImageEncoder.Png);

            imageService.SaveImage(image, outputDescriptor);

            Assert.True(File.Exists(imagePath + ".png"));
        }

        [Fact]
        public void Save_Image_With_PNG_Format_If_ImageFormat_Is_Null()
        {
            var image = this.GivenAnImage();
            string imagePath = this.GivenAPath("imageSaved");
            var outputDescriptor = new OutputDescriptor(imagePath, null);

            imageService.SaveImage(image, outputDescriptor);

            Assert.True(File.Exists(imagePath + ".png"));
        }

        [Fact]
        public void Throw_Exception_If_Save_Image_With_Incorrect_Path()
        {
            var image = this.GivenAnImage();
            string incorrectImagePath = this.GivenAIncorrectPath();
            var outputDescriptor = new OutputDescriptor(incorrectImagePath, Abstractions.ImageEncoder.Png);

            Action saveAction = () => imageService.SaveImage(image, outputDescriptor);

            Assert.ThrowsAny<Exception>(saveAction);
        }

        [Fact]
        public void Throw_Exception_If_Save_Null_Image()
        {
            string imagePath = this.GivenAPath("imageSaved");
            var outputDescriptor = new OutputDescriptor(imagePath, Abstractions.ImageEncoder.Png);

            Action saveAction = () => imageService.SaveImage(null, outputDescriptor);

            Assert.Throws<NullReferenceException>(saveAction);
        }

        [Fact]
        public void Throw_Exception_If_Save_Image_Already_Exists_If_Is_Not_Overwrite()
        {
            string existsImagePath = this.GivenAPath(Path.Combine("Resources","Dummy_image"));
            var outputDescriptor = new OutputDescriptor(existsImagePath, Abstractions.ImageEncoder.Png, false);

            Action saveAction = () => imageService.SaveImage(null, outputDescriptor);

            Assert.Throws<FileAlreadyExistsException>(saveAction);
        }


        private Abstractions.IImage GivenAnImage()
        {
            return new ImageAdapter(Image.Load(Path.Combine("Resources", "Dummy_image.png")));
        }
        private string GivenAPath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), fileName);
        }
        private string GivenAIncorrectPath()
        {
            return "s\\/$";
        }
    }
}
