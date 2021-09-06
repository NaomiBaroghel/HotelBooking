using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey { get; set; }
        public int GuestRequestKey { get; set; }
        public int OrderKey { get; set; }
        public  Status status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime OrderDate { get; set; } //date ou on a envoye le mail
        public float priceTotal { get; set; }
       // public float taxeforhost { get; set; }



        public override string ToString()
        {
            return this.ToStringProperty();

        }
    }

}
