using KermesseBO;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebKermesse.Models;

namespace WebKermesse.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            //List<EventViewModel> eventsVM = new List<EventViewModel>();
            List<Event> events = ServiceEvents.GetAllWithAddress();
            List<String> name = new List<String>();
            List<String> address = new List<String>();
            List<String> idEvent = new List<String>();
            foreach (Event e in events)
            {
                if(e.Address != null)
                {
                    name.Add(e.Libelle);
                    address.Add(e.Address.Street + ' ' + e.Address.PostalCode + ' ' + e.Address.City);
                    idEvent.Add(e.ID.ToString());
                }
                //eventsVM.Add(new EventViewModel(e));
            }
            ViewData["ListNameEvent"] = name.ToArray();
            ViewData["ListAddressEvent"] = address.ToArray();
            ViewData["ListIdEvent"] = idEvent.ToArray();


            return View();
        }

        // GET: Map/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Map/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Map/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Map/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Map/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Map/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Map/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
