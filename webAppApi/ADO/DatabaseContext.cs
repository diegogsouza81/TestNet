namespace webAppApi.ADO
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using webAppApi.Models;

    public class DatabaseContext : DbContext
    {
        // Your context has been configured to use a 'DataModelTest' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'webAppApi.ADO.DataModelTest' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataModelTest' 
        // connection string in the application configuration file.
        public DatabaseContext()
            : base("name=DataModelTest")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Empresa> Empresas { get; set; }

        public virtual DbSet<Pessoa> Pessoas { get; set; }

    }


}