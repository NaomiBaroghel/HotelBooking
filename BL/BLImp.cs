using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Net.Mail;
using DAL;
using BE;

namespace BL
{


    public delegate bool conditionDelegate(GuestRequest GR);


    internal class BLImp : Attribute, IBL
    {

        static IDAL dal = DalFactory.getDAl();

        #region GuestRequest
        public void AddGuestRequest(GuestRequest GR)
        {
            try
            {
                if (GR.timeStay < 1)
                    throw new BLException("You have to stay at least one night");
                //  SaladForShabbat(GR);
                CheckName(GR.FamilyName, GR.PrivateName);
                CheckMail(GR.MailAddress);
                dal.AddGuestRequest(GR);
                AddNewsletter(GR);
            }
            catch (DALException ex)
            {
                throw ex;
            }
        }

        public void UpdateGuestRequest(GuestRequest GR, StatusGR status)
        {
            //we assume that only the status has changed
            try
            {
                GuestRequest myguestrequest = dal.GetGR(GR.GuestRequestKey);
                if (myguestrequest.status == StatusGR.CloseBecauseItExpired || myguestrequest.status == StatusGR.CloseThrougTheSite)
                    throw new BLException("You can't update this Guest Request");

                dal.UpdateGuestRequest(GR, status);
            }
            catch (DALException ex)
            {
                throw ex;
            }

        }




        #endregion

        #region HostingUnit

        public void AddHostingUnit(HostingUnit HU)
        {
            try
            {
                List<HostingUnit> listhu = dal.GetAllHostingUnit().ToList();
                foreach (HostingUnit hu in listhu)
                    if (hu.HostingUnitName == HU.HostingUnitName && hu.Owner.HostKey == HU.Owner.HostKey)
                        throw new BLException("You can not have two Hosting Unit with the same name");
                CheckPrice(HU);
                CheckHostKey(HU);
                CheckPhoneNumber(HU);
                CheckMail(HU.Owner.MailAddress);
                CheckName(HU.Owner.FamilyName, HU.Owner.PrivateName);
                CheckPassword(HU);
                dal.AddHostingUnit(HU);

            }
            catch (DALException ex)
            {
                throw ex;
            }
        }

        public void UpdateHostingUnit(HostingUnit HU)
        {
            try
            {
                HostingUnit hu = new HostingUnit();
                List<Order> myorder = dal.GetAllOrder().ToList();

                foreach (Order o in myorder)
                {
                    hu = dal.GetHU(o.HostingUnitKey);
                    if (o.HostingUnitKey == HU.HostingUnitKey)
                    {
                        if (o.status == Status.SendMail && HU.Owner.CollectionClearance == false)
                            throw new BLException("You can't close your clearence while an order is in process");
                        if ((o.status == Status.SendMail) && HU.pricePerNight != hu.pricePerNight)
                            throw new BLException("You can't change the price per night while an order is in process");
                        if ((o.status == Status.SendMail) && HU.Owner.MailAddress != hu.Owner.MailAddress)
                            throw new BLException("You can't change the mail address while an order is in process");
                    }

                }

                dal.UpdateHostingUnit(HU);
            }
            catch (DALException ex)
            {
                throw ex;
            }

        }
        public void RemoveHostingUnit(HostingUnit HU)
        {
            try
            {
                Predicate<int> isinlist = IsInList;
                if (isinlist(HU.HostingUnitKey))
                    throw new BLException("You can't remove this Hosting Unit because it's link to an order");
                dal.RemoveHostingUnit(HU);
            }
            catch (DALException ex)
            {
                throw ex;
            }
        }



        #endregion

        #region Order
        public void AddOrder(Order order)
        {
            try
            {
                HostingUnit hostingunit = dal.GetHU(order.HostingUnitKey);
                GuestRequest guestrequest = dal.GetGR(order.GuestRequestKey);


                //If the Host agreed with the order
                order.status = Status.SendMail;
                MailMessage mail = new MailMessage();
                try
                {
                    mail.To.Add(guestrequest.MailAddress);
                }
                catch (Exception ex)
                {
                    throw new BLException("no reservation can be made with this guest request : error in email");
                }
                mail.From = new MailAddress(hostingunit.Owner.MailAddress, "Ornao Booking");
                mail.Subject = "Order Proposition";
                mail.Body = "Hi, this is the order we can present to you \n";
                mail.Body += SendHostingUnit(mail.Body, hostingunit) + "\n";
                mail.Body += SendHiking(mail.Body, guestrequest);//add the new hiking around in the proposition order
                mail.Body += SendRentaCar(mail.Body, guestrequest);//add the agency to rent a car to the proposition order
                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                string password = hostingunit.Owner.passwordMail; //GetPassword(hostingunit);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(hostingunit.Owner.MailAddress, password);
                smtp.EnableSsl = true;

                //try
                //{
                //    smtp.Send(mail);

                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}


                order.OrderDate = DateTime.Now;

                dal.AddOrder(order);
            }
            catch (DALException ex)
            {
                throw ex;
            }



        }

        public void UpdateOrder(Order order, Status status)
        {

            try
            {
                Order myorder = dal.GetOrder(order.OrderKey);


                if (myorder.status == Status.SendMail)
                {
                    HostingUnit hostingunit = dal.GetHU(order.HostingUnitKey);
                    GuestRequest guestrequest = dal.GetGR(order.GuestRequestKey);
                    if (status == Status.Accepted)
                    {
                        if (ApproveRequest(hostingunit, guestrequest) == false)
                            throw new BLException("Cannot finalise the order");
                        UpdateDiary((HostingUnit)hostingunit, guestrequest);
                        UpdateGuestRequest(guestrequest, StatusGR.CloseThrougTheSite);
                    }


                    dal.UpdateOrder(order, status);

                }
                else
                    throw new BLException("You can't update this order");
            }
            catch (DALException ex)
            {
                throw ex;
            }
        }


        #endregion

        #region help
        public void CreateOrder(HostingUnit HU)
        {
            try
            {
                List<GuestRequest> listguestrequest = dal.GetAllClient().ToList();
                foreach (GuestRequest guestrequest in listguestrequest)
                {
                    if (ApproveRequest(HU, guestrequest) == true)
                    {
                        Order order = new Order { HostingUnitKey = HU.HostingUnitKey, GuestRequestKey = guestrequest.GuestRequestKey, status = Status.Active, CreateDate = DateTime.Now, priceTotal = HU.pricePerNight * guestrequest.timeStay };
                        AddOrder(order);
                    }

                }

            }
            catch (DALException ex)
            {
                throw ex;
            }
        }
        public List<GuestRequest> CreateOrder2(HostingUnit HU)
        {
            try
            {
                List<GuestRequest> listguestrequest = dal.GetAllClient().ToList();
                List<GuestRequest> rightguestrequest = new List<GuestRequest>();
                foreach (GuestRequest guestrequest in listguestrequest)
                {
                    if (ApproveRequest(HU, guestrequest) == true && help(HU, guestrequest))
                    {

                        rightguestrequest.Add(guestrequest);
                    }

                }
                return rightguestrequest;
            }
            catch (DALException ex)
            {
                throw ex;
            }
        }
        public bool help(HostingUnit HU, GuestRequest GR)
        {

            foreach (Order order in dal.GetAllOrder())
            {
                if (order.HostingUnitKey == HU.HostingUnitKey && order.GuestRequestKey == GR.GuestRequestKey)
                    return false;
            }
            return true;
        }
        public bool CheckClearence(HostingUnit HU)
        {
            if (HU.Owner.BankAccountNumber.ToString() != "" && HU.Owner.branch.BankNumber.ToString() != "" && HU.Owner.branch.BranchAddress != "" && HU.Owner.branch.BranchNumber.ToString() != "")
                if (HU.Owner.CollectionClearance == true)
                    return true;
            return false;
        }

        public void CheckMail(string mail)
        {


            if (mail.Length == 0 || mail.Contains(" ") || !mail.Contains("@") || !mail.Contains(".") || mail == null || mail == "someone@exemple.com")
                throw new BLException("You need to enter a mail address");

        }

        public void CheckName(string family, string Private)
        {
            if (Private.Length == 0)
                throw new BLException("You need to enter your name");
            else if (family.Length == 0)
                throw new BLException("You need to enter you family name");

        }
        public void CheckHostKey(HostingUnit HU)
        {
            if (HU.Owner.HostKey.Length != 9)
                throw new BLException("You need to enter 9 numbers for you ID");
        }
        public void CheckPhoneNumber(HostingUnit HU)
        {
            if (HU.Owner.PhoneNumber.Length != 10)
                throw new BLException("You need to enter 10 numbers for you Phone Number");

        }

        public void CheckPrice(HostingUnit HU)
        {
            if ((HU.pricePerNight > 800 && HU.typemoney == Money.NIS) || (HU.pricePerNight < 50 && HU.typemoney == Money.NIS))
                throw new BLException("Price must be between 50 NIS and 800 NIS");
            if ((HU.pricePerNight > 300 && HU.typemoney == Money.Dollars) || (HU.pricePerNight < 20 && HU.typemoney == Money.Dollars))
                throw new BLException("Price must be between 20 Dollars and 300 Dollars");
            if ((HU.pricePerNight > 200 && HU.typemoney == Money.Euros) || (HU.pricePerNight > 25 && HU.typemoney == Money.Euros))
                throw new BLException("Price must be between 25 Euros and 200 Euros");
            if ((HU.pricePerNight > 250 && HU.typemoney == Money.Pounds) || (HU.pricePerNight > 30 && HU.typemoney == Money.Pounds))
                throw new BLException("Price must be between 50 Pounds and 250 Pounds");

        }

        public void CheckPassword(HostingUnit HU)
        {
            if (HU.passwordHU == null)
                throw new BLException("You need to enter a password for this Hosting Unit");
        }
        public bool ApproveRequest(HostingUnit HU, GuestRequest GR)
        {
            try
            {
                if (HU.area == GR.area && HU.subArea == GR.subArea && HU.type == GR.type && HU.Beds >= GR.People && HU.kasherout == GR.kasherout)
                    if (((GR.Pool == Accord.dontcare || GR.Pool == Accord.yes) && HU.Pool) || ((GR.Pool == Accord.dontcare || GR.Pool == Accord.no) && !HU.Pool))
                        if (((GR.poolseparated == Accord.dontcare || GR.poolseparated == Accord.yes) && HU.poolseparated) || ((GR.poolseparated == Accord.dontcare || GR.poolseparated == Accord.no) && !HU.poolseparated))
                            if (((GR.Jacuzzi == Accord.dontcare || GR.Jacuzzi == Accord.yes) && HU.Jacuzzi) || ((GR.Jacuzzi == Accord.dontcare || GR.Jacuzzi == Accord.no) && !HU.Jacuzzi))
                                if (((GR.Garden == Accord.dontcare || GR.Garden == Accord.yes) && HU.Garden) || ((GR.Garden == Accord.dontcare || GR.Garden == Accord.no) && !HU.Garden))
                                    if (((GR.ChildrenAttractions == Accord.dontcare || GR.ChildrenAttractions == Accord.yes) && HU.ChildrenAttractions) || ((GR.ChildrenAttractions == Accord.dontcare || GR.ChildrenAttractions == Accord.no) && !HU.ChildrenAttractions))
                                        if (((GR.Sea == Accord.dontcare || GR.Sea == Accord.yes) && HU.Sea) || ((GR.Sea == Accord.dontcare || GR.Sea == Accord.no) && !HU.Sea))
                                            if (((GR.Mountain == Accord.dontcare || GR.Mountain == Accord.yes) && HU.Mountain) || ((GR.Mountain == Accord.dontcare || GR.Mountain == Accord.no) && !HU.Mountain))
                                                if (((GR.BetHabbad == Accord.dontcare || GR.BetHabbad == Accord.yes) && HU.BetHabbad) || ((GR.BetHabbad == Accord.dontcare || GR.BetHabbad == Accord.no) && !HU.BetHabbad))
                                                    if (((GR.Super == Accord.dontcare || GR.Super == Accord.yes) && HU.Super) || ((GR.Super == Accord.dontcare || GR.Super == Accord.no) && !HU.Super))
                                                    {


                                                        if (GR.EntryDate < DateTime.Now)
                                                        {
                                                            UpdateGuestRequest(GR, StatusGR.CloseBecauseItExpired);
                                                            Order thisorder = dal.GetAllOrder().FirstOrDefault(o => o.GuestRequestKey == GR.GuestRequestKey && o.HostingUnitKey == HU.HostingUnitKey);
                                                            UpdateOrder(thisorder, Status.Refused);
                                                            return false;
                                                        }
                                                        if (GR.status == StatusGR.CloseThrougTheSite || GR.status == StatusGR.CloseBecauseItExpired)
                                                            return false;

                                                        DateTime MyTime = GR.EntryDate;
                                                        while (MyTime != GR.ReleaseDate)
                                                        {
                                                            if (HU.Diary[MyTime.Day, MyTime.Month] == true)
                                                            {
                                                                return false;
                                                            }

                                                            MyTime = MyTime.AddDays(1);
                                                        }


                                                        return true;
                                                    }
                return false;
            }
            catch (DALException ex)
            {
                throw ex;
            }
        }


        public void UpdateDiary(HostingUnit HU, GuestRequest GR)
        {
            DateTime MyTime = GR.EntryDate;
            while (MyTime != GR.ReleaseDate)
            {
                HU.Diary[MyTime.Day, MyTime.Month] = true;
                MyTime = MyTime.AddDays(1);
            }


        }
        [Obsolete]
        public String GetPassword(HostingUnit HU) // get the password email of the Host, and save it if the Host want to
        {
            try
            {

                if (HU.Owner.passwordMail == null)
                {
                    Console.WriteLine("We need your mail password to send the order to the client \n Please enter your password");
                    string password = Console.ReadLine();
                    Console.WriteLine("Do you want to save this password ? y/n");
                    string yn = Console.ReadLine();
                    if (yn == "y")
                    {
                        HU.Owner.passwordMail = password;
                        UpdateHostingUnit(HU);
                    }
                    return password;

                }
                return HU.Owner.passwordMail;
            }
            catch (DALException ex)
            {
                throw ex;
            }

        }

        //Predicate
        public static bool IsInList(int key)
        {
            List<Order> ListOrder = dal.GetAllOrder().ToList();
            List<GuestRequest> listguestrequest = dal.GetAllClient().ToList();
            List<Order> order = ListOrder.FindAll(x => x.HostingUnitKey == key);

            DateTime now = DateTime.Now;

            if (order.Count != 0)
            {
                foreach (Order o in order)
                {
                    if (o.status == Status.Accepted)
                    {
                        GuestRequest gr = listguestrequest.FirstOrDefault(g => g.GuestRequestKey == o.GuestRequestKey);
                        if (gr.ReleaseDate < now)
                            return true;
                    }
                    else if (o.status == Status.SendMail)
                        return true;

                }
            }

            return false;

        }

        #endregion

        #region func
        public List<HostingUnit> FreeHostingUnit(DateTime entrydate, double staytime)
        {


            try
            {
                List<HostingUnit> freehostingunit = new List<HostingUnit>();
                List<HostingUnit> hostingunit = dal.GetAllHostingUnit().ToList();
                bool flag = true;
                DateTime MyTime = entrydate;
                DateTime ReleaseDate = entrydate.AddDays(staytime);
                foreach (HostingUnit HU in hostingunit)
                {
                    while (MyTime != ReleaseDate)
                    {
                        if (HU.Diary[MyTime.Day, MyTime.Month] == true)
                        {
                            flag = false;
                        }

                        MyTime = MyTime.AddDays(1);

                    }
                    if (flag)
                    {
                        freehostingunit.Add(HU);
                    }

                    MyTime = entrydate;
                    flag = true;

                }
                return freehostingunit;

            }
            catch (DALException ex)
            {
                throw ex;
            }



        }
        public int TimeStay(params DateTime[] dates)
        {
            TimeSpan timespan = new TimeSpan();
            if (dates.Length > 1)
            {
                timespan = dates[1] - dates[0];
                return timespan.Days;
            }
            DateTime now = DateTime.Now;
            timespan = now - dates[0];
            return timespan.Days;

        }
        public List<Order> TimeToSendMail(int numberdays)
        {
            try
            {
                List<Order> rightorder = new List<Order>();

                List<Order> listorder = dal.GetAllOrder().ToList();
                var order = from o in listorder
                            let different = o.OrderDate - o.CreateDate
                            where different.Days >= numberdays
                            select o;
                rightorder = order.ToList();
                return rightorder;

            }
            catch (DALException ex)
            {
                throw ex;
            }
        }
        public List<GuestRequest> MatchGuestRequest(List<GuestRequest> guestrequest, conditionDelegate condition)
        {
            List<GuestRequest> rightguestrequest = new List<GuestRequest>();
            foreach (GuestRequest gr in guestrequest)
            {
                if (condition(gr) == true)
                {
                    rightguestrequest.Add(gr);
                }
            }
            return rightguestrequest;
        }
        public int NumberOfOrderForAClient(GuestRequest guestrequest)
        {

            try
            {
                int count = 0;
                List<Order> listorder = dal.GetAllOrder().ToList().FindAll(o => o.GuestRequestKey == guestrequest.GuestRequestKey);
                List<Order> listorder1 = listorder.FindAll(o => o.status == Status.Accepted);
                List<Order> listorder2 = listorder.FindAll(o => o.status == Status.SendMail);
                List<Order> listorder3 = listorder.FindAll(o => o.status == Status.Refused);


                count = listorder1.Count() + listorder2.Count() + listorder3.Count();
                return count;
            }
            catch (DALException ex)
            {
                throw ex;
            }

        }
        public int NumberOfOrderForHostingUnit(HostingUnit hostingunit)
        {

            try
            {
                int count = 0;
                List<Order> listorder = dal.GetAllOrder().ToList().FindAll(o => o.HostingUnitKey == hostingunit.HostingUnitKey);
                List<Order> listorder1 = listorder.FindAll(o => o.status == Status.Accepted);
                List<Order> listorder2 = listorder.FindAll(o => o.status == Status.SendMail);
                count = listorder1.Count() + listorder2.Count();
                return count;

            }
            catch (DALException ex)
            {
                throw ex;
            }
        }


        public IEnumerable<IGrouping<Area, GuestRequest>> GroupByAreaForGuestRequest()
        {
            List<GuestRequest> guestrequests = new List<GuestRequest>();
            try
            {
                guestrequests = dal.GetAllClient().ToList();
                var groupingby = from gr in guestrequests
                                 group gr by gr.area into newGroup
                                 select newGroup;
                return groupingby;

            }
            catch (DALException ex)
            {
                throw ex;
            }

        }
        public IEnumerable<IGrouping<int, GuestRequest>> GroupByNbOfPeople()
        {
            try
            {
                List<GuestRequest> guestrequests = dal.GetAllClient().ToList();
                var groupingby = from gr in guestrequests
                                 group gr by gr.People into newGroup
                                 select newGroup;
                return groupingby;

            }
            catch (DALException ex)
            {
                throw ex;
            }

        }
        public IEnumerable<IGrouping<int, Host>> GroupByNbOfHostingUnit()
        {
            try
            {

                List<HostingUnit> hostingunit = dal.GetAllHostingUnit().ToList();
                var groupingby = (from hu in hostingunit
                                  group hu.Owner by nbofHU(hu.Owner) into newGroup
                                  select newGroup).Distinct();
                groupingby = groupingby.Distinct();
                return groupingby;

            }
            catch (DALException ex)
            {
                throw ex;
            }

        }
        public int nbofHU(Host Owner)
        {
            List<HostingUnit> listhostingunit = dal.GetAllHostingUnit().ToList();
            int count = 0;
            foreach (HostingUnit hu in listhostingunit)
            {
                if (hu.Owner.HostKey == Owner.HostKey)
                    count += 1;
            }
            return count;
        }
        public IEnumerable<IGrouping<Area, HostingUnit>> GroupByAreaForHostingUnit()
        {
            try
            {
                List<HostingUnit> hostingunit = dal.GetAllHostingUnit().ToList();
                var groupingby = from hu in hostingunit
                                 group hu by hu.area into newGroup
                                 select newGroup;
                return groupingby;

            }
            catch (DALException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<IGrouping<Kasherout, HostingUnit>> GroupByKasheroutForHostingUnit()
        {
            try
            {
                List<HostingUnit> hostingunit = dal.GetAllHostingUnit().ToList();
                var groupingby = from hu in hostingunit
                                 group hu by hu.kasherout into newGroup
                                 select newGroup;
                return groupingby;

            }
            catch (DALException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<IGrouping<Kasherout, GuestRequest>> GroupByKasheroutForGuestRequest()
        {
            try
            {
                List<GuestRequest> guestrequests = dal.GetAllClient().ToList();
                var groupingby = from gr in guestrequests
                                 group gr by gr.kasherout into newGroup
                                 select newGroup;
                return groupingby;

            }
            catch (DALException ex)
            {
                throw ex;
            }

        }
        #endregion

        #region list
        public List<HostingUnit> GetAllHostingUnit()
        {
            return dal.GetAllHostingUnit().ToList();
        }
        public List<GuestRequest> GetAllClient()
        {
            return dal.GetAllClient().ToList();
        }
        public List<Order> GetAllOrder()
        {
            return dal.GetAllOrder().ToList();
        }
        //public List<Branch> GetAllBranch()
        //{
        //    return dal.GetAllBranch().ToList();
        //}
        public List<Hiking> GetAllHiking()
        {
            return dal.GetAllHiking().ToList();
        }
        public List<RentaCar> GetAllRentaCar()
        {
            return dal.GetAllRentaCar().ToList();
        }
        public List<HostingUnit> GetAllNewHostingUnit()
        {
            return dal.GetAllNewHostingUnit().ToList();
        }
        public List<string> GetAllMailAddressForClient()
        {
            return dal.GetAllMailAddressForClient().ToList();
        }
        public List<string> GetAllSaladShabbat()
        {
            return dal.GetAllSaladShabbat().ToList();
        }
        public List<Message> GetAllMessage()
        {
            return dal.GetAllMessage().ToList();
        }
        public void AddMessage(Message M)
        {
            dal.AddMessage(M);
        }
        #endregion

        #region mine
        //mine
        public string SendHostingUnit(string body, HostingUnit HU)
        {
            body += "ID :" + HU.HostingUnitKey + "\n";
            body += "Name :" + HU.HostingUnitName + "\n";
            body += "Area :" + HU.area.ToString() + "\n";
            body += "SubArea :" + HU.subArea.ToString() + "\n";
            body += "Type :" + HU.type.ToString() + "\n";
            body += "Rooms :" + HU.Rooms + "\n";
            body += "Beds :" + HU.Beds + "\n";
            body += "Price Per Night :" + HU.pricePerNight + "\n";
            body += "Kasherout :" + HU.kasherout.ToString() + "\n";

            if (HU.Pool == true)
            {
                body += "Pool \n";
                if (HU.poolseparated == true)
                    body += "Pool Separated \n";
            }
            if (HU.Jacuzzi == true)
                body += "Jacuzzi \n";
            if (HU.Garden == true)
                body += "Garden \n";
            if (HU.ChildrenAttractions == true)
                body += "ChildrenAttractions \n";
            if (HU.Sea == true)
                body += "Sea \n";
            if (HU.Mountain == true)
                body += "Mountain \n";
            if (HU.BetHabbad == true)
                body += "Bet Habbad \n";
            if (HU.Super == true)
                body += "Super";

            return body;

        }
        public string SendHiking(string body, GuestRequest GR) //to send the hiking in the area
        {
            if (GR.Hiking)
            {
                body += "here all the hiking around your area\n";
                foreach (Hiking hiking in dal.GetAllHiking().ToList())
                {
                    if (hiking.area == GR.area)
                        body += hiking.ToString() + "\n";
                }
                return body;

            }
            return "";

        }
        public string SendRentaCar(string body, GuestRequest GR) //to send the agency to rent a car in the area
        {
            if (GR.Car)
            {
                body += "Here all agency to rent a car around your area\n";
                foreach (RentaCar rc in dal.GetAllRentaCar().ToList())
                {
                    if (rc.area == GR.area)
                        body += rc.ToString() + "\n";
                }
                return body;
            }
            return "";
        }

        public void AddNewsletter(GuestRequest GR) //add a new mail for the newsletter
        {
            try
            {
                if (GR.Newsletter == true)
                {
                    string ma = dal.GetAllMailAddressForClient().ToList().FirstOrDefault(m => m == GR.MailAddress);
                    if (ma == null)
                    {
                        //MailAddress mail = new MailAddress(GR.MailAddress);
                        string mail = GR.MailAddress;
                        dal.AddNewsletter(mail);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
        //only the director of the site can send the newsletter only if one month has passed at least
        public void SendNewsletter() //send the newsletter 
        {
            while (true)
            {
                if (Configuration.watchPremier.Elapsed.Days >= 30)
                {
                    Configuration.watchPremier = Stopwatch.StartNew();

                    MailMessage mail = new MailMessage();
                    foreach (string ma in GetAllMailAddressForClient())
                    {
                        try
                        {
                            mail.To.Add(ma);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }


                    mail.From = new MailAddress("ornaobooking@gmail.com");
                    mail.Subject = "Newsletter" + DateTime.Now.ToString();
                    mail.Body = "Hi, this is the the new Hosting Unit you can find on our site : \n";
                    foreach (HostingUnit hu in dal.GetAllNewHostingUnit().ToList())
                    {
                        mail.Body = mail.Body + hu.ToString() + "\n";
                        dal.RemoveNEWHostingUnit(hu); //delete all new hosting unit
                    }



                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    string password = "ornao0612";
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("ornaobooking@gmail.com", password);
                    smtp.EnableSsl = true;

                    try
                    {
                        smtp.Send(mail);

                    }



                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            //else
            //    throw new BLException("It hasn't been a month since the last newsletter has been sent");

        }

        public int Contest()//return the id of the Host with the most order and we let him not paye the taxe
        {
            List<HostingUnit> hostingunitslit = dal.GetAllHostingUnit().ToList();
            List<Order> listorder = dal.GetAllOrder().ToList();
            int count = 0;
            int countfinal = 0;
            int id = 0;
            foreach (HostingUnit hu in hostingunitslit)
            {

                foreach (Order order in listorder)
                {

                    if (hu.HostingUnitKey == order.HostingUnitKey && order.status == Status.Accepted)
                        count += 1;

                }
                if (count > countfinal)
                {

                    countfinal = count;
                    id = hu.HostingUnitKey;

                }
                count = 0;
            }

            return id;
        }

        [Obsolete]
        public void SaladForShabbat(GuestRequest GR) // tell wich salads the guestrequest want for shabbat
        {
            if (GR.MealShabbat == true)
            {
                foreach (string salad in dal.GetAllSaladShabbat())
                {
                    Console.WriteLine(dal.GetAllSaladShabbat().ToList().Count);
                    Console.WriteLine("Do you want to eat the salad {0}", salad + "? y/n");
                    string x = Console.ReadLine();

                    if (x == "y")
                        GR.saladshabbat.Add(salad);
                    else if (x != "n" && x != "y")
                        throw new ArgumentException("just enter y or n");

                }
            }
        }
        #endregion
        #region branch

        public IEnumerable<int?> GetBranchNumbers(string BankName)
        {
            var x = from item in GetAllBranch()
                    where item.BankName == BankName
                    select item.BranchNumber;

            List<int?> mylist = x.Distinct().ToList();
            mylist.Sort();
            return mylist;


        }

        public Branch GetMyBranch(int branchnum, string bankname)
        {
            foreach (Branch item in GetAllBranch())
            {
                if ((item.BranchNumber == branchnum) && (item.BankName == bankname))
                {
                    return item;
                }
            }
            return new Branch();
        }


        public IEnumerable<string> GetBankName()
        {
            var list = from item in GetAllBranch()
                       select item.BankName;
            return list.Distinct().ToList();
        }

        public IEnumerable<Branch> GetAllBranch()
        {
            var mylist = (from item in dal.GetAllBranch()
                          orderby item.BankNumber
                          select item);
            var list = mylist.GroupBy(x => new { x.BranchNumber, x.BankNumber, x.BankName }).Select(x => x.First());
            return list;
        }
        #endregion

        public void CheckExpirationOrder()
        {
            foreach (Order order in dal.GetAllOrder().ToList())
            {
                if ((DateTime.Now - order.CreateDate).Days >= 30)
                {
                    UpdateOrder(order, Status.Refused);

                    MailMessage mail = new MailMessage();
                    mail.To.Add((GetAllClient().ToList().FirstOrDefault(g => g.GuestRequestKey == order.GuestRequestKey)).MailAddress);
                    mail.From = new MailAddress("ornaobooking@gmail.com");
                    mail.Subject = "Expiration" + DateTime.Now.ToString();
                    mail.Body = "Hi, this order is no longer available" + order.ToString();

                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    string password = "ornao0612";
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("ornaobooking@gmail.com", password);
                    smtp.EnableSsl = true;

                    try
                    {
                        smtp.Send(mail);

                    }



                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public void CheckExpirationGuestRequest()
        {
            foreach (GuestRequest gr in dal.GetAllClient().ToList())
            {
                if (gr.EntryDate < DateTime.Now)
                {
                    UpdateGuestRequest(gr, StatusGR.CloseBecauseItExpired);

                    MailMessage mail = new MailMessage();
                    mail.To.Add(gr.MailAddress);
                    mail.From = new MailAddress("ornaobooking@gmail.com");
                    mail.Subject = "Expiration" + DateTime.Now.ToString();
                    mail.Body = "Hi, this Guest Request is no longer available" + gr.ToString();

                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    string password = "ornao0612";
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("ornaobooking@gmail.com", password);
                    smtp.EnableSsl = true;

                    try
                    {
                        smtp.Send(mail);

                    }



                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }


        }
    }
}

