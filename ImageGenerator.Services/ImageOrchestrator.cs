using System;
using ImageGenerator.Contracts;
using ImageGenerator.Contracts.Services;

namespace ImageGenerator.Services
{
    public class ImageOrchestrator : IImageOrchestrator
    {
        private readonly IFolderGenerator folderGenerator;
        private readonly IImageService imageService;

        public ImageOrchestrator(IFolderGenerator folderGenerator, IImageService imageService)
        {
            this.folderGenerator = folderGenerator;
            this.imageService = imageService;
        }

        public void Generate(ImageProperties imageProperties)
        {
            using (var image = imageService.LoadImage(imageProperties.Image))
            {
                foreach (var imageOutputProperties in imageProperties.ImageOutputProperties)
                {
                    this.folderGenerator.CreateFolderIfNotExists(imageOutputProperties);
                    using (var resizedImage = this.imageService.Resize(image, imageOutputProperties.GetResolution(image)))
                    {
                        this.imageService.SaveImage(resizedImage, new OutputDescriptor(imageProperties, imageOutputProperties));
                    }
                }
            }
        }
    }
}
