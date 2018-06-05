using KermesseBO;
using KermesseDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceEvents
    {
        public static List<Event> GetAll()
        {
            List<Event> liste = null;
            using(WebKContext context = new WebKContext())
            {
                liste = context.Events.ToList<Event>();
            }
            return liste;
        }

        public static Event GetById(Guid idEvent)
        {
            Event eventReturned = null;
            using(WebKContext context = new WebKContext())
            {
                var rqt = context.Events.Where(e => e.ID == idEvent).Include(e => e.Theme).Include(e => e.Address);
                eventReturned = rqt.Single<Event>();
            }
            return eventReturned;
        }

        public static List<Event> GetByDate(DateTime startDate, DateTime endDate)
        {
            List<Event> liste = new List<Event>();
            using (WebKContext context = new WebKContext())
            {
                var rqt = from Event e in context.Events
                          where e.StartDate >= startDate
                          && e.EndDate <= endDate
                          orderby e.StartDate
                          select e;
                foreach(Event e in rqt)
                {
                    liste.Add(e);
                }
            }
           if(liste.Count() == 0)
            {
                liste = ServiceEvents.GetAll();
            }
            return liste;
        }

        public static List<Event> GetByLibelleByTheme(string textRecherche, Guid idTheme)
        {
            List<Event> results = new List<Event>();
            using (WebKContext context = new WebKContext())
            {
               
                if (idTheme != null)
                {
                    var rqt = context.Events.Where(Event => Event.Libelle.Contains(textRecherche) && Event.Theme.ID.Equals(idTheme));
                    foreach (Event e in rqt)
                    {
                        results.Add(e);
                    }
                }
                else
                {
                    var rqt = context.Events.Where(Event => Event.Libelle.Contains(textRecherche));
                    foreach (Event e in rqt)
                    {
                        results.Add(e);
                    }
                }
                                               
            }
            return results;
        }

        //renvoie la liste d'event en fonction d'un id theme
        public static List<Event> GetByTheme(Guid idTheme)
        {
            
            List<Event> liste = null;
            using (WebKContext context = new WebKContext())
            {
               var rqt = from Event e in context.Events
                          join Theme th in context.Themes
                          on e.Theme.ID equals th.ID
                          where e.Theme.ID == idTheme
                         select e;
            }
            return liste;
        }

        public static void Insert(Event eventToAdd, Guid idTheme)
        {
            using (WebKContext context = new WebKContext())
            {
                eventToAdd.Theme = context.Themes.FirstOrDefault(t => t.ID == idTheme);
                context.Events.Add(eventToAdd);
                context.SaveChanges();
            }
        }

        public static void Update(Event eventToUpdate, Guid idTheme)
        {
            using (WebKContext context = new WebKContext())
            {
                Event eventRetrieve = Get(eventToUpdate.ID, context);
                eventRetrieve.Libelle = eventToUpdate.Libelle;
                eventRetrieve.Description = eventToUpdate.Description;
                eventRetrieve.Address = eventToUpdate.Address;
                eventRetrieve.StartDate = eventToUpdate.StartDate;
                eventRetrieve.EndDate = eventToUpdate.EndDate;
                eventRetrieve.Theme = context.Themes.FirstOrDefault(t => t.ID == idTheme);
                context.SaveChanges();
            }
        }

        public static void Remove(Guid idEvent)
        {
            using (WebKContext context = new WebKContext())
            {
                Event eventRetrieve = Get(idEvent, context);
                context.Events.Remove(eventRetrieve);
                context.SaveChanges();
            }
        }

        private static Event Get(Guid idEvent, WebKContext context)
        {
            return context.Events.FirstOrDefault(e => e.ID == idEvent);
        }
    }
}
