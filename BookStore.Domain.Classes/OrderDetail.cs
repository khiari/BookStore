using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Classes
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
