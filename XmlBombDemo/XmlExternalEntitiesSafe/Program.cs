using System;
using System.IO;
using System.Xml;

namespace XmlExternalEntitiesSafe
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.
            //settings.XmlResolver = new XmlUrlResolver();

            using (FileStream fileStream = new FileStream("XXE-File.xml", FileMode.Open))
            {
                XmlReader reader = XmlReader.Create(fileStream, settings);
                doc.Load(reader);
            }

            Console.WriteLine("This is the doc");
            //Console.WriteLine(doc.InnerXml);

            Console.WriteLine(doc["customer"].InnerXml);

            Console.ReadKey();
        }
    }
}
