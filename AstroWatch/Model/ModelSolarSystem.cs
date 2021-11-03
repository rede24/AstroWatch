using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroWatch.Model
{
    public class ModelSolarSystem
    {
        BL.Bl bl;
        public ModelSolarSystem()
        {
            bl = new BL.Bl();
        }

        public List<Planet> GetSolarSystem()
        {
            return bl.GetSolarSystem();
        }
    }
}
