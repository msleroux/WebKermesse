using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KermesseBO
{
    public class Event
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage="le libellé doit être renseigné")]
        [MaxLength(50,ErrorMessage= "le libellé ne doit pas dépasser 50 caractères")]
        [MinLength(8, ErrorMessage = "le libellé doit faire au minimum 8 caractères")]
        public String Libelle { get; set; }
        [Required(ErrorMessage = "la description doit être renseignée")]
        [MaxLength(500, ErrorMessage = "la description ne doit pas dépasser 500 caractères")]
        [MinLength(30, ErrorMessage = "le libellé doit faire au minimum 30 caractères")]
        public String Description { get; set; }
        [Required(ErrorMessage = "la date de début doit être renseignée")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "la date de fin doit être renseignée")]
        public DateTime EndDate { get; set; }
        public PostalAddress Address { get; set; }
        public Picture Picture { get; set; }
    }
    
}
