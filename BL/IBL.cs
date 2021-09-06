using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using BE;

namespace BL
{
    public interface IBL
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

        #endregion

        #region List
        /// <summary>
        /// get the copy of list in datasource of all hosting unit
        /// </summary>
        List<HostingUnit> GetAllHostingUnit();

        /// <summary>
        /// get the copy of list in datasource of all guest request
        /// </summary>
        List<GuestRequest> GetAllClient();

        /// <summary>
        /// get the copy of list in datasource of all orders
        /// </summary>
        List<Order> GetAllOrder();

        /// <summary>
        /// get the list of all branchs
        /// </summary>
      //  List<Branch> GetAllBranch();
        //get the copy of list in datasource of all hikings
        List<Hiking> GetAllHiking();
        //get the copy of list in datasource of all rent a car
        List<RentaCar> GetAllRentaCar();
        //get the copy of list in datasource of all new hosting unit 
        List<HostingUnit> GetAllNewHostingUnit();
        //get the copy of list in datasource of all mailaddress of the client
        List<string> GetAllMailAddressForClient();
        //get the copy of list in datasource of all salad for shabbat
        List<string> GetAllSaladShabbat();
        //get the copy of list in datasource of all message
        List<Message> GetAllMessage();
        //add a message to the list of message in data source
        void AddMessage(Message M);
        #endregion

        #region help
        //check if there's a possibility to make an order between this hosting unit and this guest request
        bool ApproveRequest(HostingUnit HU,GuestRequest GR);
        //after the order is accepted, we update the dates that the guest request wants in the diary of the hosting unit to false
        void UpdateDiary(HostingUnit HU, GuestRequest GR);
        // create orders with this hosting unit and the list of guest request in data source
        void CreateOrder(HostingUnit HU);
        //create a list with all guest request wich match the hosting unit
        List<GuestRequest> CreateOrder2(HostingUnit HU);
        //help for createorder2
        bool help(HostingUnit HU, GuestRequest GR);
        //check if the bank account is well written and if not write it again
        bool CheckClearence(HostingUnit HU);
        //check if the mail is right written
        void CheckMail(string mail);
        //check if there's is a family and private name
        void CheckName(string family, string Private);
        //check if the hostkey of the hostingunit have 9 numbers
        void CheckHostKey(HostingUnit HU);
        //check if the price is in a certain range
        void CheckPrice(HostingUnit HU);
        //check if there's 10 numbers in the phone number
        void CheckPhoneNumber(HostingUnit HU);
        void CheckPassword(HostingUnit HU);
        #endregion

        #region func
        /// <summary>
        /// return a list of hosting unit free for this time period 
        /// </summary>
        /// <param name="entrydate"></param>
        /// <param name="staytime"></param>
        List<HostingUnit> FreeHostingUnit(DateTime entrydate, double staytime);
        /// <summary>
        /// calculate the time between date1 and date2 or if there's is only one date between date1 to now 
        /// </summary>
        /// <param name="dates"></param>
        
        int TimeStay(params DateTime[] dates);

        /// <summary>
        ///return a list of order where the number of day since the creation date to the send mail date is bigger or equals the parameter numberday         
        /// </summary>
        /// <param name="numberdays"></param>
        
        List<Order> TimeToSendMail(int numberdays);

        /// <summary>
        /// return a list of guest request wich match the condition
        /// </summary>
        /// <param name="guestrequest"></param>
        /// <param name="condition"></param>
        
        List<GuestRequest> MatchGuestRequest(List<GuestRequest> guestrequest, conditionDelegate condition); //renvoie la list des guestrequest qui corresponde à la condition

        /// <summary>
        /// return the number of order created for this guest request 
        /// </summary>
        /// <param name="guestrequest"></param>
        
        int NumberOfOrderForAClient(GuestRequest guestrequest);

        /// <summary>
        /// return the number of order in process or accepted for this hosting unit 
        /// </summary>
        /// <param name="hostingunit"></param>
        
        int NumberOfOrderForHostingUnit(HostingUnit hostingunit);

        
        #endregion


        #region mine
        //check wich one of the hosting unit has the most order accepted and take away the tax
        int Contest();
        //send the properties of the HostingUnit in the mail for the order
        string SendHostingUnit(string body, HostingUnit HU);
        //if it ask in the guest request : add to the email of the order all the hiking possible in the area of the hosting unit
        string SendHiking(string body, GuestRequest GR);
        //if it ask in the guest request : add to the email of the order all the rent a car possible in the area of the hosting unit
        string SendRentaCar(string body, GuestRequest GR);
        // add the mail of the client in the list of mail for the newsletter
        void AddNewsletter(GuestRequest GR);
        //send the newsletter
        void SendNewsletter();
        //add in the guest request wich salad the client wants if he stay for shabbat
        void SaladForShabbat(GuestRequest GR);
        //get the password the host's mail, check if it already exist and ask if the host want to save into the system
         string GetPassword(HostingUnit HU);
        #endregion

        #region groupby
        /// <summary>
        /// group guest request by area
        /// </summary>
        IEnumerable<IGrouping<Area, GuestRequest>> GroupByAreaForGuestRequest();
        /// <summary>
        /// group guest request by number of people
        /// </summary>
        IEnumerable<IGrouping<int, GuestRequest>> GroupByNbOfPeople();
        /// <summary>
        /// group host by number of hosting unit
        /// </summary>
        IEnumerable<IGrouping<int, Host>> GroupByNbOfHostingUnit();

        //func help for groupbynbofhostingunit to get the number of hosting unit for one host
        int nbofHU(Host Owner);
        /// <summary>
        /// group hosting unit  by area
        /// </summary>
        IEnumerable<IGrouping<Area, HostingUnit>> GroupByAreaForHostingUnit();
        //group hosting unit by kasherout
        IEnumerable<IGrouping<Kasherout, HostingUnit>> GroupByKasheroutForHostingUnit();
        //group guest request by kasherout
        IEnumerable<IGrouping<Kasherout, GuestRequest>> GroupByKasheroutForGuestRequest();

        #endregion


        #region branch
        IEnumerable<int?> GetBranchNumbers(string BankName);
        Branch GetMyBranch(int branchnum, string bankname);
        IEnumerable<string> GetBankName();
        IEnumerable<Branch> GetAllBranch();

        #endregion

        void CheckExpirationOrder();
        void CheckExpirationGuestRequest();
    }
}
