using System;
using System.Collections.Generic;
using System.Text;


namespace BL
{
    public class BLFactory 
    {
        static IBL ibl = null;
        public static IBL getBL()
        {
            if (ibl == null)
                ibl = new BLImp();
            return ibl;
        }
    }
}
