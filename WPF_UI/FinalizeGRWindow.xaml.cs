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
    /// Logique d'interaction pour FinalizeGRWindow.xaml
    /// </summary>
    public partial class FinalizeGRWindow : Window
    {
        static IBL ibl = BLFactory.getBL();
        GuestRequest GR1 = new GuestRequest();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\Baroghel\source\repos\dotNet_Project_03_9361_6994\WpfApp3\WPF_UI\Images\mouseclick.wav"));

        public FinalizeGRWindow(GuestRequest gr)
        {
            InitializeComponent();
            GR1 = gr;
        }
        public FinalizeGRWindow()
        {
            InitializeComponent();
        }



        private void addrequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // player.PlaySync();
                ibl.AddGuestRequest(GR1);
                MessageBox.Show("Guest Request add with success !");
                new ChoiceWindow().ShowDialog();
            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message);


            }

        }

        #region help

        private void HelpDisplayAdd()
        {
            if (!family.Text.Equals("My Family Name is..") && !family.Text.Equals(""))
                if (!Private.Text.Equals("My Private Name is..") && !Private.Text.Equals(""))
                    if (!mail.Text.Equals("someone@exemple.com") && !mail.Text.Equals(""))
                    {
                        addrequest.IsEnabled = true;
                        return;
                    }

            addrequest.IsEnabled = false;
        }
        #endregion

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void TextBox_TextChangedMail(object sender, TextChangedEventArgs e)
        {
            GR1.MailAddress = mail.Text;
            HelpDisplayAdd();
        }

        private void TextBox_TextChangedPrivate(object sender, TextChangedEventArgs e)
        {
            GR1.PrivateName = Private.Text;
            HelpDisplayAdd();
        }

        private void TextBox_TextChangedFamily(object sender, TextChangedEventArgs e)
        {
            GR1.FamilyName = family.Text;
            HelpDisplayAdd();
        }

        private void newsletter_Checked(object sender, RoutedEventArgs e)
        {
            GR1.Newsletter = true;
        }
        private void newsletter_Unchecked(object sender, RoutedEventArgs e)
        {
            GR1.Newsletter = false;
        }

        #region enterleave
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
