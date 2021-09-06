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
    /// Logique d'interaction pour HUWindow.xaml
    /// </summary>
    public partial class HUWindow : Window
    {
        public HUWindow()
        {
            InitializeComponent();
            
        }

        private void addhostingunit_Click(object sender, RoutedEventArgs e)
        {
            new AddHUWindow().Show();
            Close();
        }

        private void privatearea_Click(object sender, RoutedEventArgs e)
        {
            new PrivateSpaceWindow().Show();
            Close();
        }

         private void cancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
