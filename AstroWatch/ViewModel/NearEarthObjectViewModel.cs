using AstroWatch.Model;
using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroWatch.ViewModel
{
     class NearEarthObjectViewModel
          : INotifyPropertyChanged

     {
          public event PropertyChangedEventHandler PropertyChanged;
          NearEarthObjectModel model = new NearEarthObjectModel();

          public List<NearEarthObject> NearEarthObj { get; set; }
          public void SearcjNEO(string s, string e)
          {

               NearEarthObj = model.GetNearEarthObject(s, e ,0 ,true);

          
          }



     }
}
