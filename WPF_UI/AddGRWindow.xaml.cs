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
    /// Logique d'interaction pour AddGRWindow.xaml
    /// </summary>
    public partial class AddGRWindow : Window
    {
      //  private static GuestRequest GR = new GuestRequest();
       // public static GuestRequest GR1 { get { return GR; } set { GR = value; } }
        GuestRequest GR = new GuestRequest();

        Window finalizewindow = new FinalizeGRWindow();
        Window saladwindow = new SaladWindow();

        bool flag = false;
        int Adults = 1;
        int Children = 0;
        int Rooms = 1;
        public AddGRWindow()
        {
            InitializeComponent();
            GR = new GuestRequest();
            GR.Rooms = Rooms;
            GR.Adults = Adults;
            GR.Children = Children;

            areacombobox.ItemsSource = Enum.GetValues(typeof(Area));

            HelpSubArea();

            typecombobox.ItemsSource = Enum.GetValues(typeof(BE.Type));
            kasheroutcombobox.ItemsSource = Enum.GetValues(typeof(Kasherout));
            calendardate.DisplayDateStart = DateTime.Today;

        }

        private void calendar_Click(object sender, RoutedEventArgs e)
        {
            if (flag == false)
            {
                vbCalendar.Visibility = Visibility.Visible;
                choose.Visibility = Visibility.Visible;
                flag = true;
            }
            else
            {
                vbCalendar.Visibility = Visibility.Collapsed;
                choose.Visibility = Visibility.Collapsed;
                flag = false;
            }

        }
        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            GR.EntryDate = calendardate.SelectedDates.First();
            GR.ReleaseDate = calendardate.SelectedDates.Last();

            vbCalendar.Visibility = Visibility.Collapsed;
            choose.Visibility = Visibility.Collapsed;
            flag = false;

            HelpDisplayNext();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            addareatoGR();
            addSubareatoGR();
            addtypetoGR();
            addkasherouttoGR();

            if (finalizewindow.Visibility == Visibility.Hidden)
                finalizewindow.Show();
            else
            {
                finalizewindow = new FinalizeGRWindow(GR);
                finalizewindow.ShowDialog();
            }


        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        #region +-

        private void adultsless_Click(object sender, RoutedEventArgs e)
        {
            if (Adults > 1)
            {
                Adults -= 1;
                adultscounter.Text = Adults.ToString();
            }
            GR.Adults = Adults;
        }

        private void childrenless_Click(object sender, RoutedEventArgs e)
        {
            if (Children > 0)
            {
                Children -= 1;
                childrencounter.Text = Children.ToString();

            }
            GR.Children = Children;
        }

        private void roomsless_Click(object sender, RoutedEventArgs e)
        {
            if (Rooms > 1)
            {
                Rooms -= 1;
                roomscounter.Text = Rooms.ToString();
            }
            GR.Rooms = Rooms;
        }

        private void adultsplus_Click(object sender, RoutedEventArgs e)
        {
            Adults += 1;
            adultscounter.Text = Adults.ToString();
            GR.Adults = Adults;
        }

        private void childrenplus_Click(object sender, RoutedEventArgs e)
        {
            Children += 1;
            childrencounter.Text = Children.ToString();
            GR.Children = Children;
        }

        private void roomsplus_Click(object sender, RoutedEventArgs e)
        {
            Rooms += 1;
            roomscounter.Text = Rooms.ToString();
            GR.Rooms = Rooms;
        }
        #endregion
        #region combobox
        private void areacombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // addareatoGR();
            HelpSubArea();


        }

        private void subareacombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //addSubareatoGR();
        }

        private void kasheroutcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // addkasherouttoGR();
        }

        private void typecombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // addtypetoGR();
        }
        #endregion

        #region checkbox

        #region pool
        private void poolyes_Checked(object sender, RoutedEventArgs e)
        {
            poolseparatedyes.IsEnabled = true;
            poolseparatedno.IsEnabled = true;
            poolseparateddc.IsEnabled = true;

            poolyes.IsChecked = true;
            poolno.IsChecked = false;
            pooldc.IsChecked = false;

            GR.Pool = Accord.yes;
            HelpDisplayNext();

        }



        private void poolno_Checked(object sender, RoutedEventArgs e)
        {
            poolyes.IsChecked = false;
            poolno.IsChecked = true;
            pooldc.IsChecked = false;

            poolseparatedyes.IsEnabled = false;
            poolseparatedno.IsEnabled = false;
            poolseparateddc.IsEnabled = false;

            GR.Pool = Accord.no;
            HelpDisplayNext();

        }

        private void pooldc_Checked(object sender, RoutedEventArgs e)
        {
            poolyes.IsChecked = false;
            poolno.IsChecked = false;
            pooldc.IsChecked = true;

            poolseparatedyes.IsEnabled = false;
            poolseparatedno.IsEnabled = false;
            poolseparateddc.IsEnabled = false;

            GR.Pool = Accord.dontcare;
            HelpDisplayNext();

        }
        private void poolyes_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }

        private void poolno_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();

        }

        private void pooldc_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }



        #endregion

        #region poolseparated
        private void poolseparatedyes_Checked(object sender, RoutedEventArgs e)
        {

            poolseparatedyes.IsChecked = true;
            poolseparatedno.IsChecked = false;
            poolseparateddc.IsChecked = false;

            GR.poolseparated = Accord.yes;
            HelpDisplayNext();
        }


        private void poolseparatedno_Checked(object sender, RoutedEventArgs e)
        {

            poolseparatedyes.IsChecked = false;
            poolseparatedno.IsChecked = true;
            poolseparateddc.IsChecked = false;
            GR.poolseparated = Accord.no;

            HelpDisplayNext();

        }



        private void poolseparateddc_Checked(object sender, RoutedEventArgs e)
        {

            poolseparatedyes.IsChecked = false;
            poolseparatedno.IsChecked = false;
            poolseparateddc.IsChecked = true;
            GR.poolseparated = Accord.dontcare;

            HelpDisplayNext();

        }
        private void poolseparatedyes_Unchecked(object sender, RoutedEventArgs e)
        {

            HelpDisplayNext();

        }


        private void poolseparatedno_Unchecked(object sender, RoutedEventArgs e)
        {

            HelpDisplayNext();


        }



        private void poolseparateddc_Unchecked(object sender, RoutedEventArgs e)
        {

            HelpDisplayNext();

        }
        #endregion

        #region jaccuzi
        private void jaccuziyes_Checked(object sender, RoutedEventArgs e)
        {
            jaccuziyes.IsChecked = true;
            jaccuzino.IsChecked = false;
            jaccuzidc.IsChecked = false;
            GR.Jacuzzi = Accord.yes;

            HelpDisplayNext();

        }

        private void jaccuzino_Checked(object sender, RoutedEventArgs e)
        {
            jaccuziyes.IsChecked = false;
            jaccuzino.IsChecked = true;
            jaccuzidc.IsChecked = false;
            GR.Jacuzzi = Accord.no;

            HelpDisplayNext();

        }

        private void jaccuzidc_Checked(object sender, RoutedEventArgs e)
        {
            jaccuziyes.IsChecked = false;
            jaccuzino.IsChecked = false;
            jaccuzidc.IsChecked = true;
            GR.Jacuzzi = Accord.dontcare;

            HelpDisplayNext();

        }

        private void jaccuziyes_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }

        private void jaccuzino_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();



        }

        private void jaccuzidc_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }

        #endregion

        #region garden
        private void gardenyes_Checked(object sender, RoutedEventArgs e)
        {
            gardenyes.IsChecked = true;
            gardenno.IsChecked = false;
            gardendc.IsChecked = false;
            GR.Garden = Accord.yes;

            HelpDisplayNext();

        }

        private void gardenno_Checked(object sender, RoutedEventArgs e)
        {
            gardenyes.IsChecked = false;
            gardenno.IsChecked = true;
            gardendc.IsChecked = false;
            GR.Garden = Accord.no;

            HelpDisplayNext();

        }

        private void gardendc_Checked(object sender, RoutedEventArgs e)
        {
            gardenyes.IsChecked = false;
            gardenno.IsChecked = false;
            gardendc.IsChecked = true;
            GR.Garden = Accord.dontcare;

            HelpDisplayNext();

        }

        private void gardenyes_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();



        }

        private void gardenno_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }

        private void gardendc_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }
        #endregion
        #region childrenattraction
        private void childrenattractionyes_Checked(object sender, RoutedEventArgs e)
        {
            childrenattractionyes.IsChecked = true;
            childrenattractionno.IsChecked = false;
            childrenattractiondc.IsChecked = false;
            GR.ChildrenAttractions = Accord.yes;

            HelpDisplayNext();

        }

        private void childrenattractionno_Checked(object sender, RoutedEventArgs e)
        {
            childrenattractionyes.IsChecked = false;
            childrenattractionno.IsChecked = true;
            childrenattractiondc.IsChecked = false;
            GR.ChildrenAttractions = Accord.no;

            HelpDisplayNext();

        }

        private void childrenattractiondc_Checked(object sender, RoutedEventArgs e)
        {
            childrenattractionyes.IsChecked = false;
            childrenattractionno.IsChecked = false;
            childrenattractiondc.IsChecked = true;
            GR.ChildrenAttractions = Accord.dontcare;

            HelpDisplayNext();

        }

        private void childrenattractionyes_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }

        private void childrenattractionno_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }

        private void childrenattractiondc_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();

        }
        #endregion
        #region sea
        private void seayes_Checked(object sender, RoutedEventArgs e)
        {

            seayes.IsChecked = true;
            seano.IsChecked = false;
            seadc.IsChecked = false;
            GR.Sea = Accord.yes;

            HelpDisplayNext();

        }

        private void seano_Checked(object sender, RoutedEventArgs e)
        {
            seayes.IsChecked = false;
            seano.IsChecked = true;
            seadc.IsChecked = false;
            GR.Sea = Accord.no;

            HelpDisplayNext();

        }

        private void seadc_Checked(object sender, RoutedEventArgs e)
        {
            seayes.IsChecked = false;
            seano.IsChecked = false;
            seadc.IsChecked = true;
            GR.Sea = Accord.dontcare;

            HelpDisplayNext();

        }
        private void seayes_Unchecked(object sender, RoutedEventArgs e)
        {

            HelpDisplayNext();



        }

        private void seano_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();



        }

        private void seadc_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }
        #endregion
        #region mountain

        private void mountainyes_Checked(object sender, RoutedEventArgs e)
        {
            mountainyes.IsChecked = true;
            mountainno.IsChecked = false;
            mountaindc.IsChecked = false;
            GR.Mountain = Accord.yes;

            HelpDisplayNext();

        }

        private void mountainno_Checked(object sender, RoutedEventArgs e)
        {
            mountainyes.IsChecked = false;
            mountainno.IsChecked = true;
            mountaindc.IsChecked = false;
            GR.Mountain = Accord.no;
            HelpDisplayNext();

        }

        private void mountaindc_Checked(object sender, RoutedEventArgs e)
        {
            mountainyes.IsChecked = false;
            mountainno.IsChecked = false;
            mountaindc.IsChecked = true;
            GR.Mountain = Accord.dontcare;
            HelpDisplayNext();

        }
        private void mountainyes_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }

        private void mountainno_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }

        private void mountaindc_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }
        #endregion
        #region bethabbad

        private void bethabbadyes_Checked(object sender, RoutedEventArgs e)
        {
            bethabbadyes.IsChecked = true;
            bethabbadno.IsChecked = false;
            bethabbaddc.IsChecked = false;
            GR.BetHabbad = Accord.yes;
            HelpDisplayNext();

        }

        private void bethabbadno_Checked(object sender, RoutedEventArgs e)
        {
            bethabbadyes.IsChecked = false;
            bethabbadno.IsChecked = true;
            bethabbaddc.IsChecked = false;
            GR.BetHabbad = Accord.no;

            HelpDisplayNext();

        }

        private void bethabbaddc_Checked(object sender, RoutedEventArgs e)
        {
            bethabbadyes.IsChecked = false;
            bethabbadno.IsChecked = false;
            bethabbaddc.IsChecked = true;
            GR.BetHabbad = Accord.dontcare;

            HelpDisplayNext();

        }

        private void bethabbadyes_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();



        }

        private void bethabbadno_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();



        }

        private void bethabbaddc_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();


        }
        #endregion
        #region super



        private void superyes_Checked(object sender, RoutedEventArgs e)
        {

            superyes.IsChecked = true;
            superno.IsChecked = false;
            superdc.IsChecked = false;
            GR.Super = Accord.yes;

            HelpDisplayNext();

        }

        private void superno_Checked(object sender, RoutedEventArgs e)
        {

            superyes.IsChecked = false;
            superno.IsChecked = true;
            superdc.IsChecked = false;
            GR.Super = Accord.no;
            HelpDisplayNext();

        }

        private void superdc_Checked(object sender, RoutedEventArgs e)
        {

            superyes.IsChecked = false;
            superno.IsChecked = false;
            superdc.IsChecked = true;
            GR.Super = Accord.dontcare;
            HelpDisplayNext();


        }

        private void superyes_Unchecked(object sender, RoutedEventArgs e)
        {
            HelpDisplayNext();

        }

        private void superno_Unchecked(object sender, RoutedEventArgs e)
        {

            HelpDisplayNext();
        }

        private void superdc_Unchecked(object sender, RoutedEventArgs e)
        {

            HelpDisplayNext();
        }
        #endregion

        #region other
        private void mealshabbat_Checked(object sender, RoutedEventArgs e)
        {


            saladshabbat.IsEnabled = true;
            GR.MealShabbat = true;
           

        }
        private void mealshabbat_Unchecked(object sender, RoutedEventArgs e)
        {
            saladshabbat.IsEnabled = false;
            GR.MealShabbat = false;
            GR.saladshabbat.RemoveRange(0,GR.saladshabbat.Count-1);
        }

        private void saladshabbat_Click(object sender, RoutedEventArgs e)
        {
            if (saladwindow.Visibility == Visibility.Hidden)
                saladwindow.Show();
            else
            {
                saladwindow = new SaladWindow(GR);
                saladwindow.ShowDialog();
            }

        }
        private void car_Checked(object sender, RoutedEventArgs e)
        {
            GR.Car = true;
        }

        private void car_Unchecked(object sender, RoutedEventArgs e)
        {
            GR.Car = false;
        }

        private void hiking_Checked(object sender, RoutedEventArgs e)
        {
            GR.Hiking = true;
        }
        private void hiking_Unchecked(object sender, RoutedEventArgs e)
        {
            GR.Hiking = false;
        }

        #endregion

        #endregion


        #region reset default
        //VOIR POUR LE CALENDAR //Pas besoin de faire GR car lorsqu'on checked ou unchecked ca va directement dans leur fonction specifique
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            poolyes.IsChecked = false;
            poolno.IsChecked = false;
            pooldc.IsChecked = false;

            poolseparatedyes.IsChecked = false;
            poolseparatedno.IsChecked = false;
            poolseparateddc.IsChecked = false;

            jaccuziyes.IsChecked = false;
            jaccuzino.IsChecked = false;
            jaccuzidc.IsChecked = false;

            gardenyes.IsChecked = false;
            gardenno.IsChecked = false;
            gardendc.IsChecked = false;

            childrenattractionyes.IsChecked = false;
            childrenattractionno.IsChecked = false;
            childrenattractiondc.IsChecked = false;

            seayes.IsChecked = false;
            seano.IsChecked = false;
            seadc.IsChecked = false;

            mountainyes.IsChecked = false;
            mountainno.IsChecked = false;
            mountaindc.IsChecked = false;

            bethabbadyes.IsChecked = false;
            bethabbadno.IsChecked = false;
            bethabbaddc.IsChecked = false;

            superyes.IsChecked = false;
            superno.IsChecked = false;
            superdc.IsChecked = false;

            car.IsChecked = false;
            hiking.IsChecked = false;
            mealshabbat.IsChecked = false;

            adultscounter.Text = "1";
            GR.Adults = 1;
            childrencounter.Text = "0";
            GR.Children = 0;
            roomscounter.Text = "1";
            GR.Rooms = 1;

            areacombobox.SelectedIndex = 0;
            // addareatoGR();
            HelpSubArea();
            // addSubareatoGR();
            typecombobox.SelectedIndex = 0;
            // addtypetoGR();
            kasheroutcombobox.SelectedIndex = 0;
            // addkasherouttoGR();

            //calendardate.SelectedDates.Remove(calendardate.SelectedDates.First());
            //calendardate.SelectedDates.Remove(calendardate.SelectedDates.Last());

            GR.EntryDate = DateTime.Today;
            GR.ReleaseDate = DateTime.Today;


            next.IsEnabled = false;
        }

        private void default_Click(object sender, RoutedEventArgs e)
        {

            poolyes.IsChecked = false;
            poolno.IsChecked = false;
            pooldc.IsChecked = true;
            // GR.Pool = Accord.dontcare;

            poolseparatedyes.IsChecked = false;
            poolseparatedno.IsChecked = false;
            poolseparateddc.IsChecked = true;
            // GR.poolseparated = Accord.no;

            jaccuziyes.IsChecked = false;
            jaccuzino.IsChecked = false;
            jaccuzidc.IsChecked = true;
            // GR.Jacuzzi = Accord.dontcare;

            gardenyes.IsChecked = false;
            gardenno.IsChecked = false;
            gardendc.IsChecked = true;
            // GR.Garden = Accord.dontcare;

            childrenattractionyes.IsChecked = false;
            childrenattractionno.IsChecked = false;
            childrenattractiondc.IsChecked = true;
            // GR.ChildrenAttractions = Accord.dontcare;

            seayes.IsChecked = false;
            seano.IsChecked = false;
            seadc.IsChecked = true;
            // GR.Sea = Accord.dontcare;

            mountainyes.IsChecked = false;
            mountainno.IsChecked = false;
            mountaindc.IsChecked = true;
            //  GR.Mountain = Accord.dontcare;

            bethabbadyes.IsChecked = false;
            bethabbadno.IsChecked = false;
            bethabbaddc.IsChecked = true;
            //  GR.BetHabbad = Accord.dontcare;

            superyes.IsChecked = false;
            superno.IsChecked = false;
            superdc.IsChecked = true;
            //  GR.Super = Accord.dontcare;

            car.IsChecked = false;
            //  GR.Car = false;
            hiking.IsChecked = false;
            // GR.Hiking = false;
            mealshabbat.IsChecked = false;
            // GR.MealShabbat = false;

            adultscounter.Text = "2";
            //GR.Adults = 2;
            childrencounter.Text = "0";
            // GR.Children = 0;
            roomscounter.Text = "1";
            // GR.Rooms = 1;

            areacombobox.SelectedIndex = 0;
            //addareatoGR();
            HelpSubArea();
            //addSubareatoGR();
            typecombobox.SelectedIndex = 0;
            //addtypetoGR();
            kasheroutcombobox.SelectedIndex = 0;
            //addkasherouttoGR();




            calendardate.SelectedDate = DateTime.Today;

            GR.EntryDate = DateTime.Today;
            GR.ReleaseDate = DateTime.Today.AddDays(2);

            next.IsEnabled = true;
            // HelpDisplayNext();
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
            if (calendardate.SelectedDate.HasValue==true)
            
                if (jaccuziyes.IsChecked == true || jaccuzino.IsChecked == true || jaccuzidc.IsChecked == true)

                    if (gardenyes.IsChecked == true || gardenno.IsChecked == true || gardendc.IsChecked == true)
                        if (childrenattractionyes.IsChecked == true || childrenattractionno.IsChecked == true || childrenattractiondc.IsChecked == true)
                            if (seayes.IsChecked == true || seano.IsChecked == true || seadc.IsChecked == true)
                                if (mountainyes.IsChecked == true || mountainno.IsChecked == true || mountaindc.IsChecked == true)
                                    if (bethabbadyes.IsChecked == true || bethabbadno.IsChecked == true || bethabbaddc.IsChecked == true)
                                        if (superyes.IsChecked == true || superno.IsChecked == true || superdc.IsChecked == true)
                                            if (poolyes.IsChecked == true)
                                            {
                                                if (poolseparatedyes.IsChecked == true || poolseparatedno.IsChecked == true || poolseparateddc.IsChecked == true)
                                                {
                                                    next.IsEnabled = true;
                                                    return;
                                                }

                                            }
                                            else if (poolno.IsChecked == true || pooldc.IsChecked == true)
                                            {
                                                next.IsEnabled = true;
                                                return;
                                            }
           
                next.IsEnabled = false;



        }





        #endregion

        #region addconboboxtoGR
        private void addareatoGR()
        {
            switch (areacombobox.SelectedItem.ToString())
            {
                case "Center":
                    GR.area = Area.Center;
                    break;
                case "Jerusalem":
                    GR.area = Area.Jerusalem;
                    break;
                case "North":
                    GR.area = Area.North;
                    break;
                case "South":
                    GR.area = Area.South;
                    break;
                default:
                    break;
            }
        }

        private void addSubareatoGR()
        {

            switch (subareacombobox.SelectedItem.ToString())
            {
                case "BatYam":
                    GR.subArea = SubArea.BatYam;
                    break;
                case "Natanya":
                    GR.subArea = SubArea.Natanya;
                    break;
                case "Raanana":
                    GR.subArea = SubArea.Raanana;
                    break;
                case "TelAviv":
                    GR.subArea = SubArea.TelAviv;
                    break;
                case "Ashdod":
                    GR.subArea = SubArea.Ashdod;
                    break;
                case "Ashkelon":
                    GR.subArea = SubArea.Ashkelon;
                    break;
                case "BeerSheva":
                    GR.subArea = SubArea.BeerSheva;
                    break;
                case "Eilat":
                    GR.subArea = SubArea.Eilat;
                    break;
                case "Haifa":
                    GR.subArea = SubArea.Haifa;
                    break;
                case "Jerusalem":
                    GR.subArea = SubArea.Jerusalem;
                    break;
                case "Netivot":
                    GR.subArea = SubArea.Netivot;
                    break;
                case "Safed":
                    GR.subArea = SubArea.Safed;
                    break;
                case "Tiberia":
                    GR.subArea = SubArea.Tiberia;
                    break;
                default:
                    break;

            }

        }

        private void addtypetoGR()
        {
            switch (typecombobox.SelectedItem.ToString())
            {
                case "HotelRooms":
                    GR.type = BE.Type.HotelRoom;
                    break;
                case "Apartment":
                    GR.type = BE.Type.Apartment;
                    break;
                case "Camping":
                    GR.type = BE.Type.Camping;
                    break;
                case "House":
                    GR.type = BE.Type.House;
                    break;
                default:
                    break;
            }
        }

        private void addkasherouttoGR()
        {
            switch (kasheroutcombobox.SelectedItem.ToString())
            {
                case "Rabanout":
                    GR.kasherout = Kasherout.Rabanout;
                    break;
                case "Badatz":
                    GR.kasherout = Kasherout.Badatz;
                    break;
                case "Lando":
                    GR.kasherout = Kasherout.Lando;
                    break;
                case "Mahfoud":
                    GR.kasherout = Kasherout.Mahfoud;
                    break;
                case "Jerusalem":
                    GR.kasherout = Kasherout.Jerusalem;
                    break;
                default:
                    break;
            }

        }

        #endregion

        
    }

}
