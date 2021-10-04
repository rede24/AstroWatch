using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Bl
    {
        DAL.Dal dal = new DAL.Dal();
        public async Task<ImageOfTheDay> GetImageOfTheDay()
        {
            return await dal.GetImageOfTheDayFromNASAApi();
        }

        public string getDescriptionPlanet(Planets nameOfPlanet)
        {
            return dal.getDescriptionPlanet(nameOfPlanet);
        }

        public async Task<List<string>> GetSearchResult(string search)
        {
            return await dal.GetSearchResult(search);
        }
    }
}