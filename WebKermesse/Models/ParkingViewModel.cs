using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KermesseBO;

namespace WebKermesse.Models
{
    public class ParkingViewModel : ViewModel<Parking>
    {
        public ParkingViewModel()
        {
            this.Metier = new Parking();
        }

        public ParkingViewModel(Parking p)
        {
            this.Metier = p;
        }

        public String name
        {
            get { return this.Metier.name; }
            set { this.Metier.name = value; }
        }

        public string idJSON
        {
            get { return Metier.idJSON; }
            set { this.Metier.idJSON = value; }
        }

        public string status
        {
            get { return Metier.status; }
            set { this.Metier.status = value; }
        }
        public int max
        {
            get { return Metier.max; }
            set { this.Metier.max = value; }
        }
        public int free
        {
            get { return Metier.free; }
            set { this.Metier.free = value; }
        }

        public string lat
        {
            get { return Metier.lat; }
            set { this.Metier.lat = value; }
        }

        public string lng
        {
            get { return Metier.lng; }
            set { this.Metier.lng = value; }
        }

        /*public IEnumerable<SelectListItem> ListParking
        {
            get
            {
                return new SelectList(Services.ServiceParkings.GetAll(), "idJSON", "Libelle");
            }
        }*/

    }
}