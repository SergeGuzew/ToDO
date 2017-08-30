using System.Data.Entity;

namespace Ru.KpXX.Tests.Test02.ToDoApi.Models
{
    public class ToDoDB: DbContext
    {
        // Your context has been configured to use a 'ToDO' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Ru.KpXX.Tests.Test02.Test01.Models.ToDO' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ToDO' 
        // connection string in the application configuration file.
        public ToDoDB()
            : base("name=ToDO")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Task> Tasks { get; set; }
    }
}