using System;
using System.Collections.Generic;

namespace Asm02Solution.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public DateTime? FullName { get; set; }

    public short? Type { get; set; }
}
