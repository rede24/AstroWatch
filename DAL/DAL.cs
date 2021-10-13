using BE;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
     public class Dal
     {
          public Dal()
          {
               new Thread(() =>
               {
                    using (var dbcontext = new PlanetDB())

                    {


                         if (dbcontext.SolarSystem.ToList().Count == 0)
                         {
                              var a = JsonConvert.DeserializeObject<Dictionary<string, string>>(new StreamReader(@"../../../DAL/Description.json").ReadToEnd());
                              var link = "www.astrowatch-12d3a.appspot.com/Planets/";
                              dbcontext.SolarSystem.Add(new Planet() { Id = 1, Description = a["Mercury"], Name = "Mercury", Url = "https://firebasestorage.googleapis.com/v0/b/astrowatch-12d3a.appspot.com/o/Planets%2FMercury.png?alt=media&token=9368f0bf-89ba-4028-b344-3c4648261be5" });
                              dbcontext.SolarSystem.Add(new Planet() { Id = 2, Description = a["Venus"], Name = "Venus", Url = "https://firebasestorage.googleapis.com/v0/b/astrowatch-12d3a.appspot.com/o/Planets%2FVenus.png?alt=media&token=4207ead0-daec-4d1d-a34f-a37a59e1698f" });
                              dbcontext.SolarSystem.Add(new Planet() { Id = 3, Description = a["Earth"], Name = "Earth", Url = "https://firebasestorage.googleapis.com/v0/b/astrowatch-12d3a.appspot.com/o/Planets%2FEarth.png?alt=media&token=0456b7fa-5818-42c2-8157-407d147604d6" });
                              dbcontext.SolarSystem.Add(new Planet() { Id = 4, Description = a["Mars"], Name = "Mars", Url = "https://firebasestorage.googleapis.com/v0/b/astrowatch-12d3a.appspot.com/o/Planets%2FMars.png?alt=media&token=2fcd6f2d-7658-4d0c-b71b-69c0396c792f" });
                              dbcontext.SolarSystem.Add(new Planet() { Id = 5, Description = a["Jupiter"], Name = "Jupiter", Url = "https://firebasestorage.googleapis.com/v0/b/astrowatch-12d3a.appspot.com/o/Planets%2FJupiter.png?alt=media&token=9fad61cf-2abd-4292-9f3d-a2ebd0f78f95" });
                              dbcontext.SolarSystem.Add(new Planet() { Id = 6, Description = a["Saturn"], Name = "Saturn", Url = "https://firebasestorage.googleapis.com/v0/b/astrowatch-12d3a.appspot.com/o/Planets%2FSaturn.png?alt=media&token=30f888e6-66f7-4bdd-9d4a-61ab34a85755" });
                              dbcontext.SolarSystem.Add(new Planet() { Id = 7, Description = a["Uranus"], Name = "Uranus", Url = "https://firebasestorage.googleapis.com/v0/b/astrowatch-12d3a.appspot.com/o/Planets%2FUranus.png?alt=media&token=c9bece5e-0d27-4438-9ade-56a03224079b" });
                              dbcontext.SolarSystem.Add(new Planet() { Id = 8, Description = a["Neptune"], Name = "Neptune", Url = "https://firebasestorage.googleapis.com/v0/b/astrowatch-12d3a.appspot.com/o/Planets%2FNeptune.png?alt=media&token=b8704a38-772d-40ea-8f45-958f3fae403a" });
                              dbcontext.SaveChanges();
                         }


                    }
               })


               .Start();


          }
          const string APIKEY = "js4BJax4nac2gMLpPtK0IUEOHg5uDyPsLT5dcFGh";
          public async Task<ImageOfTheDay> GetImageOfTheDayFromNASAApi()
          {
               string request = $"https://api.nasa.gov/planetary/apod?api_key={APIKEY}";
               var res = await PerformHttpRequest<ImageOfTheDay>(request);
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

          public async Task<Dictionary<string, string>> GetSearchResult(string search)
          {
               string request = $"https://images-api.nasa.gov/search?q={search}";
               var res = await PerformHttpRequest<SearchResult>(request);
               Dictionary<string, string> valuePairs = new Dictionary<string, string>();
               foreach (Item i in res.collection.items)
               {
                    if (i.links != null)
                    {
                         valuePairs.Add(i.links.FirstOrDefault().href, i.data[0].description);
                    }
               }
               return valuePairs;

          }


          public TagResult TagImage(string urlImage)
          {
               string apiKey = "acc_f264781849c7c63";
               string apiSecret = "4007359eabd9d3f72c47c0a75ce79ae7";


               string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

               var client = new RestClient(String.Format("https://api.imagga.com/v2/tags"));
               client.Timeout = -1;

               var request = new RestRequest(Method.GET);
               request.AddParameter("image_url", urlImage);
               request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

               IRestResponse response = client.Execute(request);
               var tagResult = JsonConvert.DeserializeObject<TagResult>(response.Content);


               return tagResult;
          }

          public async Task<NearEarthObjects> GetNearEarthObject(string start, string end)
          {


               string link = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={start}&end_date={end}&api_key={APIKEY}";
               var r = await PerformHttpRequest<NearEarthObjects>(link);
               return r;


          }
          public List<Planet> GetSolarSysytem()
          {
               using (var ctx = new PlanetDB())
               {
                    return ctx.SolarSystem.ToList();


               }
          }
          private async Task<T> PerformHttpRequest<T>(String requestLink)
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

          }

          //private async Task<T> GetNearEarthObject<T>(String requestLink)
          //{
          //     T searchResult = default(T);



          //     // Create a New HttpClient object.
          //     HttpClient client = new HttpClient();

          //     // Call asynchronous network methods in a try/catch block to handle exceptions
          //     try
          //     {
          //          HttpResponseMessage response = await client.GetAsync(requestLink);
          //          response.EnsureSuccessStatusCode();
          //          string responseBody = await response.Content.ReadAsStringAsync();
          //          // Above three lines can be replaced with new helper method below
          //          // string responseBody = await client.GetStringAsync(uri);

          //          searchResult = JsonConvert.DeserializeObject<T>(responseBody);


          //     }
          //     catch (HttpRequestException e)
          //     {
          //          Console.WriteLine("\nException Caught!");
          //          Console.WriteLine("Message :{0} ", e.Message);
          //     }

          //     // Need to call dispose on the HttpClient object
          //     // when done using it, so the app doesn't leak resources
          //     client.Dispose();

          //     return searchResult;

          //}
     }

}




