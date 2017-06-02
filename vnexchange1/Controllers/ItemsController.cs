using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using vnexchange1.Data;
using vnexchange1.Models;

namespace vnexchange1.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items        
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Locations = _context.Location.OrderBy(x => x.SortOrder).ToList();
            ViewBag.ItemTypes = _context.ItemType.OrderBy(x => x.SortOrder).ToList();
            var items = _context.Item.ToList();
            foreach (Item item in items)
            {
                var parseResult = -1;
                var location = int.TryParse(item.ItemLocation, out parseResult);
                item.ItemLocation = _context.Location.First(x => x.LocationId == parseResult).LocationName;
            }
            return View(items);
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .SingleOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Locations = _context.Location.OrderBy(x => x.SortOrder).ToList();
            ViewBag.ItemTypes = _context.ItemType.OrderBy(x => x.SortOrder).ToList();
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemTitle,ItemDescription,ItemPrice,ItemCategory,ItemOwner,ItemDate,ItemLocation,ItemManufacturer,ItemType,CanExchange,CanGiveAway,CanTrade")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.ItemDate = DateTime.Now;
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Locations = _context.Location.OrderBy(x => x.SortOrder).ToList();
            ViewBag.ItemTypes = _context.ItemType.OrderBy(x => x.SortOrder).ToList();
            return View(item);
        }


        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class RequestFormSizeLimitAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
        {
            private readonly FormOptions _formOptions;

            public RequestFormSizeLimitAttribute(int valueCountLimit)
            {
                _formOptions = new FormOptions()
                {
                    MultipartBodyLengthLimit = valueCountLimit,
                    BufferBodyLengthLimit = valueCountLimit,
                    ValueLengthLimit = valueCountLimit,
                    MemoryBufferThreshold = valueCountLimit,
                    ValueCountLimit = valueCountLimit
                };
            }

            public int Order { get; set; }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var features = context.HttpContext.Features;
                var formFeature = features.Get<IFormFeature>();

                if (formFeature == null || formFeature.Form == null)
                {
                    // Request form has not been read yet, so set the limits
                    features.Set<IFormFeature>(new FormFeature(context.HttpContext.Request, _formOptions));
                }
            }
        }
        [RequestFormSizeLimit(valueCountLimit: 2147483647)]
        [HttpPost]
        public IActionResult UploadFilesAjax()
        {
            long size = 0;
            var files = Request.Form.Files;
            var hostingEnvironment = new HostingEnvironment();
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                filename = hostingEnvironment.WebRootPath + $@"\uploads\{filename}";

                var filePath = Path.GetTempPath();
                var fileName = Path.GetTempFileName();

                size += file.Length;
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(fs);
                    //formFile.CopyToAsync(stream);
                }
            }
            string message = $"{files.Count} file(s) / { size} bytes uploaded successfully!";
            return Json(message);
        }

        public JsonResult CreateItem(Item item, ItemImage[] itemImages)
        {
            if (ModelState.IsValid)
            {
                item.ItemDate = DateTime.Now;
                _context.Add(item);
                _context.SaveChanges();
                foreach (ItemImage itemImage in itemImages)
                {
                    itemImage.ItemId = item.ItemId;
                    _context.Add(itemImage);
                }
                _context.SaveChanges();
                return Json(true);
            }
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Locations = _context.Location.OrderBy(x => x.SortOrder).ToList();
            ViewBag.ItemTypes = _context.ItemType.OrderBy(x => x.SortOrder).ToList();
            return Json(true);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.SingleOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemTitle,ItemDescription,ItemPrice,ItemCategory,ItemOwner,ItemDate,ItemLocation,ItemManufacturer,ItemType,CanExchange,CanGiveAway,CanTrade")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .SingleOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.SingleOrDefaultAsync(m => m.ItemId == id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ItemId == id);
        }
    }
}
