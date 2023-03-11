using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm02Solution.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }
    [Display(Name = "Product")]

    public int ProductId { get; set; }

    public int? UnitPrice { get; set; }

    public int? Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
