using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//For Data annotations
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingEntityLib
{
   public  class Cart
    {
        [Required]
        public int PId { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = " Price must not be empty")]
        [Range(1, 20000, ErrorMessage = "salary must be in range of 1000 to 20000")]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
