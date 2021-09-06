using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey { get; set; }
       // public Stopwatch watch { get; set; }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string MailAddress { get; set; }
        public bool Newsletter { get; set; }
        public StatusGR status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        private int TimeStay;
        public int timeStay { get { return (ReleaseDate - EntryDate).Days; } 
            set { TimeStay = (ReleaseDate - EntryDate).Days; } }
        public Area area { get; set; }
        public SubArea subArea { get; set; }
        public Type type { get; set; }
        public int Adults { get; set; } //1
        public int Children { get; set; }//0
        public int Rooms { get; set; }
        public int People { get {return Adults + Children; } set { } } 
        public Accord Pool { get; set; }
        public Accord poolseparated { get; set; }

        public Accord Jacuzzi { get; set; }
        public Accord Garden { get; set; }
        public Accord ChildrenAttractions { get; set; }
       

        
        public bool MealShabbat { get; set; }
        private List<string> Saladshabbat = new List<string>();
        public List<string> saladshabbat { get { return Saladshabbat; } }
        public  Kasherout kasherout { get; set; }
        public bool Car { get; set; }
        public Accord Sea { get; set; }
        public Accord Mountain { get; set; }
        public bool Hiking { get; set; }
        public Accord BetHabbad { get; set; }
        public Accord Super { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }






    }
}
