using DND_Encounter_WebApp_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DND_Encounter_WebApp_MVC.Controllers
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    //JSON translation classes:
    public class Result
    {
        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Root
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }


    //Controller:
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            client.BaseAddress = new Uri("https://www.dnd5eapi.co/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        static async Task<Root> GetMonstersAsync(string min, string max)
        {
            string path = $"monsters?challenge_rating=2,{min.ToString()},{max.ToString()}";

            Root jsonReturn = null;
            List<MonsterModel> monsters = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                jsonReturn = await response.Content.ReadAsAsync<Root>();
            }
            else
            {
                Console.WriteLine("oops I broke :(");
            }
            return jsonReturn;
        }

        public async void FormSubmit(string CR_Min_Value, string CR_Max_Value)
        {
            Root json = await GetMonstersAsync(CR_Min_Value, CR_Max_Value);
            foreach(var o in json.Results)
            {
                Debug.WriteLine(o.Name);
            }
        }
    }
}
