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
    /// Logique d'interaction pour PrivateSpaceHUWindow.xaml
    /// </summary>
    public partial class PrivateSpaceHUWindow : Window
    {
        HostingUnit HU = new HostingUnit();
        public PrivateSpaceHUWindow(HostingUnit hu)
        {
            InitializeComponent();
            HU = hu;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            new PrivateSpaceWindow().Show();
            Close();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            new UpdateHUWindow(HU).ShowDialog();
            Close();
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            new OrderWindow(HU).ShowDialog();
            Close();
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            new RemoveHUWindow(HU).ShowDialog();
            
        }
    }
}
