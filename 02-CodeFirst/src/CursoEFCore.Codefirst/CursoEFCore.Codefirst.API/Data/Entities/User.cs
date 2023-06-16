using System.ComponentModel.DataAnnotations;

namespace CursoEFCore.Codefirst.API.Data.Entities;

public class User : CursoEFBaseEntity<int>
{
    public string UserName { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    
    public virtual ICollection<Wokringexperience> Wokringexperiences { get; set; }
}