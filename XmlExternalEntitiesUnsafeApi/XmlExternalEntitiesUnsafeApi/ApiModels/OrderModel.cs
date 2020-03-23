using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace XmlExternalEntitiesUnsafeApi.ApiModels
{
    [XmlType(TypeName="order", Namespace = "")]
    public class OrderModel
    {

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }

        [XmlArray("items")]
        [XmlArrayItem("orderItem")]
        public List<OrderItemModel> Items { get; set; }

    }


    public class OrderItemModel
    {
        [XmlElement(ElementName = "itemName")]
        public string ItemName { get; set; }

        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "specialInstructions")]
        public string SpecialInstructions { get; set; }
    }


}