using Microsoft.AspNetCore.Mvc;

namespace MusicShop.Client.Controllers
{
    public class AutorizationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
