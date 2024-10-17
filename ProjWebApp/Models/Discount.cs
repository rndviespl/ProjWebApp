using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Discount
{
    public int Bro2testDiscountId { get; set; }

    public string Bro2testDiscountCode { get; set; } = null!;

    public int Bro2testDiscountPercent { get; set; }

    public DateTime Bro2testStartDate { get; set; }

    public DateTime Bro2testEndDate { get; set; }
}
