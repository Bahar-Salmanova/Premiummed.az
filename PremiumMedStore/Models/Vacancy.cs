using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class Vacancy
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Desc { get; set; }

        public ICollection<VacancyForm> VacancyForms { get; set; }
    }
}
