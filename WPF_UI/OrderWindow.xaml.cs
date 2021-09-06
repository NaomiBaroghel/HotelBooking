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
    /// Logique d'interaction pour OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        HostingUnit myhu = new HostingUnit();
        public OrderWindow(HostingUnit HU)
        {
            InitializeComponent();
            myhu = HU;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            new PrivateSpaceHUWindow(myhu).Show();
            Close();
        }

        private void createorder_Click(object sender, RoutedEventArgs e)
        {
            new CreateOrderWindow(myhu).Show();
            Close();
        }

        private void updateorder_Click(object sender, RoutedEventArgs e)
        {
            new UpdateOrderWindow(myhu).Show();
            Close();
        }
    }
}
