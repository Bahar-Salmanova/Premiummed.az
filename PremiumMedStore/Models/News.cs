using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class News
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string About { get; set; }

        [MaxLength(240)]
        public string Desc { get; set; }

       [MaxLength(2000)]

        public string FullDecs { get; set; }

    }
}
