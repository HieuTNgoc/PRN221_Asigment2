using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm02Solution.Models;

public partial class Product
{
    public int ProductId { get; set; }

    [Display(Name = "Product Name")]
    public string? ProductName { get; set; }

    [Display(Name = "Quantity")]

    public int? QuantityPerUnit { get; set; }

    [Display(Name = "Unit Price")]
    public int? UnitPrice { get; set; }

    [Display(Name = "Img URL(<255 charecters)")]
    public string? ProductImage { get; set; }

    [Display(Name = "Supplier")]
    public int? SupplierId { get; set; }

    [Display(Name = "Category")]
    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Supplier? Supplier { get; set; }
}
