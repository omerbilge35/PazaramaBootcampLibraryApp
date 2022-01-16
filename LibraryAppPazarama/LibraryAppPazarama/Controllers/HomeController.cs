using LibraryAppPazarama.Data;
using LibraryAppPazarama.Models;
using LibraryAppPazarama.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAppPazarama.Controllers
{
    public class HomeController : Controller
    {

        private readonly LibraryDbContext _context;

        public HomeController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            var model = new HomePageViewModel
            {
                PopularBooks = _context.Books.ToList()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
