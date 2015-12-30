using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Data
    {
        #region Private Properties
        private int numberOne;
        private int numberTwo;
        private int result;
        #endregion

        #region Public Properties
        public int NumberOne
        {
            get { return numberOne; }
            set { numberOne = value; }
        }
        public int NumberTwo
        {
            get { return numberTwo; }
            set { numberTwo = value; }
        }
        public int Result
        {
            get { return result; }
            set { result = value; }
        }
        #endregion
    }
}
