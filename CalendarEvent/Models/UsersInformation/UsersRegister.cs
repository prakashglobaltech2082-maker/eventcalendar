using CalendarEvent.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarEvent.Models.UsersInformation
{
    [Table("users",Schema ="account")]
    public class UsersRegister:BaseEntity
    {
        [Column("name",TypeName ="VARCHAR(50)")]
        public string Name { get; set; }

        [Column("password", TypeName = "NVARCHAR(255)")]

        public string Password { get; set; }

    }
}
