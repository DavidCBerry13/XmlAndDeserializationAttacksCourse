using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace XmlBombDemo
{
    public class Program
    {
        public const long ONE_MB = 1000000;

        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.MaxCharactersFromEntities = 10000 * ONE_MB;

            Stopwatch sw = Stopwatch.StartNew();
            using (FileStream fileStream = new FileStream("XmlBomb.txt", FileMode.Open))
            {
                XmlReader reader = XmlReader.Create(fileStream, settings);
                doc.Load(reader);
            }
            sw.Stop();

            Console.WriteLine(doc.InnerText);
            Console.WriteLine("XML Bomb Stats");
            Console.WriteLine($"Parse Time: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"String Length: {doc.InnerText.Length}");
            Console.WriteLine($"Memory: {Process.GetCurrentProcess().WorkingSet64 / ONE_MB} MB");
            Console.ReadKey();
        }
    }
}

