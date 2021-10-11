using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace AstroWatch.Model
{
     class NearEarthObjectModel
     {
          Bl bl = new Bl();

          public List<NearEarthObject> GetNearEarthObject(string start, string end, double diameter, bool hazardous)
          {
               return (from s in Task.Run(()=>bl.GetNearEarthObject(start, end)).Result
                      where s.Diameter > diameter && s.Hazardous == hazardous 
                       select s).ToList();
          }
     }
}
