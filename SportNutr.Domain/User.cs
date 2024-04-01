using System.Collections.Generic;

namespace SportNutr.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Навигационное свойство
        public virtual ICollection<Order> Orders { get; set; }
    }
}