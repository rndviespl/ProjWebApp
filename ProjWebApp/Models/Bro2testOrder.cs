using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testOrder
{
    public int Bro2testOrderId { get; set; }

    public int Bro2testUserId { get; set; }

    public DateTime Bro2testDateTimeOrder { get; set; }

    public string? Bro2testTypeOrder { get; set; }

    public string? Bro2testStatus { get; set; }

    public virtual ICollection<Bro2testOrderComposition> Bro2testOrderCompositions { get; set; } = new List<Bro2testOrderComposition>();

    public virtual ICollection<Bro2testOrderHistory> Bro2testOrderHistories { get; set; } = new List<Bro2testOrderHistory>();

    public virtual ICollection<Bro2testReturn> Bro2testReturns { get; set; } = new List<Bro2testReturn>();
}
