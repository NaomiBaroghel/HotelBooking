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
    /// Logique d'interaction pour BankAccountWindow.xaml
    /// </summary>
    public partial class BankAccountWindow : Window
    {
        static IBL ibl = BLFactory.getBL();
        HostingUnit HU4 = new HostingUnit();

        public BankAccountWindow(HostingUnit hu)
        {

            InitializeComponent();
            HU4 = hu;
            //citycombobox.ItemsSource = Enum.GetValues(typeof(SubArea));
            //banknamecombobox.ItemsSource = Enum.GetValues(typeof(Bankname));
            mynamecombobox.ItemsSource = ibl.GetBankName();



        }
        public BankAccountWindow()
        {

            InitializeComponent();
            //citycombobox.ItemsSource = Enum.GetValues(typeof(SubArea));
            //banknamecombobox.ItemsSource = Enum.GetValues(typeof(Bankname));
            mynamecombobox.ItemsSource = ibl.GetBankName();

        }


        private void ok_Click(object sender, RoutedEventArgs e)
        {
            addtoHU();
            this.Visibility = Visibility.Hidden;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            addtoHU();
            this.Visibility = Visibility.Hidden;
        }
        private void TextAllow1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
           

        }

        private void TextAllow2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
           

        }

        private void TextAllow3(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
           

        }

        
        private void banknamecombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // addbanknametoBranch();
        }

        private void TextBox_TextChangedbranchaddress(object sender, TextChangedEventArgs e)
        {
            //HU4.Owner.branch.BranchAddress = branchaddress.Text;
        }

        private void citycombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //addcitytoBranch();
        }

        private void CheckBox_collectionclearence(object sender, RoutedEventArgs e)
        {
            HU4.Owner.CollectionClearance = true;
        }
        private void UncheckBox_collectionclearence(object sender, RoutedEventArgs e)
        {
            HU4.Owner.CollectionClearance = false;
        }

        #region addtoBranch
        //private void addcitytoBranch()
        //{
        //    switch (citycombobox.SelectedItem.ToString())
        //    {
                 
        //        case "Ashdod":
        //            HU4.Owner.branch.BranchCity = SubArea.Ashdod;
        //            break;
        //        case "Ashkelon":
        //            HU4.Owner.branch.BranchCity = SubArea.Ashkelon;
        //            break;
        //        case "BatYam":
        //            HU4.Owner.branch.BranchCity = SubArea.BatYam;
        //            break;
        //        case "BeerSheva":
        //            HU4.Owner.branch.BranchCity = SubArea.BeerSheva;
        //            break;
        //        case "Eilat":
        //            HU4.Owner.branch.BranchCity = SubArea.Eilat;
        //            break;
        //        case "Haifa":
        //            HU4.Owner.branch.BranchCity = SubArea.Haifa;
        //            break;
        //        case "Jerusalem":
        //            HU4.Owner.branch.BranchCity = SubArea.Jerusalem;
        //            break;
        //        case "Natanya":
        //            HU4.Owner.branch.BranchCity = SubArea.Natanya;
        //            break;
        //        case "Netivot":
        //            HU4.Owner.branch.BranchCity = SubArea.Netivot;
        //            break;
        //        case "Raanana":
        //            HU4.Owner.branch.BranchCity = SubArea.Raanana;
        //            break;
        //        case "Safed":
        //            HU4.Owner.branch.BranchCity = SubArea.Safed;
        //            break;
        //        case "Tel Aviv":
        //            HU4.Owner.branch.BranchCity = SubArea.TelAviv;
        //            break;
        //        case "Tiberia":
        //            HU4.Owner.branch.BranchCity = SubArea.Tiberia;
        //            break;
        //        default:
        //            break;
        //    }
        
        //}

        //private void addbanknametoBranch()
        //{
        //    switch(banknamecombobox.SelectedItem.ToString())
        //    {
        //        case "Discount":
        //            HU4.Owner.branch.BankName = Bankname.Discount;
        //            break;
        //        case "Hapoalim":
        //            HU4.Owner.branch.BankName = Bankname.Hapoalim;
        //            break;
        //        case "Leumi":
        //            HU4.Owner.branch.BankName = Bankname.Leumi;
        //            break;
        //        case "MizrahiTfahot":
        //            HU4.Owner.branch.BankName = Bankname.MizrahiTfahot;
        //            break;
        //        default:
        //            break;
        //    }
        //}
        #endregion

        #region enterleave
        private void bankaccountnumberenter(object sender, EventArgs e)
        {
            if (bankaccountnumber.Text == "My Bank Account Number is...")
            {
                bankaccountnumber.Text = "";
                bankaccountnumber.Foreground = new SolidColorBrush(Colors.Black);
                bankaccountnumber.FontStyle = FontStyles.Normal;
            }
        }
        private void bankaccountnumberleave(object sender, EventArgs e)
        {
            if (bankaccountnumber.Text == "")
            {
                bankaccountnumber.Text = "My Bank Account Number is...";
                bankaccountnumber.Foreground = new SolidColorBrush(Colors.Gray);
                bankaccountnumber.FontStyle = FontStyles.Italic;
            }

        }
        //private void banknumberenter(object sender, EventArgs e)
        //{
        //    if (bankaccountnumber.Text == "My Bank Number is...")
        //    {
        //        banknumber.Text = "";
        //        banknumber.Foreground = new SolidColorBrush(Colors.Black);
        //        banknumber.FontStyle = FontStyles.Normal;
        //    }
        //}
        //private void banknumberleave(object sender, EventArgs e)
        //{
        //    if (banknumber.Text == "")
        //    {
        //        banknumber.Text = "My Bank Number is...";
        //        banknumber.Foreground = new SolidColorBrush(Colors.Gray);
        //        banknumber.FontStyle = FontStyles.Italic;
        //    }

        //}
        //private void branchnumberenter(object sender, EventArgs e)
        //{
        //    if (branchnumber.Text == "My Branch Number is...")
        //    {
        //        branchnumber.Text = "";
        //        branchnumber.Foreground = new SolidColorBrush(Colors.Black);
        //        branchnumber.FontStyle = FontStyles.Normal;
        //    }
        //}
        //private void branchnumberleave(object sender, EventArgs e)
        //{
        //    if (branchnumber.Text == "")
        //    {
        //        branchnumber.Text = "My Branch Number is...";
        //        branchnumber.Foreground = new SolidColorBrush(Colors.Gray);
        //        branchnumber.FontStyle = FontStyles.Italic;
        //    }

        //}
        //private void branchaddressenter(object sender, EventArgs e)
        //{
        //    if (branchaddress.Text == "My Branch Address is..")
        //    {
        //        branchaddress.Text = "";
        //        branchaddress.Foreground = new SolidColorBrush(Colors.Black);
        //        branchaddress.FontStyle = FontStyles.Normal;
        //    }
        //}
        //private void branchaddressleave(object sender, EventArgs e)
        //{
        //    if (branchaddress.Text == "")
        //    {
        //        branchaddress.Text = "My Branch Address is..";
        //        branchaddress.Foreground = new SolidColorBrush(Colors.Gray);
        //        branchaddress.FontStyle = FontStyles.Italic;
        //    }

        //}
        //private void branchanameenter(object sender, EventArgs e)
        //{
        //    if (branchaddress.Text == "My Bank Name is..")
        //    {
        //        branchaddress.Text = "";
        //        branchaddress.Foreground = new SolidColorBrush(Colors.Black);
        //        branchaddress.FontStyle = FontStyles.Normal;
        //    }
        //}
      
        #endregion

        private void addtoHU()
        {
            //if (branchnumber.Text != "" && branchnumber.Text != "My Branch Number is...")
            //{
            //    HU4.Owner.branch.BranchNumber = int.Parse(branchnumber.Text);
            //}
            //if (banknumber.Text != "" && banknumber.Text != "My Bank Number is...")
            //{
            //    HU4.Owner.branch.BankNumber = int.Parse(banknumber.Text);
            //}

            //if (name.Text != "" && name.Text != "My Bank Name is...")
            //{
            //    HU4.Owner.branch.BankName = name.Text;
            //}
            //if (city.Text != "" && city.Text != "My Branch City is...")
            //{
            //    HU4.Owner.branch.BranchCity = city.Text;
            //}
            //if (branchaddress.Text != "" && branchaddress.Text != "My Branch Address is...")
            //{
            //    HU4.Owner.branch.BranchAddress = branchaddress.Text;
            //}

            // addbanknametoBranch();
            // addcitytoBranch();

            if (bankaccountnumber.Text != "" && bankaccountnumber.Text != "My Bank Account Number is...")
            {
                HU4.Owner.BankAccountNumber = int.Parse(bankaccountnumber.Text);
            }
            HU4.Owner.branch = ibl.GetMyBranch(int.Parse(mybranchnumbercombobox.Text), mynamecombobox.Text);

        }

        private void mynamecombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mybranchnumbercombobox.ItemsSource = ibl.GetBranchNumbers(mynamecombobox.Text);

        }

        private void mybranchnumbercombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
