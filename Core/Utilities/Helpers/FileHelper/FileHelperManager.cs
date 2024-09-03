using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelperService
    {
        public string Update(IFormFile file, string filePath, string root)
        {
            if (file.Length > 0)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                return Upload(file, root);
            }
            return null;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                var extension = Path.GetExtension(file.FileName);
                var fileName = $"{GuidHelper.GuidHelper.CreateGuid()}{extension}"; // GuidHelper sınıfının CreateGuid metodunu kullanıyoruz
                var filePath = Path.Combine(root, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return fileName;
            }
            return null;
        }
    }
}
