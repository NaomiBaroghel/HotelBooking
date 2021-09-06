using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class RentaCar
    {
        public string name { get; set; }
        public Area area { get; set; }
        public string address { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
