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
        public ActionResult Index()
        {
            using (WebKContext context = new WebKContext())
            {
                Theme th = new Theme();

                try
                {
                    context.Themes.Add(th);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}