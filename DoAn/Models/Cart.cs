using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public long ProductID { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}