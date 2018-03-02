using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGenerator.Core.Model;

namespace ImageGenerator.Core.Services
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
