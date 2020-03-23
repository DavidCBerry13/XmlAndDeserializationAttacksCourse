using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsecureDeserialization.ApiModels
{
    public class DeliveryOptionsModel
    {
        public DeliveryOrCarryout DeliveryOrCarryout { get; set; }

        public bool FutureOrder { get; set; }

        public DateTime? FutureOrderTime { get; set; }
    }

    public enum DeliveryOrCarryout
    {
        Delivery,
        Carryout
    }

}
