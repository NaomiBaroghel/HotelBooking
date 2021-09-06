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
    /// Logique d'interaction pour UpdateOrderWindow.xaml
    /// </summary>
    public partial class UpdateOrderWindow : Window
    {
        static IBL ibl = BLFactory.getBL();

        HostingUnit myhu = new HostingUnit();
        List<Order> ohelp = new List<Order>();
        Order currento = new Order();
        OrderUserControl item = new OrderUserControl();
        int count = 1;
        public UpdateOrderWindow(HostingUnit HU)
        {
            InitializeComponent();
            myhu = HU;
            ohelp = ibl.GetAllOrder().FindAll(o => o.HostingUnitKey == HU.HostingUnitKey);


            if (ohelp.Count == 0)
            {
                ogrid.Children.Add(item);
            }
            else
            {

                ogrid.Children.Remove(item);
                currento = ohelp.First();
                HostingUnit hu = ibl.GetAllHostingUnit().FirstOrDefault(h => h.HostingUnitKey == currento.HostingUnitKey);
                GuestRequest gr = ibl.GetAllClient().FirstOrDefault(g => g.GuestRequestKey == currento.GuestRequestKey);
                item = new OrderUserControl(hu,gr);
                ogrid.Children.Add(item);
                update.IsEnabled = true;
                if (ohelp.Count > 1)
                {
                    next.IsEnabled = true;
                }
            }
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            count--;
            ogrid.Children.Remove(item);
            currento = ohelp[count - 1];
            HostingUnit hu = ibl.GetAllHostingUnit().FirstOrDefault(h => h.HostingUnitKey == currento.HostingUnitKey);
            GuestRequest gr = ibl.GetAllClient().FirstOrDefault(g => g.GuestRequestKey == currento.GuestRequestKey);
            item = new OrderUserControl(hu,gr);
            ogrid.Children.Add(item);
            if (count == 1)
            {
                previous.IsEnabled = false;
            }
            if (count < ohelp.Count)
                next.IsEnabled = true;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            count++;
            ogrid.Children.Remove(item); 
            currento = ohelp[count - 1];
            HostingUnit hu = ibl.GetAllHostingUnit().FirstOrDefault(h => h.HostingUnitKey == currento.HostingUnitKey);
            GuestRequest gr = ibl.GetAllClient().FirstOrDefault(g => g.GuestRequestKey == currento.GuestRequestKey);
            item = new OrderUserControl(hu, gr);
            ogrid.Children.Add(item);
            if (count == ohelp.Count)
                next.IsEnabled = false;
            if (count > 1)
                previous.IsEnabled = true;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            new ChoiceWindow4(currento).ShowDialog();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            new OrderWindow(myhu).Show();
            Close();
        }
    }
}
