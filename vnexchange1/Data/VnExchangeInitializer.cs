using vnexchange1.Models;
using System;
using System.Linq;

namespace vnexchange1.Data
{
    public static class VnExchangeInitializer
    {
        public static void Initialize(VnExchangeContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
            new Category{CategoryName="Đồ chơi trẻ em", CategoryOrder= 0, CategoryImage ="img/kidToys.jpg"},
            new Category{CategoryName="Quần áo nữ",CategoryOrder= 1,CategoryImage ="img/womanClothes.png"},
            new Category{CategoryName="Phụ kiện",CategoryOrder = 2,CategoryImage ="img/accessories.png"},
            new Category{CategoryName="Đồ dùng gia đình",CategoryOrder = 3,CategoryImage ="img/housewares1.jpg"},
            new Category{CategoryName="Quần áo trẻ em",CategoryOrder = 4,CategoryImage ="img/kidClothes.png"},
            new Category{CategoryName="Đồ dùng nam",CategoryOrder = 5,CategoryImage ="img/manClothes.png"},
            new Category{CategoryName="Sách và tạp chí",CategoryOrder = 6,CategoryImage ="img/books.png"},
            new Category{CategoryName="Đồ dùng trang điểm",CategoryOrder = 7,CategoryImage ="img/Makeup.png"}
            };
            foreach (Category s in categories)
            {
                context.Categories.Add(s);
            }
            context.SaveChanges();

        }
    }
}