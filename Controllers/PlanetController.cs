using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Services;

namespace MyFirstApp.Controllers
{
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;

        public PlanetController(PlanetService planetService)
        {
            _planetService = planetService;
        }
        
        // GET: Planet
        public ActionResult Index()
        {
            return View();
        }

        // route: action
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name {get; set;} // Action ~ PlanetModel
        
        public IActionResult Mercury()
        {
            var planet = _planetService.FirstOrDefault(p => p.Name == Name);
            return View("Detail", planet);
        }

        public IActionResult PlanetInfo(int id)
        {
            var planet = _planetService.FirstOrDefault(p => p.Id == id);
            return View("Detail", planet);
        }
    }
}
