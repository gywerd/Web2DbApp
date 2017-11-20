using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web2DbApp.Entities;
using Web2DbApp.DataAccess;

namespace Web2DbApp.Services
{
    public class MockDataProvider
    {
        #region Fields
        private string url = @"https://randomuser.me/api/?nat=dk&inc=name&noinfo&results=";
        Repository CDR = new Repository();
        #endregion

        #region Methods
        /// <summary>
        /// fetches a list of random people and save them to the database
        /// </summary>
        public List<Person> MakeMockData()
        {
            List<Person> people;
            people = GetPeople(10);
            return people;
        }


        /// <summary>
        /// Fetches chosen amount of people from 'Random User Generator' at https://randomuser.me/
        /// </summary>
        /// <param name="amount">int</param>
        /// <returns></returns>
        public List<Person> GetPeople(int amount)
        {
            List<Person> lp = new List<Person>();
            string fullurl = string.Format("{0}{1}", url, amount);
            string response;
            using (WebClient c = new WebClient())
            {
                response = c.DownloadString(fullurl);
            }
            RootObject p = JsonConvert.DeserializeObject<RootObject>(response);
            for (int i = 0; i < p.results.Count; i++)
            {
                Person pers = (Person)p.results[i].name;
                lp.Add(pers);
            }
            return lp;
        }
        #endregion

    }
}
