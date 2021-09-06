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
    /// Logique d'interaction pour SaladWindow.xaml
    /// </summary>
    public partial class SaladWindow : Window
    {
        GuestRequest GR2 = new GuestRequest();

        public SaladWindow(GuestRequest gr)
        {
            InitializeComponent();
            GR2 = gr;
        }
        public SaladWindow()
        {
            InitializeComponent();
        }


        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }



        private void hatsilmayo_Checked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Add("Hatsil Mayo");
        }
        private void hatsilmayo_Unchecked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Remove("Hatsil Mayo");
        }

        private void gezer_Checked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Add("Gezer");
        }

        private void gezer_Unchecked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Remove("Gezer");
        }

        private void selek_Checked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Add("Selek");
        }
        private void selek_Unchecked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Remove("Selek");
        }

        private void makbouha_Checked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Add("Makbouha");
        }
        private void makbouha_Unchecked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Remove("Makbouha");
        }

        private void houmous_Checked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Add("Houmous");
        }
        private void houmous_Unchecked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Remove("Houmous");
        }

        private void thina_Checked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Add("Thina");
        }
        private void thina_Unchecked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Remove("Thina");
        }

        private void krouv_Checked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Add("Krouv");
        }
        private void krouv_Unchecked(object sender, RoutedEventArgs e)
        {
            GR2.saladshabbat.Remove("Krouv");
        }

        
    }
}
