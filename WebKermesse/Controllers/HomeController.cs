using KermesseBO;
using KermesseDAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebKermesse.Models;

namespace WebKermesse.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            /* initDataBdd();*/

            //Insertion dans une SelectListe les informations des Thèmes présent en BDD
            List<Event> listeEventAVenir = GetListAVenir();
            SelectList listeThemes = GetSelectListThemes();

            //Instanciation de ViewModel avec l'event
            EventViewModel eVM = new EventViewModel();
            //Insertion de la SelectList dans le ViewModel
            eVM.ListEventAVenir = listeEventAVenir;
            eVM.ListThemes = listeThemes;
            return View(eVM);
        }
        private SelectList GetSelectListThemes()
        {
            return new SelectList(ServiceThemes.GetAll(), "ID", "Libelle");
        }
        private List<Event>GetListAVenir()
        {
            return ServiceEvents.GetByDate(DateTime.Today.AddDays(-10), DateTime.Today.AddDays(8));
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult FormAccueil(EventViewModel model)
        {
            EventViewModel eVM = new EventViewModel();
            eVM.ListThemes = GetSelectListThemes();
            List<Event> listeEvent = ServiceEvents.GetByLibelleByTheme(model.FormTextRecherche, model.FormThemeId);
            
            if(listeEvent.Count != 0)
            {
                eVM.ListEventResult = listeEvent;
                
            } else
            {
                eVM.ListEventAVenir = GetListAVenir();
            }
            return View("Index",eVM);
        }

        /*private void initDataBdd()
         {
            using (WebKContext context = new WebKContext())
            {
                Theme th = new Theme();
                th.ID = Guid.NewGuid();
                th.Libelle = "Plein air";

                Event e = new Event();
                e.ID = Guid.NewGuid();
                e.Libelle = "Apéro Géant";
                e.StartDate = DateTime.Now;
                e.EndDate = Convert.ToDateTime("01/06/2018"); ;
                e.Description = "Apéro géant sur l'esplanade Charles de Gaulle";


                PostalAddress p = new PostalAddress();
                p.ID = Guid.NewGuid();
                p.Libelle = "Champs de Mars";
                p.PostalCode = "35000";
                p.Street = "Esplanade Charles de Gaulle";
                p.City = "Rennes";


                try
                {
                    //on insère en base Theme et Adresse pour qu'ils aient un id à référencer 
                    // lorsqu'on insère l'event
                    context.Themes.Add(th);
                    context.Adresses.Add(p);
                    context.SaveChanges();

                    e.Address = p;
                    e.Theme = th;
                    context.Events.Add(e);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }

         }*/

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       

    }
}