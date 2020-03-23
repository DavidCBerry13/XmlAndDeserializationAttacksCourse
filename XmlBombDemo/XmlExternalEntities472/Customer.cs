using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XmlExternalEntities472
{
    [DataContract]
    public class Customer
    {

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "phone")]
        public List<String> PhoneNumbers { get; set; }



    }



    public class Address
    {
        [DataMember(Name = "firstName")]
        public string Street { get; set; }

        [DataMember(Name = "firstName")]
        public string City { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "zip")]
        public string Zip { get; set; }
    }

}
