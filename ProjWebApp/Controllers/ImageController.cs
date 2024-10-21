using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjWebApp.Controllers
{
    public class ImageController : Controller
    {
        // GET: ImageController
        public IActionResult GetImage(string filePath)
        {
            var fileBites = System.IO.File.ReadAllBites(filePath,"image/jpeg");
            return View();
        }

        
    }
}
