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
        ImageOfTheDay imageOfTheDay;
        public ViewModelHome()
        {
            model = new Model.ModelHome();
            imageOfTheDay = Task.Run(() => model.GetImageOfTheDay()).Result;
        }

        public string urlImage
        {
            get
            {
                return imageOfTheDay.url;
            }
        }

        public string Title
        {
            get
            {
                return imageOfTheDay.title;
            }
        }

        public string Explanation
        {
            get
            {
                return imageOfTheDay.explanation;
            }
        }

    }
}
