using KermesseBO;
using KermesseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServicePictures
    {
        public static Picture GetById(Guid idPicture)
        {
            Picture pictureReturned = null;
            using(WebKContext context = new WebKContext())
            {
                pictureReturned = context.Pictures.FirstOrDefault(p => p.ID == idPicture);
            }
            return pictureReturned;
        }
    }
}
