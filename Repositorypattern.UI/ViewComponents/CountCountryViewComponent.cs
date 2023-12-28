using Microsoft.AspNetCore.Mvc;
using Repositorypattern.Repositories.Interfaces;

namespace Repositorypattern.UI.ViewComponents
{
    public class CountCountryViewComponent : ViewComponent
    {
        private readonly ICountryRepo _countryRepo;

        public CountCountryViewComponent(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var countries = _countryRepo.GetAll();
            int TotalCount = countries.Count();                
            return View(TotalCount);
        }

    }
}
