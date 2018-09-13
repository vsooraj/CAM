using CAM.Service.Data.Repository;
using CAM.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            var softwares = _softwareRepository.Read();
            return View(softwares);
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
