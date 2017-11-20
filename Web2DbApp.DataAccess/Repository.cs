using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2DbApp.Entities;

namespace Web2DbApp.DataAccess
{
    public class Repository
    {
        #region fields
        private Executor executor;
        #endregion

        #region Constructors
        /// <summary>
        /// empty constructor
        /// </summary>
        public Repository()
        {
            executor = new Executor();
        }
        #endregion

        #region Methods
        /// <summary>
        /// reads all rows in database - returns a list
        /// </summary>
        /// <returns>List<Person></returns>
        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            //string query = "SELECT * FROM Persons";
            //using stored procedure instead of specific query
            string query = "SelectAll";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                string first = Convert.ToString(reader["FirstName"]);
                string last = Convert.ToString(reader["LastName"]);
                string title = Convert.ToString(reader["Title"]);
                Person p = new Person(first, last, title);
                persons.Add(p);
            }
            return persons;
        }

        /// <summary>
        /// Deletes and recreates Persons-table in the database and inserts new rows from list
        /// </summary>
        /// <param name="persons">List<Person></param>
        public void SavePersons(List<Person> persons)
        {
            executor.ExecuteDeleteAll();
            foreach (Person p in persons)
            {
                if (p.FirstName != "" && p.LastName != "" & p.TitleOfCourtesy != "")
                {
                    executor.Execute("SavePerson", p);
                }
            }
        }
        #endregion
    }
}
