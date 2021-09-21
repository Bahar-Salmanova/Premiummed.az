using PremiumMedStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore.ViewModel
{
    public class ProductOrderViewModel
    {
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public ProductOrder ProductOrder { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
