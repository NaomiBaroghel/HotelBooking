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
    /// Logique d'interaction pour MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        Message mymessage = new Message();
        static IBL ibl = BLFactory.getBL();

        public MessageWindow()
        {
            InitializeComponent();
            mymessage = new Message();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChangedMessage(object sender, TextChangedEventArgs e)
        {
            HelpDisplaySend();
        }

        private void TextBox_TextChangedSubject(object sender, TextChangedEventArgs e)
        {
            HelpDisplaySend();
        }

        private void TextBox_TextChangedMail(object sender, TextChangedEventArgs e)
        {
            HelpDisplaySend();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addtoMessage();
                ibl.AddMessage(mymessage);
                MessageBox.Show("Message sent with success !");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region help
        private void HelpDisplaySend()
        {
            if (!name.Equals(null))
                if (!mail.Equals(null))
                    if (!subject.Equals(null))
                        if (!message.Equals(null))
                        {
                            send.IsEnabled = true;
                            return;
                        }
            send.IsEnabled = false;
        }
        private void addtoMessage()
        {
            mymessage.Name = name.Text;
            mymessage.MailAddress = mail.Text;
            mymessage.Subject = subject.Text;
            mymessage.message = message.Text;
        }
        #endregion

        private void TextBox_TextChangedName(object sender, TextChangedEventArgs e)
        {
            HelpDisplaySend();
        }
    }
}



