using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBExtractorSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            DBExtractor.XMLHelper xml = new DBExtractor.XMLHelper();
            xml.GenerateXML_0();
            xml.GenerateXML_1();
            xml.GenerateXML_2();
            //Console.ReadLine();
        }
    }
}
