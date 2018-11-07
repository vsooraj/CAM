using CAM.Entities;
using CAM.Service.Models;
using CAM.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
namespace CAM.Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {

            ViewBag.Title = "softwares overview";
            List<Software> softwares;

            using (HttpClient client = new HttpClient())
            {
                string host = _configuration.GetSection("Host").GetSection("Name").Value;
                client.BaseAddress = new Uri(host);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Softwares").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                softwares = JsonConvert.DeserializeObject<List<Software>>(stringData);

            };

            var homeViewModel = new HomeViewModel()
            {
                Softwares = softwares,
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
