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
        
        public Guid ID { get; set ; }
        public String Libelle { get; set; }
        public String Street { get; set; }
        public String PostalCode { get; set; }
        public String City { get; set; }
    }
}
