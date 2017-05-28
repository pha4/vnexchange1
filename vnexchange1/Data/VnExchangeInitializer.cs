using vnexchange1.Models;
using System;
using System.Linq;

namespace vnexchange1.Data
{
    public static class VnExchangeInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            AddCategoryItems(ref context);

            AddLocationItems(ref context);

            AddItemTypes(ref context);

            context.SaveChanges();
        }

        private static void AddCategoryItems(ref ApplicationDbContext context)
        {
            // Look for any category.
            if (context.Category.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
            new Category{CategoryName="Đồ chơi trẻ em", CategoryOrder= 0, CategoryImage ="img/kidToys.jpg", CategoryIcon = "../img/teddy-bear.png"},
            new Category{CategoryName="Quần áo nữ",CategoryOrder= 1,CategoryImage ="img/womanClothes.png", CategoryIcon = "../img/dress.png"},
            new Category{CategoryName="Phụ kiện",CategoryOrder = 2,CategoryImage ="img/accessories.png", CategoryIcon = "../img/cosmetics.png"},
            new Category{CategoryName="Đồ dùng gia đình",CategoryOrder = 3,CategoryImage ="img/housewares1.jpg", CategoryIcon = "../img/pijama.png"},
            new Category{CategoryName="Quần áo trẻ em",CategoryOrder = 4,CategoryImage ="img/kidClothes.png", CategoryIcon = "../img/pijama.png"},
            new Category{CategoryName="Đồ dùng nam",CategoryOrder = 5,CategoryImage ="img/manClothes.png", CategoryIcon = "../img/polo.png"},
            new Category{CategoryName="Sách và tạp chí",CategoryOrder = 6,CategoryImage ="img/books.png", CategoryIcon = "../img/agenda.png"},
            new Category{CategoryName="Đồ dùng trang điểm",CategoryOrder = 7,CategoryImage ="img/Makeup.png", CategoryIcon = "../img/cosmetics.png"}
            };
            foreach (Category s in categories)
            {
                context.Category.Add(s);
            }
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

        private static void AddLocationItems(ref ApplicationDbContext context)
        {
            // Look for any location.
            if (context.Location.Any())
            {
                return;   // DB has been seeded
            }

            var locations = new Location[]
            {
            new Location{LocationName="Quận 1", LocationRegion= "HCM", SortOrder = 0},
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
    }
}