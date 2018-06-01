using KermesseBO;
using KermesseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceThemes
    {
        public static List<Theme> GetAll()
        {
            List<Theme> liste = null;
            using (WebKContext context = new WebKContext())
            {
                liste = context.Themes.ToList<Theme>();
            }
            return liste;
        }

        public static Theme GetById(Guid idTheme)
        {
            Theme themeReturned = null;
            using (WebKContext context = new WebKContext())
            {
                themeReturned = context.Themes.FirstOrDefault(t => t.ID == idTheme);
            }
            return themeReturned;
        }

        public static void Insert(Theme themeToAdd)
        {
            using (WebKContext context = new WebKContext())
            {
                context.Themes.Add(themeToAdd);
                context.SaveChanges();
            }
        }

        public static void Remove(Guid idTheme)
        {
            using (WebKContext context = new WebKContext())
            {
                Theme themeRetrieve = Get(idTheme, context);
                context.Themes.Remove(themeRetrieve);
                context.SaveChanges();
            }
        }

        private static Theme Get(Guid idTheme, WebKContext context)
        {
            return context.Themes.FirstOrDefault(t => t.ID == idTheme);
        }
    }
}
