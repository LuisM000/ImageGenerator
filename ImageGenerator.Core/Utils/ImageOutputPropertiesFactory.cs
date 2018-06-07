using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGenerator.Core.Model;
using Newtonsoft.Json;

namespace ImageGenerator.Core.Utils
{
    public static class ImageOutputPropertiesFactory
    {
        public static IList<ImageOutputProperties> CreateForXamarin(string fileExtension, string rootPath)
        {
            ImageFormat imageFormat = ImageFormatExtension.GetImageFormat(fileExtension) ??
                                      System.Drawing.Imaging.ImageFormat.Png;
            return new List<ImageOutputProperties>()
            {
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = string.Concat(rootPath,"\\iOS")
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
                        Path = string.Concat(rootPath,"\\iOS")
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
                        Path = string.Concat(rootPath,"\\iOS")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.25},
                },



                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = string.Concat(rootPath,"\\Android\\xxxhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 1},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = string.Concat(rootPath,"\\Android\\xxhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.75},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = string.Concat(rootPath,"\\Android\\xhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.5},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = string.Concat(rootPath,"\\Android\\hdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.375},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = string.Concat(rootPath,"\\Android\\mdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.25},
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = string.Concat(rootPath,"\\Android\\ldpi")
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
