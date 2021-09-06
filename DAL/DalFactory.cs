using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DalFactory
    {
        static IDAL idal = null;
        public static IDAL getDAl()
        {
            if (idal == null)
                idal = new DalXML(); //Dalimp
            return idal;

        }


    }
}
