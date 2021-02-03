using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//For Data Annotations
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingEntityLib
{
    public class Home
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}
