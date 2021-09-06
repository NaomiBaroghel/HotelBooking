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
using System.Text.RegularExpressions;
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour AddHUWindow.xaml
    /// </summary>
    public partial class AddHUWindow : Window
    {


        public HostingUnit HU1 = new HostingUnit();

        HostWindow hostwindow = new HostWindow();
        ImageWindow imagewindow = new ImageWindow();
        VideoWindow videowindow = new VideoWindow();

        int Rooms = 1;
        int Beds = 1;
        public AddHUWindow()
        {

            InitializeComponent();
            HU1 = new HostingUnit();
            moneycombobox.ItemsSource = Enum.GetValues(typeof(Money));

            areacombobox.ItemsSource = Enum.GetValues(typeof(Area));

            HelpSubArea();

            typecombobox.ItemsSource = Enum.GetValues(typeof(BE.Type));
            kasheroutcombobox.ItemsSource = Enum.GetValues(typeof(Kasherout));
            HU1.Rooms = 1;
            HU1.Beds = 1;

        }

        private void next_Click(object sender, RoutedEventArgs e)
        {

            
            addtoHU1();

            if (hostwindow.Visibility == Visibility.Hidden)
                hostwindow.Show();
            else
            {
                hostwindow = new HostWindow(HU1);
                hostwindow.ShowDialog();
            }


        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
                App.Current.Windows[intCounter].Close();
            new HUWindow().Show();
            App.Current.Windows[0].Close();
        }





        private void TextAllow(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            HelpDisplayNext();


        }
        private void TextBox_TextChangedName(object sender, TextChangedEventArgs e)
        {
           // HU1.HostingUnitName = name.Text;
            HelpDisplayNext();
        }

        private void randomname_Click(object sender, RoutedEventArgs e)
        {
            name.Text = GenerateName();
            name.FontStyle = FontStyles.Normal;
            name.Foreground = new SolidColorBrush(Colors.Black);

        }
        private void password_Changed(object sender, RoutedEventArgs e)
        {
           // HU1.Owner.passwordHU = password.Password;
            HelpDisplayNext();
        }

        private void image_Click(object sender, RoutedEventArgs e)
        {
            if (imagewindow.Visibility == Visibility.Hidden)
                imagewindow.Show();
            else
            {
                imagewindow = new ImageWindow(HU1);
                imagewindow.ShowDialog();
            }
        }
        private void video_Click(object sender, RoutedEventArgs e)
        {
            if (videowindow.Visibility == Visibility.Hidden)
                videowindow.Show();
            else
            {
                videowindow = new VideoWindow(HU1);
                videowindow.ShowDialog();
            }
        }




        #region combobox

        private void moneycombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // addmoneytoHU1();

        }

        private void areacombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HelpSubArea();
            //addareatoHU1();

        }
        private void subareacombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //addSubareatoHU1();

        }

        private void typecombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //addtypetoHU1();

        }

        private void kasheroutcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  addkasherouttoHU1();

        }


        #endregion


        #region +-
        private void roomsless_Click(object sender, RoutedEventArgs e)
        {
            if (Rooms > 1)
            {
                Rooms -= 1;
                roomscounter.Text = Rooms.ToString();
            }
           // HU1.Rooms = Rooms;
        }

        private void roomsplus_Click(object sender, RoutedEventArgs e)
        {
            Rooms += 1;
            roomscounter.Text = Rooms.ToString();
           // HU1.Rooms = Rooms;
        }

        private void bedsplus_Click(object sender, RoutedEventArgs e)
        {
            Beds += 1;
            bedscounter.Text = Beds.ToString();
           // HU1.Beds = Beds;
        }

        private void bedsless_Click(object sender, RoutedEventArgs e)
        {

            if (Beds > 1)
            {
                Beds -= 1;
                bedscounter.Text = Beds.ToString();
            }
          //  HU1.Beds = Beds;
        }
        #endregion
        #region check

        private void CheckBox_Pool(object sender, RoutedEventArgs e)
        {
            poolseparated.IsEnabled = true;
            HU1.Pool = true;
        }
        private void UncheckBox_Pool(object sender, RoutedEventArgs e)
        {
            poolseparated.IsEnabled = false;
            HU1.Pool = false;
        }



        private void CheckBox_PoolSeparated(object sender, RoutedEventArgs e)
        {
            HU1.poolseparated = true;
        }
        private void UncheckBox_PoolSeparated(object sender, RoutedEventArgs e)
        {
            HU1.poolseparated = false;
        }

        private void CheckBox_Jaccuzi(object sender, RoutedEventArgs e)
        {
            HU1.Jacuzzi = true;
        }
        private void UncheckBox_Jaccuzi(object sender, RoutedEventArgs e)
        {
            HU1.Jacuzzi = false;
        }


        private void CheckBox_Garden(object sender, RoutedEventArgs e)
        {
            HU1.Garden = true;
        }
        private void UncheckBox_Garden(object sender, RoutedEventArgs e)
        {
            HU1.Garden = false;
        }
        private void CheckBox_ChildrenAttraction(object sender, RoutedEventArgs e)
        {
            HU1.ChildrenAttractions = true;
        }
        private void UncheckBox_ChildrenAttraction(object sender, RoutedEventArgs e)
        {
            HU1.ChildrenAttractions = false;
        }



        private void CheckBox_Sea(object sender, RoutedEventArgs e)
        {
            HU1.Sea = true;
        }
        private void UncheckBox_Sea(object sender, RoutedEventArgs e)
        {
            HU1.Sea = false;
        }

        private void CheckBox_Mountain(object sender, RoutedEventArgs e)
        {
            HU1.Mountain = true;
        }
        private void UncheckBox_Mountain(object sender, RoutedEventArgs e)
        {
            HU1.Mountain = false;
        }

        private void CheckBox_BetHabbad(object sender, RoutedEventArgs e)
        {
            HU1.BetHabbad = true;
        }
        private void UncheckBox_BetHabbad(object sender, RoutedEventArgs e)
        {
            HU1.BetHabbad = false;
        }

        private void CheckBox_Super(object sender, RoutedEventArgs e)
        {
            HU1.Super = true;
        }
        private void UncheckBox_Super(object sender, RoutedEventArgs e)
        {
            HU1.Super = false;
        }
        #endregion

        #region help
        private void HelpSubArea()
        {
            switch (areacombobox.SelectedItem.ToString())
            {
                case "Center":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaC));
                    subareacombobox.SelectedIndex = 0;
                    break;
                case "North":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaN));
                    subareacombobox.SelectedIndex = 0;
                    break;
                case "South":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaS));
                    subareacombobox.SelectedIndex = 0;
                    break;
                case "Jerusalem":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaJ));
                    subareacombobox.SelectedIndex = 0;
                    break;
                default:
                    break;

            }


        }

        private void HelpDisplayNext()
        {
            if (name.Text != "Name is..." && name.Text != "")
                if (price.Text != "Price is..." && price.Text != "")
                    if (password.Password != "")
                    {
                        next.IsEnabled = true;
                        return;
                    }

            next.IsEnabled = false;

        }

        public static string GenerateName()
        {
            Random r = new Random();
            string Name = "";
            string[] namehotel = { "Beautiful House", "Luxury Room", "Deluxe Room", "The Lagoon", "Medium Room", "The Cabane", "The Evasion", "The Red Sea Room", "Cosy Apartment", "Hello World Room" };
            Name += namehotel[r.Next(namehotel.Length)];
            return Name;

        }



        #endregion


        #region addconboboxtoHU1

        private void addmoneytoHU1()
        {
            switch (moneycombobox.SelectedItem.ToString())
            {
                case "NIS":
                    HU1.typemoney = Money.NIS;
                    break;
                case "Dollars":
                    HU1.typemoney = Money.Dollars;
                    break;
                case "Euros":
                    HU1.typemoney = Money.Euros;
                    break;
                case "Pounds":
                    HU1.typemoney = Money.Pounds;
                    break;
                default:
                    break;
            }
        }
        private void addareatoHU1()
        {
            switch (areacombobox.SelectedItem.ToString())
            {
                case "Center":
                    HU1.area = Area.Center;
                    break;
                case "Jerusalem":
                    HU1.area = Area.Jerusalem;
                    break;
                case "North":
                    HU1.area = Area.North;
                    break;
                case "South":
                    HU1.area = Area.South;
                    break;
                default:
                    break;
            }
        }

        private void addSubareatoHU1()
        {

            switch (subareacombobox.SelectedItem.ToString())
            {
                case "BatYam":
                    HU1.subArea = SubArea.BatYam;
                    break;
                case "Natanya":
                    HU1.subArea = SubArea.Natanya;
                    break;
                case "Raanana":
                    HU1.subArea = SubArea.Raanana;
                    break;
                case "TelAviv":
                    HU1.subArea = SubArea.TelAviv;
                    break;
                case "Ashdod":
                    HU1.subArea = SubArea.Ashdod;
                    break;
                case "Ashkelon":
                    HU1.subArea = SubArea.Ashkelon;
                    break;
                case "BeerSheva":
                    HU1.subArea = SubArea.BeerSheva;
                    break;
                case "Eilat":
                    HU1.subArea = SubArea.Eilat;
                    break;
                case "Haifa":
                    HU1.subArea = SubArea.Haifa;
                    break;
                case "Jerusalem":
                    HU1.subArea = SubArea.Jerusalem;
                    break;
                case "Netivot":
                    HU1.subArea = SubArea.Netivot;
                    break;
                case "Safed":
                    HU1.subArea = SubArea.Safed;
                    break;
                case "Tiberia":
                    HU1.subArea = SubArea.Tiberia;
                    break;
                default:
                    break;

            }

        }

        private void addtypetoHU1()
        {
            switch (typecombobox.SelectedItem.ToString())
            {
                case "HotelRooms":
                    HU1.type = BE.Type.HotelRoom;
                    break;
                case "Apartment":
                    HU1.type = BE.Type.Apartment;
                    break;
                case "Camping":
                    HU1.type = BE.Type.Camping;
                    break;
                case "House":
                    HU1.type = BE.Type.House;
                    break;
                default:
                    break;
            }
        }

        private void addkasherouttoHU1()
        {
            switch (kasheroutcombobox.SelectedItem.ToString())
            {
                case "Rabanout":
                    HU1.kasherout = Kasherout.Rabanout;
                    break;
                case "Badatz":
                    HU1.kasherout = Kasherout.Badatz;
                    break;
                case "Lando":
                    HU1.kasherout = Kasherout.Lando;
                    break;
                case "Mahfoud":
                    HU1.kasherout = Kasherout.Mahfoud;
                    break;
                case "Jerusalem":
                    HU1.kasherout = Kasherout.Jerusalem;
                    break;
                default:
                    break;
            }

        }

        #endregion

        #region default reset
        private void default_Click(object sender, RoutedEventArgs e)
        {
            name.Text = GenerateName();
            name.Foreground = new SolidColorBrush(Colors.Black);
            name.FontStyle = FontStyles.Normal;
            price.Text = "100";
            price.Foreground = new SolidColorBrush(Colors.Black);
            price.FontStyle = FontStyles.Normal;
            HU1.pricePerNight = 100;
            moneycombobox.SelectedIndex = 0;
            areacombobox.SelectedIndex = 0;
            HelpSubArea();
            typecombobox.SelectedIndex = 0;
            kasheroutcombobox.SelectedIndex = 0;

            HelpDisplayNext();

           // next.IsEnabled = false;



        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            pool.IsChecked = false;
            poolseparated.IsChecked = false;
            jaccuzi.IsChecked = false;
            garden.IsChecked = false;
            childrenattraction.IsChecked = false;
            sea.IsChecked = false;
            mountain.IsChecked = false;
            bethabbad.IsChecked = false;
            super.IsChecked = false;
            name.Text = "Name is...";
            name.Foreground = new SolidColorBrush(Colors.Gray);
            name.FontStyle = FontStyles.Italic;
            price.Text = "Price is...";
            price.Foreground = new SolidColorBrush(Colors.Gray);
            price.FontStyle = FontStyles.Italic; moneycombobox.SelectedIndex = 0;
            rooms.Content = 1;
            Rooms = 1;
            HU1.Rooms = 1;
            beds.Content = 1;
            Beds = 1;
            HU1.Beds = 1;
            areacombobox.SelectedIndex = 0;
            HelpSubArea();
            typecombobox.SelectedIndex = 0;
            kasheroutcombobox.SelectedIndex = 0;

            password.Password = "";

            HelpDisplayNext();
           // next.IsEnabled = false;
        }
        #endregion

        #region enterleave
        private void nameenter(object sender, EventArgs e)
        {
            if (name.Text == "Name is...")
            {
                name.Text = "";
                name.Foreground = new SolidColorBrush(Colors.Black);
                name.FontStyle = FontStyles.Normal;
            }
        }
        private void nameleave(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Name is...";
                name.Foreground = new SolidColorBrush(Colors.Gray);
                name.FontStyle = FontStyles.Italic;
            }

        }

        private void priceenter(object sender, EventArgs e)
        {
            if (price.Text == "Price is...")
            {
                price.Text = "";
                price.Foreground = new SolidColorBrush(Colors.Black);
                price.FontStyle = FontStyles.Normal;
            }
        }
        private void priceleave(object sender, EventArgs e)
        {
            if (price.Text == "")
            {
                price.Text = "Price is...";
                price.Foreground = new SolidColorBrush(Colors.Gray);
                price.FontStyle = FontStyles.Italic;
            }

        }

        #endregion


        private void addtoHU1()
        {
            HU1.HostingUnitName = name.Text;
            HU1.Rooms = Rooms;
            HU1.Beds = Beds;
            HU1.passwordHU = password.Password;
            addareatoHU1();
            addSubareatoHU1();
            addtypetoHU1();
            addkasherouttoHU1();
            addmoneytoHU1();
            if (price.Text != "")
            {
                HU1.pricePerNight = int.Parse(price.Text);
            }

        }
    }
}
