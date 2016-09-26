using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Classes
{
    public class Author
    {

        public int Id { get; set; }
        [Required]
        
        public string name { get; set; }
        [Required]
        
        public string shortBio  { get; set; }

       
    }

    

}