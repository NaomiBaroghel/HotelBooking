using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using BE;
using DS2;


namespace DAL 
{
     internal class DalImp : IDAL  
    {
        #region guestrequest
        

         public void AddGuestRequest(GuestRequest GR)
        {
            Configuration.GuestRequestKey++;

            GuestRequest guest = GetGR(Configuration.GuestRequestKey);

            if (guest != null)
                throw new DALException("Already exist");
            

            GR.GuestRequestKey = Configuration.GuestRequestKey;
            GR.RegistrationDate = DateTime.Now;
            DataSource.ListGuestRequest.Add(GR);
        }

        public void UpdateGuestRequest(GuestRequest GR,StatusGR status)
        {
            GuestRequest guest = GetGR(GR.GuestRequestKey);
            if (guest == null)
                throw new DALException("Doesn't exist");
            guest.status = status;
        }

        public GuestRequest GetGR(int idgr)
        {
            return DataSource.ListGuestRequest.FirstOrDefault(g => g.GuestRequestKey == idgr);
        }

        #endregion

        #region hostingunit
        public void AddHostingUnit(HostingUnit HU)
        {
            Configuration.HostingUnitKey++;
            HostingUnit hunit = GetHU(Configuration.HostingUnitKey);
            if (hunit != null)
                throw new DALException("Already exist");
            
            HU.HostingUnitKey = Configuration.HostingUnitKey;
            HU.ConstrucDiary();
            DataSource.ListHostingUnit.Add(HU);
            DataSource.ListNewHostingUnit.Add(HU); //add the hosting unit into the list of the new hosting unit for the newsletter
        }
        public void RemoveHostingUnit(HostingUnit HU)
        {
            HostingUnit hunit = GetHU(HU.HostingUnitKey);
            if (hunit == null)
                throw new DALException("Doesn't exist");
            DataSource.ListHostingUnit.Remove(HU);

            //change into new hosting unit list if needed
            HostingUnit hu = DataSource.ListNewHostingUnit.FirstOrDefault(hostingunit => hostingunit.HostingUnitKey == HU.HostingUnitKey);
            if (hu != null)
            {
                DataSource.ListNewHostingUnit.Remove(hunit);

            }
        }
        public void RemoveNEWHostingUnit(HostingUnit HU)
        {
            HostingUnit hunit = DataSource.ListNewHostingUnit.FirstOrDefault(hostingunit => hostingunit.HostingUnitKey == HU.HostingUnitKey);
            if (hunit == null)
                throw new DALException("Doesn't exist");
            DataSource.ListNewHostingUnit.Remove(HU);
        }
        public void UpdateHostingUnit(HostingUnit HU)
        {
            HostingUnit hunit = GetHU(HU.HostingUnitKey);
            if (hunit == null)
                throw new DALException("Doesn't exist");
            DataSource.ListHostingUnit.Remove(hunit);
            DataSource.ListHostingUnit.Add(HU);
            DataSource.ListHostingUnit = DataSource.ListHostingUnit.OrderBy(h => h.HostingUnitKey).ToList();

            //change into new hosting unit list if needed
            HostingUnit hu= DataSource.ListNewHostingUnit.FirstOrDefault(hostingunit => hostingunit.HostingUnitKey == HU.HostingUnitKey);
            if(hu!=null)
            {
                DataSource.ListNewHostingUnit.Remove(hunit);
                DataSource.ListNewHostingUnit.Add(HU);
                DataSource.ListNewHostingUnit = DataSource.ListNewHostingUnit.OrderBy(h => h.HostingUnitKey).ToList();
            }


        }


        public HostingUnit GetHU(int idhu)
        {
            return DataSource.ListHostingUnit.FirstOrDefault(hostingunit => hostingunit.HostingUnitKey == idhu);

           
        }

        #endregion

        #region order 
        public void AddOrder(Order order)
        {
            Configuration.OrderKey++;
            Order orderlist = GetOrder(Configuration.OrderKey);
            if (orderlist != null)
                throw new DALException("Already exist");
            order.OrderKey = Configuration.OrderKey;
            DataSource.ListOrder.Add(order);
        }
        public void UpdateOrder(Order order, Status status)
        {
            Order orderlist = GetOrder(order.OrderKey);
            if (orderlist == null)
                throw new DALException("Doesn't exist");
            orderlist.status = status; 

    }


        public Order GetOrder(int oid)
        {
            return DataSource.ListOrder.FirstOrDefault(o => o.OrderKey == oid);
        }


        public void AddNewsletter(string mail)
        {
            DataSource.ListMailAddress.Add(mail);
        }

        public void AddMessage(Message M)
        {
            Configuration.MessageKey++;

            Message message = DataSource.ListMessage.FirstOrDefault(m => m.Key == Configuration.MessageKey);
            if (message != null)
                throw new DALException("Already exist");


            M.Key = Configuration.MessageKey;
            DataSource.ListMessage.Add(M);
        }

        #endregion

        #region list
        public IEnumerable<HostingUnit> GetAllHostingUnit()
        {
            return from item in DataSource.ListHostingUnit
                    select item;
        }
        public IEnumerable<GuestRequest> GetAllClient()
        {
            return from item in DataSource.ListGuestRequest
                   select item;
        }
        public IEnumerable<Order> GetAllOrder()
        {
            return from item in DataSource.ListOrder
                   select item;
        }


        //public List<Branch> GetAllBranch()
        //{

        //    List<Branch> list = new List<Branch>() {
        //        new Branch  { BankNumber = 1567, BankName = Bankname.Discount, BranchNumber = 154, BranchAddress = "290 Yafo", BranchCity =SubArea.Natanya},
        //        new Branch { BankNumber = 5463, BankName = Bankname.Hapoalim, BranchNumber = 138, BranchAddress = "14 Binyamin", BranchCity =SubArea.Jerusalem},
        //        new Branch { BankNumber = 8369, BankName = Bankname.Discount, BranchNumber = 234, BranchAddress = "78 Rav Ouziel", BranchCity =SubArea.Eilat},
        //        new Branch  { BankNumber = 6799, BankName =Bankname.Leumi, BranchNumber = 763, BranchAddress = "35 Chapira", BranchCity =SubArea.TelAviv},
        //        new Branch  { BankNumber = 8436, BankName = Bankname.MizrahiTfahot, BranchNumber = 597, BranchAddress = "90 VaaAleumi", BranchCity =SubArea.Raanana}
        //        };

        //    return list;
        //}
        public IEnumerable<Branch> GetAllBranch()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hiking> GetAllHiking()
        {
            return from item in DataSource.ListHiking
                   select item;
        }
        public IEnumerable<HostingUnit> GetAllNewHostingUnit()
        {
            return from item in DataSource.ListNewHostingUnit
                   select item;
        }
        public IEnumerable<string> GetAllMailAddressForClient()
        {
            return from item in DataSource.ListMailAddress
                   select item;
        }
        public IEnumerable<RentaCar> GetAllRentaCar()
        {
            return from item in DataSource.ListRentaCar
                   select item;
        }

        [Obsolete]
        public IEnumerable<string> GetAllSaladShabbat()
        {
            return from item in DataSource.ListSaladShabbat
                   select item;
        }
        public IEnumerable<Message> GetAllMessage()
        {
            return from item in DataSource.ListMessage
                   select item;
        }


        //public List<HostingUnit> GetAllHostingUnit()
        //{
        //    HostingUnit[] hunit = new HostingUnit[DataSource.ListHostingUnit.Count];
        //    DataSource.ListHostingUnit.CopyTo(hunit);
        //    return hunit.ToList();
        //}
        //public List<GuestRequest> GetAllClient() 
        //{
        //    GuestRequest[] gr = new GuestRequest[DataSource.ListGuestRequest.Count];
        //    DataSource.ListGuestRequest.CopyTo(gr);
        //    return gr.ToList();
        //}
        //public List<Order> GetAllOrder()
        //{
        //    Order[] order = new Order[DataSource.ListOrder.Count];
        //    DataSource.ListOrder.CopyTo(order);
        //    return order.ToList();
        //}


        //public List<Branch> GetAllBranch()
        //{

        //    List<Branch> list = new List<Branch>() {
        //        new Branch  { BankNumber = 1567, BankName = Bankname.Discount, BranchNumber = 154, BranchAddress = "290 Yafo", BranchCity =SubArea.Natanya},
        //        new Branch { BankNumber = 5463, BankName = Bankname.Hapoalim, BranchNumber = 138, BranchAddress = "14 Binyamin", BranchCity =SubArea.Jerusalem},
        //        new Branch { BankNumber = 8369, BankName = Bankname.Discount, BranchNumber = 234, BranchAddress = "78 Rav Ouziel", BranchCity =SubArea.Eilat},
        //        new Branch  { BankNumber = 6799, BankName =Bankname.Leumi, BranchNumber = 763, BranchAddress = "35 Chapira", BranchCity =SubArea.TelAviv},
        //        new Branch  { BankNumber = 8436, BankName = Bankname.MizrahiTfahot, BranchNumber = 597, BranchAddress = "90 VaaAleumi", BranchCity =SubArea.Raanana}
        //        };

        //    return list;
        //}

        //public List<Hiking> GetAllHiking()
        //{
        //    Hiking[] hiking = new Hiking[DataSource.ListHiking.Count];
        //    DataSource.ListHiking.CopyTo(hiking);
        //    return hiking.ToList();
        //}
        //public List<HostingUnit> GetAllNewHostingUnit()
        //{
        //    HostingUnit[] hunit = new HostingUnit[DataSource.ListNewHostingUnit.Count];
        //    DataSource.ListNewHostingUnit.CopyTo(hunit);
        //    return hunit.ToList();
        //}
        //public List<MailAddress> GetAllMailAddressForClient()
        //{
        //    MailAddress[] mailaddress = new MailAddress[DataSource.ListMailAddress.Count];
        //    DataSource.ListMailAddress.CopyTo(mailaddress);
        //    return mailaddress.ToList();
        //}
        //public List<RentaCar> GetAllRentaCar()
        //{
        //    RentaCar[] rentacar = new RentaCar[DataSource.ListRentaCar.Count];
        //    DataSource.ListRentaCar.CopyTo(rentacar);
        //    return rentacar.ToList();
        //}

        //[Obsolete]
        //public List<string> GetAllSaladShabbat()
        //{
        //    string[] saladshabbat = new string[DataSource.ListSaladShabbat.Count];
        //    DataSource.ListSaladShabbat.CopyTo(saladshabbat);
        //    return saladshabbat.ToList();
        //}
        //public List<Message> GetAllMessage()
        //{
        //    Message[] messagelist = new Message[DataSource.ListMessage.Count];
        //    DataSource.ListMessage.CopyTo(messagelist);
        //    return messagelist.ToList();
        //}


        #endregion
    }


}
