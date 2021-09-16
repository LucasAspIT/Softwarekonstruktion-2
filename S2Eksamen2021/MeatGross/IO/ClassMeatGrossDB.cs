using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            SetCon(@"Server=(localdb)\MSSQLLocalDB;Database=MeatGross;Trusted_Connection=True;Connection Timeout=5");
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
            List<ClassCountry> listCountry = new List<ClassCountry>();

            DataTable dataTable = DbReturnDataTable("SELECT * FROM CountryAndRates");

            foreach (DataRow row in dataTable.Rows)
            {
                ClassCountry classCountry = new ClassCountry();

                classCountry.id = Convert.ToInt32(row["Id"]);
                classCountry.countryCode = row["CountryCode"].ToString();
                classCountry.countryName = row["CountryName"].ToString();
                classCountry.valutaName = row["ValutaName"].ToString();

                // valutaRate?
                // updateTime?

                listCountry.Add(classCountry);
            }

            return listCountry;
        }

        public List<ClassMeat> GetAllMeatFromDB()
        {
            List<ClassMeat> temp = new List<ClassMeat>();

            return temp;
        }

        public int SaveNewCustomerInDB(ClassCustomer inClassCustomer)
        {
            int res = 0;
            string sqlQuery = "INSERT INTO Customer (CompanyName, Address, ZipCity, Phone, Mail, ContactName, Country) " +
                "VALUES (@CompanyName, @Address, @ZipCity, @Phone, @Mail, @ContactName, @Country) " +
                "SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = inClassCustomer.companyName;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = inClassCustomer.address;
                    cmd.Parameters.Add("@ZipCity", SqlDbType.NVarChar).Value = inClassCustomer.zipCity;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = inClassCustomer.phone;
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = inClassCustomer.mail;
                    cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = inClassCustomer.contactName;
                    cmd.Parameters.Add("@Country", SqlDbType.Int).Value = inClassCustomer.country.id;

                    OpenDB();
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return res;
        }

        public void UpdateCustomerInDB(ClassCustomer inClassCustomer)
        {
            string sqlQuery = "UPDATE Customer SET " +
                "CompanyName = @CompanyName, " +
                "Address = @Address, " +
                "ZipCity = @ZipCity, " +
                "Phone = @Phone, " +
                "Mail = @Mail, " +
                "ContactName = @ContactName, " +
                "Country = @Country " +
                "WHERE id = @id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = inClassCustomer.companyName;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = inClassCustomer.address;
                    cmd.Parameters.Add("@ZipCity", SqlDbType.NVarChar).Value = inClassCustomer.zipCity;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = inClassCustomer.phone;
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = inClassCustomer.mail;
                    cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = inClassCustomer.contactName;
                    cmd.Parameters.Add("@Country", SqlDbType.Int).Value = inClassCustomer.country.id;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = inClassCustomer.id;

                    OpenDB();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                CloseDB();
            }
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
