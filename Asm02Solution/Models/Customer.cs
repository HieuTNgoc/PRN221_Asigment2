using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm02Solution.Models;

public partial class Customer
{
    public int CustomerId { get; set; }
    [Display(Name = "Code")]

    public string? Password { get; set; }
    [Display(Name = "Name")]

    public string? ContactName { get; set; }
    [Display(Name = "Address")]

    public string? Address { get; set; }
    [Display(Name = "Phone")]

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
