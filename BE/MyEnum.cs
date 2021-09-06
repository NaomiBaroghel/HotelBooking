using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BE
{

    public enum Status { Active, SendMail, Accepted, Refused };
    public enum StatusGR { Active, CloseThrougTheSite, CloseBecauseItExpired };
    public enum Type { HotelRoom, House, Apartment, Camping };
    public enum Area { Center, North, South, Jerusalem };
    public enum SubAreaC { TelAviv, Natanya, BatYam, Raanana };
    public enum SubAreaJ { Jerusalem };
    public enum SubAreaS { Eilat, Ashdod, Ashkelon, BeerSheva, Netivot };
    public enum SubAreaN { Haifa, Safed, Tiberia };
    public enum SubArea { TelAviv, Natanya, Jerusalem, Eilat, Haifa, Safed, Tiberia, BeerSheva, Netivot, Ashdod, Ashkelon, BatYam, Raanana };
    public enum Accord { yes, no, dontcare };
    public enum Kasherout { Rabanout, Badatz, Mahfoud, Lando, Jerusalem };
    public enum Bankname { Discount, Leumi, Hapoalim, MizrahiTfahot }
    public enum HikingTime { Morning, AfterNoon, Evening, Night, AllDayLong }
    public enum Money {NIS, Dollars, Euros, Pounds  }
}
    
