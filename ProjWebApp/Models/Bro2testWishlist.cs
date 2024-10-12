using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testWishlist
{
    public int Bro2testWishlistId { get; set; }

    public int Bro2testUserId { get; set; }

    public int Bro2testProductId { get; set; }

    public DateTime Bro2testCreatedAt { get; set; }

    public virtual Bro2testProduct Bro2testProduct { get; set; } = null!;

    public virtual Bro2testUser Bro2testUser { get; set; } = null!;
}
