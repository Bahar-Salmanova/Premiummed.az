using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class Welcome
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string About { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
