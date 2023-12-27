using Repositorypattern.Entities;
using Repositorypattern.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.Repositories.Interfaces
{
    public interface ICityRepo
    {
        IEnumerable<City> GetAll();
        City GetById(int id);
        void Save(City city);
        void Edit(City city);
        void Delete(City city);

    }
}
