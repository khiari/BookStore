using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Classes
{
    public class Book
    {
        public Book()
        {
        }
        [Key]
        public string ISBN { get; set; }
        [Required]
        [MaxLength(10),MinLength(4)]
        public string name { get; set; }
        [Required]
        [MaxLength(10), MinLength(4)]
        public string genre { get; set; }
        [Required]
        [MaxLength(300)]
        public string description { get; set; }
        [Required]
        [Range(1.0,500.0)]
        public float price{get; set;}

        //public List<Review> reviews{ get; set; }  
        //[MinLength(1)]      
        //public List<Author> authors{ get; set; }
        //[Required]
        public string editor{ get; set; }


    }
}
