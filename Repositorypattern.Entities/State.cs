using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.Entities
{
    /// <summary>
    /// State -----------------------(*) City
    /// </summary>
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default State";
        public int CountryId { get; set; } // Foriegn key
        public Country Country { get; set; } = new();        
        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
