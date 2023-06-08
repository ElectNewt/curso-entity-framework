using System.ComponentModel.DataAnnotations;

namespace CursoEFCore.Codefirst.API.Data.Entities;

public class User : CursoEFBaseEntity
{
    public int Id { get; set; }
    public string UserName { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    
    public ICollection<Wokringexperience> Wokringexperiences { get; set; }
}