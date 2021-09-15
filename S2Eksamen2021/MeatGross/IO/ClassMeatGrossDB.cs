using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace IO
{
    public class ClassMeatGrossDB : ClassDbCon
    {
        public ClassMeatGrossDB()
        {
            SetCon(@"Server=(localdb)\MSSQLLocalDB;Database=MeatGross;Trusted_Connection=True;Connection Timeout=1");
        }

        /// <summary>
        /// Sends a query to the database askin for all customers and adds the response into a list.
        /// </summary>
        /// <returns>All customers in the database in a List of ClassCustomer</returns>
        public List<ClassCustomer> GetAllCustomersFromDB()
        {
            List<ClassCustomer> listCC = new List<ClassCustomer>();

            DataTable dataTable = DbReturnDataTable("SELECT Customer.Id, Customer.CompanyName, " +
                "Customer.Address, Customer.ZipCity, Customer.Phone, Customer.Mail, Customer.ContactName, " +
                "Customer.Country AS CountryID,  CountryAndRates.CountryCode, CountryAndRates.CountryName, CountryAndRates.ValutaName " +
                "FROM Customer LEFT OUTER JOIN " +
                "CountryAndRates ON Customer.Country = CountryAndRates.Id");

            foreach (DataRow row in dataTable.Rows)
            {
                ClassCustomer classCustomer = new ClassCustomer();
                ClassCountry classCountry = new ClassCountry();

                classCountry.id = Convert.ToInt32(row["Id"]);
                classCountry.countryCode = row["countryCode"].ToString();
                classCountry.countryName = row["countryName"].ToString();
                classCountry.valutaName = row["valutaName"].ToString();

                classCustomer.country = classCountry;

                classCustomer.id = Convert.ToInt32(row["Id"].ToString());
                classCustomer.companyName = row["CompanyName"].ToString();
                classCustomer.address = row["Address"].ToString();
                classCustomer.zipCity = row["ZipCity"].ToString();
                classCustomer.phone = row["Phone"].ToString();
                classCustomer.mail = row["Mail"].ToString();
                classCustomer.contactName = row["ContactName"].ToString();
                classCustomer.country.id = Convert.ToInt32(row["CountryID"].ToString());

                listCC.Add(classCustomer);
            }

            return listCC;
        }

        public List<ClassCountry> GetAllCountriesFromDB()
        {
            List<ClassCountry> temp = new List<ClassCountry>();

            return temp;
        }

        public List<ClassMeat> GetAllMeatFromDB()
        {
            List<ClassMeat> temp = new List<ClassMeat>();

            return temp;
        }

        public int SaveNewCustomerInDB(ClassCustomer inCustomer)
        {
            int temp = 0;

            return temp;
        }

        public void UpdateCustomerInDB(ClassCustomer inCustomer)
        {

        }

        public void UpdateMeatVolume(ClassOrder inOrder)
        {

        }

        public void UpdatePriceForMeatInDB(string inMeat, double inPrice, int inWeight)
        {

        }

        public void UpdateTimestampForMeat()
        {

        }

        public int AddOrderToDB(ClassOrder inOrder)
        {
            int temp = 0;

            return temp;
        }
    }
}
