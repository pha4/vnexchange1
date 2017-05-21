using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vnexchange1.Data;
using vnexchange1.Models;

namespace vnexchange1.Controllers
{
    public class ItemImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemImagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ItemImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemImage.ToListAsync());
        }

        // GET: ItemImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemImage = await _context.ItemImage
                .SingleOrDefaultAsync(m => m.ItemImageId == id);
            if (itemImage == null)
            {
                return NotFound();
            }

            return View(itemImage);
        }

        // GET: ItemImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemImageId,ItemId,ImagePath,IsMainImage")] ItemImage itemImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemImage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(itemImage);
        }

        // GET: ItemImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemImage = await _context.ItemImage.SingleOrDefaultAsync(m => m.ItemImageId == id);
            if (itemImage == null)
            {
                return NotFound();
            }
            return View(itemImage);
        }

        // POST: ItemImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemImageId,ItemId,ImagePath,IsMainImage")] ItemImage itemImage)
        {
            if (id != itemImage.ItemImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemImageExists(itemImage.ItemImageId))
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
            return View(itemImage);
        }

        // GET: ItemImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemImage = await _context.ItemImage
                .SingleOrDefaultAsync(m => m.ItemImageId == id);
            if (itemImage == null)
            {
                return NotFound();
            }

            return View(itemImage);
        }

        // POST: ItemImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemImage = await _context.ItemImage.SingleOrDefaultAsync(m => m.ItemImageId == id);
            _context.ItemImage.Remove(itemImage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ItemImageExists(int id)
        {
            return _context.ItemImage.Any(e => e.ItemImageId == id);
        }
    }
}
