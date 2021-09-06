using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using BE;
using BL;

namespace PL
{
    class Program
    {
        static IBL ibl = BLFactory.getBL();
        static void Main(string[] args)
        {

            GuestRequest newguestrequest = new GuestRequest { PrivateName = "Ella", FamilyName = "Bensoussan", MailAddress = "naomi.baroghel@gmail.com", EntryDate = new DateTime(2019, 06, 01), ReleaseDate = new DateTime(2020, 06, 17), area = Area.Center, subArea = SubArea.Safed, type = BE.Type.Apartment, Adults = 2, Children = 2, Rooms = 2, Pool = Accord.no, poolseparated = Accord.no, Jacuzzi = Accord.yes, Garden = Accord.yes, ChildrenAttractions = Accord.no, MealShabbat = true, kasherout = Kasherout.Badatz, Car = false, Sea = Accord.dontcare, Mountain = Accord.yes, BetHabbad = Accord.yes, Super = Accord.yes, Hiking = true };
            GuestRequest newguestrequest1 = new GuestRequest { PrivateName = "Harry", FamilyName = "Stillman", MailAddress = "naomi.baroghel@gmail.com", Newsletter = true, EntryDate = new DateTime(2020, 01, 4), ReleaseDate = new DateTime(2020, 01, 25), area = Area.Center, subArea = SubArea.Natanya, type = BE.Type.HotelRoom, Adults = 2, Rooms = 1, Pool = Accord.dontcare, poolseparated = Accord.dontcare, Jacuzzi = Accord.no, Garden = Accord.dontcare, ChildrenAttractions = Accord.no, MealShabbat = true, kasherout = Kasherout.Badatz, Car = true, Sea = Accord.yes, Mountain = Accord.no, BetHabbad = Accord.no, Super = Accord.yes, Hiking =true };
            GuestRequest newguestrequest2 = new GuestRequest { PrivateName = "Julie", FamilyName = "Zouie", MailAddress = "naomi.baroghel@gmail.com", Newsletter = true, EntryDate = new DateTime(2020, 02, 24), ReleaseDate = new DateTime(2020, 03, 03), area = Area.Jerusalem, subArea = SubArea.Jerusalem, type = BE.Type.House, Adults = 2, Children = 3, Rooms = 3, Pool = Accord.no, poolseparated = Accord.no, Jacuzzi = Accord.no, Garden = Accord.no, ChildrenAttractions = Accord.yes, MealShabbat = false, kasherout = Kasherout.Rabanout, Car = true, Sea = Accord.no, Mountain = Accord.yes, BetHabbad = Accord.dontcare, Super = Accord.dontcare, Hiking = true };
            GuestRequest newguestrequest3 = new GuestRequest { PrivateName = "David", FamilyName = "Rottenberg", MailAddress = "naomi.baroghel@gmail.com", EntryDate = new DateTime(2020, 07, 15), ReleaseDate = new DateTime(2020, 08, 10), area = Area.South, subArea = SubArea.Eilat, type = BE.Type.HotelRoom, Adults = 2, Children = 2, Rooms = 2, Pool = Accord.yes, poolseparated = Accord.yes, Jacuzzi = Accord.yes, Garden = Accord.dontcare, ChildrenAttractions = Accord.yes, MealShabbat = true, kasherout = Kasherout.Rabanout, Car = true, Sea = Accord.yes, Mountain = Accord.no, BetHabbad = Accord.dontcare, Super = Accord.dontcare };
            GuestRequest newguestrequest4 = new GuestRequest { PrivateName = "Stefen", FamilyName = "Pablo", MailAddress = "naomi.baroghel@gmail.com", EntryDate = new DateTime(2020, 08, 12), ReleaseDate = new DateTime(2020, 08, 21), area = Area.Jerusalem, subArea = SubArea.Jerusalem, type = BE.Type.Apartment, Adults = 4, Rooms = 2, Pool = Accord.dontcare, poolseparated = Accord.dontcare, Jacuzzi = Accord.no, Garden = Accord.no, ChildrenAttractions = Accord.no, MealShabbat = true, kasherout = Kasherout.Rabanout, Car = false, Sea = Accord.no, Mountain = Accord.no, BetHabbad = Accord.yes, Super = Accord.dontcare };
            GuestRequest newguestrequest5 = new GuestRequest { PrivateName = "Patrick", FamilyName = "Marciano", MailAddress = "naomi.baroghel@gmail.com", EntryDate = new DateTime(2020, 03, 12), ReleaseDate = new DateTime(2020, 03, 15), area = Area.Jerusalem, subArea = SubArea.Jerusalem, type = BE.Type.HotelRoom, Adults = 1, Rooms = 1, Pool = Accord.yes, poolseparated = Accord.no, Jacuzzi = Accord.no, Garden = Accord.no, ChildrenAttractions = Accord.yes, MealShabbat = true, kasherout = Kasherout.Badatz, Car = false, Sea = Accord.no, Mountain = Accord.yes, BetHabbad = Accord.no, Super = Accord.yes };

            string mymail = "hostbookingnaoorna@gmail.com";
            //HostingUnit newhostingunit = new HostingUnit { Owner = new Host { HostKey = "12345678", PrivateName = "Ornael", FamilyName = "Aflalou", PhoneNumber = "0586301415", MailAddress = mymail, BankAccountNumber = 14732467, branch = new Branch { BankNumber = 1567, BankName = Bankname.Discount, BranchNumber = 154, BranchAddress = "290 Yafo", BranchCity = SubArea.Natanya }, CollectionClearance = true }, HostingUnitName = "Flower Suite", Rooms = 1, Beds = 2, pricePerNight = 100, area = Area.Center, subArea = SubArea.Natanya, type = BE.Type.HotelRoom, Pool = true, poolseparated = false, Jacuzzi = false, Garden = false, ChildrenAttractions = true, kasherout = Kasherout.Badatz, Sea = false, Mountain = true, BetHabbad = false, Super = true };
            //HostingUnit newhostingunit1 = new HostingUnit { Owner = new Host { HostKey = "12345678", PrivateName = "Ornael", FamilyName = "Aflalou", PhoneNumber = "0586301415", MailAddress = mymail, BankAccountNumber = 14732467, branch = new Branch { BankNumber = 1567, BankName = Bankname.Discount, BranchNumber = 154, BranchAddress = "290 Yafo", BranchCity = SubArea.Natanya }, CollectionClearance = true }, HostingUnitName = "Luxury Suite", Rooms = 1, Beds = 2, pricePerNight = 100, area = Area.Center, subArea = SubArea.Natanya, type = BE.Type.HotelRoom, Pool = true, poolseparated = true, Jacuzzi = false, Garden = false, ChildrenAttractions = false, kasherout = Kasherout.Badatz, Sea = true, Mountain = false, BetHabbad = false, Super = true };
            //HostingUnit newhostingunit2 = new HostingUnit { Owner = new Host { HostKey = "12345678", PrivateName = "Ornael", FamilyName = "Aflalou", PhoneNumber = "0586301415", MailAddress = mymail, BankAccountNumber = 14732467, branch = new Branch { BankNumber = 1567, BankName = Bankname.Discount, BranchNumber = 154, BranchAddress = "290 Yafo", BranchCity = SubArea.Natanya }, CollectionClearance = true }, HostingUnitName = "Medium Suite", Rooms = 3, Beds = 6, pricePerNight = 100, area = Area.Center, subArea = SubArea.Natanya, type = BE.Type.HotelRoom, Pool = true, poolseparated = false, Jacuzzi = false, Garden = false, ChildrenAttractions = false, kasherout = Kasherout.Rabanout, Sea = true, Mountain = false, BetHabbad = false, Super = true };
            //HostingUnit newhostingunit3 = new HostingUnit { Owner = new Host { HostKey = "87654321", PrivateName = "Itshak", FamilyName = "Marciano", PhoneNumber = "0549302254", MailAddress = mymail, BankAccountNumber = 13682685, branch = new Branch { BankNumber = 5463, BankName = Bankname.Hapoalim, BranchNumber = 138, BranchAddress = "14 Binyamin", BranchCity = SubArea.Jerusalem }, CollectionClearance = true }, HostingUnitName = "Forest", Rooms = 2, Beds = 4, pricePerNight = 100, area = Area.Jerusalem, subArea = SubArea.Jerusalem, type = BE.Type.House, Pool = false, Jacuzzi = true, Garden = false, ChildrenAttractions = false, kasherout = Kasherout.Rabanout, Sea = false, Mountain = false, BetHabbad = false, Super = false };
            //HostingUnit newhostingunit4 = new HostingUnit { Owner = new Host { HostKey = "87654321", PrivateName = "Itshak", FamilyName = "Marciano", PhoneNumber = "0549302254", MailAddress = mymail, BankAccountNumber = 13682685, branch = new Branch { BankNumber = 5463, BankName = Bankname.Hapoalim, BranchNumber = 138, BranchAddress = "14 Binyamin", BranchCity = SubArea.Jerusalem }, CollectionClearance = true }, HostingUnitName = "Snow House", Rooms = 3, Beds = 6, pricePerNight = 100, area = Area.Jerusalem, subArea = SubArea.Jerusalem, type = BE.Type.House, Pool = false, Jacuzzi = true, Garden = true, ChildrenAttractions = false, kasherout = Kasherout.Rabanout, Sea = true, Mountain = true, BetHabbad = true, Super = true };
            //HostingUnit newhostingunit5 = new HostingUnit { Owner = new Host { HostKey = "87654321", PrivateName = "Itshak", FamilyName = "Marciano", PhoneNumber = "0549302254", MailAddress = mymail, BankAccountNumber = 13682685, branch = new Branch { BankNumber = 5463, BankName = Bankname.Hapoalim, BranchNumber = 138, BranchAddress = "14 Binyamin", BranchCity = SubArea.Jerusalem }, CollectionClearance = true }, HostingUnitName = "My House", Rooms = 5, Beds = 10, pricePerNight = 100, area = Area.Jerusalem, subArea = SubArea.Jerusalem, type = BE.Type.Apartment, Pool = false, Jacuzzi = false, Garden = true, ChildrenAttractions = true, kasherout = Kasherout.Rabanout, Sea = false, Mountain = false, BetHabbad = true, Super = true };
            //HostingUnit newhostingunit6 = new HostingUnit { Owner = new Host { HostKey = "13245768", PrivateName = "Chlomo", FamilyName = "Greenberg", PhoneNumber = "0579856223", MailAddress = mymail, BankAccountNumber = 264389368, branch = new Branch { BankNumber = 8369, BankName = Bankname.Discount, BranchNumber = 234, BranchAddress = "78 Rav Ouziel", BranchCity = SubArea.Eilat }, CollectionClearance = true }, HostingUnitName = "Luxury Room", Rooms = 1, Beds = 2, pricePerNight = 100, area = Area.South, subArea = SubArea.Eilat, type = BE.Type.HotelRoom, Pool = true, poolseparated = false, Jacuzzi = true, Garden = false, ChildrenAttractions = true, kasherout = Kasherout.Rabanout, Sea = true, Mountain = false, BetHabbad = false, Super = true };
            //HostingUnit newhostingunit7 = new HostingUnit { Owner = new Host { HostKey = "13245768", PrivateName = "Chlomo", FamilyName = "Greenberg", PhoneNumber = "0579856223", MailAddress = mymail, BankAccountNumber = 264389368, branch = new Branch { BankNumber = 8369, BankName = Bankname.Discount, BranchNumber = 234, BranchAddress = "78 Rav Ouziel", BranchCity = SubArea.Eilat }, CollectionClearance = true }, HostingUnitName = "Deluxe Room", Rooms = 2, Beds = 4, pricePerNight = 100, area = Area.South, subArea = SubArea.Eilat, type = BE.Type.HotelRoom, Pool = true, poolseparated = true, Jacuzzi = false, Garden = false, ChildrenAttractions = true, kasherout = Kasherout.Rabanout, Sea = true, Mountain = false, BetHabbad = true, Super = false };
            //HostingUnit newhostingunit8 = new HostingUnit { Owner = new Host { HostKey = "13245768", PrivateName = "Chlomo", FamilyName = "Greenberg", PhoneNumber = "0579856223", MailAddress = mymail, BankAccountNumber = 264389368, branch = new Branch { BankNumber = 8369, BankName = Bankname.Discount, BranchNumber = 234, BranchAddress = "78 Rav Ouziel", BranchCity = SubArea.Eilat }, CollectionClearance = true }, HostingUnitName = "The Sea Room", Rooms = 1, Beds = 2, pricePerNight = 100, area = Area.South, subArea = SubArea.Eilat, type = BE.Type.HotelRoom, Pool = true, poolseparated = true, Jacuzzi = false, Garden = false, ChildrenAttractions = true, kasherout = Kasherout.Rabanout, Sea = true, Mountain = false, BetHabbad = true, Super = false };
            //HostingUnit newhostingunit9 = new HostingUnit { Owner = new Host { HostKey = "13245768", PrivateName = "Chlomo", FamilyName = "Greenberg", PhoneNumber = "0579856223", MailAddress = mymail, BankAccountNumber = 264389368, branch = new Branch { BankNumber = 8369, BankName = Bankname.Discount, BranchNumber = 234, BranchAddress = "78 Rav Ouziel", BranchCity = SubArea.Eilat }, CollectionClearance = true }, HostingUnitName = "Medium Room", Rooms = 3, Beds = 6, pricePerNight = 100, area = Area.South, subArea = SubArea.Eilat, type = BE.Type.HotelRoom, Pool = true, poolseparated = false, Jacuzzi = false, Garden = false, ChildrenAttractions = true, kasherout = Kasherout.Rabanout, Sea = true, Mountain = false, BetHabbad = true, Super = false };



            


            //DONE
            Console.WriteLine("AddGR");
            addGR(newguestrequest);
            addGR(newguestrequest1);
            addGR(newguestrequest2);
            addGR(newguestrequest3);
            addGR(newguestrequest4);
            addGR(newguestrequest5);

            

           // getallClient();
           // getallMailAddressForClient();

            //DONE
            Console.WriteLine("AddHU");
            //addHU(newhostingunit);
            //addHU(newhostingunit1);
            //addHU(newhostingunit2);
            //addHU(newhostingunit3);
            //addHU(newhostingunit4);
            //addHU(newhostingunit5);
            //addHU(newhostingunit6);
            //addHU(newhostingunit7);
            //addHU(newhostingunit8);
            //addHU(newhostingunit9);

           // getallHU();

            //DONE
           // removeHU(newhostingunit8);




            //DONE
            Console.WriteLine("order");
            //createOrder(newhostingunit);
            //createOrder(newhostingunit1);
            //createOrder(newhostingunit2);
            //createOrder(newhostingunit3);
            //createOrder(newhostingunit4);
            //createOrder(newhostingunit5);
            //createOrder(newhostingunit6);
            //createOrder(newhostingunit7);
            //createOrder(newhostingunit8);
            //createOrder(newhostingunit9);
            getallOrder();

           // getallHU();




            List<GuestRequest> guestrequestlist = ibl.GetAllClient();
            List<HostingUnit> hostingunitlist = ibl.GetAllHostingUnit();
            List<Order> orderlist = ibl.GetAllOrder();

            //DONE
            Console.WriteLine("update");
            foreach (Order order in orderlist)
            {
               // Order o = new Order();
               // o.OrderKey = order.OrderKey;
               // o.HostingUnitKey = order.HostingUnitKey;
               // o.GuestRequestKey = order.GuestRequestKey;
               // o.priceTotal = order.priceTotal;
               //// o.status = Status.Accepted;
                updateOrder(order,Status.Accepted);
            }

            //Console.WriteLine("refused");
            //updateOrder(o);
            //    o.status = Status.Refused;
            //    updateOrder(o);
            //    getallOrder();
            //}

            getallOrder();


            //POUR FAIRE LES UPDATES IL FAUT CREER UN NOUVEL OBJET ET RECOPIER CHAQUE SADE DANS LE NOUVEAU OU SINON CA MODIFIE DIRECTEMENT DANS LA LISTE SANS PASSER PAR LE UPDATE
            //Console.WriteLine("update hu");
            //HostingUnit hostingunit = new HostingUnit();
            //hostingunit.HostingUnitKey = newhostingunit1.HostingUnitKey;
            //hostingunit.Owner.CollectionClearance = true; //IL ARRIVE PAS JE C PAS PK
            //hostingunit.pricePerNight = 200;
            //updateHU(hostingunit);
            //getallHU();

            //DONE
            //updateGR(newguestrequest1);
            //getallClient();

            //DONE
            //Console.WriteLine("freehu");
            //freehu(new DateTime(2020, 01, 14), 5);


            //DONE
            //Console.WriteLine("Timetostay");
            //Console.WriteLine(ibl.TimeStay(new DateTime(2019, 05, 06)));
            //Console.WriteLine(ibl.TimeStay(new DateTime(2019, 05, 06), new DateTime(2019, 05, 12)));

            //DONE 
            //Console.WriteLine("timetosend");
            //timeToSendMail(0);

            //DONE
            //Console.WriteLine("match");
            //matchGuestRequest(guestrequestlist, cond1);
            //matchGuestRequest(guestrequestlist, cond2);

            // DONE
            //Console.WriteLine("numberof");
            //Console.WriteLine(ibl.NumberOfOrderForAClient(newguestrequest1));
            //Console.WriteLine(ibl.NumberOfOrderForHostingUnit(newhostingunit2));

            //DONE 
            // Console.WriteLine("groupby");
            //groupByAreaForGuestRequest();
            //groupByAreaForHostingUnit();
            //groupByKasheroutForGuestRequest();
            //groupByKasheroutForHostingUnit();
            //groupByNbOfHostingUnit();
            //groupByNbOfPeople();

            //DONE 
            //ibl.SendNewsletter();


            //DONE
            //getallMailAddressForClient();
            //getallNewHU();
            //getallRentaCar();
            //getallSaladShabbat();
            //getallBranch();
            //getallHiking();

        }

        #region basic

        static void addGR(GuestRequest GR) // +Addnewletter + saladforshabbat
        {
            ibl.AddGuestRequest(GR);
        }

        static void updateGR(GuestRequest GR,StatusGR status)
        {
            ibl.UpdateGuestRequest(GR,status);
        }
        static void addHU(HostingUnit HU)
        {
            ibl.AddHostingUnit(HU);

        }
        static void updateHU(HostingUnit HU)
        {
            ibl.UpdateHostingUnit(HU);
        }

        static void removeHU(HostingUnit HU)
        {
            ibl.RemoveHostingUnit(HU);
        }

        static void createOrder(HostingUnit HU) //+ADDORDER(+sendhiking +sendrentacar) +approve request
        {
            ibl.CreateOrder(HU);
        }

        static void updateOrder(Order order,Status status) //+approve request + update diary +contest
        {
            ibl.UpdateOrder(order, status);
        }

        #endregion


        #region list
        static void getallClient()
        {
            foreach (GuestRequest GR in ibl.GetAllClient())
                Console.WriteLine(GR.ToString());
        }
        static void getallHU()
        {
            foreach (HostingUnit HU in ibl.GetAllHostingUnit())
                Console.WriteLine(HU.ToString());
        }
        static void getallOrder()
        {
            
            foreach (Order o in ibl.GetAllOrder())
                Console.WriteLine(o.ToString());
        }
        static void getallBranch()
        {
            foreach (Branch br in ibl.GetAllBranch())
                Console.WriteLine(br.ToString());
        }
        static void getallHiking()
        {
            foreach (Hiking hg in ibl.GetAllHiking())
                Console.WriteLine(hg.ToString());
        }
        static void getallRentaCar()
        {
            foreach (RentaCar rc in ibl.GetAllRentaCar())
                Console.WriteLine(rc.ToString());
        }
        static void getallNewHU()
        {
            foreach (HostingUnit HU in ibl.GetAllNewHostingUnit())
                Console.WriteLine(HU.ToString());
        }
        static void getallMailAddressForClient()
        {
            foreach (string ma in ibl.GetAllMailAddressForClient())
                Console.WriteLine(ma.ToString());
        }
        static void getallSaladShabbat()
        {
            foreach (string salade in ibl.GetAllSaladShabbat())
                Console.WriteLine(salade.ToString());
        }

        #endregion

        #region func

        static void freehu(DateTime DT, int timestay)
        {
            List<HostingUnit> HUlist = ibl.FreeHostingUnit(DT, timestay);
            foreach (HostingUnit hu in HUlist)
            {
                Console.WriteLine(hu.ToString());
            }
        }

        static void timeToSendMail(int numberdays)
        {
            List<Order> orderlist = ibl.TimeToSendMail(numberdays);
            foreach (Order o in orderlist)
            {
                Console.WriteLine(o.ToString());
            }
        }

        static void matchGuestRequest(List<GuestRequest> guestrequest, conditionDelegate condition) //CREER DES CONDITIONS
        {
            List<GuestRequest> guestrequestlist = ibl.MatchGuestRequest(guestrequest, condition);
            foreach (GuestRequest gr in guestrequestlist)
            {
                Console.WriteLine(gr.ToString());
            }
        }

        #endregion
        #region grouping
        static void groupByAreaForGuestRequest()
        {
            IEnumerable<IGrouping<Area, GuestRequest>> igr = ibl.GroupByAreaForGuestRequest();
            foreach (var item in igr)
            {
                switch (item.Key)
                {
                    case Area.Center:
                        Console.WriteLine("Center : ");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case Area.Jerusalem:
                        Console.WriteLine("Jerusalem : ");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case Area.North:
                        Console.WriteLine("North : ");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case Area.South:
                        Console.WriteLine("South : ");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
        static void groupByNbOfPeople()
        {
            IEnumerable<IGrouping<int, GuestRequest>> igr = ibl.GroupByNbOfPeople();
            foreach (var item in igr)
            {
                switch (item.Key)
                {
                    case 1:
                        Console.WriteLine("1 person :");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case 2:
                        Console.WriteLine("2 people :");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case 3:
                        Console.WriteLine("3 people :");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case 4:
                        Console.WriteLine("4 people :");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case 5:
                        Console.WriteLine("5 people :");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case 6:
                        Console.WriteLine("6 people :");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case 7:
                        Console.WriteLine("7 people :");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case 8:
                        Console.WriteLine("8 people :");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
        static void groupByNbOfHostingUnit()
        {
            IEnumerable<IGrouping<int, Host>> igr = ibl.GroupByNbOfHostingUnit();
            foreach (var item in igr)
            {
                switch (item.Key)
                {
                    case 1:
                        Console.WriteLine("1 hosting unit :");
                        foreach (Host h in item)
                            Console.WriteLine(h.ToString());
                        break;
                    case 2:
                        Console.WriteLine("2 hosting unit : ");
                        foreach (Host h in item)
                            Console.WriteLine(h.ToString());
                        break;
                    case 3:
                        Console.WriteLine("3 hosting unit :");
                        foreach (Host h in item)
                            Console.WriteLine(h.ToString());
                        break;
                    case 4:
                        Console.WriteLine("4 hosting unit :");
                        foreach (Host h in item)
                            Console.WriteLine(h.ToString());
                        break;
                    case 5:
                        Console.WriteLine("5 hosting unit :");
                        foreach (Host h in item)
                            Console.WriteLine(h.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
        static void groupByAreaForHostingUnit()
        {
            IEnumerable<IGrouping<Area, HostingUnit>> igr = ibl.GroupByAreaForHostingUnit();
            foreach (var item in igr)
            {
                switch (item.Key)
                {
                    case Area.Center:
                        Console.WriteLine("Center : ");
                        foreach (HostingUnit hu in item)
                            Console.WriteLine(hu.ToString());
                        break;
                    case Area.Jerusalem:
                        Console.WriteLine("Jerusalem : ");
                        foreach (HostingUnit hu in item)
                            Console.WriteLine(hu.ToString());
                        break;
                    case Area.North:
                        Console.WriteLine("North : ");
                        foreach (HostingUnit hu in item)
                            Console.WriteLine(hu.ToString());
                        break;
                    case Area.South:
                        Console.WriteLine("South : ");
                        foreach (HostingUnit hu in item)
                            Console.WriteLine(hu.ToString());
                        break;
                    default:
                        break;
                }

            }
        }
        static void groupByKasheroutForHostingUnit()
        {
            IEnumerable<IGrouping<Kasherout, HostingUnit>> igr = ibl.GroupByKasheroutForHostingUnit();
            foreach (var item in igr)
            {
                switch (item.Key)
                {
                    case Kasherout.Badatz:
                        Console.WriteLine("Badatz : ");
                        foreach (HostingUnit hu in item)
                            Console.WriteLine(hu.ToString());
                        break;
                    case Kasherout.Jerusalem:
                        Console.WriteLine("Jerusalem : ");
                        foreach (HostingUnit hu in item)
                            Console.WriteLine(hu.ToString());
                        break;
                    case Kasherout.Lando:
                        Console.WriteLine("Lando : ");
                        foreach (HostingUnit hu in item)
                            Console.WriteLine(hu.ToString());
                        break;
                    case Kasherout.Mahfoud:
                        Console.WriteLine("Mahfoud : ");
                        foreach (HostingUnit hu in item)
                            Console.WriteLine(hu.ToString());
                        break;
                    case Kasherout.Rabanout:
                        Console.WriteLine("Rabanout : ");
                        foreach (HostingUnit hu in item)
                            Console.WriteLine(hu.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
        static void groupByKasheroutForGuestRequest()
        {
            IEnumerable<IGrouping<Kasherout, GuestRequest>> igr = ibl.GroupByKasheroutForGuestRequest();
            foreach (var item in igr)
            {
                switch (item.Key)
                {
                    case Kasherout.Badatz:
                        Console.WriteLine("Badatz : ");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case Kasherout.Jerusalem:
                        Console.WriteLine("Jerusalem : ");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case Kasherout.Lando:
                        Console.WriteLine("Lando : ");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case Kasherout.Mahfoud:
                        Console.WriteLine("Mahfoud : ");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    case Kasherout.Rabanout:
                        Console.WriteLine("Rabanout : ");
                        foreach (GuestRequest gr in item)
                            Console.WriteLine(gr.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region cond
        static bool cond1(GuestRequest GR) //check if the entry date is later than today
        {
            if (GR.EntryDate >= DateTime.Now)
                return true;
            return false;
        }

        static bool cond2(GuestRequest GR) //check if the guestrequest stay more than a week
        {
            if (GR.timeStay > 7)
                return true;
            return false;
        }
        #endregion

    }
}
