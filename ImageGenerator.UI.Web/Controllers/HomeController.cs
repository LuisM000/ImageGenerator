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
        public ActionResult GenerateImages(IList<HttpPostedFileBase> files)
        {
            var rootPath = Server.MapPath(string.Concat("~/App_Data/", Guid.NewGuid().ToString()));
            var zipFilePath = string.Concat(rootPath, ".zip");
            try
            {
                foreach (var file in files)
                {
                    var imageOutputProperties = ImageOutputPropertiesFactory.CreateForXamarin(Path.GetExtension(file.FileName), rootPath);
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
    }
}