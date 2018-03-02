using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenerator.Core
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
