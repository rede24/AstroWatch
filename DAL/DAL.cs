using BE;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
               string apiKey = "acc_dfa7a0e1220a57d";
               string apiSecret = "5f7ee7c67cf6cfb641b93e0cd2f9e3ba";


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

          public  async Task<NearEarthObjects> GetNearEarthObject(string start ,string end)
          {

           
               string link = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={start}&end_date={end}&api_key={APIKEY}";
               var r =  await  PerformHttpRequest<NearEarthObjects>(link);
               return r;


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




