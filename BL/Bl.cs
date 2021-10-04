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

        public async Task<Dictionary<string, string>> GetSearchResult(string search)
        {

            Dictionary<string, string> listImagesAndDescription = await dal.GetSearchResult(search);
            Dictionary<string, string> res = new Dictionary<string, string>();
            Parallel.ForEach(listImagesAndDescription.Keys, image =>
             {
                 TagResult tag = dal.TagImage(image);
                 if (tag.result != null)
                 {
                     if (tag.result.tags.Any((x) => x.confidence > 80.0 && x.tag.en == "planet"))
                     {
                         res.Add(image, listImagesAndDescription[image]);
                     }

                 }



             });

            return res;
        }
    }
}