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
    /// Logique d'interaction pour PasswordMailWindow.xaml
    /// </summary>
    public partial class PasswordMailWindow : Window
    {
        HostingUnit HU3 = new HostingUnit();
        public bool flag = false;
        public PasswordMailWindow(HostingUnit HU)
        {
            InitializeComponent();
            HU3 = HU;
        }
        public PasswordMailWindow()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void password_Changed(object sender, RoutedEventArgs e)
        {
            //if (password.Password != "")
            //{
            //    keeppassword.IsEnabled = true;
            //}
            //else
                keeppassword.IsEnabled = true;
        }

        private void keeppassword_Checked(object sender, RoutedEventArgs e)
        {
            flag = true;
        }
        private void keeppassword_Unchecked(object sender, RoutedEventArgs e)
        {
            flag = false;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            HU3.Owner.passwordMail = password.Password;
            Close();
        }
    }
}
