using AstroWatch.ViewModel;
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
    /// Interaction logic for testpage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        ViewModelHome ViewModel = new ViewModelHome();
        Transform transform;
        int numberOfZoom = 0;
        public HomePage()
        {
            InitializeComponent();
            DataContext = ViewModel;

            transform = new MatrixTransform(image.RenderTransform.Value); // init matrix to default location
        }

        //Zoom by mouse wheel on image
        private void image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var matrix = image.RenderTransform.Value;

            numberOfZoom += e.Delta;

               if (numberOfZoom == 0)
               {
                    matrix = transform.Value;

               }
               else if (numberOfZoom < 0)
               {
                    numberOfZoom = 0;
                    return;
               }

               else if (e.Delta > 0)
               {
                    matrix.ScaleAt(1.5, 1.5, e.GetPosition(this).X, e.GetPosition(this).Y);
               }
               else
               {
                    matrix.ScaleAt(1.0 / 1.5, 1.0 / 1.5, e.GetPosition(this).X, e.GetPosition(this).Y);
               }

            image.RenderTransform = new MatrixTransform(matrix);
        }
    }
}
