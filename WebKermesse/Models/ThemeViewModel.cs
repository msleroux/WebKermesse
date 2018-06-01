using KermesseBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        
    }
}