using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
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
        private IHostingEnvironment _environment;

        public ItemsController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Items        
        [HttpGet("/items/{id}", Name = "ItemList")]
        public IActionResult Index(int? id)
        {
            if (!_context.Item.Any())
            {
                var items = new Item[]
                {
                    new Item
                    {
                        ItemTitle = "Xe hơi nhựa dành cho bé 5 tuổi trở lên",
                        ItemDescription = "Xe đồ chơi rất dễ thương, bền, màu sắc sinh động, phù hợp cho bé trai hiếu động từ 5 tuổi trở lên",
                        ItemCategory = 1,
                        ItemDate = DateTime.Now,
                        ItemLocation = "7",
                        ItemPrice = 350000,
                        ItemType = 2,
                        CanTrade = true,
                        CanExchange = true,
                        CanGiveAway = false,
                        ItemOwner = _context.Users.First().Id

                    },
                    new Item
                    {
                        ItemTitle = "Ống nhòm cực nét giá cực sốc",
                        ItemDescription = "Một món đồ chơi tuyệt vời cho các em nhỏ từ 5 đến 10 tuổi. Có thể nhòm xa đến khoảng cách 300m với hình ảnh ro ràng. Giá sốc nhât trên thị trường",
                        ItemCategory = 1,
                        ItemDate = DateTime.Now,
                        ItemLocation = "8",
                        ItemPrice = 720000,
                        ItemType = 2,
                        CanTrade = true,
                        CanExchange = false,
                        CanGiveAway = false,
                        ItemOwner = _context.Users.First().Id

                    },
                    new Item
                    {
                        ItemTitle = "Nautica Girls' Stripe Seersucker Romper with Fixed Sash",
                        ItemDescription = "Polished wire frames outline these classic Ray-Ban aviators, detailed with logo lettering at one lens. Polarized. Case and cleaning cloth included.",
                        ItemCategory = 2,
                        ItemDate = DateTime.Now,
                        ItemLocation = "8",
                        ItemPrice = 720000,
                        ItemType = 2,
                        CanTrade = true,
                        CanExchange = false,
                        CanGiveAway = false,
                        ItemOwner = _context.Users.First().Id,
                        ItemManufacturer = "Nautica"

                    },
                    new Item
                    {
                        ItemTitle = "Gymboree Big Girls' Short Sleeve Cat in Bunny Ears Graphic Tee",
                        ItemDescription = "Polished wire frames outline these classic Ray-Ban aviators, detailed with logo lettering at one lens. Polarized. Case and cleaning cloth included.",
                        ItemCategory = 2,
                        ItemDate = DateTime.Now,
                        ItemLocation = "9",
                        ItemPrice = 230000,
                        ItemType = 2,
                        CanTrade = true,
                        CanExchange = false,
                        CanGiveAway = false,
                        ItemOwner = _context.Users.First().Id,
                        ItemManufacturer = "Gymboree"

                    },
                    new Item
                    {
                        ItemTitle = "Set quần sóc áo CK hồng phấn cho bạn nữ",
                        ItemDescription = "Màu hồng phấn cực dễ thương, do hơi chật nên mình để lại giá tốt cho bạn nào thực sự thích",
                        ItemCategory = 2,
                        ItemDate = DateTime.Now,
                        ItemLocation = "4",
                        ItemPrice = 230000,
                        ItemType = 2,
                        CanTrade = true,
                        CanExchange = false,
                        CanGiveAway = false,
                        ItemOwner = _context.Users.First().Id,
                        ItemManufacturer = "CK"

                    }
                };
                foreach (Item s in items)
                {
                    _context.Item.Add(s);
                }

                _context.SaveChanges();
            }

            var items1 = new List<Item>();
            if (id != null)
            {
                items1 = _context.Item.Where(x => x.ItemCategory == id).ToList();

                ViewBag.Category = _context.Category.Where(x => x.CategoryId == id).First().CategoryName;

            }
            else
            {
                items1 = _context.Item.ToList();
            }

            foreach (Item item in items1)
            {
                var parseResult = -1;
                var location = int.TryParse(item.ItemLocation, out parseResult);
                item.ItemLocation = _context.Location.First(x => x.LocationId == parseResult).LocationName;

                var images = _context.ItemImage.Where(x => x.ItemId == item.ItemId).ToList();
                item.Images = images;
            }


            ViewBag.Locations = _context.Location.OrderBy(x => x.SortOrder).ToList();
            ViewBag.ItemTypes = _context.ItemType.OrderBy(x => x.SortOrder).ToList();

            return View(items1);
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

            var parseResult = -1;
            var location = int.TryParse(item.ItemLocation, out parseResult);
            item.ItemLocation = _context.Location.First(x => x.LocationId == parseResult).LocationName;

            var images = _context.ItemImage.Where(x => x.ItemId == item.ItemId).ToList();
            item.Images = images;

            var user = _context.Users.First(x => x.Id == item.ItemOwner);
            item.ItemOwner = user != null ? user.UserName : string.Empty;

            return View(item);
        }

        // GET: Items/Create
        [HttpGet("/items/create", Name = "CreateItem")]
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
            var imageList = new List<string>();
            foreach (var file in files)
            {
                var filename = User.Identity.Name + "_" + ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");

                size += file.Length;
                using (var fs = new FileStream(Path.Combine(uploads, filename), FileMode.Create))
                {
                    file.CopyTo(fs);
                }
                imageList.Add(filename);
            }

            ViewBag.ImageList = imageList;
            return Json(imageList);
        }

        public JsonResult CreateItem(Item item, string[] itemImages)
        {
            if (ModelState.IsValid)
            {
                item.ItemDate = DateTime.Now;
                _context.Add(item);
                _context.SaveChanges();
                for (var i = 0; i < itemImages.Length; i++)
                {
                    var itemImage = new ItemImage()
                    {
                        ItemId = item.ItemId,
                        ImagePath = itemImages[i],
                        IsMainImage = i == 0
                    };
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

        public JsonResult SearchItem(string searchText)
        {
            var result = _context.Item.Where(x => x.ItemTitle.Contains(searchText)).ToList();
            return Json(result);
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
