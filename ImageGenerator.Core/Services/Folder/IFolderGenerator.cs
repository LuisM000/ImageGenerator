using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGenerator.Core.Model;

namespace ImageGenerator.Core.Services
{
    public interface IFolderGenerator
    {
        void CreateFolderIfNotExists(ImageOutputProperties imageOutputProperties);
    }
}
