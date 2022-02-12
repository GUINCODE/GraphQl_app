using GraphQl_app.Data;
using GraphQl_app.Models;
using GraphQl_app.Models.ManyToMany;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQl_app.GraphQL_Types
{
    public class QueryType
    {
        // [Serial]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Produit> GetProduits([Service] MyAppContext context)
        {
            return context.Produits;
        }

        // [Serial]
        // [UseDbContext(typeof(MyAppContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Client> GetClients([Service] MyAppContext context)
        {
            return context.Clients;
        }
        // [Serial]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public  IQueryable<Abonnement> GetAbonnements([Service] MyAppContext context) {
            return  context.Abonnements;
        }

        // [Serial]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public  IQueryable<AbonnementClient> GetAbonnementClients([Service] MyAppContext context) {
            return  context.AbonnementClients;
        }
    }
}