using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace DwollaExercise
{
    public class API
    {
        //instance variables
        private string strBaseAddress = "http://api.openweathermap.org/data/2.5/weather";
        private string strKey = "427e5bff4ad0fb97c3a6ee7394f0220a";

        //Constructor
        public API(string location)
        {
            Location = location;
            CallWebAPI().Wait();
        }//end constructor

        //Methods
        public async Task<string> CallWebAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                //Set base URI for HTTP requests
                client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather");

                //Tells server to send data in JSON format
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Send request and await response from server
                HttpResponseMessage response = await client.GetAsync("?q=" + Location + "&APPID=" + strKey);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    CurrentWeather weather = response.Content.ReadAsAsync<CurrentWeather>().Result;

                    //Convert temperature from Kelvin to Fahrenheit
                    float temp = weather.main.temp * 1.8f - 459.67f;
                    string strTempFahrenheit = temp.ToString("n0");

                    //Display output
                    return "The temperature in " + weather.name + " is " + strTempFahrenheit + "°F. \n";
                }

                else
                {
                    return "Invalid city name. \n";
                }
            }//end using
        }//end CallWebAPI

        //Properties
        public string Location { get; set; }

        public string BaseAddress
        {
            get
            {
                return strBaseAddress;
            }

            set
            {
                strBaseAddress = value;
            }
        }

        public string Key
        {
            get
            {
                return strKey;
            }

            set
            {
                strKey = value;
            }
        }
    }
}
