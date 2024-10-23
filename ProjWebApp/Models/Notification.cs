﻿using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string UserId { get; set; }

    public string Message { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
