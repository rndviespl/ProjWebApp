using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime RegistrationDate { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<ViewHistory> ViewHistories { get; set; } = new List<ViewHistory>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
