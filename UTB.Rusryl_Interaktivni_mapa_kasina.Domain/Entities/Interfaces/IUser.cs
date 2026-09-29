using System;
using System.Collections.Generic;
using System.Text;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities.Interfaces
{
    public interface IUser<TKey> : IEntity<TKey>
    {
        string? Username { get; set; }
        string? Email { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string? Address { get; set; }
        string? City { get; set; }
        string? ZipCode { get; set; }
        string? Country { get; set; }
        double? Balance { get; set; }
    }
}
