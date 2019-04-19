using System;
using System.IO;
using ImageGenerator.Contracts;

namespace ImageGenerator.Services
{
    public class FolderGenerator : IFolderGenerator
    {
        public void CreateFolderIfNotExists(ImageOutputProperties imageOutputProperties)
        {
            string folderPath = imageOutputProperties.GetFolderPath();
            Directory.CreateDirectory(folderPath);
        }
    }
}
