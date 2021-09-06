using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using BE;

namespace DAL
{
    public interface IDAL 
    {
        #region Client
        /// <summary>
        /// add a new guest request
        /// </summary>
        /// <param name="GR"></param>
        
        void AddGuestRequest(GuestRequest GR);

        /// <summary>
        /// update a guest request
        /// </summary>
        /// <param name="GR"></param>

        void UpdateGuestRequest(GuestRequest GR, StatusGR status);
        #endregion

        #region HostingUnit
        /// <summary>
        /// add a new hosting unit
        /// </summary>
        /// <param name="HU"></param>

        void AddHostingUnit(HostingUnit HU);

        /// <summary>
        /// remove a hosting unit
        /// </summary>
        /// <param name="HU"></param>
        
        void RemoveHostingUnit(HostingUnit HU);
        //remove new hosting unit from new hosting unit list : for BL only
        void RemoveNEWHostingUnit(HostingUnit HU);

        /// <summary>
        /// update a hosting unit
        /// </summary>
        /// <param name="HU"></param>

        void UpdateHostingUnit(HostingUnit HU);

        #endregion

        #region Order
        /// <summary>
        /// add a new order
        /// </summary>
        /// <param name="order"></param>
        
        void AddOrder(Order order);

        /// <summary>
        /// update an order
        /// </summary>
        /// <param name="order"></param>

        void UpdateOrder(Order order, Status status);

        //add a new mail to the list of mail to send the newsletter
        void AddNewsletter(string mail);
        //add a message to the list of message in data source
        void AddMessage(Message M);
        #endregion

        #region List
        /// <summary>
        /// get the copy of list in datasource of all hosting unit
        /// </summary>
        IEnumerable<HostingUnit> GetAllHostingUnit();

        /// <summary>
        /// get the copy of list in datasource of all guest request
        /// </summary>
        IEnumerable<GuestRequest> GetAllClient();

        /// <summary>
        /// get the copy of list in datasource of all orders
        /// </summary>
        IEnumerable<Order> GetAllOrder();
        /// <summary>
        /// get the list of all branchs
        /// </summary>
        //  List<Branch> GetAllBranch();
        IEnumerable<Branch> GetAllBranch();

        //get the copy of list in datasource of all hikings
        IEnumerable<Hiking> GetAllHiking();

        //get the copy of list in datasource of all rent a car
        IEnumerable<RentaCar> GetAllRentaCar();

        //get the copy of list in datasource of all new hosting unit 
        IEnumerable<HostingUnit> GetAllNewHostingUnit();

        //get the copy of list in datasource of all mailaddress of the client
        IEnumerable<string> GetAllMailAddressForClient();

        //get the copy of list in datasource of all salad for shabbat
        IEnumerable<string> GetAllSaladShabbat();
        //get the copy of list in datasource of all the messageq
        IEnumerable<Message> GetAllMessage();
       
        #endregion

        #region get
        //get the guest request from the list in the data source
        GuestRequest GetGR(int idgr);

        //get the hosting unit from the list in the data source
        HostingUnit GetHU(int idhu);

        //get the order from the list in the data source
        Order GetOrder(int oid);
        #endregion



    }
}
