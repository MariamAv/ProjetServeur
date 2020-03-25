using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjetServeur.Domaine;
using ProjetServeur.Repository;

namespace ProjetServeur
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            RevuesContext context = new RevuesContext();

            
            AuteurRepo aRep = new AuteurRepo(context);
            var auteurs = aRep.FindAll();
            foreach(var auteur in auteurs)
            {
                Console.WriteLine(auteur);
            }
            
            /*
            CrudRepo<Auteur> crudAuteur = new CrudSQLRepo<Auteur>(context);
            CrudRepo<Article> crudArticle = new CrudSQLRepo<Article>(context);

            crudAuteur.FindAll();
            crudArticle.FindAll();
            */
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
