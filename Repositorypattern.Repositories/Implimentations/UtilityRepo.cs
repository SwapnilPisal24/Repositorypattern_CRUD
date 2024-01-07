using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Repositorypattern.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.Repositories.Implimentations
{
    public class UtilityRepo : IUtilityRepo
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor _contextAccessor;

        public UtilityRepo(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _contextAccessor = contextAccessor;     
        }

        public Task DeleteImage(string ContainerName, string dbPath)
        {
            if(!string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
            var filename = Path.GetFileName(dbPath);
            var completePath = Path.Combine(_env.WebRootPath, ContainerName, filename);
            if(File.Exists(completePath))
            {
                File.Delete(completePath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string ContainerName, IFormFile formFile, string dbPath)
        {
            await DeleteImage(ContainerName, dbPath);
            return await SaveImage(ContainerName, formFile);

        }

        public async Task<string> SaveImage(string ContainerName, IFormFile formFile)
        {
            var extension = Path.GetExtension(formFile.FileName);
            var filename = $"{Guid.NewGuid}{extension}";
            string folder = Path.Combine(_env.WebRootPath, ContainerName);
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder, filename);
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                await File.WriteAllBytesAsync(filePath, content);

            }
            var basepath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var completepath = Path.Combine(basepath, ContainerName, filename).Replace("\\", "/");
            return completepath;
        }
    }
}
