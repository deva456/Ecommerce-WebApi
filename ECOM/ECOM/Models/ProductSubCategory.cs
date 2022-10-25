using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM.Models
{
    public class ProductSubCategory
    {
        [Key]
        public int subCategoryId { get; set; }

        public string subCatName { get; set; }
    }
}
