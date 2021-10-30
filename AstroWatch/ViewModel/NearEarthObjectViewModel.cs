using AstroWatch.Commands;
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
using System.Windows;
using System.Windows.Input;

namespace AstroWatch.ViewModel
{
     class NearEarthObjectViewModel
          : INotifyPropertyChanged

     {

          public ICommand Filter { get; set; }
          public event PropertyChangedEventHandler PropertyChanged;
          NearEarthObjectModel model = new NearEarthObjectModel();
          public NearEarthObjectViewModel()
          {
               Filter = new FilterCommand(this);
          }

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
          public async void SearcNEO(string start, string end, double diameter)
          {
               NearEarthObj = await model.GetNearEarthObject(start, end, diameter);
          }
          public void Hazardonly(bool b = false)
          {

               if (model.neoList!=null)
               {

                    if (b)
                    {
                         NearEarthObj = model.neoList.Where(X => X.Hazardous == true).ToList();
                    }
                    else
                    {

                         NearEarthObj = model.neoList.ToList();
                    }
               }
          


          }


          protected void OnPropertyChanged([CallerMemberName] string name = null)
          {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
          }
     }
}
