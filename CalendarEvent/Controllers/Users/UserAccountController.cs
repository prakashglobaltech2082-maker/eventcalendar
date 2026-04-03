using Microsoft.AspNetCore.Mvc;

namespace CalendarEvent.Controllers.Users
{
    public class UserAccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
