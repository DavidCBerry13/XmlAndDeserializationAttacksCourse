using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsecureDeserialization.ApiModels
{
    public class OrderModel
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public List<OrderItemModel> Items { get; set; }

        public dynamic DeliveryOptions { get; set; }

    }


    public class OrderItemModel
    {
        public string ItemName { get; set; }

        public int Quantity { get; set; }

    }
}
