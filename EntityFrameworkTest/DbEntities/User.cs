using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.DbEntities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int PlaceId { get; set; }

    public virtual Rank Place { get; set; } = null!;
    
    public override string ToString()
    {
        return $"{Name} is on {Place.Name}";
    }
}
