using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarEvent.Models.Events
{
    [Table("calendarevent", Schema= "exampleschema")]
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
