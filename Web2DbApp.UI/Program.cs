using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2DbApp.Entities;
using Web2DbApp.Services;
using Web2DbApp.DataAccess;

namespace Web2DbApp.UI
{
    class Program
    {
        static List<Person> persons;
        static List<Person> mockPersons;
        static Repository CDR = new Repository();
        static MockDataProvider CSM = new MockDataProvider();
        static Person P = new Person();


        static void Main(string[] args)
        {
            mockPersons = CSM.MakeMockData();
            SavePeople(mockPersons);
            persons = CDR.GetAll();
            PrintAll(persons);
            Console.ReadKey();
        }

        #region Method
        /// <summary>
        /// prints all persons in list to console
        /// </summary>
        /// <param name="persons">List<Person></param>
        public static void PrintAll(List<Person> persons)
        {
            foreach (Person p in persons)
            {
                Console.WriteLine(p.ToString());
            }
        }

        /// <summary>
        /// save people from list to database
        /// </summary>
        /// <param name="p">List<Person></param>
        public static void SavePeople(List<Person> p)
        {
            //Repository CDR = new Repository();
            CDR.SavePersons(p);
        }
        #endregion
    }
}
