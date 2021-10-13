using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace AstroWatch.Model
{
    public class ModelHome
    {
        BL.Bl bl;
        public ModelHome()
        {
            bl = new BL.Bl();
        }

        public Task<ImageOfTheDay> GetImageOfTheDay()
        {
            return bl.GetImageOfTheDay(); 
        }
    }

}
