using Microsoft.AspNetCore.Mvc;
using ProjWebApp.Data;
using ProjWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace ProjWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public CartController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // GET: Cart
        public IActionResult Index()
        {
           var userId = _userManager.GetUserId(User); // Получаем ID текущего пользователя
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Account", "User");
            }

            var cart = _context.Carts.Include(c => c.CartItems)
                                      .ThenInclude(ci => ci.Product)
                                      .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                return View(new Cart());
            }

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            // Проверяем, авторизован ли пользователь
            if (!_signInManager.IsSignedIn(User))
            {
                return Json(new { success = false, redirectUrl = Url.Action("Account", "User") });
            }

            var userId = _userManager.GetUserId(User); // Получаем ID текущего пользователя

            // Получаем корзину пользователя или создаем новую, если она не существует
            var cart = await _context.Carts.Include(c => c.CartItems)
                                            .FirstOrDefaultAsync(c => c.UserId == userId)
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
            if (cart.CartId == null) // Убедитесь, что это условие проверяет корректно
            {
                _context.Carts.Add(cart);
            }

            // Сохраняем изменения в базе данных
            await _context.SaveChangesAsync();

            // Возвращаем JSON-ответ с информацией о корзине
            return Json(new { success = true, message = "Товар добавлен в корзину." });
        }

        // POST: Remove from Cart
        [HttpPost]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            var userId = _userManager.GetUserId(User); // Получаем ID текущего пользователя
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

            return RedirectToAction("Index");
        }
    }
}
