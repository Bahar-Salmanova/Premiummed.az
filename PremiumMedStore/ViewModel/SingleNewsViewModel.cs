using PremiumMedStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.ViewModel
{
    public class SingleNewsViewModel
    {
        public List<Galery> Galery { get; set; }
        public List<News> News { get; set; }
        public News New { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }
    }
}
