using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
namespace Your_Kcal_Day.Class
{
    class Products
    {

        List<Product> ListProducts = new List<Product>();
        public Products()
        {
            using (TextReader reader = new StringReader(Properties.Resources.CSVFile))
            {
                CsvReader csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;

                csv.Configuration.BadDataFound = context =>
                {
                    // isRecordBad = true;
                    System.Diagnostics.Debug.WriteLine(context.RawRecord);
                };

                while (csv.Read())
                {
                    Product Record = csv.GetRecord<Product>();
                    ListProducts.Add(Record);
                }
            }
        }

        public List<Product> getList()
        {
            return this.ListProducts;
        }
    }
}
