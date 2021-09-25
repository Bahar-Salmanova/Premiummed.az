using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class IndexProduct
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(700)]
        public string Desc { get; set; }

        [MaxLength(200)]
        public string Photo1 { get; set; }

        [MaxLength(200)]
        public string Photo2 { get; set; }

        [MaxLength(200)]
        public string Photo3 { get; set; }

        [NotMapped]
        public IFormFile Upload1 { get; set; }
        [NotMapped]
        public IFormFile Upload2 { get; set; }
        [NotMapped]
        public IFormFile Upload3 { get; set; }
    }
}
