using System.ComponentModel.DataAnnotations;

namespace CursfoEFCore.Codefirst.API.Data.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
}