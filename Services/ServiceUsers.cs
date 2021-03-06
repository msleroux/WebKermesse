﻿using KermesseBO;
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
        public static List<ApplicationUser> GetAll()
        {
            List<ApplicationIdentity> liste = null;
            using(WebKContext context = new WebKContext())
            {
                liste = context.AspNetUsers.ToList<ApplicationIdentity>
                   
            }
            return liste;
        }

        public static Event GetById(Guid idEvent)
        {
            Event eventReturned = null;
            using(WebKContext context = new WebKContext())
            {
                eventReturned = context.Events.FirstOrDefault(e => e.ID == idEvent);
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

        public static void Insert(Event eventToAdd)
        {
            using (WebKContext context = new WebKContext())
            {
                context.Events.Add(eventToAdd);
                context.SaveChanges();
            }
        }

        public static void Update(Event eventToUpdate)
        {
            using (WebKContext context = new WebKContext())
            {
                Event eventRetrieve = Get(eventToUpdate.ID, context);
                eventRetrieve.Libelle = eventToUpdate.Libelle;
                eventRetrieve.Description = eventToUpdate.Description;
                eventRetrieve.Address = eventToUpdate.Address;
                eventRetrieve.StartDate = eventToUpdate.StartDate;
                eventRetrieve.EndDate = eventToUpdate.EndDate;
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
