using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Classes
{
    public class IsbnQuantity
    {
        public int Id { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int quantity { get; set; }
    }
}