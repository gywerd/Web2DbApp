using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web2DbApp.Entities
{
    public class Person
    {
        #region Fields
        private string firstName;
        private string lastName;
        private string titleOfCourtesy;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Person() { }

        public Person(string first, string last, string title)
        {
            this.firstName = first;
            this.lastName = last;
            this.titleOfCourtesy = title;
        }
        #endregion

        #region Methods
        /// <summary>
        /// overrides ordinary ToString() method with specific format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", titleOfCourtesy, firstName, lastName);
        }
        #endregion

        #region Properties
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string TitleOfCourtesy { get => titleOfCourtesy; set => titleOfCourtesy = value; }
        #endregion
    }
}
