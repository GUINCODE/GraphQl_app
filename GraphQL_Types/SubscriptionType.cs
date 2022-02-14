using GraphQl_app.Models.ManyToMany;

namespace GraphQl_app.GraphQL_Types
{
    public class SubscriptionType
    {
        [Subscribe]
        [Topic]
        public AbonnementClient OnSouscriptionAdded([EventMessage] AbonnementClient abonnementClient)
        {
            return abonnementClient;
        }
    }
}