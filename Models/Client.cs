using System;

namespace GraphQl_app.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Adresse> Adresses { get; set; }
    }
}