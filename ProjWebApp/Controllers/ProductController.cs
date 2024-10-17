using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjWebApp.Data;
using ProjWebApp.Models;

namespace ProjWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: ProductController
        // GET: Product

        public IActionResult Index()
        {
            var products = _context.Products.ToList(); // Получение списка продуктов
            if (products == null || !products.Any())
            {
                // Логирование или отладка
                Console.WriteLine("No products found.");
            }
            return View(products); // Возвращает представление "Index" с продуктами
        }

        // GET: Product/Details/5
        public IActionResult Details(int id)
        {
            var product = _context.Products
                .Include(p => p.ProductAttributes) // Включение атрибутов продукта
                .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound(); // Возвращает 404, если продукт не найден
            }

            return View(product); // Возвращает представление "Details" с продуктом
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View(); // Возвращает представление "Create"
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product); // Добавление нового продукта
                _context.SaveChanges(); // Сохранение изменений в базе данных
                return RedirectToAction(nameof(Index)); // Перенаправление на метод Index
            }
            return View(product); // Возвращает представление "Create" с ошибками валидации
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound(); // Возвращает 404, если продукт не найден
            }
            return View(product); // Возвращает представление "Edit" с продуктом
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest(); // Возвращает 400 Bad Request
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product); // Обновление продукта
                    _context.SaveChanges(); // Сохранение изменений в базе данных
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Products.Any(e => e.ProductId == id))
                    {
                        return NotFound(); // Возвращает 404, если продукт не найден
                    }
                    else
                    {
                        throw; // Пробрасывает исключение, если произошла ошибка
                    }
                }
                return RedirectToAction(nameof(Index)); // Перенаправление на метод Index
            }
            return View(product); // Возвращает представление "Edit" с ошибками валидации
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound(); // Возвращает 404, если продукт не найден
            }
            return View(product); // Возвращает представление "Delete" с продуктом
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product); // Удаление продукта
                _context.SaveChanges(); // Сохранение изменений в базе данных
            }
            return RedirectToAction(nameof(Index)); // Перенаправление на метод Index
        }
    }
}
