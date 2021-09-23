using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class Products
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Photo { get; set; }

        [Required,MaxLength(200)]

        public string Photo1  { get; set; }

        [Required, MaxLength(200)]

        public string Photo2 { get; set; }

        [Required, MaxLength(200)]
        public string Photo3 { get; set; }


        [MaxLength(100)]
        public string ProductAbout { get; set; }


        [MaxLength(1000)]
        public string FullAbout { get; set; }

        [MaxLength(200)]
        public string ProductLink { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }

        public ICollection<ProductOrder> ProductOrders{ get; set; }


    }
}
