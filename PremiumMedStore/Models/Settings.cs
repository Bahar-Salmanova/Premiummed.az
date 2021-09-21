using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class Settings
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Telephone { get; set; }

        [MaxLength(500)]
        public string Adress { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
