using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XmlExternalEntities472
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContractSerializerSettings settings = new DataContractSerializerSettings();

            DataContractSerializer serializer = new DataContractSerializer(typeof(Customer), settings);

            using (FileStream fileStream = new FileStream("XXE-File.xml", FileMode.Open))
            {
                var customer = (Customer)serializer.ReadObject(fileStream);

                Console.WriteLine(customer.FirstName);

            }

        }
    }
}
