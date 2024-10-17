using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public byte[] Image1 { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
