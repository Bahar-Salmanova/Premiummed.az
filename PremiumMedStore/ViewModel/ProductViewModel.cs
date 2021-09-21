using PremiumMedStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.ViewModel
{
    public class ProductViewModel
    {
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public List<Products> Products { get; set; }
        public Products Product { get; set; }
    }
}
