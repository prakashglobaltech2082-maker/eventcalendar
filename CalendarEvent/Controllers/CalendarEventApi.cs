using CalendarEvent.DBHelper;
using CalendarEvent.Models.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalendarEvent.Controllers
{
    [Route("api/EventsAdd")]
    [ApiController]
    public class CalendarEventApi : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CalendarEventApi(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Event> getAllEvents =await _context.Calendarevent.ToListAsync();
            return Ok(getAllEvents);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Event obj)
        {
            _context.Calendarevent.Add(obj);
            await _context.SaveChangesAsync();
            return Ok(obj);
        }
    }
}
