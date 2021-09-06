using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BE
{
    public class HostingUnit
    {
        public int HostingUnitKey { get; set; }
        public string passwordHU { get; set; }


        private string imageSource = "/Images/emptyimage.jpg";

        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }
        private string videoSource = "/Images/emptyimage.jpg";

        public string VideoSource
        {
            get { return videoSource; }
            set { videoSource = value; }
        }

        public Host Owner { get; set; } = new Host();
        public string HostingUnitName { get; set; }
        public int Rooms { get; set; }
        public int Beds { get; set; }

        public float pricePerNight { get; set; }
        public Money typemoney { get; set; } = Money.NIS;



        public Area area { get; set; }
        public SubArea subArea { get; set; }
        public Type type { get; set; }


        public bool Pool { get; set; }
        public bool poolseparated { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Garden { get; set; }
        public bool ChildrenAttractions { get; set; }

        public Kasherout kasherout { get; set; }
        public bool Sea { get; set; }
        public bool Mountain { get; set; }
        public bool BetHabbad { get; set; }
        public bool Super { get; set; }


        [XmlIgnore]
        public bool[,] Diary = new bool[32, 13]; // we choosed to use a matrix of 32x13 for conveniant purpose

        [XmlArray("diary")]
        public bool[] BoardDto
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(32); } //32 is the number of rows in the matrix
        }


        public void ConstrucDiary()
        {
            for (int i = 0; i < 13; i++)
                for (int j = 0; j < 32; j++)
                {
                    Diary[j, i] = false;
                }
        }

        public override string ToString()
        {
            return this.ToStringProperty();
        }


    }
}
