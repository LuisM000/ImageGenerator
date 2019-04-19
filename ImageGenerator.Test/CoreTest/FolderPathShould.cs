using System;
using System.IO;
using Xunit;

namespace ImageGenerator.Test.CoreTest
{
    public class FolderPathShould
    {
        private string absoluteDummyUserPath = string.Concat(Directory.GetCurrentDirectory(),
                                        Path.DirectorySeparatorChar, "DummyUser", Path.DirectorySeparatorChar);

        [Fact]
        public void Generate_Absolute_Path()
        {
            FolderPath folderPath = new FolderPath()
            {
                Path = absoluteDummyUserPath,
                IsAbsolute = true
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal(absoluteDummyUserPath, generateFolder);
        }

        [Fact]
        public void Generate_Absolute_Path_From_Relative_Path()
        {
            string relativePath = string.Concat(Path.DirectorySeparatorChar.ToString(), "DummyUser", Path.DirectorySeparatorChar.ToString());
            FolderPath folderPath = new FolderPath()
            {
                Path = relativePath,
                IsAbsolute = false
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal(absoluteDummyUserPath, generateFolder);
        }


        [Fact]
        public void Add_Final_Backslash_If_Not_Contains_When_Is_Absolute()
        {
            string absolutePathWithoutBackslash = Path.Combine(Directory.GetCurrentDirectory(), "DummyUser");
            FolderPath folderPath = new FolderPath()
            {
                Path = absolutePathWithoutBackslash,
                IsAbsolute = true
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal(absoluteDummyUserPath, generateFolder);
        }

        [Fact]
        public void Add_Final_Backslash_If_Not_Contains_When_Is_Relative()
        {
            string relativePathWithoutBackslash = string.Concat(Path.DirectorySeparatorChar, "DummyUser");
            FolderPath folderPath = new FolderPath()
            {
                Path = relativePathWithoutBackslash,
                IsAbsolute = false
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal(absoluteDummyUserPath, generateFolder);
        }

        [Fact]
        public void Add_Start_Backslash_If_Not_Contains_When_Is_Relative()
        {
            string relativePathWithoutBackslash = string.Concat("DummyUser", Path.DirectorySeparatorChar);
            FolderPath folderPath = new FolderPath()
            {
                Path = relativePathWithoutBackslash,
                IsAbsolute = false
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal(absoluteDummyUserPath, generateFolder);
        }

        [Fact]
        public void Add_Start_And_Final_Backslash_If_Not_Contains_When_Is_Relative()
        {
            FolderPath folderPath = new FolderPath()
            {
                Path = "DummyUser",
                IsAbsolute = false
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal(absoluteDummyUserPath, generateFolder);
        }
    }
}
