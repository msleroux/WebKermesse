using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KermesseBO
{
    public class Theme
    {
        [Key]
        public Guid ID { get; set; }
        public String Libelle { get; set; }
    }
}
