using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web2DbApp.Entities
{
    public class JsonPerson
    {
        #region Properties
        public string first { get; set; }
        public string last { get; set; }
        public string title { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public JsonPerson() { }
        #endregion

        #region Methods
        /// <summary>
        /// converts a Jsonperson object into a Person object 
        /// </summary>
        /// <param name="jperson">JsonPerson</param>
        public static explicit operator Person(JsonPerson jperson)
        {
            Person p = new Person();
            p.FirstName = DecodeString(jperson.first);
            p.LastName = DecodeString(jperson.last);
            p.TitleOfCourtesy = jperson.title;
            return p;
        }

        /// <summary>
        /// Corrects issues with scandinavian characters
        /// </summary>
        /// <param name="str">string</param>
        /// <returns></returns>
        private static string DecodeString(string str)
        {
            str = str.Replace("Ã¦", "æ");
            str = str.Replace("Ã¸", "ø");
            str = str.Replace("Ã…", "å");
            str = str.Replace("Ã…", "Æ");
            str = str.Replace("Ã˜", "Ø");
            str = str.Replace("Ã…", "Å");
            return str;
        }
        #endregion

    }
}
