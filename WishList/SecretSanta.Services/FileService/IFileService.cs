using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SecretSanta.Services.FileService
{
    public interface IFileService
    {
        String SaveFile(HttpPostedFileBase file);
    }
}
