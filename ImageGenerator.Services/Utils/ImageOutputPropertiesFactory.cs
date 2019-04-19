using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ImageGenerator.Services.Utils
{
    public static class ImageOutputPropertiesFactory
    {
        public static IList<ImageOutputProperties> CreateForXamarin(string fileExtension, string rootPath)
        {
            ImageFormat imageFormat = new ImageFormat(fileExtension);
            return new List<ImageOutputProperties>()
            {
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath,"iOS")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.75},
                    ImageName = new ImageName() {Suffix = "@3x"}
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath,"iOS")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.5},
                    ImageName = new ImageName() {Suffix = "@2x"}
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath,"iOS")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.25},
                },



                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath,"Android","xxxhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 1},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath,"Android", "xxhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.75},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath,"Android", "xhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.5},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath,"Android","hdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.375},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath,"Android", "mdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.25},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath,"Android", "ldpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.1875},
                }

            };
        }

        public static ImageOutputProperties CreateFromJson(string json)
        {
            return JsonConvert.DeserializeObject<ImageOutputProperties>(json);
        }

        public static IList<ImageOutputProperties> CreateListFromJson(string json)
        {
            return JsonConvert.DeserializeObject<IList<ImageOutputProperties>>(json);
        }
    }
}
