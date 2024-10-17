using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Attribute1
{
    public int AttributesId { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = [];
}
