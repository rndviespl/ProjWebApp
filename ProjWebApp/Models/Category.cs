using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryTitle { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
