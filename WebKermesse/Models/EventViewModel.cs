using KermesseBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebKermesse.Models
{
    public class EventViewModel : ViewModel<Event>
    {
        public EventViewModel()
        {
            this.Metier = new Event();
            this.Metier.Theme = new Theme() { ID = Guid.Empty };
            this.Metier.Address = new PostalAddress() { ID = Guid.Empty };
            this.Metier.Picture = new Picture() { ID = Guid.Empty };
        }
        public EventViewModel(Event e)
        {
            this.Metier = e;
        }

        public String Libelle
        {
            get { return Metier.Libelle; }
            set { this.Metier.Libelle = value; }
        }
        public String Description
        {
            get { return Metier.Description; }
            set { this.Metier.Description = value; }
        }
        public DateTime StartDate
        {
            get { return Metier.StartDate; }
            set { this.Metier.StartDate = value; }
        }
        public DateTime EndDate
        {
            get { return Metier.EndDate; }
            set { this.Metier.EndDate = value; }
        }

        public Guid ThemeId
        {
            get { return Metier.Theme.ID; }
            set { this.Metier.Theme.ID = value; }
        }

        public Guid AddressId
        {
            get { return Metier.Address.ID; }
            set { this.Metier.Address.ID = value; }
        }

        public String StreetAddress
        {
            get { return Metier.Address.Street; }
            set { this.Metier.Address.Street = value; }
        }

        public String PostalCodeAddress
        {
            get { return Metier.Address.PostalCode; }
            set { this.Metier.Address.PostalCode = value; }
        }

        public String CityAddress
        {
            get { return Metier.Address.City; }
            set { this.Metier.Address.City = value; }
        }
        public IEnumerable<SelectListItem> ListThemes { get; set; }
        public IEnumerable<Event> ListEventAVenir { get; set; }
    }
}