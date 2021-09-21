using PremiumMedStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.ViewModel
{
    public class HomeViewModel
    {
        public Welcome Welcome { get; set; }
        public List< IndexProduct >IndexProduct { get; set; }
        public List<Clients> Clients { get; set; }
        public List<News> News { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public Settings Setting { get; set; }
        public SosialLinks SosialLinks { get; set; }

    }
}
