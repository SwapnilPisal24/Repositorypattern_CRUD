using Microsoft.EntityFrameworkCore;
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
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDBContext _context;

        public CityRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Delete(City city)
        {
            _context.cities.Remove(city);
            _context.SaveChanges();
        }

        public void Edit(City city)
        {
            _context.cities.Update(city);
            _context.SaveChanges();

        }

        public IEnumerable<City> GetAll()
        {
            var cities = _context.cities.Include(x => x.State.Country).ToList();
            return cities;
        }


        public City GetById(int id)
        {
            var city = _context.cities.Find(id);
            return city;
        }

        public void Save(City city)
        {
            _context.cities.Add(city);
            _context.SaveChanges();
        }
    }
}
