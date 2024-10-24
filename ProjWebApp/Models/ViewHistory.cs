﻿using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class ViewHistory
{
    public int ViewId { get; set; }

    public string UserId { get; set; }

    public int ProductId { get; set; }

    public DateTime ViewDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
