using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class Hiking
    {
        public Area area {get;set;}
        public string HikingName { get; set; } //key
        public HikingTime hikingtime { get; set; }
        public int price { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
