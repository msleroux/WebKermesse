using KermesseBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebKermesse.Models
{
    public class PostalAddressViewModel : ViewModel<PostalAddress>
    {
        public PostalAddressViewModel()
        {
            this.Metier = new PostalAddress();
        }
        public PostalAddressViewModel(PostalAddress pA)
        {
            this.Metier = pA;
        }
        public String StreetAddress
        {
            get { return Metier.Street; }
            set { this.Metier.Street = value; }
        }

        public String PostalCodeAddress
        {
            get { return Metier.PostalCode; }
            set { this.Metier.PostalCode = value; }
        }

        public String CityAddress
        {
            get { return Metier.City; }
            set { this.Metier.City = value; }
        }
    }
}