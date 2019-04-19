using System;
namespace ImageGenerator.Exceptions
{
    public class FileAlreadyExistsException : Exception
    {
        public string Path { get; }

        public FileAlreadyExistsException(string path)
        {
            Path = path;
        }
    }
}