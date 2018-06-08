using KermesseBO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebKermesse.Models
{
    public class EventViewModel : ViewModel<Event>
    {
      

        public EventViewModel()
        {
            this.Metier = new Event();
            this.Metier.Theme = new Theme() { ID = Guid.Empty };
            this.Metier.Address = new PostalAddress() { ID = Guid.Empty };
            this.Metier.Picture = new Picture() { ID = Guid.Empty };
        }
        public EventViewModel(Event e)
        {
            this.Metier = e;
        }

        [Display(Name = "Libellé")]
        public String Libelle
        {
            get { return Metier.Libelle; }
            set { this.Metier.Libelle = value; }
        }
        [Display(Name = "Description")]
        public String Description
        {
            get { return Metier.Description; }
            set { this.Metier.Description = value; }
        }
        [Display(Name = "Date de début")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime StartDate
        {
            get { return Metier.StartDate; }
            set { this.Metier.StartDate = value; }
        }
        [Display(Name = "Date de fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime EndDate
        {
            get { return Metier.EndDate; }
            set { this.Metier.EndDate = value; }
        }
        [Display(Name = "Thème")]
        public Guid ThemeId
        {
            get { return Metier.Theme.ID; }
            set { this.Metier.Theme.ID = value; }
        }

        public Guid AddressId
        {
            get { return Metier.Address.ID; }
            set { this.Metier.Address.ID = value; }
        }
        [Display(Name = "N° et nom de rue")]
        public String StreetAddress
        {
            get { return Metier.Address.Street; }
            set { this.Metier.Address.Street = value; }
        }
        [Display(Name = "Code Postal")]
        public String PostalCodeAddress
        {
            get { return Metier.Address.PostalCode; }
            set { this.Metier.Address.PostalCode = value; }
        }
        [Display(Name = "Ville")]
        public String CityAddress
        {
            get { return Metier.Address.City; }
            set { this.Metier.Address.City = value; }
        }
        public Picture Picture
        {
            get { return Metier.Picture; }
            set { this.Metier.Picture = value; }
        }
        public IEnumerable<SelectListItem> ListThemes { get; set; }

        //[FileExtensions(Extensions ="jpg,jpeg")]
        //[Display(Name = "Browse File")]
        [DataType(DataType.Upload)]
        [Display(Name = "Image")]
        public String file { get; set; }
        

       
    }
}