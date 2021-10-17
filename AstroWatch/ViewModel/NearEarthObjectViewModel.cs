using AstroWatch.Model;
using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AstroWatch.ViewModel
{
     class NearEarthObjectViewModel
          : INotifyPropertyChanged

     {
          public event PropertyChangedEventHandler PropertyChanged;
          NearEarthObjectModel model = new NearEarthObjectModel();

        private List<NearEarthObject> nearEarthObj;
         public List<NearEarthObject> NearEarthObj
        {
            get
            {
                return nearEarthObj;
            }
            set
            {
                nearEarthObj = value;
                OnPropertyChanged("NearEarthObj");
            }
        }
        public void SearcjNEO(string start, string end, double diameter, bool hazardous)
        {
            NearEarthObj = model.GetNearEarthObject(start, end, diameter, hazardous);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
