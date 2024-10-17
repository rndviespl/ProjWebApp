using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public string Title { get; set; } = null!;

    public int? DiscountPercent { get; set; }

    public int? Wbarticul { get; set; }

    public string? Description { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? CategoryId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = [];

    public virtual Category? Category { get; set; }

    public virtual ICollection<Image> Images { get; set; } = [];

    public virtual ICollection<OrderComposition> OrderCompositions { get; set; } = [];

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = [];

    public virtual ICollection<Return> Returns { get; set; } = [];

    public virtual ICollection<ViewHistory> ViewHistories { get; set; } = [];

    public virtual ICollection<Wishlist> Wishlists { get; set; } = [];
}
