using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//For Data Annotations
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingEntityLib
{
    public class ProductDetails
    {
        [Required]
        [MaxLength(100, ErrorMessage = " PID must not be empty")]
        public int PId { get; set; }    
        [Required]
       
        public string ProductName { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = " Price must not be empty")]
        [Range(1, 20000, ErrorMessage = "salary must be in range of 1000 to 20000")]
        public int Price { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = " Content must not be empty")]

        public string Content { get; set; }
        public string Display()
        {
            string data = "";
            string[] cols = Content.Split(',');
            foreach (var col in cols)
            {
                string cName, cValue;
                string[] cNValue = col.Split(':');
                cName = cNValue[0];
                cValue = cNValue[1];
                data = data + cName + ": " + cValue + "<br/>";
            }
            return data;
        }

    }
}
