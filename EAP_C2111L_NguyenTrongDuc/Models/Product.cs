using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAP_C2111L_NguyenTrongDuc.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}