using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Infrastructure.Services;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Routing http://localhost/home/index
        //by default it's get
        [HttpGet]
        public IActionResult Index()
        {
            // call movie service class to get list of movie card models
            MovieService service = new MovieService();
            var movieCards = service.GetTop30RevenueMovies();

            //passing data from controller to view: strongly typed; ViewBag and ViewData

            ViewBag.PageTitle = "Top Revenue Movies";
            ViewData["xxx"] = "testdata";
            return View(movieCards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CU()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
