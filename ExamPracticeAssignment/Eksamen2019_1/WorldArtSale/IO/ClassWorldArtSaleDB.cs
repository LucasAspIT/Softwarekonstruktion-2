using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace IO
{
    public class ClassWorldArtSaleDB : ClassDbCon
    {

        public ClassWorldArtSaleDB()
        {
            SetCon(@"Server=(localdb)\MSSQLLocalDB;Database=WorldArtSale;Trusted_Connection=True;Connection Timeout=1");
        }

        public List<ClassCustomer> GetAllCustomersFromDB()
        {
            List<ClassCustomer> listCC = new List<ClassCustomer>();

            DataTable dataTable = DbReturnDataTable("SELECT Customer.id, Customer.name, Customer.address, " +
                "Customer.zipCity, Customer.country, Customer.email, Customer.phone, Customer.maximumBid, " +
                "Customer.preferredCurrency, Country.code, Country.countryName, Country.valutaName " +
                "FROM Country RIGHT OUTER JOIN " +
                "Customer ON Country.id = Customer.preferredCurrency " +
                "WHERE(Customer.isActive = 1)");

            foreach (DataRow row in dataTable.Rows)
            {
                ClassCustomer classCustomer = new ClassCustomer();
                ClassCountry classCountry = new ClassCountry();

                classCountry.id = Convert.ToInt32(row["preferredCurrency"]);
                classCountry.code = row["code"].ToString();
                classCountry.countryName = row["countryName"].ToString();
                classCountry.valutaName = row["valutaName"].ToString();

                classCustomer.classCountry = classCountry;

                classCustomer.customerID = Convert.ToInt32(row["id"].ToString());
                classCustomer.name = row["name"].ToString();
                classCustomer.address = row["address"].ToString();
                classCustomer.zipCity = row["zipCity"].ToString();
                classCustomer.country = row["country"].ToString();
                classCustomer.email = row["email"].ToString();
                classCustomer.phoneNo = row["phone"].ToString();
                classCustomer.maxBid = row["maximumBid"].ToString();

                classCustomer.customerCurrencyID = classCountry.id.ToString();

                listCC.Add(classCustomer);
            }

            return listCC;
        }

        public List<ClassCountry> GetAllCountriesFromDB()
        {
            List<ClassCountry> listCountry = new List<ClassCountry>();

            DataTable dataTable = DbReturnDataTable("SELECT * FROM Country");

            foreach (DataRow row in dataTable.Rows)
            {
                ClassCountry classCountry = new ClassCountry();

                classCountry.id = Convert.ToInt32(row["id"]);
                classCountry.code = row["code"].ToString();
                classCountry.countryName = row["countryName"].ToString();
                classCountry.valutaName = row["valutaName"].ToString();

                listCountry.Add(classCountry);
            }

            return listCountry;
        }

        public List<ClassArt> GetAllArtFromDB()
        {
            List<ClassArt> res = new List<ClassArt>();

            return res;
        }
    }
}
