namespace CursoEFCore.Codefirst.API.Data.Entities;

public abstract class CursoEFBaseEntity
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedTimeUtc { get; set; }
}