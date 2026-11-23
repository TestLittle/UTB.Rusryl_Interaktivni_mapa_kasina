using Microsoft.AspNetCore.Identity;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities.Interfaces;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Identity
{
    public class User : IdentityUser<int>, IUser<int>
    {
        public virtual string? Username { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? Address { get; set; }
        public virtual string? City { get; set; }
        public virtual string? ZipCode { get; set; }
        public virtual string? Country { get; set; }
        public virtual double? Balance { get; set; }

    }
}
