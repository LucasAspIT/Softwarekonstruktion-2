using System.Data;
using System.Data.SqlClient;

namespace IO
{
    /// <summary>
    /// This class is used to communicate between a C# project and a given SQL-Server's designated database.
    /// The methods in this class can only be accessed through inheritance.
    /// </summary>
    public class ClassDbCon
    {
        // Fields that are used in the various methods in this class
        private string _connectionString;
        protected SqlConnection con;
        private SqlCommand _command;

        /// <summary>
        /// Default constructor.
        /// <br>_connectionString gets initialised to a valid ConnectionString with the URL to the SQL-Server and information about which database is to be used.</br>
        /// <br>Additional info about the connectionstring can be found here: https://www.connectionstrings.com/sql-server/ </br>
        /// </summary>
        public ClassDbCon()
        {
            // _connectionString = @"Server=(LocalDb)\mssqllocaldb;Database=FamilyDB;Trusted_Connection=True;";
            // con = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Overloaded constructor.
        /// <br>Has the same function as the default constructor, but has to receive a parameter with indication to the connection to the SQL-Server via the ConnectionString.</br>
        /// </summary>
        /// <param name="inConnectionString"></param>
        public ClassDbCon(string inConnectionString)
        {
            _connectionString = inConnectionString;
            con = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Method which can be used to define which SQL-Server and/or which database a connection should be established with.
        /// <br>The method can be called as needed and will overrule the SqlConnection that was created in one of the two constructors.</br>
        /// </summary>
        /// <param name="inConnectionString"></param>
        protected void SetCon(string inConnectionString)
        {
            _connectionString = inConnectionString;
            con = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// This method opens the connection to the database.
        /// <br>It checks if all the conditions are fulfilled for opening the connection, before it gets opened.</br>
        /// <br>If the conditions are not fulfilled, it will attempt to handle the most common errors.</br>
        /// </summary>
        protected void OpenDB()
        {
            try
            {
                if (this.con != null && con.State == ConnectionState.Closed) // Checks if the instance 'con' is initialised and that there isn't a connection already.
                {
                    con.Open(); // Opens the connection to the database.
                }
                else
                {
                    if (con.State == ConnectionState.Open) // Checks if the error is because there is an open connection already.
                    {
                        // If yes - closes the connection and then calls itself (recursive) again to open the connection.
                        CloseDB();
                        OpenDB();
                    }
                    else // If the error wasn't because of an open connection, then it must be a missing initialisation of 'con'.
                    {
                        con = new SqlConnection(_connectionString); // Initialises 'con' with the given ConnectionString.
                        OpenDB(); // Calls itself (recursive) to open the connection.
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method closes the connection to the database.
        /// </summary>
        protected void CloseDB()
        {
            try
            {
                con.Close(); // Closes the connection.
            }
            catch (SqlException ex) // Handles the exceptions (errors) that may happen during communication with the database.
            {
                throw ex;
            }
        }

        /// <summary>
        /// The purpose of this method, is to perform actions in the database, that does not require a returned result.
        /// <br>However, the method will always return an integer which states whether it succeeded or not.</br>
        /// <br>Returns: -1 if the action was not performed.</br>
        /// <br>Returns: A number from 0 to N indicates that it was executed successfully, and how many datasets that were affected.</br>
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns>int</returns>
        protected int ExecuteNonQuery(string sqlQuery)
        {
            int res = 0;
            _command = new SqlCommand(sqlQuery, con); // The instance of 'SqlCommand' is initialised with the parameters string 'SqlQuery' and SqlConnection 'con'.

            try
            {
                OpenDB();
                res = _command.ExecuteNonQuery(); // The database is called and the given query gets executed.
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally // Anything in 'finally' gets executed whether the code gets executed with or without errors.
            {
                CloseDB();
            }

            return res;
        }

        /// <summary>
        /// Denne metode skal håndtere forespørgelser til databasen som skal returnere et resultatsæt.
        /// Det resultatsæt der modtages fra DB, konverteres over i en collection af typen DataTable
        /// </summary>
        /// <param name="sqlQuery">string</param>
        /// <returns>DataTable</returns>
        protected DataTable DbReturnDataTable(string sqlQuery)
        {
            DataTable dtRes = new DataTable();

            try
            {
                OpenDB();
                using (_command = new SqlCommand(sqlQuery, con)) // Her initialiseres instansen af SqlCommand med parameterne string query og SqlConnection con
                {
                    using (var adapter = new SqlDataAdapter(_command)) // Her foretages kaldet til databasen ved, at der oprettes en ny instans af en SqlDataAdapter. Resultatet overføres til en abstrakt datatype.
                    {
                        adapter.Fill(dtRes); // Her overføres data fra den abstrakte datatype til den DataTable metoden skal returnere
                    }
                }
            }
            catch (SqlException ex) // Håndtere de exceptions (fejl) der måtte opstå under kommunikationen med databasen
            {
                throw ex;
            }
            finally // Ved angivelse 'finally' sikre jeg, at det der står i 'finally' altid bliver udført, uanset om koden kunne eksekveres med eller uden fejl
            {
                CloseDB();
            }

            return dtRes;
        }

        protected string DbReturnString(string sqlQuery)
        {
            string res = "";
            bool foundOne = false;

            try
            {
                OpenDB();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con)) 
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) // If the reader has recieved a response from the database, execute the code in the while loop.
                    {
                        res = reader.GetString(0);
                        foundOne = true;
                    }
                    if (!foundOne)
                    {
                        res = "No data found!";
                    }
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

        /// <summary>
        /// This method handles queries to the database that returns a dataset.
        /// <br>The query is made through a StoredProcedure on the SQL-Server.</br>
        /// </summary>
        /// <param name="inCommand"></param>
        /// <returns>DataTable</returns>
        protected DataTable MakeCallToStoredProcedure(SqlCommand inCommand)
        {
            DataTable dtRes = new DataTable();
            try
            {
                OpenDB();
                using (SqlDataAdapter adapter = new SqlDataAdapter(inCommand)) // Her foretages kaldet til databasen ved, at der oprettes en ny instans af en SqlDataAdapter. Resultatet overføres til en abstrakt datatype.
                {
                    adapter.Fill(dtRes); // Her overføres data fra den abstrakte datatype til den DataTable metoden skal returnere
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

            return dtRes;
        }
    }
}
