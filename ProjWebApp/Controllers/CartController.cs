using Microsoft.AspNetCore.Mvc;
using ProjWebApp.Data;
using ProjWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationContext _context;

        public CartController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Cart
        public IActionResult Index(int userId)
        {
            var cart = _context.Carts.Include(c => c.CartItems)
                                      .ThenInclude(ci => ci.Product)
                                      .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                return View(new Cart());
            }

            return View(cart);
        }

        // POST: Add to Cart
        [HttpPost]
        public IActionResult AddToCart(int productId, int userId, int quantity)
        {
            // Получаем корзину пользователя или создаем новую, если она не существует
            var cart = _context.Carts.Include(c => c.CartItems)
                                      .FirstOrDefault(c => c.UserId == userId)
                                      ?? new Cart { UserId = userId, CreatedAt = DateTime.Now };

            // Проверяем, есть ли уже товар в корзине
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem != null)
            {
                // Если товар уже есть, увеличиваем количество
                cartItem.Quantity += quantity;
            }
            else
            {
                // Если товара нет, добавляем новый элемент в корзину
                cartItem = new CartItem { ProductId = productId, Quantity = quantity };
                cart.CartItems.Add(cartItem);
            }

            // Если корзина новая, добавляем ее в контекст
            if (cart.CartId == 0)
            {
                _context.Carts.Add(cart);
            }

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            // Возвращаем JSON-ответ с информацией о корзине
            return Json(new { success = true, message = "Товар добавлен в корзину." });
        }

        // POST: Remove from Cart
        [HttpPost]
        public IActionResult RemoveFromCart(int cartItemId, int userId)
        {
            var cart = _context.Carts.Include(c => c.CartItems)
                                      .FirstOrDefault(c => c.UserId == userId);
            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
                if (cartItem != null)
                {
                    cart.CartItems.Remove(cartItem);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index", new { userId });
        }
    }
}
