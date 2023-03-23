using System.ComponentModel.DataAnnotations;

namespace CursoEFCore.Codefirst.API.Data.Entities;

public class Wokringexperience
{
    public int Id { get; set; }

    public int UserId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
    
    public string Details { get; set; }

    public string Environment { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}