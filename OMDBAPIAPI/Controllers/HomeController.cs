using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMDBAPIAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OMDBAPIAPI.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MoviesDAL md = new MoviesDAL();
            md.GetMovie("shrek");
            return View();

        }

        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieSearch(string Title)
        {
            MoviesDAL m= new MoviesDAL();
            Movies mov = m.GetMovie(Title);
            return View(mov);
        }

        public IActionResult MovieNight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            MoviesDAL m = new MoviesDAL();
            Movies mov1 = m.GetMovie(title1);
            Movies mov2 = m.GetMovie(title2);
            Movies mov3 = m.GetMovie(title3);
            List<Movies> listMove = new List<Movies>();
            listMove.Add(mov1);
            listMove.Add(mov2);
            listMove.Add(mov3);
            return View(listMove);

        }
        
        public IActionResult Privacy()
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
