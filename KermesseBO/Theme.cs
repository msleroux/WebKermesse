using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KermesseBO
{
    public class Theme : IEntityIdentifiable
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "le libellé doit être renseigné")]
        [MaxLength(50, ErrorMessage = "le libellé ne doit pas dépasser 50 caractères")]
        [MinLength(8, ErrorMessage = "le libellé doit faire au minimum 8 caractères")]
        public String Libelle { get; set; }
    }
}
