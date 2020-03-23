using SafeDeserializationApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeDeserializationData
{
    public class OrderRepository
    {
        public OrderRepository()
        {
            orders = new List<OrderModel>();
        }

        private List<OrderModel> orders;



        public List<OrderModel> GetOrders()
        {
            return orders.ToList();
        }


        public void AddOrder(OrderModel order)
        {
            orders.Add(order);
        }

    }
}
