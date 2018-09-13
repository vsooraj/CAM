using CAM.Service.Data.Repository;
using CAM.Service.Models;
using CAM.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace CAM.Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISoftwareRepository _softwareRepository;

        public HomeController(ISoftwareRepository softwareRepository)
        {
            _softwareRepository = softwareRepository;
        }
        public IActionResult Index()
        {

            ViewBag.Title = "softwares overview";

            var softwares = _softwareRepository.Read(); 

            var homeViewModel = new HomeViewModel()
            {
                Softwares = softwares.ToList(),
                Title = "Welcome to Cabot Assete"
            };

            return View(homeViewModel);

     
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
