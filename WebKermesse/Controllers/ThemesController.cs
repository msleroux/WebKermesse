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
    public class ThemesController : Controller
    {
        // GET: Themes
        public ActionResult Index()
        {
            List<ThemeViewModel> themesVM = new List<ThemeViewModel>();
            List<Theme> themes = ServiceThemes.GetAll();
            foreach (Theme t in themes)
            {
                themesVM.Add(new ThemeViewModel(t));
            }
            return View(themesVM);
        }

        // GET: Themes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Themes/Create
        public ActionResult Create()
        {
            Theme t = new Theme() { ID = Guid.Empty, Libelle = "Saisir libellé" };
            return View(new ThemeViewModel(t));
        }

        // POST: Themes/Create
        [HttpPost]
        public ActionResult Create(ThemeViewModel tVM)
        {
            try
            {
                // TODO: Add insert logic here
                Theme themeToAdd = new Theme() { ID = Guid.NewGuid(), Libelle = tVM.Libelle };
                ServiceThemes.Insert(themeToAdd);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {

                return View(tVM);
            }
        }

        // GET: Themes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Themes/Edit/5
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

        // GET: Themes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Themes/Delete/5
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
