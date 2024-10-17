using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjWebApp.Data;
using ProjWebApp.Models;
using System.IO;
using System.Threading.Tasks;

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

            ViewBag.Categories = _context.Categories.ToList();
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public IActionResult Details(int id)
        {
            var product = _context.Products
                .Include(p => p.ProductAttributes)
                .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile[] ImageFiles)
        {
            try
            {
                // Проверяем валидность модели
                if (ModelState.IsValid)
                {
                    // Папка для загрузки изображений
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Scr", "Images");

                    // Проверяем, существует ли папка, если нет - создаем
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Разрешенные расширения файлов
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

                    if (ImageFiles != null && ImageFiles.Length > 0)
                    {
                        // Обрабатываем каждое загруженное изображение
                        foreach (var imageFile in ImageFiles)
                        {
                            if (imageFile.Length > 0)
                            {
                                var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();

                                // Проверяем, является ли файл допустимым изображением
                                if (!allowedExtensions.Contains(fileExtension))
                                {
                                    ModelState.AddModelError("", "Недопустимый формат файла. Пожалуйста, загрузите изображение в формате JPG, PNG или GIF.");
                                    continue; // Пропускаем этот файл
                                }

                                var fileName = Path.GetFileName(imageFile.FileName);
                                var filePath = Path.Combine(uploadsFolder, fileName);

                                // Проверяем, существует ли файл с таким именем
                                if (System.IO.File.Exists(filePath))
                                {
                                    ModelState.AddModelError("", $"Файл с именем {fileName} уже существует.");
                                    continue; // Пропускаем этот файл
                                }

                                // Сохраняем изображение на сервере
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await imageFile.CopyToAsync(stream);
                                }

                                // Создание объекта изображения и привязка к продукту
                                var image = new Image
                                {
                                    ImagePath = filePath, // Сохраняем полный путь изображения
                                    ProductId = product.ProductId // Предполагается, что product.ProductId уже установлен
                                };
                                product.Images.Add(image);
                            }
                        }
                    }

                    // Устанавливаем дату добавления товара
                    product.DateAdded = DateTime.Now;

                    // Добавляем продукт в контекст базы данных
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Title", product.CategoryId);
                return View(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Произошла ошибка: " + ex.Message);
                ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Title", product.CategoryId);
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Title", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Products.Any(e => e.ProductId == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Title", product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}