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
    /// Logique d'interaction pour UpdateHostWindow.xaml
    /// </summary>
    public partial class UpdateHostWindow : Window
    {
        HostingUnit HU3 = new HostingUnit();
        HostingUnit previoushu1 = new HostingUnit();
        Window updatebankaccountwindow = new UpdateBankAccountWindow();
        public UpdateHostWindow()
        {
            InitializeComponent();
        }
        public UpdateHostWindow(HostingUnit hu,HostingUnit currenthu)
        {
            InitializeComponent();
            previoushu1 = hu;
            HU3 = currenthu;
            id.Text = hu.Owner.HostKey.ToString();
            family.Text = hu.Owner.FamilyName;
            Private.Text = hu.Owner.PrivateName;
            phonenumber.Text = hu.Owner.PhoneNumber.ToString();
            mail.Text = hu.Owner.MailAddress;
            password.Password = hu.Owner.passwordMail;
            

           
        }

        #region enterleave
        private void identer(object sender, EventArgs e)
        {
            if (id.Text == "My ID is...")
            {
                id.Text = "";
                id.Foreground = new SolidColorBrush(Colors.Black);
                id.FontStyle = FontStyles.Normal;
            }
        }
        private void idleave(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                id.Text = "My ID is...";
                id.Foreground = new SolidColorBrush(Colors.Gray);
                id.FontStyle = FontStyles.Italic;
            }

        }
        private void familyenter(object sender, EventArgs e)
        {
            if (family.Text == "My Family Name is..")
            {
                family.Text = "";
                family.Foreground = new SolidColorBrush(Colors.Black);
                family.FontStyle = FontStyles.Normal;
            }
        }
        private void familyleave(object sender, EventArgs e)
        {
            if (family.Text == "")
            {
                family.Text = "My Family Name is..";
                family.Foreground = new SolidColorBrush(Colors.Gray);
                family.FontStyle = FontStyles.Italic;
            }

        }

        private void privateenter(object sender, EventArgs e)
        {
            if (Private.Text == "My Private Name is..")
            {
                Private.Text = "";
                Private.Foreground = new SolidColorBrush(Colors.Black);
                Private.FontStyle = FontStyles.Normal;
            }
        }
        private void privateleave(object sender, EventArgs e)
        {
            if (Private.Text == "")
            {
                Private.Text = "My Private Name is..";
                Private.Foreground = new SolidColorBrush(Colors.Gray);
                Private.FontStyle = FontStyles.Italic;
            }

        }
        private void phonenumberenter(object sender, EventArgs e)
        {
            if (phonenumber.Text == "My Phone Number is...")
            {
                phonenumber.Text = "";
                phonenumber.Foreground = new SolidColorBrush(Colors.Black);
                phonenumber.FontStyle = FontStyles.Normal;
            }
        }
        private void phonenumberleave(object sender, EventArgs e)
        {
            if (phonenumber.Text == "")
            {
                phonenumber.Text = "My Phone Number is...";
                phonenumber.Foreground = new SolidColorBrush(Colors.Gray);
                phonenumber.FontStyle = FontStyles.Italic;
            }

        }

        private void mailenter(object sender, EventArgs e)
        {
            if (mail.Text == "someone@exemple.com")
            {
                mail.Text = "";
                mail.Foreground = new SolidColorBrush(Colors.Black);
                mail.FontStyle = FontStyles.Normal;
            }
        }
        private void mailleave(object sender, EventArgs e)
        {
            if (mail.Text == "")
            {
                mail.Text = "someone@exemple.com";
                mail.Foreground = new SolidColorBrush(Colors.Gray);
                mail.FontStyle = FontStyles.Italic;
            }

        }
        #endregion


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

        private void configuratebankaccount_Click(object sender, RoutedEventArgs e)
        {
            if (updatebankaccountwindow.Visibility == Visibility.Hidden)
                updatebankaccountwindow.Show();
            else
            {
                updatebankaccountwindow = new UpdateBankAccountWindow(previoushu1,HU3);
                updatebankaccountwindow.ShowDialog();
            }
        }

        private void password_Changed(object sender, RoutedEventArgs e)
        {
            if (password.Password != "")
            {
                keeppassword.IsEnabled = true;
            }
            else
                keeppassword.IsEnabled = false;
        }

        private void keeppassword_Checked(object sender, RoutedEventArgs e)
        {
            HU3.Owner.passwordMail = password.Password;
        }
        private void keeppassword_Unchecked(object sender, RoutedEventArgs e)
        {
            HU3.Owner.passwordMail = null;
        }
        public void addtoHU()
        {
            if (id.Text != "")
            {
                HU3.Owner.HostKey = id.Text;

            }
            if (phonenumber.Text != "")
            {
                HU3.Owner.PhoneNumber =phonenumber.Text;

            }
            HU3.Owner.FamilyName = family.Text;
            HU3.Owner.PrivateName = Private.Text;
            HU3.Owner.MailAddress = mail.Text;
            
        }
    }
}
