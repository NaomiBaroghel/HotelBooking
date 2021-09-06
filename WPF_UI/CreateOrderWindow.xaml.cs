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
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        static IBL ibl = BLFactory.getBL();

        HostingUnit HU1 = new HostingUnit();
        Order myorder = new Order();
        List<GuestRequest> grhelp = new List<GuestRequest>();
        GuestRequest currentgr = new GuestRequest();
        GRUserControl item = new GRUserControl(new GuestRequest());
        int count = 1;

        public CreateOrderWindow(HostingUnit hu)
        {
            InitializeComponent();
            HU1 = hu;
            myorder.HostingUnitKey = hu.HostingUnitKey;
            grhelp = ibl.CreateOrder2(hu);

            if (grhelp.Count == 0)
            {
                grgrid.Children.Add(item);
                createorder.IsEnabled = false;
            }
            else
            {

                grgrid.Children.Remove(item);
                item = new GRUserControl(grhelp.First());
                grgrid.Children.Add(item);
                currentgr = grhelp.First();
                createorder.IsEnabled = true;
                if (grhelp.Count > 1)
                {
                    next.IsEnabled = true;
                }
            }

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            new OrderWindow(HU1).Show();
            Close();
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            count--;
            grgrid.Children.Remove(item);
            item = new GRUserControl(grhelp[count - 1]);
            grgrid.Children.Add(item);
            currentgr = grhelp[count - 1];
            if (count == 1)
            {
                previous.IsEnabled = false;
            }
            if (count < grhelp.Count)
                next.IsEnabled = true;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            count++;
            grgrid.Children.Remove(item);
            item = new GRUserControl(grhelp[count - 1]);
            grgrid.Children.Add(item);
            currentgr = grhelp[count - 1];
            if (count == grhelp.Count)
                next.IsEnabled = false;
            if (count > 1)
                previous.IsEnabled = true;

        }

        private void createorder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                if (ibl.ApproveRequest(HU1, currentgr) == false)
                    MessageBox.Show("You can't choose this Guest Request : \r\n Either it's no longer valid, either you already have an order like this");
                else
                {
                    myorder.HostingUnitKey = HU1.HostingUnitKey;
                    myorder.GuestRequestKey = currentgr.GuestRequestKey;
                    myorder.priceTotal = currentgr.timeStay * HU1.pricePerNight;
                    new ChoiceWindow3(myorder, HU1).ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
