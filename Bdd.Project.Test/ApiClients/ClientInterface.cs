using Bdd.Project.Test.Models;
using Bdd.Project.Test.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using OpenWeatherApi;
using System.Configuration;

namespace Bdd.Project.Test.ApiClients
{
    public class ClientInterface
    {
        public static WeatherResponseModel weather;
        private static string AppId = ConfigurationManager.AppSettings["ApiAppId"];
        public WeatherResponseModel GetCurrentWeather(string lat, string lon)
        {
            Client client = new Client(new HttpClient());
            var response = client.CurrentWeatherDataAsync(q: "", id: "", lat: lat, lon: lon, zip: "", units: Units.Metric, lang: Lang.En, mode: Mode.Json, AppId: AppId).Result;
            weather = new WeatherResponseModel()
            {
                current = new Current()
                {
                    temp = response.Main.Temp
                }
            };
            return weather;
        }
    }
}
