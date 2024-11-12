using LR9.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR9.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // Створення колекції
            var products = new List<ProductModel>
        {
            new ProductModel { ID = 1, Name = "Four cheese", Price = 11.49m },
            new ProductModel { ID = 2, Name = "Pepperoni", Price = 10.99m },
            new ProductModel { ID = 3, Name = "Caesar salad", Price = 6.49m },
            new ProductModel { ID = 4, Name = "Pasta carbonara", Price = 10.99m },
            new ProductModel { ID = 5, Name = "Iced tea", Price = 2.19m },
            new ProductModel { ID = 6, Name = "Orange juice", Price = 2.49m }
        };

            // Передача колекції у подання
            return View(products);
        }
    }
}
