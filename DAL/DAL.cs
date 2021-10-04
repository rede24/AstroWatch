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
            string request = $"https://api.nasa.gov/planetary/apod?api_key={APIKEY}";
            var res = await Util<ImageOfTheDay>.PerformHttpRequest(request);
            return res;
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

        public async Task<List<string>> GetSearchResult(string search)
        {            
            string request = $"https://images-api.nasa.gov/search?q={search}";
            var res = await Util<SearchResult>.PerformHttpRequest(request);
            List<string> links = new List<string>();
            foreach (Item i in res.collection.items)
            {
                if (links.Count==10)
                {
                    break;
                }
               var res2 = await Util<List<string>>.PerformHttpRequest(i.href);
                if (res2 != null)
                    links.Add(res2[2]);
            }
            return links;


        }
       
   
        
        }
    class Util<T> {
        public static async Task<T> PerformHttpRequest(String requestLink)
    {
        T searchResult = default(T);



        // Create a New HttpClient object.
        HttpClient client = new HttpClient();

        // Call asynchronous network methods in a try/catch block to handle exceptions
        try
        {
            HttpResponseMessage response = await client.GetAsync(requestLink);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);

            searchResult = JsonConvert.DeserializeObject<T>(responseBody);


        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }

        // Need to call dispose on the HttpClient object
        // when done using it, so the app doesn't leak resources
        client.Dispose();

        return searchResult;

    } }
   

}

