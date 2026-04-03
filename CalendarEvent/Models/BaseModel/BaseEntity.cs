using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarEvent.Models.BaseModel
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("created_date")]
        public DateTimeOffset CreatedDate { get;set;  }
        [Column("modified_date")]
        public DateTimeOffset? ModifiedDate { get;set;  }
    }
}
