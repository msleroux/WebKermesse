using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebKermesse.Models;
using KermesseBO;
using System.Data.Entity;

namespace KermesseDAL
{
   
    public class WKContext : IdentityDbContext<ApplicationUser>
    {
        
            public WKContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WKContext, MLV.DAL.Migrations.Configuration>());
        }

            public static WKContext Create()
            {
                return new WKContext();
        }
        
       



}
    }
}
