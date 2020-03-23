using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace XmlBombDemo_DefaultSafe
{
    /// <summary>
    /// Program demonstrating default safe behavior on XML Reader processes in .NET
    /// </summary>
    /// <remarks>
    /// If you do not provide a custom XmlReaderSettings object to the XmlReader class, then the default
    /// settings file has the DtdProcessing property set to Prohibit which means this program will throw
    /// an exception when it tries to parse our XML file.  In an actual application you would catch this
    /// exception, but the important thing for us is that the code is now safe by default.  The exponential
    /// expansion cannot occur without us specifically enabling DTD Processing.
    /// </remarks>
    class Program
    {
        public const long ONE_MB = 1000000;

        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            Stopwatch sw = Stopwatch.StartNew();
            using (FileStream fileStream = new FileStream("XmlBomb.txt", FileMode.Open))
            {
                XmlReader reader = XmlReader.Create(fileStream);
                Console.WriteLine($"Default DTD Processing is set to {reader.Settings.DtdProcessing}");
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
