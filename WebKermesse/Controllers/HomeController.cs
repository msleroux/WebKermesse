using KermesseBO;
using KermesseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebKermesse.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
           /* initDataBdd();*/
           
                return View();
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

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       

    }
}