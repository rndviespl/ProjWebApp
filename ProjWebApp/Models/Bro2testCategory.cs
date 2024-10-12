using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testCategory
{
    public int Bro2testCategoryId { get; set; }

    public string Bro2testCategoryTitle { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<Bro2testProduct> Bro2testProducts { get; set; } = new List<Bro2testProduct>();

    public virtual ICollection<Bro2testCategory> InverseParentCategory { get; set; } = new List<Bro2testCategory>();

    public virtual Bro2testCategory? ParentCategory { get; set; }
}
