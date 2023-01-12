using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.DbEntities;

public partial class Rank
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
