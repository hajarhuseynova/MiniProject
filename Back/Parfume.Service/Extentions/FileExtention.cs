using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfume.Service.Extentions
{
    public static class FileExtention
    {

        public static bool isImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }
        public static bool isSizeOk(this IFormFile file, int size)
        {
            return file.Length / 1024 / 1024 <= size;
        }

        public static string CreateImage(this IFormFile file, string root, string path)
        {
            string FileName = Guid.NewGuid().ToString() + file.FileName;
            string FullPath = Path.Combine(root, path, FileName);
            using (FileStream filestream = new FileStream(FullPath, FileMode.Create))
            {
                file.CopyTo(filestream);
            }
            return FileName;
        }
    }
}
