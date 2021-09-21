using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }

        [Required, MaxLength(100)]
        public string Telephone { get; set; }

        [Required, MaxLength(500)]
        public string Adres { get; set; }

        [MaxLength(2000)]
        public string Message { get; set; }

        public int ProductId { get; set; }

        public Products Product { get; set; }
    }
}
