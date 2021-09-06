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
    /// Logique d'interaction pour HostWindow.xaml
    /// </summary>
    public partial class HostWindow : Window
    {
        
        static IBL ibl = BLFactory.getBL();
        HostingUnit HU3 = new HostingUnit();
        Window bankaccountwindow = new BankAccountWindow();
        public HostWindow(HostingUnit hu)
        {
            InitializeComponent();
            HU3 = hu;

        }
        public HostWindow()
        {
            InitializeComponent();
        }


        private void addhu_Click(object sender, RoutedEventArgs e)
        {

            
            try
            {
                addtoHU();
                ibl.AddHostingUnit(HU3);
                MessageBox.Show("Hosting Unit add with success !");
                new ChoiceWindow2().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void TextAllow1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            
            HelpDisplayaddHU();
        }
        private void TextAllow2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
           
            HelpDisplayaddHU();
        }

       
        private void TextBox_TextChangedFamily(object sender, TextChangedEventArgs e)
        {
           // HU3.Owner.FamilyName = family.Text;
            HelpDisplayaddHU();
        }
        private void TextBox_TextChangedPrivate(object sender, TextChangedEventArgs e)
        {
           // HU3.Owner.PrivateName = Private.Text;
            HelpDisplayaddHU();
        }


        private void TextBox_TextChangedMail(object sender, TextChangedEventArgs e)
        {
           // HU3.Owner.MailAddress = mail.Text;
            HelpDisplayaddHU();
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

        private void configuratebankaccount_Click(object sender, RoutedEventArgs e)
        {
            if (bankaccountwindow.Visibility == Visibility.Hidden)
                bankaccountwindow.Show();
            else
            {
                bankaccountwindow = new BankAccountWindow(HU3);
                bankaccountwindow.ShowDialog();
            }
        }

        #region help
        public void HelpDisplayaddHU()
        {
            if (!id.Text.Equals("My ID is...") && !id.Text.Equals(""))
                if (!family.Text.Equals("My Family Name is..") && !family.Text.Equals(""))
                    if (!Private.Text.Equals("My Private Name is..") && !Private.Text.Equals(""))
                        if (!mail.Text.Equals("someone@exemple.com") && !mail.Text.Equals(""))
                            if (!phonenumber.Equals("My Phone Number is...") && !phonenumber.Equals(""))

                            {
                                addhu.IsEnabled = true;
                                return;
                            }

            addhu.IsEnabled = false;
        }

        public void addtoHU()
        {
            if (id.Text != "")
            {
                HU3.Owner.HostKey = id.Text;

            }
            if (phonenumber.Text != "")
            {
                HU3.Owner.PhoneNumber = phonenumber.Text;

            }
            HU3.Owner.FamilyName = family.Text;
            HU3.Owner.PrivateName = Private.Text;
            HU3.Owner.MailAddress = mail.Text;
        }
        #endregion

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

    }


}
