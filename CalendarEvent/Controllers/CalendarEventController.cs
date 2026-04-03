using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalendarEvent.Controllers
{
    public class CalendarEventController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
