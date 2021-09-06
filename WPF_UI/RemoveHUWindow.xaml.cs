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
    /// Logique d'interaction pour RemoveHUWindow.xaml
    /// </summary>
    public partial class RemoveHUWindow : Window
    {
        HostingUnit HU2 = new HostingUnit();
        static IBL ibl = BLFactory.getBL();

        public RemoveHUWindow(HostingUnit hu)
        {
            InitializeComponent();
            HU2 = hu;
        }


        private void yes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HostingUnit hu2 = ibl.GetAllHostingUnit().FirstOrDefault(h => h.HostingUnitKey == HU2.HostingUnitKey);
                ibl.RemoveHostingUnit(hu2);
               // hu2 = ibl.GetAllHostingUnit().FirstOrDefault(h => h.HostingUnitKey == HU2.HostingUnitKey);

                for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
                    App.Current.Windows[intCounter].Close();
                new PrivateSpaceWindow().Show();
                App.Current.Windows[0].Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        
    }
}
