namespace GraphQl_app.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        public string AdresseMail { get; set; }
        public string AdressePostale { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}