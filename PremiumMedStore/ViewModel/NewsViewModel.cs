using PremiumMedStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.ViewModel
{
    public class NewsViewModel
    {
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public List<News> News { get; set; }
        
    }
}
