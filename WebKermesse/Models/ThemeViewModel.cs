using KermesseBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebKermesse.Models
{
    public class ThemeViewModel : ViewModel<Theme>
    {
        public ThemeViewModel()
        {
            this.Metier = new Theme();
        }

        public ThemeViewModel(Theme t)
        {
            this.Metier = t;
        }

        public String Libelle
        {
            get { return this.Metier.Libelle; }
            set { this.Metier.Libelle = value; }
        }

        public Guid ThemeId
        {
            get { return Metier.ID; }
            set { this.Metier.ID = value; }
        }

        public IEnumerable<SelectListItem> ListThemes
        { get
            {
                return new SelectList(Services.ServiceThemes.GetAll(),"ID","Libelle");
            }
        }
    }
}