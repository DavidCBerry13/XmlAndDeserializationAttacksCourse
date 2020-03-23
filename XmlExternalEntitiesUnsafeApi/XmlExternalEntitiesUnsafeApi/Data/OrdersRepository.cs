using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XmlExternalEntitiesUnsafeApi.ApiModels;

namespace XmlExternalEntitiesUnsafeApi.Data
{
    public class OrdersRepository
    {

        public OrdersRepository()
        {
            orders = new List<OrderModel>()
            {
                new OrderModel() { Name = "Joshua Turner", Phone = "212-555-1234",
                    Items = new List<OrderItemModel>() { new OrderItemModel() { ItemName = "Large Cheese Pizza", Quantity = 1 }}},
                new OrderModel() { Name = "Mary Evans", Phone = "303-555-9876",
                    Items = new List<OrderItemModel>() { new OrderItemModel() { ItemName = "Large Pepperoni Pizza", Quantity = 2 }}},
                new OrderModel() { Name = "Mary Evans", Phone = "303-555-9876",
                    Items = new List<OrderItemModel>() { new OrderItemModel() { ItemName = "Large Sausage Pizza", Quantity = 1, SpecialInstructions = "Cut into squares" }, new OrderItemModel() { ItemName = "Medium Pepperoni Pizza", Quantity =2 }} }
            };



        }


        private List<OrderModel> orders;


        public List<OrderModel> GetOrders()
        {
            return orders.ToList();
        }


        public void AddOrder(OrderModel order)
        {
            this.orders.Add(order);
        }


    }
}