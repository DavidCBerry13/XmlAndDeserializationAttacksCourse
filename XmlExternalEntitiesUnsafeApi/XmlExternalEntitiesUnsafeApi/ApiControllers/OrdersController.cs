using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XmlExternalEntitiesUnsafeApi.ApiModels;
using XmlExternalEntitiesUnsafeApi.Data;

namespace XmlExternalEntitiesUnsafeApi.ApiControllers
{
    public class OrdersController : ApiController
    {
        public OrdersController(OrdersRepository repository)
        {
            ordersRepository = repository;
        }

        private OrdersRepository ordersRepository;

        // GET: api/Orders
        public List<OrderModel> Get()
        {
            var orders = ordersRepository.GetOrders();
            return orders;
        }


        // POST: api/Orders
        public void Post([FromBody]OrderModel order)
        {
            ordersRepository.AddOrder(order);
        }


    }
}
