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

namespace AstroWatch.Pages
{
     /// <summary>
     /// Interaction logic for SolarSystem.xaml
     /// </summary>
     public partial class SolarSystem : Page
     {
          public SolarSystem()
          {
               InitializeComponent();
            //   ExampleCarouselControl.Width = 600;
            //   ExampleCarouselControl.Height = 0;
             //  ExampleCarouselControl.ReInitialize();

          }
          #region Carousel

          private void CarouselSpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
          {
               ExampleCarouselControl.RotationSpeed = e.NewValue;
          }

          private void LookdownOffsetSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
          {
               ExampleCarouselControl.LookDownOffset = e.NewValue;
               ExampleCarouselControl.SetElementPositions();
          }

          private void CarouselFadeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
          {
               ExampleCarouselControl.Fade = e.NewValue;
               ExampleCarouselControl.SetElementPositions();
          }

          private void CarouselScaleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
          {
               ExampleCarouselControl.Scale = e.NewValue;
               ExampleCarouselControl.SetElementPositions();
          }

          private void VerticalOrientationRadioButton_Checked(object sender, RoutedEventArgs e)
          {
               ExampleCarouselControl.Width = 0;
               ExampleCarouselControl.Height = 600;
               ExampleCarouselControl.ReInitialize();
          }

          private void HorizontalOrientationRadioButton_Checked(object sender, RoutedEventArgs e)
          {
               ExampleCarouselControl.Width = 600;
               ExampleCarouselControl.Height = 0;
               ExampleCarouselControl.ReInitialize();
          }

          private void ExampleCarouselControl_OnElementSelected(object sender)
          {
               //spherecontrol selected = examplecarouselcontrol.currentlyselected as spherecontrol;
               //if (currentlyselectedellipse != null)
               //     currentlyselectedellipse.fill = selected.spherefill;
               //if ((currentlyselectednametextblock != null) && (currentlyselectednameshadowtextblock != null))
               //{
               //     currentlyselectednametextblock.foreground = selected.spherefill;
               //     currentlyselectednametextblock.text = selected.name;
               //     currentlyselectednameshadowtextblock.text = selected.name;
               //}
          }

          #endregion
     }
}
