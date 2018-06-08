using KermesseBO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebKermesse.Models;


namespace WebKermesse.Controllers
{
    public class ParkingController : Controller
    {

        private double yToLat(double y)
        {
            y = y / (20037508.34 / 180);
            double lat = ((Math.Atan(Math.Exp(y * (Math.PI /180) ))) / (Math.PI /360)) - 90;
            lat = Math.Round(lat, 8);
            return lat;
        }
        private double xToLon(double x)
        {
            double lon = (x * 180) / 20037508.34;
            lon = Math.Round(lon, 8);
            return lon;
        }


        public ActionResult Index()
        {
          
            string html = string.Empty;
            string url = @"http://data.citedia.com/r1/parks";

            //Requete sur l'url 
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.AutomaticDecompression = DecompressionMethods.GZip;
            
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //Lecture du flux de réponse
            using (Stream stream = response.GetResponseStream())
            
            //Cast en string du flux 
            using (StreamReader reader = new StreamReader(stream))

            {
                html = reader.ReadToEnd();

            }

            // Une string... mais on veut un JSON !
            JObject parkings = JObject.Parse(html);

            //Création de la liste des Parkings à partir du JsonObject
           List<Parking> listParks = new List<Parking>();
                    
            for (int i = 0; i < parkings["parks"].Count(); i++)
            {
                Parking p = new Parking();
                
                p.name = (string) parkings["parks"][i]["parkInformation"]["name"];
                p.idJSON = (string) parkings["parks"][i]["id"];
                p.status = (string)parkings["parks"][i]["parkInformation"]["status"];
                p.lng = (xToLon((double)parkings["features"]["features"][i]["geometry"]["coordinates"][0])).ToString(CultureInfo.InvariantCulture);
                p.lat = (yToLat((double)parkings["features"]["features"][i]["geometry"]["coordinates"][1])).ToString(CultureInfo.InvariantCulture);
                p.max = (int) parkings["parks"][i]["parkInformation"]["max"];
                p.free = (int)parkings["parks"][i]["parkInformation"]["free"];

                listParks.Add(p);

            }

            List<ParkingViewModel> psVM = new List<ParkingViewModel>();
          
            foreach (Parking p in listParks)
            {
                psVM.Add(new ParkingViewModel(p));
            }

            return View(psVM);

        }

       

    }
}
