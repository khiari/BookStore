using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Classes
{
    public class Author
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(10),MinLength(4)]
        public string name { get; set; }
        [Required]
        [MaxLength(300)]
        public string shortBio  { get; set; }

        public static implicit operator List<object>(Author v)
        {
            throw new NotImplementedException();
        }
    }

    

}