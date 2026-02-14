using Microsoft.AspNetCore.Hosting;
using Restaurants.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Storage
{
    public class FileStorage : IFileStorage
    {
        private readonly IWebHostEnvironment _env;
        public FileStorage(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> SaveFileAsync(Stream stream, string fileName, string contentType)
        {
            var uploadFolder = Path.Combine(_env.WebRootPath, "uploads");
            if(!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var UniqueFileName = Guid.NewGuid() +Path.GetExtension(fileName);
            var filePath= Path.Combine(uploadFolder, UniqueFileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await stream.CopyToAsync(fileStream);
            return $"/uploads/{UniqueFileName}";
        }
    }
}
