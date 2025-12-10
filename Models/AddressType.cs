using System;
using System.Collections.Generic;

namespace BreweryHomepageEFClasses.Models;

public partial class AddressType
{
    public int AddressTypeId { get; set; }

    public string? Name { get; set; }

    public override string ToString()
    {
        return $"{AddressTypeId}, {Name}";
    }
}
