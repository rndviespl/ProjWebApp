﻿using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public string UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual User User { get; set; } = null!;
}
