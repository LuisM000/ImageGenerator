using System;
using System.IO;
using ImageGenerator.Services;
using ImageGenerator.Test.Builders;
using Xunit;

namespace ImageGenerator.Test.ServicesTest
{
    public class FolderGeneratorShould
    {
        private readonly FolderGenerator folderGenerator;
        private readonly string outputDirectoryBase = Path.Combine(Directory.GetCurrentDirectory(), "Dummy");

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
            string relativePath = Path.Combine("Dummy", "Relative");
            ImageOutputPropertiesBuilder imageOutputProperties = new ImageOutputPropertiesBuilder()
                .WithRelativeFolderPath(relativePath);

            folderGenerator.CreateFolderIfNotExists(imageOutputProperties);

            Assert.True(Directory.Exists(string.Concat(Directory.GetCurrentDirectory(), Path.DirectorySeparatorChar.ToString(), relativePath)));
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
            if (Directory.Exists(outputDirectoryBase))
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
            return Path.Combine(outputDirectoryBase, path);
        }
    }


}