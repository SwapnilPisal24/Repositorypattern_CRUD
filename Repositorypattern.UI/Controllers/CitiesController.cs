using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositorypattern.Entities;
using Repositorypattern.Repositories.Interfaces;

namespace Repositorypattern.UI.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICityRepo _cityRepo;

        public CitiesController(IStateRepo stateRepo, ICityRepo cityRepo)
        {
            _stateRepo = stateRepo;
            _cityRepo = cityRepo;
        }

        public IActionResult Index()
        {
            var cities = _cityRepo.GetAll();
            return View(cities);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var states = _stateRepo.GetAll();
            ViewBag.stateList = new SelectList(states, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(City city)
        {
            _cityRepo.Save(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var city = _cityRepo.GetById(Id);
            var states = _stateRepo.GetAll();
            ViewBag.stateList = new SelectList(states, "Id", "Name");
            return View(city);
        }
        [HttpPost]
        public IActionResult Edit(City city)
        {
            _cityRepo.Edit(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var city = _cityRepo.GetById(Id);
            _cityRepo.Delete(city);
            return RedirectToAction("Index");

        }

    }
}
