using KermesseDAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceAccount
    {
             public static List<ApplicationUser> GetAllUsers()
        {
            List<ApplicationUser> liste = null;
            using (WebKContext context = new WebKContext())
            {
                liste = context.Users.ToList();
            }
            return liste;
        }

        public static ApplicationUser GetById(string idUser)
        {
            ApplicationUser userReturned = null;
            using (WebKContext context = new WebKContext())
            {
                var rqt = context.Users.Where(u => u.Id == idUser);
                userReturned = rqt.Single<ApplicationUser>();
            }
            return userReturned;
        }

        public static ApplicationUser GetByPhoneNumber(string phoneNumber)
        {
            ApplicationUser userReturned = null;
            using (WebKContext context = new WebKContext())
            {
                               var rqt = context.Users.Where(e =>e.PhoneNumber == phoneNumber);
                userReturned = rqt.Single<ApplicationUser>();

            }
            return userReturned;
        }

        public static ApplicationUser GetByEmail(string email)
        {
            ApplicationUser userReturned = null;
            using (WebKContext context = new WebKContext())
            {
                var rqt = context.Users.Where(e => e.Email == email);
                userReturned = rqt.Single<ApplicationUser>();

            }
            return userReturned;
        }

        public static ApplicationUser GetByUserName(string userName)
        {
            ApplicationUser userReturned = null;
            using (WebKContext context = new WebKContext())
            {
                var rqt = context.Users.Where(e => e.UserName == userName);
                userReturned = rqt.Single<ApplicationUser>();

            }
            return userReturned;
        }

        public static void DeleteCompteMembre(string id)
        {
           using (WebKContext context = new WebKContext())
            {
                ApplicationUser userRetrieve = Get(id, context);
                context.Users.Remove(userRetrieve);
                context.SaveChanges();
            }
        }



        

         private static ApplicationUser Get(string idUser, WebKContext context)
           {
               return context.Users.First(u => u.Id == idUser);
           }
    }
}
