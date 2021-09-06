using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class DALException : Exception
    {
        public DALException() {}
        public DALException(string message)
        : base("DAL Exception : " + message){ }
    }
}
