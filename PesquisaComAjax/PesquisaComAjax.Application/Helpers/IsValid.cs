using PesquisaComAjax.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace PesquisaComAjax.Application.Helpers
{
    public class IsValid
    {
        
        public static byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;

        }

        public static bool IsImage(HttpPostedFileBase file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }
            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        private static void ObterFotoUpload(HttpPostedFileBase fotoUpload)
        {
            if (fotoUpload != null && fotoUpload.ContentLength > 0)
            {
                MemoryStream ms = new MemoryStream();
                fotoUpload.InputStream.CopyTo(ms);
                var byts = ms.ToArray();
                ms.Dispose();
                byte[] foto = byts;
            }
        }


    }
}
