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
    public class ItemRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemRequestsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ItemRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemRequest.ToListAsync());
        }

        // GET: ItemRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemRequest = await _context.ItemRequest
                .SingleOrDefaultAsync(m => m.RequestID == id);
            if (itemRequest == null)
            {
                return NotFound();
            }

            return View(itemRequest);
        }

        // GET: ItemRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,ItemID,RequestorID,Message,RequestType")] ItemRequest itemRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(itemRequest);
        }

        // GET: ItemRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemRequest = await _context.ItemRequest.SingleOrDefaultAsync(m => m.RequestID == id);
            if (itemRequest == null)
            {
                return NotFound();
            }
            return View(itemRequest);
        }

        // POST: ItemRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,ItemID,RequestorID,Message,RequestType")] ItemRequest itemRequest)
        {
            if (id != itemRequest.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemRequestExists(itemRequest.RequestID))
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
            return View(itemRequest);
        }

        // GET: ItemRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemRequest = await _context.ItemRequest
                .SingleOrDefaultAsync(m => m.RequestID == id);
            if (itemRequest == null)
            {
                return NotFound();
            }

            return View(itemRequest);
        }

        // POST: ItemRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemRequest = await _context.ItemRequest.SingleOrDefaultAsync(m => m.RequestID == id);
            _context.ItemRequest.Remove(itemRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ItemRequestExists(int id)
        {
            return _context.ItemRequest.Any(e => e.RequestID == id);
        }
    }
}
