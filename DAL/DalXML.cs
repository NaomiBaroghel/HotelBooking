using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Net.Mail;
using BE;
using DS2;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace DAL
{
    public class DalXML : IDAL
    {
        XElement ConfigurationRoot;
        XElement MessageRoot;
        XElement BranchRoot;


        string GuestRequestPath = @"GRxml.XML";
        string HostingUnitPath = @"HUxml.XML";
        string NewHostingUnitPath = @"NewHostingUnitxml.XML";
        string ConfigurationPath = @"configxml.XML";
        string CarPath = @"Carxml.XML";
        string HikingPath = @"Hikingxml.XML";
        string OrderPath = @"Orderxml.XML";
        string MessagePath = @"Messagexml.XML";
        string MailAdressPath = @"MailAdressexml.XML";
        string SaladPath = @"Saladxml.XML";

        string BranchPath = @"Branchxml.XML";

        BackgroundWorker bw = new BackgroundWorker();



        public DalXML()
        {

            if (!File.Exists(MessagePath))
                CreateFilesMessage();
            else
                LoadDataMessage();

            if (!File.Exists(ConfigurationPath))
                CreateFilesConf();
            else
                LoadDataConf();

            if (!File.Exists(GuestRequestPath))
            {

                saveListToXML(DataSource.ListGuestRequest, GuestRequestPath);

            }
            else
                DataSource.ListGuestRequest = (loadListFromXML<GuestRequest>(GuestRequestPath));

            if (!File.Exists(HostingUnitPath))
            {
                saveListToXML(DataSource.ListHostingUnit, HostingUnitPath);



            }
            else
                DataSource.ListHostingUnit = (loadListFromXML<HostingUnit>(HostingUnitPath));

            if (!File.Exists(OrderPath))
            {
                saveListToXML(DataSource.ListOrder, OrderPath);

            }
            else
                DataSource.ListOrder = (loadListFromXML<Order>(OrderPath));

            if (!File.Exists(NewHostingUnitPath))
            {
                saveListToXML(DataSource.ListNewHostingUnit, NewHostingUnitPath);

            }
            else
                DataSource.ListNewHostingUnit = (loadListFromXML<HostingUnit>(NewHostingUnitPath));

            if (!File.Exists(HikingPath))
            {
                saveListToXML(DataSource.ListHiking, HikingPath);

            }
            else
                DataSource.ListHiking = (loadListFromXML<Hiking>(HikingPath));

            if (!File.Exists(MailAdressPath))
            {
                saveListToXML(DataSource.ListMailAddress, MailAdressPath);

            }
            else
                DataSource.ListMailAddress = (loadListFromXML<string>(MailAdressPath));

            if (!File.Exists(CarPath))
            {
                saveListToXML(DataSource.ListRentaCar, CarPath);

            }
            else
                DataSource.ListRentaCar = (loadListFromXML<RentaCar>(CarPath));


            bw.DoWork += BWork;
            bw.RunWorkerAsync();


        }

        private void BWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LoadBankData();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void saveListToXML<T>(T source, string Path)
        {
            FileStream file = new FileStream(Path, FileMode.Create);
            XmlSerializer x = new XmlSerializer(source.GetType());
            x.Serialize(file, source);
            file.Close();
        }

        public static List<T> loadListFromXML<T>(string path)
        {
            if (File.Exists(path))
            {
                List<T> list;
                XmlSerializer x = new XmlSerializer(typeof(List<T>));
                FileStream file = new FileStream(path, FileMode.Open);
                list = (List<T>)x.Deserialize(file);
                file.Close();
                return list;
            }
            else return new List<T>();
        }

        private void CreateFilesMessage()
        {

            MessageRoot = new XElement("Messages");
            MessageRoot.Save(MessagePath);
        }


        private void CreateFilesConf()
        {
            XElement grkey = new XElement("GuestRequestKey", "1000000000");
            XElement hukey = new XElement("HostingUnitKey", "200000000");
            XElement orderkey = new XElement("OrderKey", "300000000");
            XElement messagekey = new XElement("MessageKey", "400000000");


            ConfigurationRoot = new XElement("Configurations", grkey, hukey, orderkey, messagekey);
            ConfigurationRoot.Save(ConfigurationPath);
        }

        private void LoadDataMessage()
        {
            try
            {
                MessageRoot = XElement.Load(MessagePath);
            }
            catch
            {
                throw new DirectoryNotFoundException("There was a problem while uploading the file");
            }
        }

        private void LoadDataConf()
        {
            try
            {
                ConfigurationRoot = XElement.Load(ConfigurationPath);
            }
            catch
            {
                throw new DirectoryNotFoundException("There was a problem while uploading the file");
            }
        }

         
        void LoadBankData()
        {
            const string xmlLocalPath = @"Branchxml.XML";
            WebClient wc = new WebClient();
            if (!File.Exists(BranchPath))
            {
                try
                {
                    string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                    wc.DownloadFile(xmlServerPath, xmlLocalPath);

                }
                catch (Exception)
                {
                    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                    wc.DownloadFile(xmlServerPath, xmlLocalPath);
                }
                finally
                {
                    wc.Dispose();
                }
            }

            BranchRoot = XElement.Load(xmlLocalPath);
        }
        private Branch ConvertBranch(XElement element)
        {
            Branch branch = new Branch();
            branch.BankName = element.Element("שם_בנק").Value;
            branch.BankNumber = int.Parse(element.Element("קוד_בנק").Value);
            branch.BranchNumber = int.Parse(element.Element("קוד_סניף").Value);
            branch.BranchAddress = element.Element("כתובת_ה-ATM").Value;
            branch.BranchCity = element.Element("ישוב").Value;
            return branch;
        }


        XElement ConvertMessage(Message mess)
        {
            XElement MessageElement = new XElement("Message");
            MessageElement.Add(new XElement("Key", mess.Key));
            MessageElement.Add(new XElement("Name", mess.Name));
            MessageElement.Add(new XElement("MailAddress", mess.MailAddress));
            MessageElement.Add(new XElement("Subject", mess.Subject));
            MessageElement.Add(new XElement("Message", mess.message));


            
            return MessageElement;
        }



        Message ConvertMessage(XElement element)
        {

            Message mess = new Message();
            mess.Key = int.Parse(element.Element("Key").Value);
            mess.Name = element.Element("Name").Value;
            mess.MailAddress = element.Element("MailAddress").Value;
            mess.Subject = element.Element("Subject").Value;
            mess.message = element.Element("Message").Value;

            return mess;

        }

        #region Guestrequest
        public void AddGuestRequest(GuestRequest GR)
        {
            LoadDataConf();
            DataSource.ListGuestRequest = loadListFromXML<GuestRequest>(GuestRequestPath);
            int key = int.Parse(ConfigurationRoot.Element("GuestRequestKey").Value);
            key++;


            GuestRequest guest = GetGR(key);

            if (guest != null)
                throw new DALException("Already exist");


            GR.GuestRequestKey = key;
            GR.RegistrationDate = DateTime.Now;
            ConfigurationRoot.Element("GuestRequestKey").Value = key.ToString();
            ConfigurationRoot.Save(ConfigurationPath);
            DataSource.ListGuestRequest.Add(GR);
            saveListToXML(DataSource.ListGuestRequest, GuestRequestPath);
        }

        public void UpdateGuestRequest(GuestRequest GR, StatusGR status)
        {
            DataSource.ListGuestRequest = loadListFromXML<GuestRequest>(GuestRequestPath);

            GuestRequest guest = GetGR(GR.GuestRequestKey);
            if (guest == null)
                throw new DALException("Doesn't exist");
            guest.status = status;
            saveListToXML(DataSource.ListGuestRequest, GuestRequestPath);
        }

        public GuestRequest GetGR(int idgr)
        {
            DataSource.ListGuestRequest = loadListFromXML<GuestRequest>(GuestRequestPath);
            return DataSource.ListGuestRequest.FirstOrDefault(g => g.GuestRequestKey == idgr);
        }

        #endregion

        #region hostingunit

        public void AddHostingUnit(HostingUnit HU)
        {
            LoadDataConf();
            DataSource.ListHostingUnit = loadListFromXML<HostingUnit>(HostingUnitPath);
            int key = int.Parse(ConfigurationRoot.Element("HostingUnitKey").Value);
            key++;
            HostingUnit hunit = GetHU(key);
            if (hunit != null)
                throw new DALException("Already exist");

            HU.HostingUnitKey = key;
            HU.ConstrucDiary();
            ConfigurationRoot.Element("HostingUnitKey").Value = key.ToString();
            ConfigurationRoot.Save(ConfigurationPath);
            DataSource.ListHostingUnit.Add(HU);
            DataSource.ListNewHostingUnit.Add(HU);//add the hosting unit into the list of the new hosting unit for the newsletter
            saveListToXML(DataSource.ListHostingUnit, HostingUnitPath);
            saveListToXML(DataSource.ListNewHostingUnit, NewHostingUnitPath);


        }

        public void RemoveHostingUnit(HostingUnit HU)
        {
            DataSource.ListHostingUnit = loadListFromXML<HostingUnit>(HostingUnitPath);

            HostingUnit hunit = GetHU(HU.HostingUnitKey);
            if (hunit == null)
                throw new DALException("Doesn't exist");
            
                if (!DataSource.ListHostingUnit.Remove(hunit))
                    throw new DALException("dont want to remove");
           
            DataSource.ListHostingUnit.Remove(HU);
            saveListToXML(DataSource.ListHostingUnit, HostingUnitPath);

            //change into new hosting unit list if needed
            HostingUnit hu = DataSource.ListNewHostingUnit.FirstOrDefault(hostingunit => hostingunit.HostingUnitKey == HU.HostingUnitKey);
            if (hu != null)
            {
                DataSource.ListNewHostingUnit.Remove(hu);
                saveListToXML(DataSource.ListNewHostingUnit, NewHostingUnitPath);

            }
        }

        public void RemoveNEWHostingUnit(HostingUnit HU)
        {
            DataSource.ListNewHostingUnit = loadListFromXML<HostingUnit>(NewHostingUnitPath);

            HostingUnit hunit = DataSource.ListNewHostingUnit.FirstOrDefault(hostingunit => hostingunit.HostingUnitKey == HU.HostingUnitKey);
            if (hunit == null)
                throw new DALException("Doesn't exist");
            DataSource.ListNewHostingUnit.Remove(hunit);
            saveListToXML(DataSource.ListNewHostingUnit, NewHostingUnitPath);


        }

        public void UpdateHostingUnit(HostingUnit HU)
        {

            DataSource.ListHostingUnit = loadListFromXML<HostingUnit>(HostingUnitPath);
            DataSource.ListNewHostingUnit = loadListFromXML<HostingUnit>(NewHostingUnitPath);

            HostingUnit hunit = GetHU(HU.HostingUnitKey);
            if (hunit == null)
                throw new DALException("Doesn't exist");
            DataSource.ListHostingUnit.Remove(hunit);
            DataSource.ListHostingUnit.Add(HU);
            DataSource.ListHostingUnit = DataSource.ListHostingUnit.OrderBy(h => h.HostingUnitKey).ToList();
            saveListToXML(DataSource.ListHostingUnit, HostingUnitPath);

            //change into new hosting unit list if needed
            HostingUnit hu = DataSource.ListNewHostingUnit.FirstOrDefault(hostingunit => hostingunit.HostingUnitKey == HU.HostingUnitKey);
            if (hu != null)
            {
                DataSource.ListNewHostingUnit.Remove(hunit);
                DataSource.ListNewHostingUnit.Add(HU);
                DataSource.ListNewHostingUnit = DataSource.ListNewHostingUnit.OrderBy(h => h.HostingUnitKey).ToList();
                saveListToXML(DataSource.ListNewHostingUnit, NewHostingUnitPath);

            }

        }


        public HostingUnit GetHU(int idhu)
        {
            DataSource.ListHostingUnit = loadListFromXML<HostingUnit>(HostingUnitPath);

            return DataSource.ListHostingUnit.FirstOrDefault(hostingunit => hostingunit.HostingUnitKey == idhu);


        }

        #endregion

        #region order
        public void AddOrder(Order order)
        {
            LoadDataConf();
            DataSource.ListOrder = loadListFromXML<Order>(OrderPath);
            int key = int.Parse(ConfigurationRoot.Element("OrderKey").Value);
            key++;

            Order orderlist = GetOrder(key);
            if (orderlist != null)
                throw new DALException("Already exist");
            order.OrderKey = key;
            DataSource.ListOrder.Add(order);
            ConfigurationRoot.Element("OrderKey").Value = key.ToString();
            ConfigurationRoot.Save(ConfigurationPath);
            saveListToXML(DataSource.ListOrder, OrderPath);


        }
        public void UpdateOrder(Order order, Status status)
        {
            DataSource.ListOrder = loadListFromXML<Order>(OrderPath);

            Order orderlist = GetOrder(order.OrderKey);
            if (orderlist == null)
                throw new DALException("Doesn't exist");
            orderlist.status = status;
            saveListToXML(DataSource.ListOrder, OrderPath);


        }


        public Order GetOrder(int oid)
        {
            DataSource.ListOrder = loadListFromXML<Order>(OrderPath);

            return DataSource.ListOrder.FirstOrDefault(o => o.OrderKey == oid);
        }
        #endregion

        #region func 
        public void AddMessage(Message M)
        {
            LoadDataConf();
            LoadDataMessage();
            int key = int.Parse(ConfigurationRoot.Element("MessageKey").Value);
            key++;

            Message message = DataSource.ListMessage.FirstOrDefault(m => m.Key == key);
            if (message != null)
                throw new DALException("Already exist");


            M.Key = key;
            ConfigurationRoot.Element("MessageKey").Value = key.ToString();
            ConfigurationRoot.Save(ConfigurationPath);
            MessageRoot.Add(ConvertMessage(M));
            MessageRoot.Save(MessagePath);
        }

        public void AddNewsletter(string mail)
        {
            DataSource.ListMailAddress = loadListFromXML<string>(MailAdressPath);

            DataSource.ListMailAddress.Add(mail);
            saveListToXML(DataSource.ListMailAddress, MailAdressPath);


        }
        #endregion

        #region list
        public IEnumerable<Message> GetAllMessage()
        {
            return from item in MessageRoot.Elements()
                   select ConvertMessage(item);
        }
        public IEnumerable<GuestRequest> GetAllClient()
        {
            DataSource.ListGuestRequest = loadListFromXML<GuestRequest>(GuestRequestPath);
            var v = from item in DataSource.ListGuestRequest
                    select item;
            return v.AsEnumerable();
        }
        public IEnumerable<HostingUnit> GetAllHostingUnit()
        {
            DataSource.ListHostingUnit = loadListFromXML<HostingUnit>(HostingUnitPath);
            var v = from item in DataSource.ListHostingUnit
                    select item;
            return v.AsEnumerable();
        }

        public IEnumerable<Order> GetAllOrder()
        {
            DataSource.ListOrder = loadListFromXML<Order>(OrderPath);
            var v = from item in DataSource.ListOrder
                    select item;
            return v.AsEnumerable();
        }

        public IEnumerable<Branch> GetAllBranch()
        {
            try
            {
                if (BranchRoot == null)
                {
                    throw new InvalidOperationException("List is charging");

                }
                var x = (from item in BranchRoot.Elements()
                         select ConvertBranch(item));
                return x;
            }
            catch (Exception ex)
            {

                throw ex;
            }

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

        public IEnumerable<Hiking> GetAllHiking()
        {
            DataSource.ListHiking = loadListFromXML<Hiking>(HikingPath);
            var v = from item in DataSource.ListHiking
                    select item;
            return v.AsEnumerable();
        }
        public IEnumerable<HostingUnit> GetAllNewHostingUnit()
        {
            DataSource.ListNewHostingUnit = loadListFromXML<HostingUnit>(NewHostingUnitPath);
            var v = from item in DataSource.ListNewHostingUnit
                    select item;
            return v.AsEnumerable();
        }
        public IEnumerable<string> GetAllMailAddressForClient()
        {
            DataSource.ListMailAddress = loadListFromXML<string>(MailAdressPath);
            var v = from item in DataSource.ListMailAddress
                    select item;
            return v.AsEnumerable();
        }
        public IEnumerable<RentaCar> GetAllRentaCar()
        {
            DataSource.ListRentaCar = loadListFromXML<RentaCar>(CarPath);
            var v = from item in DataSource.ListRentaCar
                    select item;
            return v.AsEnumerable();
        }

        [Obsolete]
        public IEnumerable<string> GetAllSaladShabbat()
        {
            DataSource.ListSaladShabbat = loadListFromXML<string>(SaladPath);
            var v = from item in DataSource.ListSaladShabbat
                    select item;
            return v.AsEnumerable();
        }


        const string xmlLocalPath = @"atm.xml";
        WebClient wc = new WebClient();
        private void func()
        {
            try
            {
                string xmlServerPath =
               @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                wc.DownloadFile(xmlServerPath, xmlLocalPath);
            }
            catch (Exception)
            {
                string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                wc.DownloadFile(xmlServerPath, xmlLocalPath);
            }
            finally
            {
                wc.Dispose();
            }
        }



        #endregion










    }

}
