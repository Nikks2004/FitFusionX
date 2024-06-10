using System;

namespace SportNutr.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string FavoriteSport { get; set; }
        public string Goals { get; set; }
    }

}