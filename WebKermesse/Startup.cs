using KermesseDAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using KermesseDAL;
using Owin;


[assembly: OwinStartupAttribute(typeof(WebKermesse.Startup))]
namespace WebKermesse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void CreateRoleAndUser()
        {
            using (WebKContext contexte = new WebKContext())
            {
                //on récupère les managers de roles et users
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(contexte));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexte));


                //on va créer des nouveaux roles : on vérifie s'ils existent déjà
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website

                    //création de admin et de ses attributs
                    var admin = new ApplicationUser();
                    admin.UserName = "ep";
                    admin.Email = "ep@gmail.com";
                    admin.LockoutEnabled = false;

                    string adminPWD = "Pa$$w0rd";

                    //on l'ajoute dans aux manager des users ?
                    var chkAdmin = userManager.Create(admin, adminPWD);

                    //Add default User to Role Admin
                    if (chkAdmin.Succeeded)
                    {                        //???
                        var result1 = userManager.AddToRole(admin.Id, "EventPlanner");
                                            }
                   
                }

                if (!roleManager.RoleExists("EventPlanner"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "EventPlanner";
                    roleManager.Create(role);
                    //création du user et de ses attributs
                    var user = new ApplicationUser();
                    user.UserName = "sa";
                    user.Email = "sa@gmail.com";

                    string userPWD = "Pa$$w0rd";

                    //on l'ajoute dans aux manager des users ?
                    var chkUser = userManager.Create(user, userPWD);

                    //Add default User to Role Admin
                    if (chkUser.Succeeded)
                    {
                        //???
                        var result2 = userManager.AddToRole(user.Id, "EventPlanner");

                    }
                   
                }

                if (!roleManager.RoleExists("Member"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Member";
                    roleManager.Create(role);

                }
                //création du user et de ses attributs
                var member = new ApplicationUser();
                member.UserName = "mb";
                member.Email = "mb@gmail.com";
                member.LockoutEnabled = false;

                string memberPWD = "Pa$$w0rd";

                //on l'ajoute dans aux manager des users ?
                var chkMember = userManager.Create(member, memberPWD);

                //Add default User to Role Admin
                if (chkMember.Succeeded)
                {
                    //???
                    var result3 = userManager.AddToRole(member.Id, "Member");

                }
            }
        }
    }
}
