namespace CursoEFCore.Codefirst.API.Data.Entities;

public abstract class CursoEFBaseEntity<TId>
{
    public TId Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedTimeUtc { get; set; }
}

