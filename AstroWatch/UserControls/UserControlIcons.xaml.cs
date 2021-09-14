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
    /// Interaction logic for UserControlIcons.xaml
    /// </summary>
    public partial class UserControlIcons : UserControl
    {
         
        public UserControlIcons()
        {
            InitializeComponent();
           
           DataContext = this                  ;
             com = new  NavigationCommand();
        }
          public ICommand com { get; set; }


          public string Text { get; set; }
        public string ImageSource { get; set; }

       

       


     }
}
