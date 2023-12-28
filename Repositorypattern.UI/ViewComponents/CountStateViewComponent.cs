using Microsoft.AspNetCore.Mvc;
using Repositorypattern.Repositories.Interfaces;

namespace Repositorypattern.UI.ViewComponents
{
    public class CountStateViewComponent : ViewComponent
    {
        private readonly IStateRepo _stateRepo;

        public CountStateViewComponent(IStateRepo stateRepo)
        {
            _stateRepo = stateRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var states = _stateRepo.GetAll();
            int Totalstates = states.Count();
            return View(Totalstates);
        }
    }
}
