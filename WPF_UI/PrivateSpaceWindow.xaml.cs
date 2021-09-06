using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour PrivateSpaceWindow.xaml
    /// </summary>
    public partial class PrivateSpaceWindow : Window
    {
        static IBL ibl = BLFactory.getBL();
        List<HostingUnit> hostingunitlist = ibl.GetAllHostingUnit();
        List<HostingUnit> huhelp = new List<HostingUnit>();
        HostingUnit hucurrent = new HostingUnit();
        HUUserControl item = new HUUserControl(new HostingUnit());
        int count = 1;
        public PrivateSpaceWindow()
        {
            InitializeComponent();
            areacombobox.ItemsSource = Enum.GetValues(typeof(Area));
            if (hostingunitlist.Count == 0)
            {
                hugrid.Children.Add(item);
            }
            else
            {
                huhelp = hostingunitlist;
                hugrid.Children.Remove(item);
                item = new HUUserControl(huhelp.First());
                hugrid.Children.Add(item);
                hucurrent = huhelp.First();
                choose.IsEnabled = true;
                if (huhelp.Count > 1)
                {
                    next.IsEnabled = true;
                }
            }

            areacombobox.SelectedIndex = -1;

        }

        private void areacombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBox_searchkey(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
           
           

        }

       public void Changed_searchkey(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChangedsearchname(object sender, TextChangedEventArgs e)
        {
           
        }

        #region enterleave
        private void searchkeyenter(object sender, EventArgs e)
        {
            if (searchkey.Text == "Search by Key...")
            {
                searchkey.Text = "";
                searchkey.Foreground = new SolidColorBrush(Colors.Black);
                searchkey.FontStyle = FontStyles.Normal;
            }
        }
        private void searchkeyleave(object sender, EventArgs e)
        {
            if (searchkey.Text == "")
            {
                searchkey.Text = "Search by Key...";
                searchkey.Foreground = new SolidColorBrush(Colors.Gray);
                searchkey.FontStyle = FontStyles.Italic;
            }

        }

        private void searchnameenter(object sender, EventArgs e)
        {
            if (searchname.Text == "Search by Name...")
            {
                searchname.Text = "";
                searchname.Foreground = new SolidColorBrush(Colors.Black);
                searchname.FontStyle = FontStyles.Normal;
            }
        }
        private void searchnameleave(object sender, EventArgs e)
        {
            if (searchname.Text == "")
            {
                searchname.Text = "Search by Name...";
                searchname.Foreground = new SolidColorBrush(Colors.Gray);
                searchname.FontStyle = FontStyles.Italic;
            }

        }

        #endregion

        #region help find
        private void findbykey(int key)
        {
            HostingUnit currenthu = hostingunitlist.FirstOrDefault(hu => hu.HostingUnitKey == key);
            if (currenthu == null)
            {
                hugrid.Children.Add(new HUUserControl(new HostingUnit()));
                choose.IsEnabled = false;
                previous.IsEnabled = false;
                next.IsEnabled = false;
                count = 1;
            }
            else
            {
                hugrid.Children.Add(new HUUserControl(currenthu));
                choose.IsEnabled = true;
                previous.IsEnabled = false;
                next.IsEnabled = false;
                count = 1;
            }

        }


        private void findbyname(string name)
        {
            huhelp = hostingunitlist.FindAll(hu => hu.HostingUnitName == name);
           
            HelpDisplay();
        }


        private void findbyarea(string area)
        {
            huhelp = hostingunitlist.FindAll(hu => hu.area.ToString() == area);
           

            HelpDisplay();
        }
        #endregion

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            new HUWindow().Show();
            Close();
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            count--;
            hugrid.Children.Remove(item);
            item = new HUUserControl(huhelp[count-1]);
            hugrid.Children.Add(new HUUserControl(huhelp[count-1]));
            hucurrent = huhelp[count-1];
            if (count == 1)
            {
                previous.IsEnabled = false;
            }
            if (count < huhelp.Count)
                next.IsEnabled = true;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            count++;
            hugrid.Children.Remove(item);
            item = new HUUserControl(huhelp[count-1]);
            hugrid.Children.Add(item);
            hucurrent = huhelp[count-1];
            if (count == huhelp.Count)
                next.IsEnabled = false;
            if (count > 1)
                previous.IsEnabled = true;


        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            new PasswordHUWindow(hucurrent).ShowDialog();
        }

        private void HelpDisplay()
        {
            if (huhelp.Count == 0)
            {
                hugrid.Children.Remove(item);
                item = new HUUserControl(new HostingUnit());
                hugrid.Children.Add(item);
                hucurrent = new HostingUnit();
                previous.IsEnabled = false;
                next.IsEnabled = false;
                choose.IsEnabled = false;
                count = 1;
                
            }
            else
            {
                hugrid.Children.Remove(item);
                item = new HUUserControl(huhelp.First());
                hugrid.Children.Add(item);
                hucurrent = huhelp.First();
                choose.IsEnabled = true;
                previous.IsEnabled = false;
                count = 1;
                if (huhelp.Count > 1)
                {
                    next.IsEnabled = true;
                }
                else
                    next.IsEnabled = false;
            }
        }

        private void okarea_Click(object sender, RoutedEventArgs e)
        {
            findbyarea(areacombobox.SelectedItem.ToString());
        }

        private void okname_Click(object sender, RoutedEventArgs e)
        {
            findbyname(searchname.Text);
        }

        private void okkey_Click(object sender, RoutedEventArgs e)
        {
            if (searchkey.Text != "")
            {
                findbykey(int.Parse(searchkey.Text));

            }
           
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            huhelp = hostingunitlist;
            HelpDisplay();
        }
    }
}
