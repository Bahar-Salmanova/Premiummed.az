using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class Clients
       
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Url { get; set; }

        [MaxLength(300)]
        public string Logo { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
