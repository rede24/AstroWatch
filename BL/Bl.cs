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
        public async Task<List<NearEarthObject>> GetNearEarthObject(string start, string end)
        {
            NearEarthObjects nearEarthObject = await dal.GetNearEarthObject(start, end);
            var result = from s in nearEarthObject.near_earth_objects.Values
                         from q in s
                         select new NearEarthObject()
                         {
                             Id = q.id.ToString(),
                             Name = q.name,
                             Hazardous = q.is_potentially_hazardous_asteroid,
                             Diameter = q.estimated_diameter.meters.estimated_diameter_min,
                             Velocety = q.close_approach_data[0].relative_velocity.kilometers_per_hour,
                             MissDistance = q.close_approach_data[0].miss_distance.kilometers,
                             CloseApproach = q.close_approach_data[0].close_approach_date
                         };
            return result.ToList();
        }

        public async Task<Dictionary<string, string>> GetSearchResult(string search, bool debug = true)
        {

            Dictionary<string, string> listImagesAndDescription = await dal.GetSearchResult(search);
            Dictionary<string, string> res = new Dictionary<string, string>();           
            Parallel.ForEach(listImagesAndDescription.Keys, image =>
            {
                TagResult tag = dal.TagImage(image);
                if (tag.result != null)
                    if (tag.result.tags.Any((x) => x.confidence > 90.0 && x.tag.en == "planet"))
                        res.Add(image, listImagesAndDescription[image]);
            });
            
            return res;
        }
        public List<Planet> GetSolarSystem()
        {
            return dal.GetSolarSysytem();
        }
    }
}