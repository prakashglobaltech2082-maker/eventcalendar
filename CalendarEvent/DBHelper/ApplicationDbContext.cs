using CalendarEvent.Models.Events;
using CalendarEvent.Models.UsersInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CalendarEvent.DBHelper
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Event> Calendarevent { get; set; }
        public DbSet<UsersRegister> Users { get; set; }
    }
}
