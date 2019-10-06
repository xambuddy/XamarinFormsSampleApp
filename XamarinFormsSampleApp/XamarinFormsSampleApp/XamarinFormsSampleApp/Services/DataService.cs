using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsSampleApp.Entities;

namespace XamarinFormsSampleApp.Services
{
    public class DataService
    {
        static HttpClient httpClient = new HttpClient();

        readonly string serverUrl = "https://api.nasa.gov";

        readonly string apiKey = "azigzxG1NOJoc060MjcIxLfknnKUWmkr6vOBAWA2";

        public async Task<PhotoOfTheDay> GetPhotoOfTheDayAsync()
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            var infoJson = await httpClient.GetStringAsync($"{serverUrl}/planetary/apod?api_key={apiKey}&date={dateToday}");

            var photoOfTheDay = JsonConvert.DeserializeObject<PhotoOfTheDay>(infoJson);

            return photoOfTheDay;
        }
    }
}
