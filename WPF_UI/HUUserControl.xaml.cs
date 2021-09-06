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
    /// Logique d'interaction pour HUUserControl.xaml
    /// </summary>
    public partial class HUUserControl : UserControl
    {
        
        public HUUserControl(HostingUnit HU)
        {
            InitializeComponent();
            
            Image.Source = new BitmapImage(new Uri(HU.ImageSource, UriKind.RelativeOrAbsolute));
            video.Source = new Uri(HU.VideoSource, UriKind.RelativeOrAbsolute);
            //video.Play();

            
            printproterties(HU);


        }

        #region help
        private void printproterties(HostingUnit HU)
        {
            id.Text += HU.HostingUnitKey;
            name.Text += HU.HostingUnitName;
            area.Text += HU.area.ToString();
            subarea.Text += HU.subArea.ToString();
            typetxt.Text += HU.type.ToString();
            rooms.Text += HU.Rooms.ToString();
            beds.Text += HU.Beds.ToString();
            price.Text += HU.pricePerNight.ToString() + HU.typemoney.ToString();
            kasherouttxt.Text += HU.kasherout.ToString();



            if (HU.Pool == true)
                properties.Text += "Pool        ";
            if (HU.poolseparated == true)
                properties.Text += "Pool Separated \r\n";
            if (HU.Jacuzzi == true)
                properties.Text += "Jacuzzi       ";
            if (HU.Garden == true)
                properties.Text += "Garden \r\n";
            if (HU.ChildrenAttractions == true)
                properties.Text += "Children Attraction     ";
            if (HU.Sea == true)
                properties.Text += "Sea \r\n";
            if (HU.Mountain == true)
                properties.Text += "Mountain       ";
            if (HU.BetHabbad == true)
                properties.Text += "Bet Habbad \r\n";
            if (HU.Super == true)
                properties.Text += "Super ";

     
    }
        #endregion

        private void vbImage_MouseLeave(object sender, MouseEventArgs e)
        {
            vbimage.Width = 200;
            vbimage.Height = 200;
        }
        private void vbImage_MouseEnter(object sender, MouseEventArgs e)
        {
            vbimage.Width = this.Width / 3;
            vbimage.Height = this.Height /3;
        }
    }
}
