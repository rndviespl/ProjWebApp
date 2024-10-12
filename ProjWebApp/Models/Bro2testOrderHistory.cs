using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testOrderHistory
{
    public int Bro2testOrderHistoryId { get; set; }

    public int Bro2testOrderId { get; set; }

    public string Bro2testStatus { get; set; } = null!;

    public DateTime Bro2testUpdatedAt { get; set; }

    public virtual Bro2testOrder Bro2testOrder { get; set; } = null!;
}
