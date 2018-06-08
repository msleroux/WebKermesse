using KermesseBO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebKermesse.Models
{
    public class AccueilViewModel 
    {
        private ListEventViewModel _eventResults = null;

        public ThemeViewModel ThemeView;

        public string Recherche { get; set; }
        public Guid IdThemeRecherche { get; set; }

    
        public AccueilViewModel()
        {
            Recherche = "";
            ThemeView = new ThemeViewModel();
         }
         
          

        public ListEventViewModel EventResults
        {
            get
            {
                return _eventResults;
            }
            set
            {
                _eventResults = value;
               
            }
        }
    }
}