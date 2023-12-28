using Microsoft.AspNetCore.Mvc;
using Repositorypattern.Repositories.Interfaces;

namespace Repositorypattern.UI.ViewComponents
{
    public class CountCityViewComponent : ViewComponent
    {
        private readonly ICityRepo _cityRepo;

        public CountCityViewComponent(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities = _cityRepo.GetAll();
            int TotalCities = cities.Count();
            return View(TotalCities);
        }
    }
}
