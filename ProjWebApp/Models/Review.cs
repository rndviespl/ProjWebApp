using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Review
{
    public int Bro2testReviewId { get; set; }

    public int Bro2testProductId { get; set; }

    public int Bro2testUserId { get; set; }

    public sbyte Bro2testRating { get; set; }

    public string? Bro2testComment { get; set; }

    public DateTime Bro2testDateTime { get; set; }
}
