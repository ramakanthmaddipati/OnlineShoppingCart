using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//For Data Annotations
using System.Linq;
using System.Web;

namespace OnlineShoppingMvc.Models
{
    public class Products
    {
        //public int Cid { get; set; }
        [Required]
        public int Pid { get; set; }
        //public string Cname { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public int Price { get; set; }
        
    }
}