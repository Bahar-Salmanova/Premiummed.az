using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public ICollection<Products> Products { get; set; }
        public string CategoryImage { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }




    }
}
