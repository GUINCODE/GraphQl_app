using GraphQl_app.Data;
using GraphQl_app.Models;
using GraphQl_app.Models.ManyToMany;
using GraphQl_app.Notifications;
using HotChocolate.Subscriptions;

namespace GraphQl_app.GraphQL_Types
{
    public class MutationType
    {
        public async Task<Produit> SaveProduitAsync([Service] MyAppContext context, Produit newProduit)
        {
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

        public async Task<string> DeleteProduitAsync([Service] MyAppContext context, int id)
        {
            var produit = await context.Produits.FindAsync(id);
            if (produit == null)
            {
                return "id not found";
            }
            context.Produits.Remove(produit);
            await context.SaveChangesAsync();
            return "Deleted";
        }

        public async Task<Client> AddClientAsync([Service] MyAppContext context, Client client)
        {
            context.Clients.Add(client);
            await context.SaveChangesAsync();
            return client;
        }

        public async Task<Abonnement> AddAbonnementAsync([Service] MyAppContext context, Abonnement abonnement)
        {
            context.Abonnements.Add(abonnement);
            await context.SaveChangesAsync();
            return abonnement;
        }

        public async Task<AbonnementClient> EnregAbonnement(
            [Service] MyAppContext context,
             AbonnementClient abonnementClient,
             [Service] ITopicEventSender eventSender,
             CancellationToken cancellationToken)
        {

            context.AbonnementClients.Add(abonnementClient);
            Notification notification = new();
            notification.TypeNotif = "added_abonnement";
            notification.AbonnementId = abonnementClient.AbonnementId;
            notification.ClientId = abonnementClient.ClientId;
            await context.SaveChangesAsync(cancellationToken);
            await  eventSender.SendAsync(nameof (SubscriptionType.OnSouscriptionAdded), notification, cancellationToken) ;
            return abonnementClient;
        }
    }
}