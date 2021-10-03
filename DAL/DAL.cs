using BE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal
    {
        const string APIKEY = "js4BJax4nac2gMLpPtK0IUEOHg5uDyPsLT5dcFGh";
        public async Task<ImageOfTheDay> GetImageOfTheDayFromNASAApi()
        {
            ImageOfTheDay myDeserializedClass = null;
            string request = $"https://api.nasa.gov/planetary/apod?api_key={APIKEY}";


            // Create a New HttpClient object.
            HttpClient client = new HttpClient();

            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                HttpResponseMessage response = await client.GetAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                myDeserializedClass = JsonConvert.DeserializeObject<ImageOfTheDay>(responseBody);


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            // Need to call dispose on the HttpClient object
            // when done using it, so the app doesn't leak resources
            client.Dispose();

            return myDeserializedClass;
        }

        public string getDescriptionPlanet(Planets nameOfPlanet)
        {
            switch (nameOfPlanet)
            {
                case Planets.Mercury:
                    return "aaaa";                    
                case Planets.Venus:
                    return "bbb";                    
                case Planets.Earth:
                    return "ccc";
                case Planets.Mars:
                    return "ddd";
                case Planets.Jupiter:
                    return "eee";
                case Planets.Saturn:
                    return "fff";
                case Planets.Uranus:
                    return "ggg";
                case Planets.Neptune:
                    return "hhh";                    

                default:
                    return "default";
            }
        }
    }
}
