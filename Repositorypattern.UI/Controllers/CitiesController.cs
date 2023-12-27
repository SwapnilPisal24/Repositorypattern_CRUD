using Microsoft.AspNetCore.Mvc;
using Repositorypattern.Repositories.Interfaces;

namespace Repositorypattern.UI.Controllers
{
    public class CitiesController : Controller
    {
        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
    }
}
