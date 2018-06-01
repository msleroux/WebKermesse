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
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            List<EventViewModel> eventsVM = new List<EventViewModel>();
            List<Event> events = ServiceEvents.GetAll();
            foreach(Event e in events)
            {
                eventsVM.Add(new EventViewModel(e));
            }
            return View(eventsVM);
        }

        // GET: Events/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            //Création d'un Event avec des valeurs par défaut
            Event e = new Event() { ID = Guid.Empty, Libelle = "Saisir un libellé", Description = "Saisir une description", StartDate = DateTime.Today, EndDate = DateTime.Today };
            e.Theme = new Theme() { ID = Guid.Empty };
            e.Address = new PostalAddress() { ID = Guid.Empty };
            //Insertion dans une SelectListe les informations des Thèmes présent en BDD
            SelectList listeThemes = new SelectList(ServiceThemes.GetAll(), "ID", "Libelle");
            //Instanciation de ViewModel avec l'event
            EventViewModel eVM = new EventViewModel(e);
            //Insertion de la SelectList dans le ViewModel
            eVM.ListThemes = listeThemes;
            return View(eVM);
        }

        // POST: Events/Create
        [HttpPost]
        public ActionResult Create(EventViewModel eVM)
        {
            try
            {
                //Création d'un event à partir du ViewModel
                Event e = new Event { ID = Guid.NewGuid(), Libelle = eVM.Libelle, Description = eVM.Description, StartDate = eVM.StartDate, EndDate = eVM.EndDate };
                e.Address = new PostalAddress() { ID = Guid.NewGuid(), Libelle = "Adresse évent: " + e.Libelle, Street = eVM.StreetAddress, PostalCode = eVM.PostalCodeAddress, City = eVM.CityAddress };
                ServiceEvents.Insert(e,eVM.ThemeId);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(eVM);
            }
        }

        // GET: Events/Edit/5
        public ActionResult Edit(Guid id)
        {
            //Récupération des infos de l'event
            Event e = ServiceEvents.GetById(id);
            if(e.Address == null)
            {
                e.Address = new PostalAddress() { ID = Guid.Empty };
            }
            //Insertion dans une SelectListe les informations des Thèmes présent en BDD
            List<Theme> themes = ServiceThemes.GetAll();
            SelectList listeThemes = new SelectList(ServiceThemes.GetAll(), "ID", "Libelle");
            //Sélection dans la selectList de l'item qui correspond au thème enregistré avant modification
            foreach (var item in listeThemes)
            {
                if(item.Text == e.Theme.Libelle)
                {
                    item.Selected = true;
                    break;
                }
            }
            //Instanciation de ViewModel avec l'event
            EventViewModel eVM = new EventViewModel(e);
            //Insertion de la SelectList dans le ViewModel
            eVM.ListThemes = listeThemes;
            return View(eVM);
        }

        // POST: Events/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, EventViewModel eVM)
        {
            try
            {
                Event e = new Event { ID = id, Libelle = eVM.Libelle, Description = eVM.Description, StartDate = eVM.StartDate, EndDate = eVM.EndDate };
                if (eVM.AddressId == Guid.Empty)
                {
                    e.Address = new PostalAddress() { ID = Guid.NewGuid(), Libelle = "Adresse évent: " + e.Libelle, Street = eVM.StreetAddress, PostalCode = eVM.PostalCodeAddress, City = eVM.CityAddress };
                }
                else
                {
                    e.Address = new PostalAddress() { ID = eVM.AddressId, Libelle = "Adresse évent: " + e.Libelle, Street = eVM.StreetAddress, PostalCode = eVM.PostalCodeAddress, City = eVM.CityAddress };
                }
                ServiceEvents.Update(e, eVM.ThemeId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(eVM);
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Events/Delete/5
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
