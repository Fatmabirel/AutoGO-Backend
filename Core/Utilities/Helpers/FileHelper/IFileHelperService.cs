using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelperService
    {
        string Upload(IFormFile file, string root); // Dosya yükleme
        string Update(IFormFile file, string filePath, string root); // Dosya güncelleme
        void Delete(string filePath); // Dosya silme
    }
}
