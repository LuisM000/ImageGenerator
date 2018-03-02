using System;
using System.DirectoryServices.Protocols;
using System.IO;
using ImageGenerator.Core.Services;
using ImageGenerator.Core.Test.Builders;
using Xunit;

namespace ImageGenerator.Core.Test
{
    public class FolderGeneratorShould
    {
        private readonly FolderGenerator folderGenerator;
        private string outputDirectoryBase = string.Concat(Directory.GetCurrentDirectory(), "\\Dummy\\");

        public FolderGeneratorShould()
        {
            folderGenerator = new FolderGenerator();
            DeleteDirectory();
        }

        [Fact]
        public void Create_Absolute_Folder()
        {
            string absolutePath = this.GivenAAbsolutePath("absolute");
            ImageOutputPropertiesBuilder imageOutputProperties = new ImageOutputPropertiesBuilder()
                .WithAbsoluteFolderPath(absolutePath);
            
            folderGenerator.CreateFolderIfNotExists(imageOutputProperties);

            Assert.True(Directory.Exists(absolutePath));
        }

        [Fact]
        public void Create_Relative_Folder()
        {
            string relativePath = "Dummy\\Relative";
            ImageOutputPropertiesBuilder imageOutputProperties = new ImageOutputPropertiesBuilder()
                .WithRelativeFolderPath(relativePath);

            folderGenerator.CreateFolderIfNotExists(imageOutputProperties);

            Assert.True(Directory.Exists(string.Concat(Directory.GetCurrentDirectory(),"\\", relativePath)));
        }


        [Fact]
        public void No_Creates_Folder_If_Already_Exists()
        {
            string path = string.Concat(outputDirectoryBase, "Directory");
            this.CreateDirectory(path);
            DateTime creationDirectory = Directory.GetCreationTime(path);
            ImageOutputPropertiesBuilder imageOutputProperties = new ImageOutputPropertiesBuilder()
                .WithAbsoluteFolderPath(path);

            folderGenerator.CreateFolderIfNotExists(imageOutputProperties);

            Assert.Equal(creationDirectory, Directory.GetCreationTime(path));
        }

      

        private void DeleteDirectory()
        {
            if(Directory.Exists(outputDirectoryBase))
                Directory.Delete(outputDirectoryBase, true);
        }

        private void CreateDirectory(string absolutePath)
        {
            if (Directory.Exists(absolutePath))
                Directory.Delete(absolutePath, true);
            Directory.CreateDirectory(absolutePath);
        }
        private string GivenAAbsolutePath(string path)
        {
            return string.Concat(outputDirectoryBase, path);
        }
    }



   
}
