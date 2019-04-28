using System;
using System.Collections.Generic;
using System.IO;

namespace ImageGenerator.VS4Mac.Utils
{
    public static class ImageOutputPropertiesFactory
    {
        public static IList<ImageOutputProperties> CreateForAndroid4x(string fileExtension, string rootPath, bool overwriteFiles)
        {
            ImageFormat imageFormat = new ImageFormat(fileExtension);
            return new List<ImageOutputProperties>()
            {
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-xxxhdpi")                        
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 1 },
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-xxhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 0.75 },
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-xhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 0.5 },
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-hdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 0.375 },
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-mdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 0.25 },
                    OverwriteFile = overwriteFiles
                },
                 new ImageOutputProperties()
                 {
                     FolderPath = new FolderPath()
                     {
                         IsAbsolute = true,
                         Path = Path.Combine(rootPath, "drawable")
                     },
                     ImageFormat = imageFormat,
                     ImageDimensions = new ImageDimensions() { Percentage = 0.25 },
                    OverwriteFile = overwriteFiles
                 },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-ldpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 0.1875 },
                    OverwriteFile = overwriteFiles
                }
            };
        }
        public static IList<ImageOutputProperties> CreateForAndroid3x(string fileExtension, string rootPath, bool overwriteFiles)
        {
            ImageFormat imageFormat = new ImageFormat(fileExtension);
            return new List<ImageOutputProperties>()
            {
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-xxhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 1 },
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-xhdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 2d/3d },
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-hdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 0.5 },
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-mdpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 1d/3d },
                    OverwriteFile = overwriteFiles
                },
                 new ImageOutputProperties()
                 {
                     FolderPath = new FolderPath()
                     {
                         IsAbsolute = true,
                         Path = Path.Combine(rootPath, "drawable")
                     },
                     ImageFormat = imageFormat,
                     ImageDimensions = new ImageDimensions() { Percentage = 1d/3d },
                    OverwriteFile = overwriteFiles
                 },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath, "drawable-ldpi")
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() { Percentage = 0.25 },
                    OverwriteFile = overwriteFiles
                }
            };
        }

        public static IList<ImageOutputProperties> CreateForIOS4x(string fileExtension, string rootPath, bool overwriteFiles)
        {
            ImageFormat imageFormat = new ImageFormat(fileExtension);
            return new List<ImageOutputProperties>()
            {
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath)
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.75},
                    ImageName = new ImageName() {Suffix = "@3x"},
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath)
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.5},
                    ImageName = new ImageName() {Suffix = "@2x"},
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath)
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 0.25},
                    OverwriteFile = overwriteFiles
                }
            };
        }
        public static IList<ImageOutputProperties> CreateForIOS3x(string fileExtension, string rootPath, bool overwriteFiles)
        {
            ImageFormat imageFormat = new ImageFormat(fileExtension);
            return new List<ImageOutputProperties>()
            {
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath)
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 1},
                    ImageName = new ImageName() {Suffix = "@3x"},
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath)
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 2d/3d},
                    ImageName = new ImageName() {Suffix = "@2x"},
                    OverwriteFile = overwriteFiles
                },
                new ImageOutputProperties()
                {
                    FolderPath = new FolderPath()
                    {
                        IsAbsolute = true,
                        Path = Path.Combine(rootPath)
                    },
                    ImageFormat = imageFormat,
                    ImageDimensions = new ImageDimensions() {Percentage = 1d/3d},
                    OverwriteFile = overwriteFiles
                }
            };
        }

    }
}
