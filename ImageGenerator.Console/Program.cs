using System;
using System.Collections.Generic;
using System.IO;
using ImageGenerator.Services;
using ImageGenerator.Services.Utils;

namespace ImageGenerator.Console
{
    class Program
    {
        static readonly ImageOrchestrator imageOrchestrator =
           new ImageOrchestrator(new FolderGenerator(), new ImageService());

        static void Main(string[] args)
        {

            string filePath = args[0];
            string outputFolder = args[1];
            string jsonFilePath = null;
            if (args.Length > 2)
            {
                jsonFilePath = args[2];
            }



            IList<ImageOutputProperties> outputProperties;
            if (jsonFilePath == null)
            {
                outputProperties = ImageOutputPropertiesFactory.CreateForXamarin(Path.GetExtension(filePath), outputFolder);
            }
            else
            {
                string json = File.ReadAllText(jsonFilePath);
                outputProperties = ImageOutputPropertiesFactory.CreateListFromJson(json);
            }

            var file = File.ReadAllBytes(filePath);

            ImageProperties imageProperties = new ImageProperties()
            {
                FileName = Path.GetFileNameWithoutExtension(filePath),
                Image = file,
                ImageOutputProperties = outputProperties
            };


            imageOrchestrator.Generate(imageProperties);
        }
    }
}
