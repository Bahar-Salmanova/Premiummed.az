using PremiumMedStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.ViewModel
{
    public class CareerViewModel
    {
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public List<Vacancy>  Vacancy { get; set; }
    }
}
