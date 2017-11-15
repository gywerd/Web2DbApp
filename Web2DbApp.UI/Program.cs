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
        

        static void Main(string[] args)
        {
            List<Person> persons;
            Repository CDR = new Repository();
            MockDataProvider CSM = new MockDataProvider();
            CSM.MakeMockData();
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
        #endregion
    }
}
