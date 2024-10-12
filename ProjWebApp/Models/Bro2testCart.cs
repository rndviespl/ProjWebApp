using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testCart
{
    public int Bro2testCartId { get; set; }

    public int Bro2testUserId { get; set; }

    public DateTime Bro2testCreatedAt { get; set; }

    public virtual ICollection<Bro2testCartItem> Bro2testCartItems { get; set; } = new List<Bro2testCartItem>();

    public virtual Bro2testUser Bro2testUser { get; set; } = null!;
}
