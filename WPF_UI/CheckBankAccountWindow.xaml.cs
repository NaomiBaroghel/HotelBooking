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
using BL;
using BE;
using System.Text.RegularExpressions;

namespace WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour CheckBankAccountWindow.xaml
    /// </summary>
    public partial class CheckBankAccountWindow : Window
    {
        static IBL ibl = BLFactory.getBL();
        HostingUnit HU4 = new HostingUnit();
        public CheckBankAccountWindow(HostingUnit hu)
        {
            InitializeComponent();
            HU4 = hu;
            
            //citycombobox.ItemsSource = Enum.GetValues(typeof(SubArea));
            //banknamecombobox.ItemsSource = Enum.GetValues(typeof(Bankname));
            //bankaccountnumber.Text = hu.Owner.BankAccountNumber.ToString();
            //banknumber.Text = hu.Owner.branch.BankNumber.ToString();
            //branchnumber.Text = hu.Owner.branch.BranchNumber.ToString();
            //branchaddress.Text = hu.Owner.branch.BranchAddress;
            //banknamecombobox.SelectedItem = hu.Owner.branch.BankName.ToString();
            //citycombobox.SelectedItem = hu.Owner.branch.BranchCity.ToString();

            mynamecombobox.ItemsSource = ibl.GetBankName();
            mynamecombobox.SelectedItem = hu.Owner.branch.BankName;
            mybranchnumbercombobox.ItemsSource = ibl.GetBranchNumbers(mynamecombobox.Text);
            mybranchnumbercombobox.ItemsSource = hu.Owner.branch.BranchNumber.ToString();
            if (hu.Owner.CollectionClearance == true)
            {
                collectionclearence.IsChecked = true;
            }
            else
            {
                collectionclearence.IsChecked = false;
            }

        }
        public CheckBankAccountWindow()
        {
            InitializeComponent();
            //citycombobox.ItemsSource = Enum.GetValues(typeof(SubArea));
            //banknamecombobox.ItemsSource = Enum.GetValues(typeof(Bankname));
        }



        private void TextAllow1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            HelpDisplay();
        }

        private void TextAllow2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            HelpDisplay();

        }

        private void TextAllow3(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            HelpDisplay();

        }



        private void branchaddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            HelpDisplay();
        }
        private void CheckBox_collectionclearence(object sender, RoutedEventArgs e)
        {
            collectionclearence.IsChecked = true;
            HU4.Owner.CollectionClearance = true;
            HelpDisplay();
        }
        private void UncheckBox_collectionclearence(object sender, RoutedEventArgs e)
        {
            collectionclearence.IsChecked = false;
            HU4.Owner.CollectionClearance = false;
            HelpDisplay();
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
        //    switch (banknamecombobox.SelectedItem.ToString())
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
            //if (bankaccountnumber.Text != "" && bankaccountnumber.Text != "My Bank Account Number is...")
            //{
            //    HU4.Owner.BankAccountNumber = int.Parse(bankaccountnumber.Text);
            //}
            //if (branchaddress.Text != "" && branchaddress.Text != "My Branch Address is...")
            //{
            //    HU4.Owner.branch.BranchAddress = branchaddress.Text;
            //}

            //addbanknametoBranch();
            //addcitytoBranch();

            if (bankaccountnumber.Text != "" && bankaccountnumber.Text != "My Bank Account Number is...")
            {
                HU4.Owner.BankAccountNumber = int.Parse(bankaccountnumber.Text);
            }
            HU4.Owner.branch = ibl.GetMyBranch(int.Parse(mybranchnumbercombobox.Text), mynamecombobox.Text);


        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addtoHU();
                ibl.UpdateHostingUnit(HU4);
                Close();
            }
            catch (Exception ex)
            {
                if (ex.Message == "BL Exception : You can't close your clearence while an order is in process")
                {
                    MessageBox.Show("You need to allow the collection clearence");
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        private void HelpDisplay()
        {
            if (!bankaccountnumber.Equals("") && !bankaccountnumber.Equals("My Bank Account Number is..."))
                //if (!banknumber.Equals("") && !banknumber.Equals("My Bank Number is..."))
                //    if (!branchnumber.Equals("") && !banknumber.Equals("My Branch Number is..."))
                //        if (!branchaddress.Equals("") && !branchaddress.Equals("My Branch Address is.."))
                           // if (collectionclearence.IsChecked == true)
                            {
                                ok.IsEnabled = true;
                                return;
                                
                            }
            ok.IsEnabled = false;
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
