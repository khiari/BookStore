using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Classes
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [Range(0,5)]
        public float rating { get; set; }
        [Required]
        [StringLength(300)]
        public string review { get; set; }


    }
}