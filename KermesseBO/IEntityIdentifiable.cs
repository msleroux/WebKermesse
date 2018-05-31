using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KermesseBO
{
    public interface IEntityIdentifiable
    {
        Guid ID { get; set; }
    }
}
