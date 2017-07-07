using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vnexchange1.Data;
using vnexchange1.Models;
using vnexchange1.ViewModels;

namespace vnexchange1.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Categories
        //public ActionResult Index()
        public List<Category> Index()
        {
            return (_context.Category.ToList());
            //var originalResults = _context.Category.ToList();
            //var results = new List<CategoryViewModel>();

            //if (originalResults != null && originalResults.Count > 0)
            //{
            //    foreach (var result in originalResults)
            //    {
            //        results.Add(new CategoryViewModel
            //        {
            //            CategoryId = result.CategoryId,
            //            CategoryIcon = result.CategoryIcon,
            //            CategoryImage = result.CategoryImage,
            //            CategoryName = result.CategoryName,
            //            CategoryOrder = result.CategoryOrder,
            //            CategoryCount = _context.Category.Where(x => x.CategoryId == result.CategoryId).Count()
            //        });
            //    }
            //}
            //return View(results);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .SingleOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryOrder,CategoryImage")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.SingleOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,CategoryOrder,CategoryImage")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .SingleOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.SingleOrDefaultAsync(m => m.CategoryId == id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
