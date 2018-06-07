using KermesseBO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebKermesse.Controllers
{
    public class ParkingController : ApiController
    {
        static string _address = "http://data.citedia.com/r1/parks";
        private string result;

        // GET api/values
        /*public async System.Threading.Tasks.Task<IEnumerable<string>> Get()
        {
            var result = await GetExternalResponse();

            return new string[] { result, "value2" };
        }

        private static async Task<string> GetExternalResponse()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_address);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }*/

        public void test()
        {
            HttpClient client = new HttpClient();

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("http://data.citedia.com/r1/parks").Result;
             
                if (response.IsSuccessStatusCode)
                {
                var json = response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<Parking>>(json);

                }

            }
         
    }
}
