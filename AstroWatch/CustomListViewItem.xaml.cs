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

namespace AstroWatch
{
    /// <summary>
    /// Interaction logic for CustomListViewItem.xaml
    /// </summary>
    public partial class CustomListViewItem : UserControl
    {
        public CustomListViewItem()
        {
            InitializeComponent();
            tt_home.Visibility = Visibility.Visible;
        }
        private string text;

        public string ImageSource { get; set; }
        public string Text
        {
            set {
                text = value;
            }
            get {
                return text;
            }
        }


        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            //if (Tg_Btn.IsChecked == true)
            //{
            //    //tt_home.Visibility = Visibility.Collapsed;
            //    tt_contacts.Visibility = Visibility.Collapsed;
            //    tt_messages.Visibility = Visibility.Collapsed;
            //    tt_maps.Visibility = Visibility.Collapsed;
            //    tt_settings.Visibility = Visibility.Collapsed;
            //    tt_signout.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    //tt_home.Visibility = Visibility.Visible;
            //    tt_contacts.Visibility = Visibility.Visible;
            //    tt_messages.Visibility = Visibility.Visible;
            //    tt_maps.Visibility = Visibility.Visible;
            //    tt_settings.Visibility = Visibility.Visible;
            //    tt_signout.Visibility = Visibility.Visible;
            //}
        }
    }
}
