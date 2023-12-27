using Repositorypattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.Repositories.Interfaces
{
    public interface ICountryRepo 
    {
        IEnumerable<Country> GetAll();
        
        Country GetById(int id);
        void Save(Country country);
        void Edit(Country country);
        void Delete(Country country);

    }
}
