using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testNotification
{
    public int Bro2testNotificationId { get; set; }

    public int Bro2testUserId { get; set; }

    public string Bro2testMessage { get; set; } = null!;

    public bool Bro2testIsRead { get; set; }

    public DateTime Bro2testCreatedAt { get; set; }

    public virtual Bro2testUser Bro2testUser { get; set; } = null!;
}
