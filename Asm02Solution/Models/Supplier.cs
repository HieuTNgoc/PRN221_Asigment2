using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm02Solution.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    [Display(Name = "Name")]
    public string? CompanyName { get; set; }

    [Display(Name = "Address")]
    public string? Address { get; set; }

    [Display(Name = "Phone")]
    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
