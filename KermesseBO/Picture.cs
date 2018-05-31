using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KermesseBO
{
    public class Picture : IEntityIdentifiable
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "le chemin doit être renseigné")]
        public String Path { get; set; }
    }
}
