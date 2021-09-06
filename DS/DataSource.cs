using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{

    public class DataSource
    {

            //Celui qui n'a pas de pool n'a même pas le sade poolseparated
        public  static List<HostingUnit> ListHostingUnit = new List<HostingUnit>() {
            new HostingUnit{Owner = new Host{HostKey = 12345678, PrivateName="Ornael", FamilyName="Aflalou", PhoneNumber=0586301415, MailAddress="ornael.aflalou@gmail.com", BankAccountNumber= 14732467, branch = new Branch {BankNumber = 1567, BankName=Bankname.Discount, BranchNumber = 154, BranchAddress = "290 Yafo", BranchCity = SubArea.Natanya },CollectionClearance= true}, HostingUnitName="Flower Suite",Rooms=1, Beds=2,pricePerNight=100, area=Area.Center, subArea=SubArea.Natanya,type=BE.Type.HotelRoom,Pool=true,poolseparated=false, Jacuzzi=false,Garden=false,ChildrenAttractions= true, kasherout=Kasherout.Badatz,Car=false,Sea=false, Mountain=true,BetHabbad=false,Super=true },
            new HostingUnit{Owner = new Host{HostKey = 12345678, PrivateName="Ornael", FamilyName="Aflalou", PhoneNumber=0586301415, MailAddress="ornael.aflalou@gmail.com", BankAccountNumber= 14732467,branch = new Branch {BankNumber = 1567, BankName=Bankname.Discount, BranchNumber = 154, BranchAddress = "290 Yafo", BranchCity = SubArea.Natanya},CollectionClearance= true},HostingUnitName="Luxury Suite",Rooms=1, Beds=2,pricePerNight=100,area=Area.Center,subArea=SubArea.Natanya, type=BE.Type.HotelRoom,Pool=true,poolseparated=true, Jacuzzi=false, Garden=false,ChildrenAttractions= false,kasherout=Kasherout.Badatz, Car=true, Sea=true,  Mountain=false, BetHabbad=false,Super=true},
            new HostingUnit{Owner = new Host{HostKey = 12345678, PrivateName="Ornael", FamilyName="Aflalou", PhoneNumber=0586301415, MailAddress="ornael.aflalou@gmail.com", BankAccountNumber= 14732467, branch = new Branch { BankNumber = 1567, BankName=Bankname.Discount, BranchNumber = 154, BranchAddress = "290 Yafo", BranchCity = SubArea.Natanya }, CollectionClearance= true },HostingUnitName="Medium Suite",Rooms=3,Beds=6, pricePerNight=100,area=Area.Center, subArea=SubArea.Natanya,type=BE.Type.HotelRoom,Pool=true,poolseparated=false, Jacuzzi=false, Garden=false, ChildrenAttractions= false,kasherout=Kasherout.Rabanout, Car=true, Sea=true, Mountain=false, BetHabbad=false, Super=true},
            new HostingUnit{Owner = new Host{HostKey = 87654321, PrivateName="Itshak", FamilyName="Marciano", PhoneNumber=0549302254, MailAddress="ornael.aflalou@gmail.com",  BankAccountNumber= 13682685,branch=new Branch{BankNumber = 5463, BankName=Bankname.Hapoalim, BranchNumber = 138, BranchAddress = "14 Binyamin", BranchCity = SubArea.Jerusalem }, CollectionClearance= true },HostingUnitName="Forest",Rooms=2,Beds=4,pricePerNight=100,area=Area.Center, subArea=SubArea.Jerusalem,type=BE.Type.House, Pool=false, Jacuzzi=true, Garden=false, ChildrenAttractions= false,kasherout=Kasherout.Rabanout,Car=false, Sea=false,  Mountain=false, BetHabbad=false, Super=false},
            new HostingUnit{Owner = new Host{HostKey = 87654321, PrivateName="Itshak", FamilyName="Marciano", PhoneNumber=0549302254, MailAddress="ornael.aflalou@gmail.com",  BankAccountNumber= 13682685,branch=new Branch{BankNumber = 5463, BankName=Bankname.Hapoalim, BranchNumber = 138, BranchAddress = "14 Binyamin", BranchCity = SubArea.Jerusalem  }, CollectionClearance= true },HostingUnitName="Snow House",Rooms=3, Beds=6,pricePerNight=100,area=Area.Center, subArea=SubArea.Jerusalem,type=BE.Type.House, Pool=false, Jacuzzi=true, Garden=true, ChildrenAttractions= false,kasherout=Kasherout.Rabanout, Car=false, Sea=true,  Mountain=true, BetHabbad=true, Super=true},
            new HostingUnit{Owner = new Host{HostKey = 87654321, PrivateName="Itshak", FamilyName="Marciano", PhoneNumber=0549302254, MailAddress="ornael.aflalou@gmail.com",  BankAccountNumber= 13682685,branch=new Branch{BankNumber = 5463, BankName=Bankname.Hapoalim, BranchNumber = 138, BranchAddress = "14 Binyamin", BranchCity = SubArea.Jerusalem  }, CollectionClearance= true },HostingUnitName="My House",Rooms=5,Beds=10,pricePerNight=100, area=Area.Center, subArea=SubArea.Jerusalem,type=BE.Type.Apartment, Pool=false,Jacuzzi=false,Garden=true, ChildrenAttractions= true,kasherout=Kasherout.Rabanout, Car=false, Sea=false,  Mountain=false, BetHabbad=true, Super=true},
            new HostingUnit{Owner = new Host{HostKey = 13245768, PrivateName="Chlomo", FamilyName="Greenberg", PhoneNumber=0579856223, MailAddress="ornael.aflalou@gmail.com", BankAccountNumber= 264389368,branch = new Branch{BankNumber = 8369, BankName=Bankname.Discount, BranchNumber = 234, BranchAddress = "78 Rav Ouziel", BranchCity = SubArea.Eilat },CollectionClearance= true },HostingUnitName="Luxury Room",Rooms=1,Beds=2,pricePerNight=100, area=Area.South, subArea=SubArea.Eilat, type=BE.Type.HotelRoom, Pool=true,poolseparated=false, Jacuzzi=true, Garden=false, ChildrenAttractions= true,kasherout=Kasherout.Rabanout,Car=true, Sea=true,  Mountain=false, BetHabbad=false,Super=true},
            new HostingUnit{Owner = new Host{HostKey = 13245768, PrivateName="Chlomo", FamilyName="Greenberg", PhoneNumber=0579856223, MailAddress="ornael.aflalou@gmail.com", BankAccountNumber= 264389368,branch = new Branch{BankNumber = 8369, BankName=Bankname.Discount, BranchNumber = 234, BranchAddress = "78 Rav Ouziel", BranchCity = SubArea.Eilat  },CollectionClearance= true },HostingUnitName="Deluxe Room",Rooms=2,Beds=4, pricePerNight=100,area=Area.South, subArea=SubArea.Eilat,type=BE.Type.HotelRoom, Pool=true,poolseparated=true, Jacuzzi=false, Garden=false, ChildrenAttractions= true,kasherout=Kasherout.Rabanout,Car=true, Sea=true,  Mountain=false, BetHabbad=true, Super=false},
            new HostingUnit{Owner = new Host{HostKey = 13245768, PrivateName="Chlomo", FamilyName="Greenberg", PhoneNumber=0579856223, MailAddress="ornael.aflalou@gmail.com", BankAccountNumber= 264389368, branch = new Branch{BankNumber = 8369, BankName=Bankname.Discount, BranchNumber = 234, BranchAddress = "78 Rav Ouziel", BranchCity = SubArea.Eilat  },CollectionClearance= true },HostingUnitName="The Sea Room",Rooms=1,Beds=2,pricePerNight=100, area=Area.South, subArea=SubArea.Eilat,type=BE.Type.HotelRoom, Pool=true,poolseparated=true, Jacuzzi=false, Garden=false, ChildrenAttractions= true,kasherout=Kasherout.Rabanout,Car=true, Sea=true,  Mountain=false, BetHabbad=true, Super=false} };


        //celui qui ne veut pas de newsletter n'a pas le sade newsletter
        public  List<GuestRequest> ListGuestRequest = new List<GuestRequest>() {
            new GuestRequest{PrivateName="Harry", FamilyName="Stillman", MailAddress="naomi.baroghel@gmail.com", Newsletter = true, EntryDate =new DateTime (2020,01,4),ReleaseDate = new DateTime(2020,01,25), area=Area.Center, subArea=SubArea.Natanya, type=BE.Type.HotelRoom, Adults=2,Children= 0, Pool=Accord.dontcare,poolseparated=Accord.dontcare, Jacuzzi=Accord.no, Garden=Accord.dontcare, ChildrenAttractions=Accord.no, MealShabbat = true, kasherout=Kasherout.Badatz, Car=true, Sea=Accord.yes, Mountain=Accord.no,BetHabbad=Accord.no,Super=Accord.yes},
            new GuestRequest{PrivateName="Julie", FamilyName="Zouie", MailAddress="naomi.baroghel@gmail.com", Newsletter = true, EntryDate =new DateTime(2020,02,24),ReleaseDate= new DateTime(2020,03,03),area=Area.Center, subArea=SubArea.Jerusalem,type=BE.Type.House, Adults=2, Children=3, Pool=Accord.no, poolseparated=Accord.no, Jacuzzi=Accord.no,Garden=Accord.no,ChildrenAttractions=Accord.yes, MealShabbat=false,kasherout = Kasherout.Rabanout, Car=true, Sea=Accord.no,Mountain=Accord.yes, newMountain=true, BetHabbad=Accord.dontcare,Super=Accord.dontcare },
            new GuestRequest{PrivateName="David", FamilyName="Rottenberg",MailAddress="naomi.baroghel@gmail.com", EntryDate=new DateTime(2020,07,15), ReleaseDate=new DateTime(2020,08,10),area=Area.South,subArea=SubArea.Eilat, type=BE.Type.HotelRoom, Adults=2, Children=2, Pool=Accord.yes,poolseparated=Accord.yes,Jacuzzi=Accord.yes, Garden=Accord.dontcare,ChildrenAttractions=Accord.yes,MealShabbat=true, kasherout=Kasherout.Rabanout,Car= true, Sea=Accord.yes,Mountain=Accord.no, BetHabbad=Accord.dontcare,Super=Accord.dontcare },
            new GuestRequest{PrivateName="Stefen", FamilyName="Pablo", MailAddress="naomi.baroghel@gmail.com", EntryDate=new DateTime(2020,08,12), ReleaseDate=new DateTime(2020,08,21),area=Area.Center, subArea=SubArea.Jerusalem,type=BE.Type.Apartment,Adults= 4, Children=0, Pool=Accord.dontcare,poolseparated=Accord.dontcare,Jacuzzi=Accord.no,Garden=Accord.no,ChildrenAttractions=Accord.no,MealShabbat= true,kasherout=Kasherout.Rabanout,Car=false, Sea=Accord.no, Mountain=Accord.no, BetHabbad=Accord.yes,Super=Accord.dontcare }
         };



       

        public  List<Order> ListOrder = new List<Order>();
        public  List<Hiking> ListHiking = new List<Hiking>();
        public  List<RentaCar> ListRentaCar = new List<RentaCar>();
        public  List<HostingUnit> ListNewHostingUnit = new List<HostingUnit>();
        public  List<MailAddress> ListMailAddress = new List<MailAddress>();
        public  List<string> ListSaladShabbat = new List<string>();

        


        }
}
