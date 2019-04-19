using System;
using System.IO;

namespace ImageGenerator
{
    public class FolderPath
    {
        public string Path { get; set; }
        public bool IsAbsolute { get; set; }

        public string GetFolderPath()
        {
            if (this.IsAbsolute)
            {
                return this.Path.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) ? this.Path :
                    string.Concat(this.Path, System.IO.Path.DirectorySeparatorChar.ToString());
            }

            string relativePath = this.Path;
            if (!relativePath.StartsWith(System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                relativePath = string.Concat(System.IO.Path.DirectorySeparatorChar.ToString(), relativePath);
            if (!relativePath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                relativePath = string.Concat(relativePath, System.IO.Path.DirectorySeparatorChar.ToString());

            return string.Concat(Directory.GetCurrentDirectory(), relativePath);
        }
    }
}
