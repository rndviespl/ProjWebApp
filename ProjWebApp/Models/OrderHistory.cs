using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class OrderHistory
{
    public int OrderHistoryId { get; set; }

    public int OrderId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public virtual Order Order { get; set; } = null!;
}
