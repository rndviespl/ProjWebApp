using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testUser
{
    public int Bro2testUserId { get; set; }

    public string Bro2testUsername { get; set; } = null!;

    public string Bro2testPassword { get; set; } = null!;

    public string Bro2testEmail { get; set; } = null!;

    public string? Bro2testFullName { get; set; }

    public DateTime Bro2testRegistrationDate { get; set; }

    public virtual ICollection<Bro2testCart> Bro2testCarts { get; set; } = new List<Bro2testCart>();

    public virtual ICollection<Bro2testNotification> Bro2testNotifications { get; set; } = new List<Bro2testNotification>();

    public virtual ICollection<Bro2testReview> Bro2testReviews { get; set; } = new List<Bro2testReview>();

    public virtual ICollection<Bro2testViewHistory> Bro2testViewHistories { get; set; } = new List<Bro2testViewHistory>();

    public virtual ICollection<Bro2testWishlist> Bro2testWishlists { get; set; } = new List<Bro2testWishlist>();
}
