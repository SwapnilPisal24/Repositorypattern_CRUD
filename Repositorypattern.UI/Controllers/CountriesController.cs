using Microsoft.AspNetCore.Mvc;
using Repositorypattern.Entities;
using Repositorypattern.Repositories.Interfaces;

namespace Repositorypattern.UI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepo _countryRepo;

        public CountriesController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("UserId")!=null)
            {
                var countries = _countryRepo.GetAll();
                return View(countries);
            }
            return RedirectToAction("Login","Auth");
        }
        [HttpGet]
        public IActionResult Create()
        {
            Country country = new Country();
            return View(country);
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            _countryRepo.Save(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var country = _countryRepo.GetById(Id);
            return View(country);
        }
        [HttpPost]
        public IActionResult Edit(Country country)
        {
            _countryRepo.Edit(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var country = _countryRepo.GetById(Id);
            _countryRepo.Delete(country);
            return RedirectToAction("Index");
        }
    }
} 
