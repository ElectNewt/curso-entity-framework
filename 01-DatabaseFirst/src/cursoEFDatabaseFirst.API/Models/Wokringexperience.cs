using System;
using System.Collections.Generic;

namespace cursoEFDatabaseFirst.API.Models;

public partial class Wokringexperience
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Details { get; set; } = null!;

    public string Environment { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Userid User { get; set; } = null!;
}
