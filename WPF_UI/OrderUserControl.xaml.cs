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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour OrderUserControl.xaml
    /// </summary>
    public partial class OrderUserControl : UserControl
    {
        public OrderUserControl(HostingUnit HU, GuestRequest GR)
        {
            InitializeComponent();
            hugrid.Children.Add(new HUUserControl(HU));
            grgrid.Children.Add(new GRUserControl(GR));
        }
        public OrderUserControl()
        {
            InitializeComponent();
        }
    }
}
