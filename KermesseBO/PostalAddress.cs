using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KermesseBO
{
    public class PostalAddress
    {
        private Guid id { get; set; }
        private String libelle { get; set; }
        private String street { get; set; }
        private int postalCode { get; set; }
        private String city { get; set; }
    }
}
