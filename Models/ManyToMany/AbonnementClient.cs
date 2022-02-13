using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQl_app.Models.ManyToMany
{
    public class AbonnementClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int AbonnementId { get; set; }
        public Abonnement Abonnement { get; set; }
    }
}