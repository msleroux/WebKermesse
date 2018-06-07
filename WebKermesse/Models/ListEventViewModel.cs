using KermesseBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebKermesse.Models
{
    public class ListEventViewModel : List<EventViewModel>
    {
        private List<EventViewModel> _eventResults = new List<EventViewModel>();

           
        public List<EventViewModel> EventResults
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