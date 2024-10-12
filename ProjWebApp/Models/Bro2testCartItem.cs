using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testCartItem
{
    public int Bro2testCartItemId { get; set; }

    public int Bro2testCartId { get; set; }

    public int Bro2testProductId { get; set; }

    public int Bro2testQuantity { get; set; }

    public virtual Bro2testCart Bro2testCart { get; set; } = null!;

    public virtual Bro2testProduct Bro2testProduct { get; set; } = null!;
}
