namespace webAppApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<webAppApi.ADO.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(webAppApi.ADO.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.


            var empresa1 = new Empresa { Id = 1, Nome = "Empresa 1 " };
            var empresa2 = new Empresa { Id = 2, Nome = "Empresa 2" };
            var empresa3 = new Empresa { Id = 3, Nome = "Empresa 3" };

         
            context.Empresas.AddOrUpdate(
              p => p.Nome,
              empresa1,
              empresa2,
              empresa3
            );
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Pessoas.AddOrUpdate(
              p => p.Nome,
              new Pessoa { Nome = "Andrew " ,Sobrenome = "Peters",DataNascimento = DateTime.Parse("1981-12-05"),Empresa = empresa1 },
              new Pessoa { Nome = "Brice", Sobrenome = "Lambson", DataNascimento = DateTime.Parse("1981-12-05"), Empresa = empresa2 },
              new Pessoa { Nome = "Rowan",Sobrenome="Miller", DataNascimento = DateTime.Parse("1981-12-05"), Empresa = empresa3 }
            );
            //
        }
    }
}
