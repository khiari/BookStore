using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Classes
{
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public int clientId { get; set; }
        [MinLength(1)]
        public List<IsbnQuantity> IsbnQuantities { get; set; }


    }

    

}
