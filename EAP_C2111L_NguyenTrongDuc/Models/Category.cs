using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAP_C2111L_NguyenTrongDuc.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    }
}