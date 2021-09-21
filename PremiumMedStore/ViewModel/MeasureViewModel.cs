using PremiumMedStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.ViewModel
{
    public class MeasureViewModel
    {
        public List<Galery> Galeries { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public List<Measure> Measures { get; set; }
        public Measure Measure { get; set; }
    }
}
