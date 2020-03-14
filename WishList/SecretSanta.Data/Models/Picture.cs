using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SecretSanta.Data.Models
{
    public class Picture
    {
        [Key]
        public String GuidName { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }
        public Picture(String guid, HttpPostedFileBase file)
        {
            GuidName = guid;
            Name = file.FileName;
            Path = $"{guid}{System.IO.Path.GetExtension(file.FileName)}";
        }
    }
}
