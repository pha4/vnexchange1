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
using vnexchange1.Object;
using vnexchange1.PaginatedList;
using Microsoft.AspNetCore.Identity;
using vnexchange1.ViewModels;

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
        //[HttpGet("/items/{id}/{page}", Name = "ItemList")]
        public IActionResult Index(int? id, int? page)
        {
            //if (!_context.Item.Any())
//            if (false)
//            {
//                var user = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
//                var itemOwner = user.Id;
//                var userEmail = user.Email;
//                var xeday4banh = new Item
//                {
//                    ItemTitle = "Xe đẩy 4 bánh cho bé",
//                    ItemDescription = "xe đẩy cho bé nhập khẩu Úc" +
//"một chiếc xe đẩy em bé sẽ là sự lựa chọn tốt cho bạn giúp bạn vừa chăm sóc bé," +
//"vừa rảnh tay hơn công việc.Với 1 chiếc xe đẩy phù hợp cho bé," +
//"bạn chỉ cần để em bé nằm hoặc ngồi trên xe và làm công việc của mình hay đưa em bé đi dạo 1 cách dệ dàng.",
//                    ItemCategory = 2,
//                    ItemDate = DateTime.Now,
//                    ItemLocation = "12",
//                    ItemPrice = 2300000,
//                    ItemType = 1,
//                    CanTrade = true,
//                    CanExchange = true,
//                    CanGiveAway = false,
//                    ItemOwner = itemOwner

//                };
//                _context.Item.Add(xeday4banh);
//                for (var i = 1; i < 4; i++)
//                {
//                    var itemImage = new ItemImage()
//                    {
//                        ItemId = xeday4banh.ItemId,
//                        ImagePath = userEmail + "_" + "xeday4banh" + i.ToString() + ".jpg",
//                        IsMainImage = i == 0
//                    };
//                    _context.ItemImage.Add(itemImage);
//                }
//                _context.SaveChanges();

//                var xeday = new Item
//                {
//                    ItemTitle = "Xe đẩy bé 3 bánh",
//                    ItemDescription = "Xe phun tuyết nháy đèn, xe đẩy êm không rung lắc",
//                    ItemCategory = 2,
//                    ItemDate = DateTime.Now,
//                    ItemLocation = "12",
//                    ItemPrice = 0,
//                    ItemType = 1,
//                    CanTrade = false,
//                    CanExchange = true,
//                    CanGiveAway = true,
//                    ItemOwner = itemOwner

//                };
//                _context.Item.Add(xeday3banh);
//                for (var i = 1; i < 2; i++)
//                {
//                    var itemImage = new ItemImage()
//                    {
//                        ItemId = xeday.ItemId,
//                        ImagePath = userEmail + "_" + "xeday" + i.ToString() + ".jpg",
//                        IsMainImage = i == 0
//                    };
//                    _context.ItemImage.Add(itemImage);
//                }                

//                _context.SaveChanges();

//                var xeoto = new Item
//                {
//                    ItemTitle = "xe ô tô cho bé chạy 2 bình 2 máy",
//                    ItemDescription = "xe mới 100% bán lẻ giá sỉ còn nhiều mẫu xe khác liên hệ để biết thêm." +
//"Xe đẩy seebabyT03 là sản phẩm mang một phong cách rất hiện đại của SeeBaby " +
//"Xe đẩy seebabyT03 là sản phẩm mang một phong cách rất hiện đại của SeeBaby " +
//                    "Dây an toàn 3 điểm. Phanh và hệ thống treo an toàn hai bánh sau " +
//"Đệm ghế êm ái, lưng ghế có thể thay đổi nhiều vị trí mang lại cho bé các tư thế nằm, ngồi thoải mái " +
//"Bao test mọi chức năng đến hết bảo hành.",
//                    ItemCategory = 2,
//                    ItemDate = DateTime.Now,
//                    ItemLocation = "5",
//                    ItemPrice = 1300000,
//                    ItemType = 1,
//                    CanTrade = true,
//                    CanExchange = true,
//                    CanGiveAway = false,
//                    ItemOwner = itemOwner,
//                    ItemStatus = "Như mới"

//                };
//                _context.Item.Add(iphone);
//                for (var i = 1; i < 4; i++)
//                {
//                    var itemImage = new ItemImage()
//                    {
//                        ItemId = iphone.ItemId,
//                        ImagePath = "pha4@csc.com_iphone" + i.ToString() + ".jpg",
//                        IsMainImage = i == 0
//                    };
//                    _context.ItemImage.Add(itemImage);

//                }
//                _context.SaveChanges();

//                var samsung = new Item
//                {
//                    ItemTitle = "Samsung Galaxy A7 2017 dual 2 sim A720F/DS black",
//                    ItemDescription = "Tình trạng : Hàng công ty chính hãng Samsung Việt Nam, còn đẹp khoảng 99%, like new, nguyên zin, còn bảo hành chính hãng toàn quốc đến 05/2018",
//                    ItemCategory = 20,
//                    ItemDate = DateTime.Now,
//                    ItemLocation = "7",
//                    ItemPrice = 7100000,
//                    ItemType = 1,
//                    CanTrade = true,
//                    CanExchange = true,
//                    CanGiveAway = false,
//                    ItemOwner = itemOwner,
//                    ItemStatus = "Fullbox (trùng imel)"

//                };
//                _context.Item.Add(samsung);
//                for (var i = 1; i < 5; i++)
//                {
//                    var itemImage = new ItemImage()
//                    {
//                        ItemId = samsung.ItemId,
//                        ImagePath = "pha4@csc.com_samsung" + i.ToString() + ".jpg",
//                        IsMainImage = i == 0
//                    };
//                    _context.ItemImage.Add(itemImage);

//                }
//                _context.SaveChanges();

//                var jade = new Item
//                {
//                    ItemTitle = "Vòng ngọc Jade thiên nhiên",
//                    ItemDescription = "Vòng ngọc Jade thiên nhiên. • Với vẻ đẹp thuần túy, không quá kiêu sa.Như một lời nhắn nhủ bình an - như ý. • Ni : 51.5 mm, Màu sắc: xanh đậm, Kiểu: Bản lá hẹ",
//                    ItemCategory = 26,
//                    ItemDate = DateTime.Now,
//                    ItemLocation = "2",
//                    ItemPrice = 500000,
//                    ItemType = 1,
//                    CanTrade = true,
//                    CanExchange = true,
//                    CanGiveAway = false,
//                    ItemOwner = itemOwner,
//                    ItemStatus = "Mới 100%",
//                    ItemColor = "Xanh lá hẹ"
//                };
//                _context.Item.Add(jade);
//                for (var i = 1; i < 3; i++)
//                {
//                    var itemImage = new ItemImage()
//                    {
//                        ItemId = jade.ItemId,
//                        ImagePath = "pha4@csc.com_jade" + i.ToString() + ".jpg",
//                        IsMainImage = i == 0
//                    };
//                    _context.ItemImage.Add(itemImage);

//                }
//                _context.SaveChanges();

//            }

            var items1 = new List<Item>();
            if (id != null)
            {

                items1 = _context.Item.Where(x => x.ItemCategory == id && x.IsApproved && !x.IsClosed && !x.IsHide).ToList();
                var subCategories = _context.Category.Where(x => x.ParentCategory == id).ToList();
                foreach (var subCategory in subCategories)
                {
                    items1.AddRange(_context.Item.Where(x => x.ItemCategory == subCategory.CategoryId && x.IsApproved && !x.IsClosed && !x.IsHide));
                }

                ViewBag.Category = _context.Category.Where(x => x.CategoryId == id).First().CategoryName;

            }
            else
            {
                items1 = _context.Item.Where(x => x.IsApproved && !x.IsClosed && !x.IsHide).ToList();
            }

            foreach (Item item in items1)
            {
                var parseResult = -1;
                var location = int.TryParse(item.ItemLocation, out parseResult);
                item.ItemLocation = _context.Location.First(x => x.LocationId == parseResult).LocationName;

                var images = _context.ItemImage.Where(x => x.ItemId == item.ItemId).ToList();
                item.Images = images;

                var owner = _context.Users.FirstOrDefault(x => x.Id == item.ItemOwner);
                if (owner != null)
                {
                    item.ItemOwner = owner.UserName;
                }
            }

            SetViewBagData("all", 0, 0, 0, page ?? 1, 10, items1.Count() / 10);

            ViewBag.Action = "Index";

            var pagingResult = PaginatedList<Item>.Create(items1, page ?? 1, 10);

            return View(pagingResult);
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

            GenerateBreadCrumb(item.ItemCategory);

            var interestingItems = new List<InterestingItemViewModel>();

            var items1 = _context.Item.Where(x => x.ItemCategory == item.ItemCategory && x.IsApproved && !x.IsClosed && !x.IsHide && x.ItemId != id).ToList();
            var subCategories = _context.Category.Where(x => x.ParentCategory == item.ItemCategory).ToList();
            foreach (var subCategory in subCategories)
            {
                items1.AddRange(_context.Item.Where(x => x.ItemCategory == subCategory.CategoryId && x.IsApproved && !x.IsClosed && !x.IsHide && x.ItemId != id));
            }

            foreach (Item item1 in items1)
            {
                var images1 = _context.ItemImage.Where(x => x.ItemId == item1.ItemId).ToList();
                item1.Images = images1;
            }

            ViewBag.InterestingItems = items1;

            SetViewBagData("all", 0, 0, 0, 1, 10, 0);

            return View(item);
        }

        private void GenerateBreadCrumb(int itemCategory)
        {
            var category = _context.Category.FirstOrDefault(x => x.CategoryId == itemCategory);

            var breadCrumb = new List<Category>();

            if (category.ParentCategory != 0)
            {
                var parentCategory = _context.Category.FirstOrDefault(x => x.CategoryId == category.ParentCategory);
                breadCrumb.Add(parentCategory);
            }

            breadCrumb.Add(category);

            ViewBag.BreadCrumb = breadCrumb;
        }

        [HttpGet("/items/search/{search}", Name = "Search")]
        public IActionResult Search(string search)
        {
            var results = _context.Item.Where(x => x.ItemTitle.Contains(search) && x.IsApproved && !x.IsClosed && !x.IsHide).ToList();

            foreach (Item item in results)
            {
                var parseResult = -1;
                var location = int.TryParse(item.ItemLocation, out parseResult);
                item.ItemLocation = _context.Location.First(x => x.LocationId == parseResult).LocationName;

                var images = _context.ItemImage.Where(x => x.ItemId == item.ItemId).ToList();
                item.Images = images;

                var owner = _context.Users.FirstOrDefault(x => x.Id == item.ItemOwner);
                if (owner != null)
                {
                    item.ItemOwner = owner.UserName;
                }
            }

            SetViewBagData("all", 0, 0, 0, 1, 10, results.Count() / 10);

            ViewBag.Action = "Search";

            var pagingResult = PaginatedList<Item>.Create(results, 1, 10);

            return View(pagingResult);
        }

        private void SetViewBagData(string searchText, int locationID, int itemTypeID, int categoryID, int page, int itemPerPage, int numberOfPage)
        {
            ViewBag.Locations = _context.Location.OrderBy(x => x.SortOrder).ToList();
            ViewBag.ItemTypes = _context.ItemType.OrderBy(x => x.SortOrder).ToList();
            ViewBag.Categories = _context.Category.ToList();

            ViewBag.SearchText = searchText;
            ViewBag.LocationID = locationID;
            ViewBag.ItemTypeID = itemTypeID;
            ViewBag.CategoryID = categoryID;
            ViewBag.ItemPerPage = itemPerPage;
            ViewBag.Page = page;

            var firstThreeNewestItems = _context.Item.Where(x => x.IsApproved && !x.IsClosed && !x.IsHide).OrderBy(x => x.ItemDate).Take(3).ToList();
            var carouselHighlightItems = new List<CarouselHighlightItem>();
            foreach (var firstThreeNewestItem in firstThreeNewestItems)
            {
                var carouselHighlightItem = new CarouselHighlightItem
                {
                    ItemID = firstThreeNewestItem.ItemId,
                    ItemOwner = firstThreeNewestItem.ItemOwner,
                    ItemPrice = firstThreeNewestItem.ItemPrice,
                    ItemTitle = firstThreeNewestItem.ItemTitle,
                    ItemStatus = firstThreeNewestItem.ItemStatus,
                    ItemLocation = firstThreeNewestItem.ItemLocation,
                    ItemOwnerID = firstThreeNewestItem.ItemOwner
                };

                var itemImage = _context.ItemImage.FirstOrDefault(x => x.ItemId == firstThreeNewestItem.ItemId);
                var owner = _context.Users.FirstOrDefault(x => x.Id == firstThreeNewestItem.ItemOwner);
                var location = _context.Location.FirstOrDefault(x => x.LocationId.ToString() == firstThreeNewestItem.ItemLocation);

                carouselHighlightItem.ItemImage = itemImage != null ? itemImage.ImagePath : "";
                carouselHighlightItem.ItemOwner = owner != null ? owner.UserName : "";
                carouselHighlightItem.ItemLocation = location != null ? location.LocationName : "";
                carouselHighlightItems.Add(carouselHighlightItem);
            }

            ViewBag.CarouselHighlightItems = carouselHighlightItems;

            var pages = new List<int>();

            for (var i = 1; i <= numberOfPage; i++)
            {
                pages.Add(i);
            }

            ViewBag.Pages = pages;
        }

        //[HttpGet("/items/search/{advanceSearchText}/{location}/{category}/{itemType}", Name = "AdvanceSearch")]
        public IActionResult Search(string advanceSearchText, int location, int category, int itemType, int? page, int? itemPerPage)
        {

            var category1 = _context.Category.FirstOrDefault(x => x.CategoryId == category);
            var subCategories = new List<string>();
            if (category1 != null && category1.ParentCategory == 0)
            {
                var subCategories1 = _context.Category.Where(x => x.ParentCategory == category1.CategoryId).ToList();
                foreach (var subCategory in subCategories1)
                {
                    subCategories.Add(subCategory.CategoryId.ToString());
                }
            }

            var results = _context.Item.Where(x => (advanceSearchText == "all" || x.ItemTitle.Contains(advanceSearchText)) &&
                (location == 0 || x.ItemLocation == location.ToString()) &&
                (category == 0 || x.ItemCategory == category || subCategories.IndexOf(x.ItemCategory.ToString()) > 0) &&
                (itemType == 0 || x.ItemType == itemType) &&
                x.IsApproved && !x.IsClosed && !x.IsHide).ToList();



            foreach (Item item in results)
            {
                var parseResult = -1;
                int.TryParse(item.ItemLocation, out parseResult);
                item.ItemLocation = _context.Location.First(x => x.LocationId == parseResult).LocationName;

                var images = _context.ItemImage.Where(x => x.ItemId == item.ItemId).ToList();
                item.Images = images;

                var owner = _context.Users.FirstOrDefault(x => x.Id == item.ItemOwner);
                if (owner != null)
                {
                    item.ItemOwner = owner.UserName;
                }
            }

            SetViewBagData(advanceSearchText, location, itemType, category, page ?? 1, itemPerPage ?? 10, results.Count() / itemPerPage ?? 10);

            ViewBag.Action = "Index";

            var pagingResult = PaginatedList<Item>.Create(results, page ?? 1, itemPerPage ?? 10);

            return View(pagingResult);
        }

        // GET: Items/Create
        [HttpGet("/items/create", Name = "CreateItem")]
        public IActionResult Create()
        {
            var subCategories = new Dictionary<int, List<Category>>();
            var categories = _context.Category.Where(x => x.ParentCategory < 1).ToList();
            ViewBag.Categories = categories;
            foreach (var category in categories)
            {
                var subCategories1 = _context.Category.Where(x => x.ParentCategory == category.CategoryId).ToList();
                subCategories.Add(category.CategoryId, subCategories1);
            }
            ViewBag.SubCategories = subCategories;
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
                item.IsApproved = true;
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

        public JsonResult CreateRequest(string itemID, string requestType, string message)
        {
            var itemRequest = new ItemRequest()
            {
                ItemID = itemID,
                RequestType = requestType,
                Message = message,
                RequestorID = User.Identity.Name
            };

            _context.ItemRequest.Add(itemRequest);
            _context.SaveChanges();
            return Json(true);
        }

        public JsonResult SearchItem(string searchText)
        {
            var result = _context.Item.Where(x => x.ItemTitle.Contains(searchText) && x.IsApproved && !x.IsClosed && !x.IsHide).ToList();
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
