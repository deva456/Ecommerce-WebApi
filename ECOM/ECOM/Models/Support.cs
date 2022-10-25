using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM.Models
{
    public class Support
    {
        [Key]
        public int supportId { get; set; }

        public string Questions { get; set; }
        public string Answers { get; set; }


    }
}
