using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime DateTimeOrder { get; set; }

    public string? TypeOrder { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<OrderComposition> OrderCompositions { get; set; } = new List<OrderComposition>();

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();
}
