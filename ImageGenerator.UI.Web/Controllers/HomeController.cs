using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ImageGenerator.Core.Model;
using ImageGenerator.Core.Services;
using ImageGenerator.Core.Utils;
using ImageGenerator.UI.Web.Helpers;

namespace ImageGenerator.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImageOrchestrator imageOrchestrator;
        public HomeController()
        {
            imageOrchestrator = new ImageOrchestrator(new FolderGenerator(), new ImageService());
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateImages(IList<HttpPostedFileBase> files, string json)
        {
            var rootPath = Server.MapPath(string.Concat("~/App_Data/", Guid.NewGuid().ToString()));
            var zipFilePath = string.Concat(rootPath, ".zip");
            try
            {
                foreach (var file in files)
                {
                    var imageOutputProperties = string.IsNullOrEmpty(json)
                        ? ImageOutputPropertiesFactory.CreateForXamarin(Path.GetExtension(file.FileName), rootPath)
                        : this.CreateFromJson(json, Path.GetExtension(file.FileName), rootPath);

                    ImageProperties imageProperties = new ImageProperties()
                    {
                        FileName = Path.GetFileNameWithoutExtension(file.FileName),
                        Image = file.ToArray(),
                        ImageOutputProperties = imageOutputProperties
                    };
                    imageOrchestrator.Generate(imageProperties);
                }

                ZipFile.CreateFromDirectory(rootPath, zipFilePath,
                    CompressionLevel.Fastest, true);

                return File(zipFilePath, "application/zip", "Xamarin_Images.zip");
            }
            catch (Exception ex)
            {
                return View("Index",(object)$"Ups... algo ha ocurrido{ex.StackTrace}");
            }
            finally
            {
                if(Directory.Exists(rootPath))
                    Directory.Delete(rootPath, true);
            }
        }



        private IList<ImageOutputProperties> CreateFromJson(string json, string extension, string rootPath)
        {
            var imagesOutputProperties = ImageOutputPropertiesFactory.CreateListFromJson(json);
            ImageFormat imageFormat = new ImageFormat(extension);
            foreach (var imageOutputProperties in imagesOutputProperties)
            {
                imageOutputProperties.FolderPath.IsAbsolute = true;
                imageOutputProperties.FolderPath.Path =  string.Concat(rootPath, "\\", imageOutputProperties.FolderPath.Path);
                imageOutputProperties.ImageFormat = imageFormat;

            }

            return imagesOutputProperties;
        }
    }
}