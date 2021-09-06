using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IBL ibl = BLFactory.getBL();

        System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\Baroghel\source\repos\dotNet_Project_03_9361_6994\WpfApp3\WPF_UI\Images\pinson.wav"));
        bool sound = true;

        public MainWindow()
        {

            InitializeComponent();
            player.PlayLooping();


            try
            {
                Thread thr = new Thread(ibl.SendNewsletter);
                thr.IsBackground = true;
                thr.Start();

                Thread thr2 = new Thread(ibl.CheckExpirationOrder);
               // thr2.Start();
                Thread thr3 = new Thread(ibl.CheckExpirationGuestRequest);
              //  thr3.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void client_Click(object sender, RoutedEventArgs e)
        {
            new AddGRWindow().Show();
            Close();
        }

        private void hostingunit_Click(object sender, RoutedEventArgs e)
        {


            new HUWindow().Show();
            Close();
        }

        private void webmaster_Click(object sender, RoutedEventArgs e)
        {

            new PasswordWindow().ShowDialog();

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
                App.Current.Windows[intCounter].Close();
            new ByeByeWindow().Show();
            App.Current.Windows[0].Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.housebeautiful.com/");
        }

        private void contact_Click(object sender, RoutedEventArgs e)
        {
            new MessageWindow().ShowDialog();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            if (sound == true)
            {
                player.Stop();
                play.Content = "Music Play";
                sound = false;
            }
            else
            {
                player.PlayLooping();
                play.Content = "Music Stop";
                sound = true;
            }
        }

    }
}
