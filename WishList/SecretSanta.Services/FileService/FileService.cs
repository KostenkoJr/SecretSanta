using SecretSanta.Data.Models;
using System;
using System.IO;
using System.Web;

namespace SecretSanta.Services.FileService
{
    public class FileService //: IFileService
    {
        public static string SaveFile(HttpPostedFileBase file)
        {
            if (file == null)
                return null;
            String guid = Guid.NewGuid().ToString();
            Picture picture = new Picture(guid, file);
            //file.SaveAs(Path.Combine($"C:\\Users\\danil\\Desktop\\WishList\\WishList\\WishList\\Files\\{picture.Path}"));
            var p = System.Web.Hosting.HostingEnvironment.MapPath($"~/Files/{picture.Path}");
            file.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath($"~/Files/{picture.Path}"));
            return picture.Path;
        }
    }
}
