using System;
using System.IO;
using ImageGenerator.Core.Model;
using Xunit;

namespace ImageGenerator.Core.Test
{
     public class FolderPathShould
    {
        [Fact]
        public void Generate_Absolute_Path()
        {
            FolderPath folderPath = new FolderPath()
            {
                Path = "C:\\Users\\DummyUser\\",
                IsAbsolute = true
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal("C:\\Users\\DummyUser\\",generateFolder);
        }

        [Fact]
        public void Generate_Absolute_Path_From_Relative_Path()
        {
            FolderPath folderPath = new FolderPath()
            {
                Path = "\\DummyUser\\",
                IsAbsolute = false
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal(string.Concat(Directory.GetCurrentDirectory(), "\\DummyUser\\"), generateFolder);
        }


        [Fact]
        public void Add_Final_Backslash_If_Not_Contains_When_Is_Absolute()
        {
            FolderPath folderPath = new FolderPath()
            {
                Path = "C:\\Users\\DummyUser",
                IsAbsolute = true
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal("C:\\Users\\DummyUser\\", generateFolder);
        }

        [Fact]
        public void Add_Final_Backslash_If_Not_Contains_When_Is_Relative()
        {
            FolderPath folderPath = new FolderPath()
            {
                Path = "\\DummyUser",
                IsAbsolute = false
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal(string.Concat(Directory.GetCurrentDirectory(), "\\DummyUser\\"), generateFolder);
        }
        
        [Fact]
        public void Add_Start_Backslash_If_Not_Contains_When_Is_Relative()
        {
            FolderPath folderPath = new FolderPath()
            {
                Path = "DummyUser\\",
                IsAbsolute = false
            };

            string generateFolder = folderPath.GetFolderPath();

            Assert.Equal(string.Concat(Directory.GetCurrentDirectory(), "\\DummyUser\\"), generateFolder);
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

            Assert.Equal(string.Concat(Directory.GetCurrentDirectory(), "\\DummyUser\\"), generateFolder);
        }
    }
}