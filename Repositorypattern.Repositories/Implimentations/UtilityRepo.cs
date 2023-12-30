using Microsoft.AspNetCore.Http;
using Repositorypattern.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.Repositories.Implimentations
{
    public class UtilityRepo : IUtilityRepo
    {
        public Task DeleteFile(string ContainerName, string dbPath)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditImage(string ContainerName, IFormFile formFile, string dbPath)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveImage(string ContainerName, IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}
