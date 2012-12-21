using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace DBExtractor
{
    class Header
    {

    }

    class XMLHelper
    {
        private string PREFIX = @"xls";
        private string NS = @"urn:schemas-microsoft-com:office:spreadsheet";

        private string[] ar_columnWidth = { "80", "80", "50", "100", "150", "50", "50", "150", "100", "50", "50", "50", "50", "100", "80", "50", "50" };
        private string[] ar_header = { "Magazyn", "Symbol", "Nazwa", "Stan magazynowy", "Ilość do dyspozycji", "Jm", "Cena", "Ostatnia cena zakupu", "Cena minimalna", "Vat", "Waga", "PKWiU", "SWW", "Lokalizacja", "Producent", "Grupa", "Kod" };
        private string[] ar_dataType = {"String", "String", "String", "Number", "Number", "String", "Number", "Number", "Number", "Number", "Number", "String", "String", "String", "String", "String", "String" };
        private string[][] ar_data = new string[][] {
            new string[] {"NAV", "00032010", "CH-2094 - Scooby Doo Gra Nawiedzony Zamek", "0", "0", "SZT", "106.48", "58.56", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "5029736020941"},
            new string[] {"NAV", "00037044", "GEO-591 - Geomag tylko panele 60 el.", "0", "0", "SZT", "41.06", "16.07", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772005919"},
            new string[] {"NAV", "00037045", "GEO-592 - Geomag tylko panele 90", "0", "0", "SZT", "46.75", "18.26", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772005926"},
            new string[] {"NAV", "00037084", "GEO-092 - Geomag Gbaby SEA 11 el.", "75", "73", "SZT", "82.03", "32.81", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000921"},
            new string[] {"NAV", "00037085", "GEO-093 - Geomag Gbaby SEA 19 el.", "64", "59", "SZT", "123.98", "49.59", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000938"},
            new string[] {"NAV", "00037096", "GEO-085 - Geomag Gbaby FARM 8 el.", "0", "0", "SZT", "62.52", "25.01", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000853"},
            new string[] {"NAV", "00037097", "GEO-086 - Geomag Gbaby FARM 11 el.", "231", "228", "SZT", "82.03", "32.81", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000860"},
            new string[] {"NAV", "00037098", "GEO-087 - Geomag Gbaby FARM 19 el.", "96", "78", "SZT", "123.98", "49.59", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000877"},
            new string[] {"NAV", "00037099", "GEO-090 - Geomag Gbaby SEA 4 el.", "84", "82", "SZT", "32.44", "12.98", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000907"},
            new string[] {"NAV", "00037101", "GEO-091 - Geomag Gbaby SEA 8 el.", "74", "72", "SZT", "62.52", "25.01", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000914"},
            new string[] {"NAV", "00037102", "GEO-064 - Geomag PRO Color 100 el.", "0", "0", "SZT", "157.64", "63.06", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000648"},
            new string[] {"NAV", "00037103", "GEO-066 - Geomag PRO Color 200 el.", "0", "0", "SZT", "315.85", "120.02", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000662"},
            new string[] {"NAV", "00037104", "GEO-063 - Geomag PRO Color 66 el.", "0", "0", "SZT", "106.1", "40.31", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772000631"},
            new string[] {"NAV", "00037105", "GEO-214 - Geomag PRO Metal 100 el.", "0", "0", "SZT", "157.64", "63.06", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772002147"},
            new string[] {"NAV", "00037106", "GEO-215 - Geomag PRO Metal 140 el.", "17", "16", "SZT", "237.32", "84.85", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772002154"},
            new string[] {"NAV", "00037107", "GEO-212 - Geomag PRO Metal 44 el.", "0", "0", "SZT", "69.02", "27.61", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772002123"},
            new string[] {"NAV", "00037109", "GEO-893 - Geomag PRO Panels 131 el.", "0", "0", "SZT", "157.64", "56.31", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772008934"},
            new string[] {"NAV", "00037110", "GEO-894 - Geomag PRO Panels 176 el.", "0", "0", "SZT", "207.23", "51.34", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772008941"},
            new string[] {"NAV", "00037111", "GEO-895 - Geomag PRO Panels 222 el.", "0", "0", "SZT", "263.01", "105.2", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772008958"},
            new string[] {"NAV", "00037112", "GEO-701 - Geomag Wheels - zestaw 25 el.", "62", "58", "SZT", "40.57", "16.23", "0", "23", "0", "", "", "", "Toy Time", "grupa główna", "871772007012"}
        };

        public void GenerateXML_0()
        {
            XmlWriterSettings xmlWS = new XmlWriterSettings();
            xmlWS.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlWriter.Create("Kartoteki-0.xml", xmlWS))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(PREFIX, "Workbook", NS);
                
                    writer.WriteStartElement(PREFIX, "Styles", NS);
                        writer.WriteStartElement(PREFIX, "Style", NS);
                        writer.WriteAttributeString(PREFIX, "ID", NS, "1");
                            writer.WriteStartElement(PREFIX, "Font", NS);
                            writer.WriteAttributeString(PREFIX, "Bold", NS, "1");
                            writer.WriteEndElement(); //Font
                        writer.WriteEndElement(); //Style
                    writer.WriteEndElement(); //Styles
                
                    writer.WriteStartElement(PREFIX, "Worksheet", NS);
                    writer.WriteAttributeString(PREFIX, "Name", NS, "Arkusz");
                        writer.WriteStartElement(PREFIX, "Table", NS);

                            foreach (string columnWidth in ar_columnWidth)
                            {
                                writer.WriteStartElement(PREFIX, "Column", NS);
                                writer.WriteAttributeString(PREFIX, "Width", NS, columnWidth);
                                writer.WriteEndElement(); // Column
                            }

                            writer.WriteStartElement(PREFIX, "Row", NS);
                            writer.WriteAttributeString(PREFIX, "StyleID", NS, "1");
                            
                            foreach (string header in ar_header)
                            {
                                writer.WriteStartElement(PREFIX, "Cell", NS);
                                writer.WriteStartElement(PREFIX, "Data", NS);
                                writer.WriteAttributeString(PREFIX, "Type", NS, "String");
                                writer.WriteString(header);
                                writer.WriteEndElement(); // Data
                                writer.WriteEndElement(); // Cell

                            }
                            writer.WriteEndElement(); // Row
                            
                            foreach (string[] row in ar_data)
                            {
                                writer.WriteStartElement(PREFIX, "Row", NS);

                                for (int i = 0; i < ar_dataType.Length; i++)
                                {
                                    writer.WriteStartElement(PREFIX, "Cell", NS);

                                    writer.WriteStartElement(PREFIX, "Data", NS);
                                    writer.WriteAttributeString(PREFIX, "Type", NS, ar_dataType[i]);
                                    writer.WriteString(row[i]);
                                    writer.WriteEndElement(); // Data

                                    writer.WriteEndElement(); // Cell
                                }

                                writer.WriteEndElement(); // Row
                            }
                
                        writer.WriteEndElement(); // Table
                    writer.WriteEndElement(); // Worksheet
                
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public void GenerateXML_1()
        {
            XmlWriterSettings xmlWS = new XmlWriterSettings();
            xmlWS.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlWriter.Create("Kartoteki-1.xml", xmlWS))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(PREFIX, "Workbook", NS);

                writer.WriteStartElement(PREFIX, "Worksheet", NS);
                writer.WriteAttributeString(PREFIX, "Name", NS, "Arkusz");
                writer.WriteStartElement(PREFIX, "Table", NS);

                foreach (string columnWidth in ar_columnWidth)
                {
                    writer.WriteStartElement(PREFIX, "Column", NS);
                    writer.WriteAttributeString(PREFIX, "Width", NS, columnWidth);
                    writer.WriteEndElement(); // Column
                }

                writer.WriteStartElement(PREFIX, "Row", NS);
                foreach (string header in ar_header)
                {
                    writer.WriteStartElement(PREFIX, "Cell", NS);
                    writer.WriteStartElement(PREFIX, "Data", NS);
                    writer.WriteAttributeString(PREFIX, "Type", NS, "String");
                    writer.WriteString(header);
                    writer.WriteEndElement(); // Data
                    writer.WriteEndElement(); // Cell

                }
                writer.WriteEndElement(); // Row

                foreach (string[] row in ar_data)
                {
                    writer.WriteStartElement(PREFIX, "Row", NS);

                    for (int i = 0; i < ar_dataType.Length; i++)
                    {
                        writer.WriteStartElement(PREFIX, "Cell", NS);

                        writer.WriteStartElement(PREFIX, "Data", NS);
                        writer.WriteAttributeString(PREFIX, "Type", NS, ar_dataType[i]);
                        writer.WriteString(row[i]);
                        writer.WriteEndElement(); // Data

                        writer.WriteEndElement(); // Cell
                    }

                    writer.WriteEndElement(); // Row
                }

                writer.WriteEndElement(); // Table
                writer.WriteEndElement(); // Worksheet

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public void GenerateXML_2()
        {
            PREFIX = null;
            NS = null;

            XmlWriterSettings xmlWS = new XmlWriterSettings();
            xmlWS.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlWriter.Create("Kartoteki-2.xml", xmlWS))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(PREFIX, "Workbook", NS);

                writer.WriteStartElement(PREFIX, "Worksheet", NS);
                writer.WriteAttributeString(PREFIX, "Name", NS, "Arkusz");
                writer.WriteStartElement(PREFIX, "Table", NS);

                writer.WriteStartElement(PREFIX, "Row", NS);
                foreach (string header in ar_header)
                {
                    writer.WriteStartElement(PREFIX, "Cell", NS);
                    writer.WriteStartElement(PREFIX, "Data", NS);
                    writer.WriteAttributeString(PREFIX, "Type", NS, "String");
                    writer.WriteString(header);
                    writer.WriteEndElement(); // Data
                    writer.WriteEndElement(); // Cell

                }
                writer.WriteEndElement(); // Row

                foreach (string[] row in ar_data)
                {
                    writer.WriteStartElement(PREFIX, "Row", NS);

                    for (int i = 0; i < ar_dataType.Length; i++)
                    {
                        writer.WriteStartElement(PREFIX, "Cell", NS);

                        writer.WriteStartElement(PREFIX, "Data", NS);
                        writer.WriteAttributeString(PREFIX, "Type", NS, ar_dataType[i]);
                        writer.WriteString(row[i]);
                        writer.WriteEndElement(); // Data

                        writer.WriteEndElement(); // Cell
                    }

                    writer.WriteEndElement(); // Row
                }

                writer.WriteEndElement(); // Table
                writer.WriteEndElement(); // Worksheet

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
