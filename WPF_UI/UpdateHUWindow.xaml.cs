using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour UpdateHUWindow.xaml
    /// </summary>
    public partial class UpdateHUWindow : Window
    {
        static IBL ibl = BLFactory.getBL();
        HostingUnit HU1 = new HostingUnit();
        HostingUnit previoushu = new HostingUnit();
        int Rooms = 1;
        int Beds = 1;

        Window imagewindow = new UpdateImageWindow();
        Window videowindow = new UpdateVideoWindow();
        Window updatehostwindow = new UpdateHostWindow();
        public UpdateHUWindow(HostingUnit hu)
        {
            InitializeComponent();
            previoushu = hu;
            HU1.HostingUnitKey = hu.HostingUnitKey;
            HU1.passwordHU = hu.passwordHU;
            moneycombobox.ItemsSource = Enum.GetValues(typeof(Money));
            areacombobox.ItemsSource = Enum.GetValues(typeof(Area));
            typecombobox.ItemsSource = Enum.GetValues(typeof(BE.Type));
            kasheroutcombobox.ItemsSource = Enum.GetValues(typeof(Kasherout));
            HU1tomoney();
            HU1toarea();
            HU1tosubarea();
            HU1totype();
            HU1tokasherout();

           

            name.Text = hu.HostingUnitName;
            price.Text = hu.pricePerNight.ToString();
            roomscounter.Text = hu.Rooms.ToString();
            Rooms = hu.Rooms;
            bedscounter.Text = hu.Beds.ToString();
            Beds = hu.Beds;
       
            if (hu.Pool == true)
            {
                pool.IsChecked = true;
                poolseparated.IsEnabled = true;
                if (hu.poolseparated == true)
                    poolseparated.IsChecked = true;
                else
                    poolseparated.IsChecked = false;
            }
            else
                pool.IsChecked = false;
            if (hu.Jacuzzi == true)
                jaccuzi.IsChecked = true;
            else
                jaccuzi.IsChecked = false;
            if (hu.Garden == true)
                garden.IsChecked = true;
            else
                garden.IsChecked = false;
            if (hu.ChildrenAttractions == true)
                childrenattraction.IsChecked = true;
            else
                childrenattraction.IsChecked = false;
            if (hu.Sea == true)
                sea.IsChecked = true;
            else
                sea.IsChecked = false;
            if (hu.Mountain == true)
                mountain.IsChecked = true;
            else
                mountain.IsChecked = false;
            if (hu.BetHabbad == true)
                bethabbad.IsChecked = true;
            else
                bethabbad.IsChecked = false;
            if (hu.Super == true)
                super.IsChecked = true;
            else
                super.IsChecked = false;


            HU1.ImageSource = hu.ImageSource;
            HU1.VideoSource = hu.VideoSource;
            HU1.Owner = hu.Owner;
        }
        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addtoHU1();
                ibl.UpdateHostingUnit(HU1);
                
                MessageBox.Show("Update with success !");
                HostingUnit newhu = ibl.GetAllHostingUnit().FirstOrDefault(hu => hu.HostingUnitKey == HU1.HostingUnitKey);
                new PrivateSpaceHUWindow(newhu).Show(); 
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            new PrivateSpaceHUWindow(previoushu).Show();
            Close();
        }

        private void TextAllow(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }
        private void image_Click(object sender, RoutedEventArgs e)
        {
            if (imagewindow.Visibility == Visibility.Hidden)
                imagewindow.Show();
            else
            {
                imagewindow = new UpdateImageWindow(previoushu, HU1);
                imagewindow.ShowDialog();
            }
        }
        private void video_Click(object sender, RoutedEventArgs e)
        {
            if (videowindow.Visibility == Visibility.Hidden)
                videowindow.Show();
            else
            {
                videowindow = new UpdateVideoWindow(previoushu, HU1);
                videowindow.ShowDialog();
            }
        }


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


        private void areacombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HelpSubArea();
        }

        #region +-

        private void bedsplus_Click(object sender, RoutedEventArgs e)
        {
            Beds += 1;
            bedscounter.Text = Beds.ToString();

        }

        private void bedsless_Click(object sender, RoutedEventArgs e)
        {

            if (Beds > 1)
            {
                Beds -= 1;
                bedscounter.Text = Beds.ToString();
            }
        }

        private void roomsplus_Click(object sender, RoutedEventArgs e)
        {
            Rooms += 1;
            roomscounter.Text = Rooms.ToString();
        }

        private void roomsless_Click(object sender, RoutedEventArgs e)
        {
            if (Rooms > 1)
            {
                Rooms -= 1;
                roomscounter.Text = Rooms.ToString();
            }
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
        #endregion

        #region enterleave
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

        #endregion

        private void updatehost_Click(object sender, RoutedEventArgs e)
        {
            if (updatehostwindow.Visibility == Visibility.Hidden)
                updatehostwindow.Show();
            else
            {
                updatehostwindow = new UpdateHostWindow(previoushu, HU1);
                updatehostwindow.ShowDialog();
            }
        }
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
        #region hutocombobox
        private void HU1tomoney()
        {
            switch (previoushu.typemoney.ToString())
            {
                case "NIS":
                    moneycombobox.SelectedIndex = 0;
                    break;
                case "Dollars":
                    moneycombobox.SelectedIndex = 1;
                    break;
                case "Euros":
                    moneycombobox.SelectedIndex = 2;
                    break;
                case "Pounds":
                    moneycombobox.SelectedIndex = 3;
                    break;
                default:
                    break;
            }
        }
        private void HU1toarea()
        {
            switch (previoushu.area.ToString())
            {
                case "Center":
                    areacombobox.SelectedIndex = 0;
                    break;
                case "Jerusalem":
                    areacombobox.SelectedIndex = 3;
                    break;
                case "North":
                    areacombobox.SelectedIndex = 1;
                    break;
                case "South":
                    areacombobox.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
        }

        private void HU1tosubarea()
        {

            switch (previoushu.subArea.ToString())
            {
                case "BatYam":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaC));
                    subareacombobox.SelectedIndex = 2;
                    break;
                case "Natanya":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaC));
                    subareacombobox.SelectedIndex = 1;
                    break;
                case "Raanana":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaC));
                    subareacombobox.SelectedIndex = 3;
                    break;
                case "TelAviv":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaC));
                    subareacombobox.SelectedIndex = 0;
                    break;
                case "Ashdod":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaS));
                    subareacombobox.SelectedIndex = 1;
                    break;
                case "Ashkelon":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaS));
                    subareacombobox.SelectedIndex = 2;
                    break;
                case "BeerSheva":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaS));
                    subareacombobox.SelectedIndex = 3;
                    break;
                case "Eilat":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaS));
                    subareacombobox.SelectedIndex = 0;
                    break;
                case "Netivot":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaS));
                    subareacombobox.SelectedIndex = 4;
                    break;
                case "Jerusalem":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaJ));
                    subareacombobox.SelectedIndex = 0;
                    break;
                case "Haifa":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaN));
                    subareacombobox.SelectedIndex = 0;
                    break;
                case "Safed":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaS));
                    subareacombobox.SelectedIndex = 1;
                    break;
                case "Tiberia":
                    subareacombobox.ItemsSource = Enum.GetValues(typeof(SubAreaN));
                    subareacombobox.SelectedIndex = 2;
                    break;
                default:
                    break;
                    
            }


        }

        private void HU1totype()
        {
            switch (previoushu.type.ToString())
            {
                case "HotelRooms":
                    typecombobox.SelectedIndex = 0;
                    break;
                case "Apartment":
                    typecombobox.SelectedIndex = 2;
                    break;
                case "Camping":
                    typecombobox.SelectedIndex = 3;
                    break;
                case "House":
                    typecombobox.SelectedIndex = 1;
                    break;
                default:
                    break;
            }
        }

        private void HU1tokasherout()
        {
            switch (previoushu.kasherout.ToString())
            {
                case "Rabanout":
                    kasheroutcombobox.SelectedIndex = 0;
                    break;
                case "Badatz":
                    kasheroutcombobox.SelectedIndex = 1;
                    break;
                case "Lando":
                    kasheroutcombobox.SelectedIndex = 3;
                    break;
                case "Mahfoud":
                    kasheroutcombobox.SelectedIndex = 2;
                    break;
                case "Jerusalem":
                    kasheroutcombobox.SelectedIndex = 4;
                    break;
                default:
                    break;
            }

        }
        #endregion

        private void addtoHU1()
        {
            HU1.HostingUnitName = name.Text;
            HU1.Rooms = Rooms;
            HU1.Beds = Beds;
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
