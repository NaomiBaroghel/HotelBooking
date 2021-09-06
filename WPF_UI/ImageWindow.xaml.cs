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
    /// Logique d'interaction pour ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        HostingUnit HU5 = new HostingUnit();
        public ImageWindow(HostingUnit hu)
        {
            InitializeComponent();
            HU5 = hu;
        }
        public ImageWindow()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void searchfile_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog f = new Microsoft.Win32.OpenFileDialog();
            f.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            f.ShowDialog();
            fileimage.Text = f.FileName;
            

        }

        private void TextBox_TextChangedfileimage(object sender, TextChangedEventArgs e)
        {
            HU5.ImageSource = @fileimage.Text;
        }

        private void TextBox_TextChangedurl(object sender, TextChangedEventArgs e)
        {
            if (url.Text != "https://...")
                HU5.ImageSource = @url.Text;
        }


        private void urlenter(object sender, EventArgs e)
        {
            if (url.Text == "https://...")
            {
                url.Text = "";
                url.Foreground = new SolidColorBrush(Colors.Black);
                url.FontStyle = FontStyles.Normal;
            }
        }
        private void urlleave(object sender, EventArgs e)
        {
            if (url.Text == "")
            {
                url.Text = "https://...";
                url.Foreground = new SolidColorBrush(Colors.Gray);
                url.FontStyle = FontStyles.Italic;
            }

        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
