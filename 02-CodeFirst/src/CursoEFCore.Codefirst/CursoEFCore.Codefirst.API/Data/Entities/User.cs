using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Codefirst.API.Data.Entities;

public class User : CursoEFBaseEntity<int>
{
    public string UserName { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    
    public Address Address { get; set; } // 👈 this
    public virtual ICollection<Wokringexperience> Wokringexperiences { get; set; }
}

[Owned]
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}