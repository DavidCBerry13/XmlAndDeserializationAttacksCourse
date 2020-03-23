using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;
using XmlExternalEntitiesUnsafeApi.ApiModels;
using XmlExternalEntitiesUnsafeApi.Data;
using System.Xml;
using XmlExternalEntitiesUnsafeApi.Util;

namespace XmlExternalEntitiesUnsafeApi.ApiControllers
{

    /// <summary>
    /// Represents a Plain Old XML (POX) Service.
    /// </summary>
    /// <remarks>
    /// POX Services were popular a few years back bit not so much anymore but you will still find some around.
    /// The idea is that you don't take advantage of model binding but just pass in XML and then the action method
    /// or even another method deeper down in the stack is responsible for deserializing that XML into objects.
    /// In these cases, you have to make sure that deserialization process is secure.
    /// </remarks>
    public class OrdersPoxController : ApiController
    {
        public OrdersPoxController(OrdersRepository repository)
        {
            ordersRepository = repository;
        }

        private OrdersRepository ordersRepository;


        // GET: api/OrdersPox
        public List<OrderModel> Get()
        {
            var orders = ordersRepository.GetOrders();
            return orders;
        }

        // POST: api/OrdersPox
        public void Post([RawRequestDataAttribute]string xml)
        {
            using (StringReader textReader = new StringReader(xml) )
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                // .NET 4.5.2 and after => Default is Prohibit.  Setting to Parse makes vulnerable
                // Before .NET 4.5.2 this was set to Parse by default (which was vulnerable)
                settings.DtdProcessing = DtdProcessing.Parse;

                XmlReader reader = XmlReader.Create(textReader, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(OrderModel));

                var orderModel = serializer.Deserialize(reader) as OrderModel;
                ordersRepository.AddOrder(orderModel);
            }






        }

    }
}
