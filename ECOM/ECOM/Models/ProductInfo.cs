using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM.Models
{
    public class ProductInfo
    {
        [Key]
        public int productId { get; set; }
        public string productBrand { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productDetails { get; set; }       
        public string productImage { get; set; }
        public string productImage1 { get; set; }
        public string productImage2 { get; set; }
        public string productImage3 { get; set; }
        public int productQuantity { get; set; }
        public bool addedToWishList { get; set; }
        public bool Available { get; set; }

        public int subCategoryId { get; set; }

        [ForeignKey("subCategoryId")]
        public virtual ProductSubCategory ProductSubCategory { get; set; }

        public int categoryId { get; set; }

        [ForeignKey("categoryId")]
        public virtual ProductCategory productCategory { get; set; }

    }
}
