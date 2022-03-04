using GraphQl_app.Data;
using GraphQl_app.Models;
using GraphQl_app.Models.ManyToMany;
using GraphQl_app.Notifications;

namespace GraphQl_app.GraphQL_Types
{
    public class SubscriptionType
    {
        [Subscribe]
        [Topic]
        public Notification OnSouscriptionAdded([EventMessage] Notification notification)
        {
            return notification;
        }
    }
}