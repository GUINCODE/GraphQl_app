using GraphQl_app.Data;
using GraphQl_app.Models;

namespace GraphQl_app.GraphQL_Types
{
    public class MutationType
    {
        public async Task<Produit> SaveProduitAsync([Service] MyAppContext context, Produit newProduit){
          context.Produits.Add(newProduit);
          await context.SaveChangesAsync();
          return newProduit;
        }

        public async Task<Produit> UpdateProduitAsync([Service] MyAppContext context, Produit updateProduit)
        {
            context.Produits.Update(updateProduit);
            await context.SaveChangesAsync();
            return updateProduit;
        }

        public async Task<string> DeleteProduitAsync([Service] MyAppContext context, int id) {
             var produit =  await context.Produits.FindAsync(id);
          if (produit==null) 
          {
              return "id not found";
          }
          context.Produits.Remove(produit);
          await context.SaveChangesAsync();
          return "Deleted";
        }
}
}