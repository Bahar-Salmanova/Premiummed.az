﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class Galery
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Photo { get; set; }

        [MaxLength(300)]
        public string Photo1 { get; set; }

        [MaxLength(300)]
        public string Photo2 { get; set; }


        [NotMapped]
        public IFormFile Upload1 { get; set; }
        [NotMapped]
        public IFormFile Upload2 { get; set; }
        [NotMapped]
        public IFormFile Upload3 { get; set; }
    }
}
