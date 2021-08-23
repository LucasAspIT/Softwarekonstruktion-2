using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Repository;

namespace IO
{
    public class ClassFamilyDB : ClassDbCon
    {
        public ClassFamilyDB()
        {
            SetCon(@"Server=(LocalDb)\mssqllocaldb;Database=FamilyDB;Trusted_Connection=True;");
        }

        public List<ClassPerson> GetAllPersonsFromDB()
        {
            List<ClassPerson> listPersonRes = new List<ClassPerson>();

            string sqlQuery = "SELECT Familymembers.Id, Familymembers.name, Familymembers.address, " + 
                "Familymembers.streetNo, Familymembers.phone, Familymembers.mail, Familymembers.birthday, " + 
                "Familymembers.job, Familymembers.zipCode, ZipCity.cityName, ZipCity.streetName, " +
                "Familymembers.genderId, Gender.genderDescription " +
                "FROM Familymembers LEFT OUTER JOIN " +
                "Gender ON Familymembers.genderId = Gender.Id LEFT OUTER JOIN " +
                "ZipCity ON Familymembers.zipCode = ZipCity.zipCode";

            DataTable dataTable = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassPerson person = new ClassPerson();

                person.Id = Convert.ToInt32(row["Id"]);
                person.name = row["name"].ToString();
                person.zipCity.streetName = row["address"].ToString();
                person.zipCity.zipCode = row["zipCode"].ToString();
                person.zipCity.cityName = row["cityName"].ToString() + " " + row["streetName"].ToString();
                person.phone = row["phone"].ToString();
                person.mail = row["mail"].ToString();
                person.birthday = Convert.ToDateTime(row["birthday"]);
                person.job = row["job"].ToString();
                person.gender.Id = Convert.ToInt32(row["genderId"]);
                person.gender.genderType = row["genderDescription"].ToString();

                listPersonRes.Add(person);
            }

            return listPersonRes;
        }

        public List<ClassGender> GetAllGenderFromDB()
        {
            List<ClassGender> genderList = new List<ClassGender>();
            string sqlQuery = "SELECT * FROM Gender";
            DataTable dataTable = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassGender CG = new ClassGender();

                CG.Id = Convert.ToInt32(row["Id"]);
                CG.genderType = row["genderDescription"].ToString();

                genderList.Add(CG);
            }

            return genderList;
        }

        public int InsertPersonInDB(ClassPerson inPerson)
        {
            int res = 0;
            string sqlQuery = "INSERT INTO Familymembers (name, address, streetNo, phone, mail, birthday, job, zipCode, genderId) " +
                              "VALUES (@name, @address, @streetNo, @phone, @mail, @birthday, @job, @zipCode, @genderId) " +
                              "SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inPerson.name;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = inPerson.zipCity.streetName;
                    cmd.Parameters.Add("@streetNo", SqlDbType.NVarChar).Value = inPerson.zipCity.streetNumber;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inPerson.phone;
                    cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = inPerson.mail;
                    cmd.Parameters.Add("@birthday", SqlDbType.Date).Value = inPerson.birthday;
                    cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = inPerson.job;
                    cmd.Parameters.Add("@zipCode", SqlDbType.NVarChar).Value = inPerson.zipCity.zipCode;
                    cmd.Parameters.Add("@genderId", SqlDbType.Int).Value = inPerson.gender.Id;

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

        public int DeletePerson(ClassPerson inPerson)
        {
            return ExecuteNonQuery($"DELETE FROM Familymembers WHERE Id = {inPerson.Id}");
        }

        public int UpdatePersonInDB(ClassPerson inPerson)
        {
            int res = 0;
            string sqlQuery = "UPDATE Familymembers " +
                              "SET " +
                              "name = @name, " +
                              "address = @address, " +
                              "streetNo = @streetNo, " +
                              "phone = @phone, " +
                              "mail = @mail, " +
                              "birthday = @birthday, " +
                              "job = @job, " +
                              "zipCode = @zipCode, " +
                              "genderId = @genderId " +
                              "WHERE " +
                              "Id = @personId";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = inPerson.name;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = inPerson.zipCity.streetName;
                    cmd.Parameters.Add("@streetNo", SqlDbType.NVarChar).Value = inPerson.zipCity.streetNumber;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = inPerson.phone;
                    cmd.Parameters.Add("@mail", SqlDbType.NVarChar).Value = inPerson.mail;
                    cmd.Parameters.Add("@birthday", SqlDbType.Date).Value = inPerson.birthday;
                    cmd.Parameters.Add("@job", SqlDbType.NVarChar).Value = inPerson.job;
                    cmd.Parameters.Add("@zipCode", SqlDbType.NVarChar).Value = inPerson.zipCity.zipCode;
                    cmd.Parameters.Add("@genderId", SqlDbType.Int).Value = inPerson.gender.Id;
                    cmd.Parameters.Add("@personId", SqlDbType.Int).Value = inPerson.Id;

                    OpenDB();
                    res = cmd.ExecuteNonQuery();
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

        public string GetCityName(string inZip)
        {
            string res = DbReturnString($"SELECT cityName FROM ZipCity WHERE zipCode = '{inZip}'");
            if (res.Trim().Length == 0)
            {
                res = "Postnr. findes ikke.";
            }

            return res;
        }
    }
}
