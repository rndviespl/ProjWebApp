using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testProduct
{
    public int Bro2testProductId { get; set; }

    public decimal Bro2testPrice { get; set; }

    public string Bro2testTitle { get; set; } = null!;

    public int? Bro2testDiscountPercent { get; set; }

    public int? Bro2testWbarticul { get; set; }

    public string? Bro2testDescription { get; set; }

    public string? Bro2testImageUrl { get; set; }

    public DateTime? Bro2testDateAdded { get; set; }

    public int? Bro2testCategoryId { get; set; }

    public virtual ICollection<Bro2testCartItem> Bro2testCartItems { get; set; } = new List<Bro2testCartItem>();

    public virtual Bro2testCategory? Bro2testCategory { get; set; }

    public virtual ICollection<Bro2testOrderComposition> Bro2testOrderCompositions { get; set; } = new List<Bro2testOrderComposition>();

    public virtual ICollection<Bro2testProductAttribute> Bro2testProductAttributes { get; set; } = new List<Bro2testProductAttribute>();

    public virtual ICollection<Bro2testReturn> Bro2testReturns { get; set; } = new List<Bro2testReturn>();

    public virtual ICollection<Bro2testReview> Bro2testReviews { get; set; } = new List<Bro2testReview>();

    public virtual ICollection<Bro2testViewHistory> Bro2testViewHistories { get; set; } = new List<Bro2testViewHistory>();

    public virtual ICollection<Bro2testWishlist> Bro2testWishlists { get; set; } = new List<Bro2testWishlist>();
}
