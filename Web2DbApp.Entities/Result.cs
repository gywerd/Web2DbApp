using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web2DbApp.Entities
{
    public class Result
    {
        #region Properties
        public JsonPerson name { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Result() { }
        #endregion
    }
}
