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
    /// Logique d'interaction pour WMWindow.xaml
    /// </summary>
    public partial class WMWindow : Window
    {
        static IBL ibl = BLFactory.getBL();
        public WMWindow()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void showgr_Click(object sender, RoutedEventArgs e)
        {
            if(areagr.IsChecked==true)
            {
                 LinqUserControl gruc = new LinqUserControl();
                gruc.Source = ibl.GroupByAreaForGuestRequest();
                page.Content = gruc;
                
            }
            if(peoplegr.IsChecked==true)
            {
                LinqUserControl gruc = new LinqUserControl();
                gruc.Source = ibl.GroupByNbOfPeople();
                page.Content = gruc;
            }
            if (kasheroutgr.IsChecked == true)
            {
                LinqUserControl gruc = new LinqUserControl();
                gruc.Source = ibl.GroupByKasheroutForGuestRequest();
                page.Content = gruc;
            }
        }

        private void showhu_Click(object sender, RoutedEventArgs e)
        {
            if (areahu.IsChecked == true)
            {
                LinqUserControl huuc = new LinqUserControl();
                huuc.Source = ibl.GroupByAreaForHostingUnit();
                page2.Content = huuc;

            }
            if (kasheroutgr.IsChecked == true)
            {
                LinqUserControl huuc = new LinqUserControl();
                huuc.Source = ibl.GroupByKasheroutForHostingUnit();
                page2.Content = huuc;
            }
        }

        private void showhost_Click(object sender, RoutedEventArgs e)
        {
            
                LinqUserControl hostuc = new LinqUserControl();
                hostuc.Source = ibl.GroupByNbOfHostingUnit();
            //foreach ( Host host in hostuc.Source)
            //{
            //    if(host.HostKey)
            //}
                page3.Content = hostuc;
            
        }



        private void areagr_Checked(object sender, RoutedEventArgs e)
        {
            areagr.IsChecked = true;
            peoplegr.IsChecked = false;
            kasheroutgr.IsChecked = false;
        }
        private void areagr_Unchecked(object sender, RoutedEventArgs e)
        {
            areagr.IsChecked = false;
            peoplegr.IsChecked = false;
            kasheroutgr.IsChecked = false;
        }
        private void peoplegr_Checked(object sender, RoutedEventArgs e)
        {
            areagr.IsChecked = false;
            peoplegr.IsChecked = true;
            kasheroutgr.IsChecked = false;
        }
        private void peoplegr_Unchecked(object sender, RoutedEventArgs e)
        {
            areagr.IsChecked = false;
            peoplegr.IsChecked = false;
            kasheroutgr.IsChecked = false;
        }

        private void kasheroutgr_Checked(object sender, RoutedEventArgs e)
        {
            areagr.IsChecked = false;
            peoplegr.IsChecked = false;
            kasheroutgr.IsChecked=true;
        }
        private void kasheroutgr_Unchecked(object sender, RoutedEventArgs e)
        {
            areagr.IsChecked = false;
            peoplegr.IsChecked = false;
            kasheroutgr.IsChecked = false;
        }

        private void areahu_Checked(object sender, RoutedEventArgs e)
        {
            areahu.IsChecked = true;
            kasherouthu.IsChecked = false;
        }
        private void areahu_Unchecked(object sender, RoutedEventArgs e)
        {
            areahu.IsChecked = false;
            kasherouthu.IsChecked = false;
        }

        private void kasherouthu_Checked(object sender, RoutedEventArgs e)
        {
            areahu.IsChecked = false;
            kasherouthu.IsChecked = true;
        }
        private void kasherouthu_Unchecked(object sender, RoutedEventArgs e)
        {
            areahu.IsChecked = false;
            kasherouthu.IsChecked = false;
        }

        
    }
}
