using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Return
{
    public int ReturnId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime ReturnDate { get; set; }

    public string? Reason { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
