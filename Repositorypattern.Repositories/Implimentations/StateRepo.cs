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
    public class StateRepo : IStateRepo
    {

        private readonly ApplicationDBContext _context;

        public StateRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Delete(State state)
        {
            _context.states.Remove(state);
            _context.SaveChanges();
        }

        public void Edit(State state)
        {
            _context.states.Update(state);
            _context.SaveChanges();
        }

        public IEnumerable<State> GetAll()
        {
            var States = _context.states.Include(x => x.Country).ToList(); // Include use for agor loading
            return States;
        }

        public State GetById(int id)
        {
            var state = _context.states.Find(id);
            return state;
        }

        public void Save(State state)
        {
            _context.states.Add(state);
            _context.SaveChanges();

        }
    }
}
