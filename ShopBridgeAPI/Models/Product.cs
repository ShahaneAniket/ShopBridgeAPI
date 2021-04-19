using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id{ get; set; }
        [Required]
        public string ProductName{ get; set; }
        public string Description { get; set; }
        [Required]
        public int Price{ get; set; }

    }
}
