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

            AccueilViewModel aVM = new AccueilViewModel();
            List<Event> events = GetListAVenir();
            foreach(Event e in events)
            {
                if (e.Picture == null)
                {
                    e.Picture = new Picture() { Path = "Upcoming_Events-Banner.jpg" };

                }
            }
            aVM.EventResults = initListEventViewModel(events);
            aVM.ThemeView = new ThemeViewModel();
            return View(aVM);
        }

        //pour premier chargement page accueil sans recherche
        private List<Event>GetListAVenir()
        {
            return ServiceEvents.GetByDate(DateTime.Today.AddDays(-10), DateTime.Today.AddDays(8));
        }


        //transforme une liste d'event en EventViewModel
        private ListEventViewModel initListEventViewModel(List<Event> events)
        {
            ListEventViewModel liste = new ListEventViewModel();
            foreach (Event e in events)
            {
                liste.Add(new EventViewModel(e));
            }
            return liste;
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult FormAccueil(AccueilViewModel model)
        {
          
            List<Event> listeEvent = new List<Event>();

           

            //si aucune infos rentrées dans les champs
            if (model.Recherche.Count() == 0 && (model.ThemeView.ThemeId) == Guid.Empty)
            {
              listeEvent = ServiceEvents.GetAll();

            } else {
               
             // les cas de champs nul sont gérées dans la classe de services
               listeEvent = ServiceEvents.GetByLibelleByTheme(model.Recherche, model.ThemeView.ThemeId);

            }

            AccueilViewModel leVM = new AccueilViewModel();
            foreach (Event e in listeEvent)
            {
                if (e.Picture == null)
                {
                    e.Picture = new Picture() { Path = "Upcoming_Events-Banner.jpg" };

                }
            }
            leVM.EventResults = initListEventViewModel(listeEvent);

            return View("Index",leVM);
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