using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM.Models
{
    public class ProductCategory
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
