using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testOrderComposition
{
    public int Bro2testProductId { get; set; }

    public int Bro2testOrderId { get; set; }

    public sbyte Bro2testQuantity { get; set; }

    public decimal Bro2testPriceAtOrder { get; set; }

    public virtual Bro2testOrder Bro2testOrder { get; set; } = null!;

    public virtual Bro2testProduct Bro2testProduct { get; set; } = null!;
}
