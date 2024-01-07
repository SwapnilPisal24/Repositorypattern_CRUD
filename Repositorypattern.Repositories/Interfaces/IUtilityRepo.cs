using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.Repositories.Interfaces
{
    public interface IUtilityRepo
    {
        Task<string> SaveImage(string ContainerName, IFormFile formFile);   
        Task<string> EditImage(string ContainerName, IFormFile formFile, string dbPath);
        Task DeleteImage(string ContainerName, string dbPath);
    }
}
