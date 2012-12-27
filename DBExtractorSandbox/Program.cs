using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;

namespace DBExtractorSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * XML
             * /
            DBExtractor.XMLHelper xml = new DBExtractor.XMLHelper();
            xml.GenerateXML_0();
            xml.GenerateXML_1();
            xml.GenerateXML_2();
            xml.GenerateXML_3();
            xml.GenerateXML_4();
            xml.GenerateXML_5();
            */

            /*
             * DB
             * /
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
            SqlDataReader rdr = null;
            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from Customers", conn);

                //
                // 4. Use the connection
                //

                // get query results
                rdr = cmd.ExecuteReader();

                // print the CustomerID of each record
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            */

            // Retrieve the enumerator instance and then the data.
            SqlDataSourceEnumerator instance =
              SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();

            // Display the contents of the table.
            DisplayData(table);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }

        private static void DisplayData(System.Data.DataTable table)
        {
            foreach (System.Data.DataRow row in table.Rows)
            {
                foreach (System.Data.DataColumn col in table.Columns)
                {
                    Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                }
                Console.WriteLine("============================");
            }
        }
    }
}
