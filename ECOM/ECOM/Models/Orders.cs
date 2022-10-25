using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM.Models
{
    public class Orders
    {
        [Key]
        public int orderId { get; set; }

        

        public int productId { get; set; }

        [ForeignKey("productId")]
        public virtual ProductInfo ProductInfo { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }

        public string productImage { get; set; }

        public int productQuantity { get; set; }

        public decimal productPrice { get; set; }

        public string productBrand { get; set; }
    }
}
