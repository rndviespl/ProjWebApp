using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class OrderComposition
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public sbyte Quantity { get; set; }

    public decimal PriceAtOrder { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
