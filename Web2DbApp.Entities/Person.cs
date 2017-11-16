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
            firstName = ParseString(first);
            lastName = ParseString(last);
            titleOfCourtesy = ParseString(title);
        }
        #endregion

        #region Methods
        /// <summary>
        /// checks if string contains digits
        /// </summary>
        /// <param name="s">string</param>
        /// <returns></returns>
        public string RemoveNumeric(string s)
        {
            string res = "";
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    res = res + c;
                }
            }

            return res;
        }

        /// <summary>
        /// returns a string with uppercase first letter and no spaces
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string ParseString(string s)
        {
            string temp = UppercaseFirst(s);
            temp = RemoveNumeric(temp);
            temp = temp.Replace(" ", "-");
            return temp;
        }

        /// <summary>
        /// overrides ordinary ToString() method with specific format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", TitleOfCourtesy, FirstName, LastName);
        }

        /// <summary>
        /// returns string with uppercase first letter
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            string res = char.ToUpper(s[0]) + s.Substring(1);
            return res;
        }
        #endregion

        #region Properties
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = ParseString(value);
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = ParseString(value);
            }
        }
        public string TitleOfCourtesy
        {
            get => titleOfCourtesy;
            set
            {
                titleOfCourtesy = ParseString(value);
            }
        }

        #endregion
    }
}
