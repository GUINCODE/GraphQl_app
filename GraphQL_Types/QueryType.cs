using GraphQl_app.Data;
using GraphQl_app.Models;
// using GraphQl_app.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQl_app.GraphQL_Types
{
    public class QueryType
    {
         public async Task<List<Produit>> AllProduitAsync([Service] MyAppContext context ){
            return await context.Produits.ToListAsync();
         }
    }
}