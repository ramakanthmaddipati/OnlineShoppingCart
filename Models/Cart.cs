using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//For Data Annotations
using System.Linq;
using System.Web;

namespace OnlineShoppingMvc.Models
{
    public class Cart
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}