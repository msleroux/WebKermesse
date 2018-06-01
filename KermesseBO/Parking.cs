using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KermesseBO
{
    public class Parking
    {
        public Guid ID { get; set; }

        public string name { get; set; }

        public string status { get; set; }

        public string max { get; set; }

        public string free { get; set; }

        public double tarif { get; set; }

    }
}
