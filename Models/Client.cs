using System;
using GraphQl_app.Models.ManyToMany;

namespace GraphQl_app.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AbonnementClient> AbonnementClients { get; set; }
        public ICollection<Adresse> Adresses { get; set; }
    }
}