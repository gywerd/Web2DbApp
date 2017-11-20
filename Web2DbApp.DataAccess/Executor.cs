using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2DbApp.Entities;

namespace Web2DbApp.DataAccess
{
    public class Executor
    {
        #region Fields
        private const string connectionString = @"Data Source=10.205.44.39,49172;Initial Catalog=DanielWeb2DbApp;Persist Security Info=True;User ID=Aspit;Password=Server2012";
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Executor() { }
        #endregion

        #region Methods
        /// <summary>
        /// executes a sqlQuery
        /// </summary>
        /// <param name="procedureName">string</param>
        /// <param name="person">Person</param>
        public void Execute(string procedureName, Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //open connection
                connection.Open();

                //create a command object identifying the stored procedure
                SqlCommand command = new SqlCommand(procedureName, connection);

                //set the command object so it knows to execute a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                //add parameters to command, which will be passed to the stored procedure
                command.Parameters.Add(new SqlParameter("@FirstName", person.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", person.LastName));
                command.Parameters.Add(new SqlParameter("@Title", person.TitleOfCourtesy));

                // execute the command
                command.ExecuteNonQuery();

                //close connection
                connection.Close();
            }
        }

        /// <summary>
        /// executes a sqlQuery - not used - content commented out
        /// </summary>
        /// <param name="procedureName">string</param>
        /// <param name="sqlQuery">string</param>
        public void Execute(string procedureName, string sqlQuery)
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            //SqlCommand command = new SqlCommand(sqlQuery, connection);
            //command.ExecuteNonQuery();
            //connection.Close();
        }

        /// <summary>
        /// executes a sqlQuery - returns a DataSet
        /// </summary>
        /// <param name="procedureName">string</param>
        /// <returns>DataSet</returns>
        public DataSet Execute(string procedureName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(procedureName, connection);
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataSet set = new DataSet();
                adapter.Fill(set);
                connection.Close();
                return set;
            }
        }

        /// <summary>
        /// executes stored procedure that deletes and recreates Persons-table
        /// </summary>
        public void ExecuteDeleteAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            //string sqlQuery = $"DELETE FROM Persons";
            //using stored procedure instead of specific query
            string sqlQuery = "DeleteAll";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

    }
}
