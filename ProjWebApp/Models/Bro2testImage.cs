using System;
using System.Collections.Generic;

namespace ProjWebApp.Models;

public partial class Bro2testImage
{
    public int Bro2testImageId { get; set; }

    public int Bro2testProductId { get; set; }

    public byte[] Bro2testImage1 { get; set; } = null!;

    public virtual Bro2testProduct Bro2testProduct { get; set; } = null!;
}
