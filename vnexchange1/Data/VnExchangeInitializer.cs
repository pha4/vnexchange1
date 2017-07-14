using vnexchange1.Models;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace vnexchange1.Data
{
    public static class VnExchangeInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            AddCategoryItems(context);

            AddLocationItems(ref context);

            AddItemTypes(ref context);

            //AddUsers(userManager);

            //context.SaveChanges();

            //AddItems(context);

            context.SaveChanges();

        }

        private static void AddCategoryItems(ApplicationDbContext context)
        {
            // Look for any category.
            if (context.Category.Any())
            {
                return;   // DB has been seeded
            }
            var item = new Category { CategoryName = "Đồ chơi trẻ em", CategoryOrder = 0, CategoryImage = "img/kidToys.jpg", CategoryIcon = "../img/teddy-bear.png" };

            var categories = new List<Category>()
            {

            new Category{CategoryName="Đồ chơi trẻ em 2-5 tuổi", CategoryOrder= 100, CategoryImage ="img/kidToys.jpg", CategoryIcon = "../img/teddy-bear.png"},
            new Category{CategoryName="Đồ chơi trẻ em 5-7 tuổi", CategoryOrder= 101, CategoryImage ="img/kidToys.jpg", CategoryIcon = "../img/teddy-bear.png"},
            new Category{CategoryName="Đồ chơi trẻ em 7-12 tuổi", CategoryOrder= 102, CategoryImage ="img/kidToys.jpg", CategoryIcon = "../img/teddy-bear.png"}

            };

            AddCategoryAndSubCategories(item, categories, context);

            var item1 = new Category { CategoryName = "Quần áo", CategoryOrder = 1, CategoryImage = "img/womanClothes.png", CategoryIcon = "../img/dress.png" };

            var categories1 = new List<Category>()
            {
            new Category{CategoryName="Nữ",CategoryOrder = 200,CategoryImage ="img/womanClothes.png", CategoryIcon = "../img/dress.png"},
            new Category{CategoryName="Nam",CategoryOrder = 201,CategoryImage ="img/womanClothes.jpg", CategoryIcon = "../img/dress.png"},
            new Category{CategoryName="Trẻ em",CategoryOrder = 202,CategoryImage ="img/kidClothes.png", CategoryIcon = "../img/pijama.png"}

            };

            AddCategoryAndSubCategories(item1, categories1, context);

            var item2 = new Category { CategoryName = "Sách", CategoryOrder = 2, CategoryImage = "img/books.png", CategoryIcon = "../img/agenda.png" };

            var categories2 = new List<Category>()
            {
            new Category{CategoryName="Văn học",CategoryOrder = 300,CategoryImage ="img/books.png", CategoryIcon = "../img/agenda.png"},
            new Category{CategoryName="Giáo khoa",CategoryOrder = 301,CategoryImage ="img/books.png", CategoryIcon = "../img/agenda.png"},
            new Category{CategoryName="Truyện tranh",CategoryOrder = 302,CategoryImage ="img/books.png", CategoryIcon = "../img/agenda.png"},
            new Category{CategoryName="Tham khảo",CategoryOrder = 303,CategoryImage ="img/books.png", CategoryIcon = "../img/agenda.png"}
            };

            AddCategoryAndSubCategories(item2, categories2, context);

            var item3 = new Category { CategoryName = "Đồ dùng gia đình", CategoryOrder = 3, CategoryImage = "img/housewares1.jpg", CategoryIcon = "../img/pijama.png" };

            var categories3 = new List<Category>()
            {
            new Category{CategoryName="Bếp",CategoryOrder = 400,CategoryImage ="img/books.png", CategoryIcon = "../img/agenda.png"},
            new Category{CategoryName="Nội thất",CategoryOrder = 401,CategoryImage ="img/books.png", CategoryIcon = "../img/agenda.png"},
            new Category{CategoryName="Phòng tắm",CategoryOrder = 402,CategoryImage ="img/books.png", CategoryIcon = "../img/agenda.png"}
            };

            AddCategoryAndSubCategories(item3, categories3, context);


            var item4 = new Category { CategoryName = "Đồ điện tử", CategoryOrder = 4, CategoryImage = "img/housewares1.jpg", CategoryIcon = "../img/pijama.png" };

            var categories4 = new List<Category>()
            {
            new Category{CategoryName="Điện gia dụng",CategoryOrder = 500,CategoryImage ="img/housewares1.png", CategoryIcon = "../img/agenda.png"},
            new Category{CategoryName="Điện thoại/Máy tính bảng", CategoryOrder = 501,CategoryImage ="img/housewares1.png", CategoryIcon = "../img/agenda.png"},
            new Category{CategoryName="Phòng tắm",CategoryOrder = 502,CategoryImage ="img/housewares1.png", CategoryIcon = "../img/agenda.png"}
            };

            AddCategoryAndSubCategories(item4, categories4, context);

            var item5 = new Category { CategoryName = "Đồ dùng nam", CategoryOrder = 5, CategoryImage = "img/manClothes.png", CategoryIcon = "../img/polo.png" };

            var categories5 = new List<Category>()
            {
                new Category{CategoryName="Quần áo công sở",CategoryOrder = 600,CategoryImage ="img/manClothes.png", CategoryIcon = "../img/polo.png"},
                new Category{CategoryName="Phụ kiện", CategoryOrder = 601,CategoryImage ="img/manClothes.png", CategoryIcon = "../img/polo.png"},
                new Category{CategoryName="Quần áo thể thao",CategoryOrder = 602,CategoryImage ="img/manClothes.png", CategoryIcon = "../img/agenda.png"}
            };

            AddCategoryAndSubCategories(item5, categories5, context);

            var item6 = new Category { CategoryName = "Phụ kiện nữ", CategoryOrder = 6, CategoryImage = "img/accessories.png", CategoryIcon = "../img/cosmetics.png" };

            var categories6 = new List<Category>()
            {
                new Category{CategoryName="Đồ trang điểm",CategoryOrder = 700,CategoryImage ="img/accessories.png", CategoryIcon = "../img/cosmetics.png"},
                new Category{CategoryName="Nước hoa", CategoryOrder = 701,CategoryImage ="img/accessories.png", CategoryIcon = "../img/cosmetics.png"},
                new Category{CategoryName="Ví, giày, kẹp tóc",CategoryOrder = 702,CategoryImage ="img/accessories.png", CategoryIcon = "../img/cosmetics.png"}
            };

            AddCategoryAndSubCategories(item6, categories6, context);

        }


        private static void AddCategoryAndSubCategories(Category category, List<Category> subCategories, ApplicationDbContext context)
        {

            context.Category.Add(category);
            context.SaveChanges();

            foreach (var item in subCategories)
            {
                item.ParentCategory = category.CategoryId;
            }

            context.Category.AddRange(subCategories);
            context.SaveChanges();
        }

        private static void AddItemTypes(ref ApplicationDbContext context)
        {
            // Look for any category.
            if (context.ItemType.Any())
            {
                return;   // DB has been seeded
            }

            var itemTypes = new ItemType[]
            {
            new ItemType{ItemTypeName="Cần", SortOrder = 0},
            new ItemType{ItemTypeName="Có", SortOrder = 1}
            };
            foreach (ItemType s in itemTypes)
            {
                context.ItemType.Add(s);
            }
        }

        private static void AddUsers(UserManager<ApplicationUser> userManager)
        {
            //var _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)); ;
            var user = new ApplicationUser { UserName = "pha4", Email = "pha4@csc.com" };
            var checkUser = userManager.CreateAsync(user, "P@ssword123");
        }

        private static void AddLocationItems(ref ApplicationDbContext context)
        {
            // Look for any location.
            if (context.Location.Any())
            {
                return;   // DB has been seeded
            }

            var locations = new Location[]
            {
            new Location{LocationName="Khác", LocationRegion= "", SortOrder = 0},
            new Location{LocationName="Quận 1", LocationRegion= "HCM", SortOrder = 1},
            new Location{LocationName="Quận 2", LocationRegion= "HCM", SortOrder = 2},
            new Location{LocationName="Quận 3", LocationRegion= "HCM", SortOrder = 3},
            new Location{LocationName="Quận 4", LocationRegion= "HCM", SortOrder = 4},
            new Location{LocationName="Quận 5", LocationRegion= "HCM", SortOrder = 5},
            new Location{LocationName="Quận 6", LocationRegion= "HCM", SortOrder = 6},
            new Location{LocationName="Quận 7", LocationRegion= "HCM", SortOrder = 7},
            new Location{LocationName="Quận 8", LocationRegion= "HCM", SortOrder = 8},
            new Location{LocationName="Quận 9", LocationRegion= "HCM", SortOrder = 9},
            new Location{LocationName="Quận 10", LocationRegion= "HCM", SortOrder = 10},
            new Location{LocationName="Quận 11", LocationRegion= "HCM", SortOrder = 11},
            new Location{LocationName="Quận 12", LocationRegion= "HCM", SortOrder = 12},
            new Location{LocationName="Quận Tân Bình", LocationRegion= "HCM", SortOrder = 13},
            new Location{LocationName="Quận Gò Vấp", LocationRegion= "HCM", SortOrder = 14},
            new Location{LocationName="Quận Phú Nhuận", LocationRegion= "HCM", SortOrder = 15},
            new Location{LocationName="Quận Bình Tân", LocationRegion= "HCM", SortOrder = 16},
            new Location{LocationName="Quận Thủ Đức", LocationRegion= "HCM", SortOrder = 17},
            new Location{LocationName="Quận Tân Phú", LocationRegion= "HCM", SortOrder = 18}
            };

            foreach (Location l in locations)
            {
                context.Location.Add(l);
            }
        }


        private static void AddItems(ApplicationDbContext context)
        {
            // Look for any category.
            if (context.Item.Any())
            {
                return;   // DB has been seeded
            }

            var items = new Item[]
            {
            new Item{
                ItemTitle = "Xe hơi nhựa dành cho bé 5 tuổi trở lên",
                ItemDescription = "Xe đồ chơi rất dễ thương, bền, màu sắc sinh động, phù hợp cho bé trai hiếu động từ 5 tuổi trở lên",
                ItemCategory = 0,
                ItemDate = DateTime.Now,
                ItemLocation = "7",
                ItemPrice = 350000,
                ItemType = 2,
                CanTrade = true,
                CanExchange = true,
                CanGiveAway = false,
                ItemOwner = context.Users.First().Id

            },
            new Item{
                ItemTitle = "Ống nhòm cực nét giá cực sốc",
                ItemDescription = "Một món đồ chơi tuyệt vời cho các em nhỏ từ 5 đến 10 tuổi. Có thể nhòm xa đến khoảng cách 300m với hình ảnh ro ràng. Giá sốc nhât trên thị trường",
                ItemCategory = 0,
                ItemDate = DateTime.Now,
                ItemLocation = "8",
                ItemPrice = 720000,
                ItemType = 2,
                CanTrade = true,
                CanExchange = false,
                CanGiveAway = false,
                ItemOwner = context.Users.First().Id

            }
            };
            foreach (Item s in items)
            {
                context.Item.Add(s);
            }

            context.SaveChanges();
        }
    }
}