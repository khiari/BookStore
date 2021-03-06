﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain.Classes
{
    public class Cart
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.Column("Id")]
        public int RecordId { get; set; } 
        public string CartId { get; set; }
        public string BookId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Book Book { get; set; }

      


    }

    

}
