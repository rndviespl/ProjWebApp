using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testReturn
{
    public int Bro2testReturnId { get; set; }

    public int Bro2testOrderId { get; set; }

    public int Bro2testProductId { get; set; }

    public int Bro2testQuantity { get; set; }

    public DateTime Bro2testReturnDate { get; set; }

    public string? Bro2testReason { get; set; }

    public virtual Bro2testOrder Bro2testOrder { get; set; } = null!;

    public virtual Bro2testProduct Bro2testProduct { get; set; } = null!;
}
