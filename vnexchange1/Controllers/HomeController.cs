using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vnexchange1.Data;
using Microsoft.EntityFrameworkCore;

namespace vnexchange1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categoryCount = new Dictionary<string, string>();
            var results = _context.Category.ToList();
            foreach (var result in results)
            {
                categoryCount.Add(result.CategoryId.ToString(), _context.Item.Where(x => x.ItemCategory == result.CategoryId).Count().ToString());
            }
            ViewBag.CategoryCount = categoryCount;            
            //return View();
            return View(await _context.Category.Where(x => x.ParentCategory < 1).ToListAsync());
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
            return View();
        }
    }
}
