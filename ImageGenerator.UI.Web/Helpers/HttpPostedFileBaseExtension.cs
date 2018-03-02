using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ImageGenerator.UI.Web.Helpers
{
    public static class HttpPostedFileBaseExtension
    {
        public static byte[] ToArray(this HttpPostedFileBase httpPostedFileBase)
        {
            byte[] data;
            using (var inputStream = httpPostedFileBase.InputStream)
            {
                if (!(inputStream is MemoryStream memoryStream))
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            return data;
        }
    }
}