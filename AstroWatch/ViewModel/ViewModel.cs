using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroWatch.ViewModel
{
    class ViewModelHome
    {
        Model.ModelHome model;

        public ViewModelHome()
        {
            model = new Model.ModelHome();            
        }

        public string urlImage
        {
            get
            {
                return Task.Run(() => model.imageOfTheDay).Result.url;
            }
        }      
    }
}
