using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeDeserializationApiModels
{
    public class OrderResponseModel
    {

        public DateTime OrderReadyTime { get; set; }

        public List<OrderItemModel> Items { get; set; }

        public String Filename { get; set; }

        public bool IsFileReadOnly { get; set; }

    }
}
