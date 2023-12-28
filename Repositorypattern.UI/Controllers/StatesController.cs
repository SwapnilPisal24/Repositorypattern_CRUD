using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;
using Repositorypattern.Entities;
using Repositorypattern.Repositories.Interfaces;
using State = Repositorypattern.Entities.State;

namespace Repositorypattern.UI.Controllers
{
   
    public class StatesController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICountryRepo _countryRepo;

        public StatesController(IStateRepo stateRepo, ICountryRepo countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            var states = _stateRepo.GetAll();
            return View(states);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var countries = _countryRepo.GetAll();
            ViewBag.countryList = new SelectList(countries, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Entities.State state)
        {
            _stateRepo.Save(state);
            return RedirectToAction("Index"); 
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var states = _stateRepo.GetById(Id);
            var countries = _countryRepo.GetAll();
            ViewBag.countryList = new SelectList(countries, "Id", "Name");
            return View(states);
        }
        [HttpPost]
        public  IActionResult Edit(Entities.State state)
        {
            _stateRepo.Edit(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var state = _stateRepo.GetById(Id);
            _stateRepo.Delete(state); 
            return RedirectToAction("Index");

        }
    } 
}
