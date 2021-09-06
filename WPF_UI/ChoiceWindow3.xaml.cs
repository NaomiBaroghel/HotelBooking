using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Logique d'interaction pour ChoiceWindow3.xaml
    /// </summary>
    public partial class ChoiceWindow3 : Window
    {
        static IBL ibl = BLFactory.getBL();
        Order myorder = new Order();
        HostingUnit previoushu = new HostingUnit();
        PasswordMailWindow passwordwindow;
        Thread thr;
        public ChoiceWindow3(Order order,HostingUnit hu)
        {
            InitializeComponent();
            myorder = order;
            previoushu = hu;
            MessageBox.Show(hu.Owner.MailAddress);
        }
        public ChoiceWindow3()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                thr = new Thread(addOrder);
                thr.Start();


                while(thr.IsAlive)
                { }
                for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
                    App.Current.Windows[intCounter].Close();
                new CreateOrderWindow(previoushu).Show();
                App.Current.Windows[0].Close();

            }
            catch (BLException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addOrder()
        {
            //try
            //{
                Thread thr2 = new Thread(CheckMail);
                thr2.SetApartmentState(ApartmentState.STA);
                thr2.Start();
                thr2.Join();

                ibl.AddOrder(myorder);
                MessageBox.Show("Order made with success !");
                if (passwordwindow.flag == false)
                {
                    previoushu.Owner.passwordMail = "";
                }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void CheckMail()
        {
            if (previoushu.Owner.passwordMail == "" || previoushu.Owner.passwordMail == null)
            {
                passwordwindow = new PasswordMailWindow(previoushu);
                passwordwindow.ShowDialog();
                MessageBox.Show(previoushu.Owner.MailAddress);
                MessageBox.Show(previoushu.Owner.passwordMail);

            }
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }
    }
}
