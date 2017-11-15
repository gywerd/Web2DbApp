using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web2DbApp.Entities
{
    public class RootObject
    {
        #region Properties
        public List<Result> results { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// empty constructor
        /// </summary>
        public RootObject() { }
        #endregion
    }
}
