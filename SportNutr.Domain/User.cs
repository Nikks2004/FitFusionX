using System.Collections.Generic;

namespace SportNutr.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Privilege { get; set; }
        public byte[] SecretHash { get; set; }

        // Навигационное свойство
        public virtual ICollection<Order> Orders { get; set; }
    }
}