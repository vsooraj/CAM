using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CAM.Entities;
using CAM.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CAM.WebUI.Controllers
{
    public class DashboardSystemsController : Controller
    {
        private readonly IConfiguration _configuration;

        public DashboardSystemsController(IConfiguration configuration)
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

            var dashboardSystems = new DashboardSystems()
            {
                Systems = 1000,
                Servers = 20,
                Laptops = 400,
                Desktops = 400,
                Devices = 50,

                Assets = new List<Asset>() {
                    new Asset{ },
                    new Asset{ },
                    new Asset{ },
                    new Asset{ },
                    new Asset{ },
                    new Asset{ },
                    new Asset{ }
                }
            };
            return View(dashboardSystems);
        }
        // GET: DashboardSystems/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboardSystems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardSystems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardSystems/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardSystems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboardSystems/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardSystems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}