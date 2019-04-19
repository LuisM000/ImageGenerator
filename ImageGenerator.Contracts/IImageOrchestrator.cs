using System;
namespace ImageGenerator.Contracts
{
    public interface IImageOrchestrator
    {
        void Generate(ImageProperties imageProperties);
    }
}
