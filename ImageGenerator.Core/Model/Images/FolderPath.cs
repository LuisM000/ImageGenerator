using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenerator.Core.Model
{
    public class FolderPath
    {
        public string Path { get; set; }
        public bool IsAbsolute { get; set; }

        public string GetFolderPath()
        {
            if (this.IsAbsolute)
            {
                return this.Path.EndsWith("\\") ? this.Path : string.Concat(this.Path, "\\");
            }

            string relativePath = this.Path;
            if(!relativePath.StartsWith("\\"))
                relativePath=string.Concat("\\",relativePath);
            if (!relativePath.EndsWith("\\"))
                relativePath = string.Concat(relativePath, "\\");

            return string.Concat(Directory.GetCurrentDirectory(), relativePath);
        }
    }
}
