using AstroWatch.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AstroWatch.Pages
{
     /// <summary>
     /// Interaction logic for Page1.xaml
     /// </summary>
     public partial class DangerPage : Page
     {
          NearEarthObjectViewModel vm;
          public DangerPage()
          {
               InitializeComponent();
               vm = new NearEarthObjectViewModel();
               DataContext = vm;

          }

          private void Button_Click(object sender, RoutedEventArgs e)
          {
               var start = DateTime.Parse(startDate.Text).ToString("yyyy-MM-dd");
               var end = DateTime.Parse(endDate.Text).ToString("yyyy-MM-dd");
               double diameter = 0;
               if (txtDiameter.Text!=null)
               {
                   double.TryParse(txtDiameter.Text,out diameter);
               }

               bool hazardous = is_potentially_hazardous_asteroid.IsChecked.Value;



               Task.Run(()=> vm.SearcNEO(start, end, diameter));

         
              
          }

       
     }
}
