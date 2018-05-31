using KermesseBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebKermesse.Models
{
    public class EventViewModel : ViewModel<Event>
    {
        public EventViewModel()
        {
            this.Metier = new Event();
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
    }
}