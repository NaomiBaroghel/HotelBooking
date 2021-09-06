using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour ChoiceWindow4.xaml
    /// </summary>
    public partial class ChoiceWindow4 : Window
    {
        static IBL ibl = BLFactory.getBL();
        Order myorder = new Order();
        Thread thr ;
        Status status;
        HostingUnit hu = new HostingUnit();
        GuestRequest gr = new GuestRequest();
        public ChoiceWindow4(Order order)
        {
            InitializeComponent();
            myorder = order;
             hu = ibl.GetAllHostingUnit().FirstOrDefault(h => h.HostingUnitKey == myorder.HostingUnitKey);
             gr = ibl.GetAllClient().FirstOrDefault(g => g.GuestRequestKey == myorder.GuestRequestKey);

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void refused_Click(object sender, RoutedEventArgs e)
        {
            status = Status.Refused;
            thr = new Thread(updateacceptedrefused);
            thr.Start();
            while(thr.IsAlive)
            { }
            Close();
        }

        private void accepted_Click(object sender, RoutedEventArgs e)
        {
            status = Status.Accepted;
            thr = new Thread(updateacceptedrefused);
            thr.Start();
            while(thr.IsAlive)
            { }
            Close();
        }

        public void updateacceptedrefused()
        {
            try
            {
                Thread thr2 = new Thread(CheckBA);
                thr2.SetApartmentState(ApartmentState.STA);
            thr2.Start();
            thr2.Join();

            ibl.UpdateOrder(myorder, status);
                MessageBox.Show("Update with success !");
                if (hu.HostingUnitKey != ibl.Contest()) //wich means that this new order is already count in the Contest
                {
                    int taxe = 10 * gr.timeStay;
                    MessageBox.Show("Your need to pay " + taxe.ToString() + "NIS");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }



       public void CheckBA()
        {
            HostingUnit hu = ibl.GetAllHostingUnit().FirstOrDefault(h => h.HostingUnitKey == myorder.HostingUnitKey);

            if (ibl.CheckClearence(hu) == false)
            {
                new CheckBankAccountWindow(hu).ShowDialog();
            }

        }
    }
}
