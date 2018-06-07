using KermesseBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Services
{     // *********************************************************************

    public class ServiceParkings : ApiController
    {
        static string _address = "http://data.citedia.com/r1/";
        private static string result;


        // GET api/values
       /* public async Task<IEnumerable<string>> Get()
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
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("http://data.citedia.com/r1/parks").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("status ok");
                Console.WriteLine(response);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.ReadLine();
        }
      


    }
}