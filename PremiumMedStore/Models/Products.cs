using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremiumMedStore.Models
{
    public class Products
    {
        public int Id { get; set; }

        [MaxLength(120)]

        public string Name { get; set; }
        
        public int ProductCategoryId { get; set; }
     
        public ProductCategory ProductCategory { get; set; }
     
        [MaxLength(200)]
        public string Photo { get; set; }

        [MaxLength(200)]

        public string Photo1 { get; set; }

        [MaxLength(200)]

        public string Photo2 { get; set; }

        [MaxLength(200)]
        public string Photo3 { get; set; }


        [MaxLength(100)]
        public string ProductAbout { get; set; }


        [MaxLength(1000)]
        public string FullAbout { get; set; }

        [MaxLength(200)]
        public string ProductLink { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
        [NotMapped]
        public IFormFile Upload1 { get; set; }
        [NotMapped]
        public IFormFile Upload2 { get; set; }
        [NotMapped]
        public IFormFile Upload3 { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }


    }
}
