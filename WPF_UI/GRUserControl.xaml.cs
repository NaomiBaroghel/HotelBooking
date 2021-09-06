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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Logique d'interaction pour GRUserControl.xaml
    /// </summary>
    public partial class GRUserControl : UserControl
    {
        public GRUserControl(GuestRequest gr)
        {
            InitializeComponent();
            printproterties(gr);
        }

        private void printproterties(GuestRequest GR)
        {
            id.Text += GR.GuestRequestKey;
            family.Text += GR.FamilyName;
            Private.Text += GR.PrivateName;
            mail.Text += GR.MailAddress;
            enterday.Text = GR.EntryDate.Date.ToString();
            releaseday.Text = GR.ReleaseDate.Date.ToString();
            area.Text += GR.area.ToString();
            subarea.Text += GR.subArea.ToString();
            type.Text += GR.type.ToString();
            kasherout.Text += GR.kasherout.ToString();
            rooms.Text += GR.Rooms.ToString();
            adults.Text += GR.Adults.ToString();
            children.Text += GR.Children.ToString();
            
            foreach(string s in GR.saladshabbat)
            {
                salad.Text += s + ", ";
            }

            if (GR.Car ==true)
                properties.Text += "Car \r\n";
            if (GR.Hiking == true)
                properties.Text += "Hiking \r\n";
           

            if (GR.Pool == Accord.yes)
            {
                properties.Text += "Pool \r\n";
                    if(GR.poolseparated == Accord.yes)
                {
                    properties.Text += "Pool Separated \r\n";
                }
                    else if(GR.poolseparated == Accord.dontcare)
                        properties.Text += "Pool Separated : Don't Care \r\n";
            }
            else if (GR.Pool == Accord.dontcare)
                properties.Text += "Pool : Don't Care \r\n";

            if (GR.Jacuzzi == Accord.yes)
                properties.Text += "Jacuzzi \r\n";
            else if (GR.Jacuzzi == Accord.dontcare)
                properties.Text += "Jacuzzi : Don't Care \r\n";

            if (GR.Garden == Accord.yes)
                properties.Text += "Garden \r\n";
            else if (GR.Garden == Accord.dontcare)
                properties.Text += "Garden : Don't Care \r\n";

            if (GR.ChildrenAttractions == Accord.yes)
                    properties.Text += "Children Attractions \r\n";
                else if (GR.ChildrenAttractions == Accord.dontcare)
                    properties.Text += "Children Attractions : Don't Care \r\n";

            if (GR.Sea == Accord.yes)
                properties.Text += "Sea \r\n";
            else if (GR.Sea == Accord.dontcare)
                properties.Text += "Sea : Don't Care \r\n";

            if (GR.Mountain == Accord.yes)
                properties.Text += "Mountain \r\n";
            else if (GR.Mountain == Accord.dontcare)
                properties.Text += "Mountain : Don't Care \r\n";

            if (GR.BetHabbad == Accord.yes)
                properties.Text += "Bet Habbad \r\n";
            else if (GR.BetHabbad == Accord.dontcare)
                properties.Text += "Bet Habbad : Don't Care \r\n";

            if (GR.Super == Accord.yes)
                properties.Text += "Super \r\n";
            else if (GR.Super == Accord.dontcare)
                properties.Text += "Super : Don't Care \r\n";
           


        }
    }
}
