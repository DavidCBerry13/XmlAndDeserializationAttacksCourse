using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace XmlBombDemo
{

    /// <summary>
    /// Program demonstrating Ignore DTD behavior on XML Reader processes in .NET
    /// </summary>
    /// <remarks>
    /// You can use the Ignore value to ignore any DTD information in the document.
    /// In this case however, an exception will still get thrown because the now there
    /// is no reference to the entity specified in the XML document.  Still though, this
    /// is safe because you can catch and handle this exception rather than having an
    /// XML Bomb crash your application process.
    /// </remarks>
    public class Program
    {
        public const long ONE_MB = 1000000;

        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Ignore;

            Stopwatch sw = Stopwatch.StartNew();
            using (FileStream fileStream = new FileStream("XmlBomb.txt", FileMode.Open))
            {
                XmlReader reader = XmlReader.Create(fileStream, settings);
                doc.Load(reader);
            }
            sw.Stop();

            Console.WriteLine(doc.InnerText);
            Console.WriteLine($"XML Bomb Stats");
            Console.WriteLine($"Parse Time:      {sw.ElapsedMilliseconds}  ms");
            Console.WriteLine($"String Length:   {doc.InnerText.Length}");
            Console.WriteLine($"Memory:          {Process.GetCurrentProcess().WorkingSet64 / ONE_MB} MB");

            Console.ReadKey();
        }
    }

}