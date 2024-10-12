using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testProductAttribute
{
    public int Bro2testProductId { get; set; }

    public int Bro2testAttributesId { get; set; }

    public int Bro2testCount { get; set; }

    public string? Bro2testDescription { get; set; }

    public virtual Bro2testAttribute Bro2testAttributes { get; set; } = null!;

    public virtual Bro2testProduct Bro2testProduct { get; set; } = null!;
}
