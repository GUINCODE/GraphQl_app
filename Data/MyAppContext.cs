using GraphQl_app.Models;
using GraphQl_app.Models.ManyToMany;
using Microsoft.EntityFrameworkCore;


namespace GraphQl_app.Data {
    public class MyAppContext : DbContext {
        public MyAppContext() { }
        public MyAppContext(DbContextOptions<MyAppContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbonnementClient>().HasKey(sc => new { sc.AbonnementId, sc.ClientId });   //Obligatoire pour les Deux méthodes
          //Méthode_2

            modelBuilder.Entity<Client>()
                              .HasMany(t => t.AbonnementClients)
                              .WithOne(t => t.Client)
                              .HasForeignKey(t => t.ClientId);

            modelBuilder.Entity<Abonnement>()
                                .HasMany(t => t.AbonnementClients)
                                .WithOne(t => t.Abonnement)
                                .HasForeignKey(t => t.AbonnementId);
        }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Adresse>  Adresse { get; set; }
        public DbSet<Abonnement>  Abonnements{ get; set; }
        public DbSet<AbonnementClient>  AbonnementClients { get; set; }
    }
}