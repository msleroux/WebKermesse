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
        public String Libelle { get; set; }

        [Required(ErrorMessage = "la description doit être renseignée")]
        public String Description { get; set; }

        [Required(ErrorMessage = "la date de début doit être renseignée")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "la date de fin doit être renseignée")]
        public DateTime EndDate { get; set; }

        public PostalAddress Address { get; set; }

        public Theme Theme { get; set; }
    }
}
