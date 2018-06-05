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
            List<Event> liste = new List<Event>();
            using(WebKContext context = new WebKContext())
            {
                var rqt = from Event e in context.Events orderby e.StartDate select e;
                foreach(Event e in rqt)
                {
                    liste.Add(e);
                }
            }
            return liste;
        }

        public static Event GetById(Guid idEvent)
        {
            Event eventReturned = null;
            using(WebKContext context = new WebKContext())
            {
                var rqt = context.Events.Where(e => e.ID == idEvent).Include(e => e.Theme).Include(e => e.Address).Include(e => e.Picture);
                eventReturned = rqt.Single<Event>();
            }
            return eventReturned;
        }

        public static List<Event> GetByDate(DateTime startDate, DateTime endDate)
        {
            List<Event> liste = null;
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
            return liste;
        }

        /*public static List<Event> GetByTheme(Guid idTheme)
        {
            List<Event> liste = null;
            using (WebKContext context = new WebKContext())
            {
                var rqt = from Event e in context.Events
                          where e.
            }
            return liste;
        }*/

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
                Event eventRetrieve = GetById(idEvent, context);
                if(eventRetrieve.Address != null)
                {
                    context.Adresses.Remove(eventRetrieve.Address);
                }
                if(eventRetrieve.Picture != null)
                {
                    context.Pictures.Remove(eventRetrieve.Picture);
                }
                context.Events.Remove(eventRetrieve);
                context.SaveChanges();
            }
        }

        private static Event Get(Guid idEvent, WebKContext context)
        {
            return context.Events.FirstOrDefault(e => e.ID == idEvent);
        }

        private static Event GetById(Guid idEvent, WebKContext context)
        {
            Event eventReturned = null;
            var rqt = context.Events.Where(e => e.ID == idEvent).Include(e => e.Theme).Include(e => e.Address).Include(e => e.Picture);
            eventReturned = rqt.Single<Event>();
            return eventReturned;
        }
    }
}
