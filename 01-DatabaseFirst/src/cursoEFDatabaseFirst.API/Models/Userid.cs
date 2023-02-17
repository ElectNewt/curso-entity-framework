using System;
using System.Collections.Generic;

namespace cursoEFDatabaseFirst.API.Models;

public partial class Userid
{
    public int UserId1 { get; set; }

    public string UserName { get; set; } = null!;

    public virtual ICollection<Wokringexperience> Wokringexperiences { get; } = new List<Wokringexperience>();
}
