using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Massive;
using Microsoft.AspNet.Mvc;

namespace OrmDemo.Controllers
{
    public class HomeController : Controller
    {
        private IConnectionStringProvider connectionStringProvider;

        public HomeController(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Initialize()
        {
            var initialize = new Initialize()
                .With( connectionStringProvider.GetConnectionString("ConnectionString"))
                .CreateDatabase()
                .PopulateDatabase();
            return RedirectToAction("Index");
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
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
