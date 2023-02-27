﻿using System;
using System.Collections.Generic;

namespace Asm02Solution.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? QuantityPerUnit { get; set; }

    public int? UnitPrice { get; set; }

    public string? ProductImage { get; set; }

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Supplier? Supplier { get; set; }
}