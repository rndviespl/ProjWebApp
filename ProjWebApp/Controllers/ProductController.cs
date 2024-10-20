using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjWebApp.Data;
using ProjWebApp.Models;
using System.Web.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace ProjWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Product
        public IActionResult Index(string searchString, int? categoryId)
        {
            var products = _context.Products.Include(p => p.Category).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Title.Contains(searchString));
            }

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value);
            }

            var productList = products.ToList();

            // Отладка: вывод информации о продуктах
            foreach (var product in productList)
            {
                Console.WriteLine($"Product Title: {product.Title}, Price: {product.Price}");
                foreach (var image in product.Images)
                {
                    Console.WriteLine($"Image Path: {image.ImagePath}");
                }
            }
            
            ViewBag.Categories = _context.Categories.ToList();
            return View(productList);
        }


        // GET: Product/Details/5
        public IActionResult Details(int id)
        {
            var product = _context.Products
                .Include(p => p.Images)
                .Include(p => p.ProductAttributes)
                .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
