using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testAttribute
{
    public int Bro2testAttributesId { get; set; }

    public string? Bro2testSize { get; set; }

    public string? Bro2testColor { get; set; }

    public string? Bro2testDescription { get; set; }

    public virtual ICollection<Bro2testProductAttribute> Bro2testProductAttributes { get; set; } = new List<Bro2testProductAttribute>();
}
