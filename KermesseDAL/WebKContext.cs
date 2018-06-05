namespace KermesseDAL
{
    using System;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Linq;
    using KermesseBO;

    public class WebKContext : IdentityDbContext<ApplicationUser>
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « WebKContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « KermesseDAL.WebKContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « WebKContext » dans le fichier de configuration de l'application.
        public WebKContext()
            :base("name=WebKContext", throwIfV1Schema: false)
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<WebKContext, KermesseDAL.Migrations.Configuration>());
        }

      
        public static WebKContext Create()
        {
            return new WebKContext();
        }
        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }


        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Theme> Themes { get; set; }

        public virtual DbSet<PostalAddress> Adresses { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }
    }

   

}