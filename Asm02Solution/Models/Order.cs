using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm02Solution.Models;

public partial class Order
{
    public int OrderId { get; set; }
    [Display(Name = "Order Date")]

    public DateTime? OrderDate { get; set; }
    [Display(Name = "Required Date")]

    public DateTime? RequiredDate { get; set; }
    [Display(Name = "Shipped Date")]

    public DateTime? ShippedDate { get; set; }
    [Display(Name = "Total (VND)")]

    public decimal? Freght { get; set; }
    [Display(Name = "Ship Address")]

    public string? ShipAddress { get; set; }
    [Display(Name = "Customer")]

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
