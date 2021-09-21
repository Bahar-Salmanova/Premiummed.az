using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.Models
{
    public class VacancyForm
    {
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }

        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        [Required,MaxLength(100)]
        public string Surname { get; set; }

        [Required, MaxLength(100)]
        public string Telephone { get; set; }

        [MaxLength(1000)]
        public string Text { get; set; }

        [MaxLength(300)]
        public string File { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }

    }
}
