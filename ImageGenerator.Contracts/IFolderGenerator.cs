using System;

namespace ImageGenerator.Contracts
{
    public interface IFolderGenerator
    {
        void CreateFolderIfNotExists(ImageOutputProperties imageOutputProperties);
    }
}