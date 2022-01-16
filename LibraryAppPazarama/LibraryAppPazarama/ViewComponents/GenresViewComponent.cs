using LibraryAppPazarama.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAppPazarama.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly LibraryDbContext _context;
        public GenresViewComponent(LibraryDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(_context.Genres.ToList());
        }

    }
}
