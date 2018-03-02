using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGenerator.Core.Model;

namespace ImageGenerator.Core.Services
{
    public class ImageOrchestrator:IImageOrchestrator
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
            var image = imageProperties.GetImage();
            foreach (var imageOutputProperties in imageProperties.ImageOutputProperties)
            {
                this.folderGenerator.CreateFolderIfNotExists(imageOutputProperties);
                using (var resizedImage = this.imageService.Resize(image, imageOutputProperties.GetResolution(image)))
                {

                    this.imageService.SaveImage(resizedImage,new OutputDescriptor(imageProperties,imageOutputProperties));
                }
            }
        }
    }
}
