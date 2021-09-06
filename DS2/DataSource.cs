using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using BE;

namespace DS2
{
    public class DataSource
    {
        public static List<HostingUnit> ListHostingUnit = new List<HostingUnit>();
       

        public static List<GuestRequest> ListGuestRequest = new List<GuestRequest>();
       



        public static List<Order> ListOrder = new List<Order>();
        public static List<Hiking> ListHiking = new List<Hiking>() { new Hiking { area = Area.Center, HikingName = "Lifta", hikingtime = HikingTime.AfterNoon, price = 50 }, new Hiking { area = Area.Center, HikingName = "Ir David", hikingtime = HikingTime.Night, price = 75 }, new Hiking { area = Area.South, HikingName = "Mitspe Ramon", hikingtime = HikingTime.AllDayLong, price = 150 } };
        public static List<RentaCar> ListRentaCar = new List<RentaCar>() { new RentaCar { name = "Aviv", area = Area.Center, address = "78 Ben Tsion" }, new RentaCar { name = "Hertz", area = Area.South, address = "25 Jerusalem" } };
        public static List<HostingUnit> ListNewHostingUnit = new List<HostingUnit>();
        public static List<string> ListMailAddress = new List<string>();
        public static List<Message> ListMessage = new List<Message>() ;
        public static List<string> ListSaladShabbat = new List<string>() { "hatsil mayo", "gezer", "selek", "makbouha", "houmous", "thina", "krouv" };
    }
}


