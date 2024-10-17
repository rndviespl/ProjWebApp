using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class ProductAttribute
{
    public int ProductId { get; set; }

    public int AttributesId { get; set; }

    public int Count { get; set; }

    public string? Description { get; set; }

    public virtual AttributeProduct Attributes { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
