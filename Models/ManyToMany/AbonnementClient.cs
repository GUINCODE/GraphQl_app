namespace GraphQl_app.Models.ManyToMany
{
    public class AbonnementClient
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int AbonnementId { get; set; }
        public Abonnement Abonnement { get; set; }
    }
}