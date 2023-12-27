using Repositorypattern.Entities;
using Repositorypattern.repositories;
using Repositorypattern.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.Repositories.Implimentations
{
    public class CountryRepo : ICountryRepo
    {
        private readonly ApplicationDBContext _context;

        public CountryRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Delete(Country country)
        {
            _context.countries.Remove(country);
            _context.SaveChanges();
        }

        public void Edit(Country country)
        {
            _context.countries.Update(country);
            _context.SaveChanges();

        }

        public IEnumerable<Country> GetAll()
         {
            var countris = _context.countries;
            return countris;
        }

        public Country GetById(int id)
        {
            var country = _context.countries.Find(id);
            return country; 
        }

        public void Save(Country country)
        {
            _context.countries.Add(country);
            _context.SaveChanges();
        }
    }
}
