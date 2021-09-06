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

namespace WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        string mypassword = "1234";
        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            
                if (password.Password == mypassword)
                {
                    for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
                        App.Current.Windows[intCounter].Close();
                    new WMWindow().Show();
                    App.Current.Windows[0].Close();
                }
                else
            {
                MessageBox.Show("Wrong Password...         \n \n Try Again !");
            }

            
        }
    }
}
