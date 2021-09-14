using AstroWatch.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AstroWatch
{
     class NavigationCommand : ICommand
     {
          event EventHandler ICommand.CanExecuteChanged
          {
               add
               {
                    CommandManager.RequerySuggested += value;
               }

               remove
               {
                    CommandManager.RequerySuggested -= value;
               }
          }

          bool ICommand.CanExecute(object parameter)
          { return true;
          }

          void ICommand.Execute(object parameter)
          {
               string page = parameter as string;
               MessageBox.Show(page);
       
               switch (page)
               {
                    case "Home" : 
                               MainWindow.CurrentPage.Content =
                      new HomePage();

                         break;
                    case "SolarSystem":
                         MainWindow.CurrentPage.Content =
                      new SolarSystem();

                         break;
                    case "Search":
                         MainWindow.CurrentPage.Content =
                       new Search();

                         break;
                    case "Show planets":
                         MainWindow.CurrentPage.Content =
                       new DangerPage();

                         break;



               }


          }
     }
}
