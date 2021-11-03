using AstroWatch.Model;
using AstroWatch.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AstroWatch.Commands
{
    class FilterCommand : ICommand
    {
        NearEarthObjectViewModel nepmodel;
        public FilterCommand(NearEarthObjectViewModel m)
        {
            nepmodel = m;
        }
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
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool val = bool.Parse(parameter.ToString());
            if (val)
            {
                nepmodel.Hazardonly(true);

            }
            else
            {
                nepmodel.Hazardonly();
            }

        }
    }
}
