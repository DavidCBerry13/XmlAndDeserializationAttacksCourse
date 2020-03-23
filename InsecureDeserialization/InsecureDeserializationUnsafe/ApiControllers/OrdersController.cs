using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InsecureDeserialization.ApiModels;
using InsecureDeserialization.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InsecureDeserialization.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public OrdersController(OrderRepository repository, IHostingEnvironment hostingEnvironment)
        {
            ordersRepository = repository;
            webRoot = hostingEnvironment.WebRootPath;

        }

        private OrderRepository ordersRepository;
        protected String webRoot;


        // GET: api/Orders
        [HttpGet]
        public List<OrderModel> Get()
        {
            return ordersRepository.GetOrders();
        }


        // POST: api/Orders
        [HttpPost]
        public OrderResponseModel Post([FromBody]OrderModel order)
        {
            ordersRepository.AddOrder(order);

            string filePath = Path.Combine(webRoot, "ImportantFile.txt");
            OrderResponseModel model = new OrderResponseModel()
            {
                OrderReadyTime = DateTime.Now.AddMinutes(30),
                Items = order.Items,
                Filename = filePath,
                IsFileReadOnly = (new FileInfo(filePath)).IsReadOnly
            };

            return model;
        }


    }
}
