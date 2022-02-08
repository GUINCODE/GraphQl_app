using GraphQl_app.Models;
using Microsoft.EntityFrameworkCore;


namespace GraphQl_app.Data {
    public class MyAppContext : DbContext {
        public MyAppContext() { }
        public MyAppContext(DbContextOptions<MyAppContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
        }

        public DbSet<Produit> Produits { get; set; }
    }
}