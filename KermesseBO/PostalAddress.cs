using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KermesseBO
{
    public class PostalAddress
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "le libellé doit être renseigné")]
        [MaxLength(50, ErrorMessage = "le libellé ne doit pas dépasser 50 caractères")]
        [MinLength(8, ErrorMessage = "le libellé doit faire au minimum 8 caractères")]
        public String Libelle { get; set; }
        [Required(ErrorMessage = "le renseignement de Rue doit être renseigné")]
        [MaxLength(50, ErrorMessage = "le renseignement de Rue ne doit pas dépasser 50 caractères")]
        [MinLength(8, ErrorMessage = "le renseignement de Rue doit faire au minimum 8 caractères")]
        public String Street { get; set; }
        [Required(ErrorMessage = "le renseignement de Code Postal doit être renseigné")]
        [StringLength(50, ErrorMessage = "le Code Postal doit faire 5 caractères")]
        public String PostalCode { get; set; }
        [Required(ErrorMessage = "le renseignement de la Ville doit être renseigné")]
        [MaxLength(50, ErrorMessage = "le renseignement de la Ville ne doit pas dépasser 50 caractères")]
        [MinLength(8, ErrorMessage = "le renseignement de la Ville doit faire au minimum 8 caractères")]
        public String City { get; set; }
    }
}
