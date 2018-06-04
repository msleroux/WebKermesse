using KermesseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceAccount
    {
        public static WebKContext GetWebKContext()
        {
            return new WebKContext();
        }
    }
}
