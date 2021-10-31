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
         public List<NearEarthObject> neoList;



        public async Task<List<NearEarthObject>> GetNearEarthObject(string start, string end, double diameter)
        {
               neoList=(from s in await bl.GetNearEarthObject(start, end)
                    where s.Diameter > diameter 
                    select s).ToList();
               return neoList;


        }

     }
}
