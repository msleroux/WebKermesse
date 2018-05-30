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
        private Guid id { get; set; }
        [Required(ErrorMessage="le libellé doit être renseigné")]
        private String libelle { get; set; }
        [Required(ErrorMessage = "la description doit être renseignée")]
        private String description { get; set; }
        [Required(ErrorMessage = "la date de début doit être renseignée")]
        private DateTime startDate { get; set; }
        [Required(ErrorMessage = "la date de fin doit être renseignée")]
        private DateTime endDate { get; set; }
        private PostalAddress address { get; set; }
        private Theme theme { get; set; }
    }
}
