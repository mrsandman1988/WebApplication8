using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication8.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
    }
}
