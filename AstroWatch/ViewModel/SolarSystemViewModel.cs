using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroWatch.ViewModel
{
     public class SolarSystemViewModel : INotifyPropertyChanged
     {
          Model.ModelSolarSystem model;
          private string descriptionPlanet;
          public List<Planet> SolarSystemPlanets { get; set; }

          public event PropertyChangedEventHandler PropertyChanged;

          public SolarSystemViewModel()
          {
               model = new Model.ModelSolarSystem();
               SolarSystemPlanets = model.GetSolarSystem();
          }

          protected virtual void OnPropertyChanged(string propertyName)
          {
               PropertyChangedEventHandler handler = PropertyChanged;
               if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
          }

          public void setDescriptionPlanet(Planets nameOfPlanet)
          {
               DescriptionPlanet = model.getDescriptionPlanet(nameOfPlanet);
          }

          public string DescriptionPlanet
          {
               get
               {
                    if (descriptionPlanet == null)
                         descriptionPlanet = "default";
                    return descriptionPlanet;
               }
               set
               {
                    descriptionPlanet = value;
                    OnPropertyChanged("DescriptionPlanet");
               }
          }

     }
}
