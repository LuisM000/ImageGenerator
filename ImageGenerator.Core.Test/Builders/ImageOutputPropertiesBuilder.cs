using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using ImageGenerator.Core.Model;

namespace ImageGenerator.Core.Test.Builders
{
    public class ImageOutputPropertiesBuilder
    {
        private ImageOutputProperties imageOutputProperties;

        public ImageOutputPropertiesBuilder()
        {
            imageOutputProperties = new ImageOutputProperties()
            {
                ImageDimensions = new ImageDimensions() { Resolution = new Size(1, 1) },
                ImageFormat = System.Drawing.Imaging.ImageFormat.Png
            };
        }

        public ImageOutputPropertiesBuilder WithResolution(Size resolution)
        {
            imageOutputProperties.ImageDimensions.Percentage = 0;
            imageOutputProperties.ImageDimensions.Resolution = resolution;
            return this;
        }

        public ImageOutputPropertiesBuilder WithResolution(int percentage)
        {
            imageOutputProperties.ImageDimensions.Percentage = percentage;
            imageOutputProperties.ImageDimensions.Resolution = Size.Empty;
            return this;
        }

        public ImageOutputPropertiesBuilder AddSuffixName(string suffix)
        {
            imageOutputProperties.ImageName = new ImageName()
            {
                Suffix = suffix
            };
            return this;
        }

        public ImageOutputPropertiesBuilder WithAbsoluteFolderPath(string absolutePath)
        {
            imageOutputProperties.FolderPath = new FolderPath()
            {
                IsAbsolute = true,
                Path = absolutePath
            };
            return this;
        }

        public ImageOutputPropertiesBuilder WithRelativeFolderPath(string relativePath)
        {
            imageOutputProperties.FolderPath = new FolderPath()
            {
                IsAbsolute = false,
                Path = relativePath
            };
            return this;
        }
        public ImageOutputProperties WithFormat(ImageFormat imageFormat)
        {
            imageOutputProperties.ImageFormat = imageFormat;
            return this;
        }


        public static implicit operator ImageOutputProperties(ImageOutputPropertiesBuilder builder)
        {
            return builder.imageOutputProperties;
        }

      
    }
}
