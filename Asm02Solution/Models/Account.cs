using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm02Solution.Models;

public partial class Account
{
    public int AccountId { get; set; }

    [Display(Name = "Username")]
    [Required(ErrorMessage = "Username is required")]
    [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 255")]
    public string? UserName { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required")]
    [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 255")]
    public string? Password { get; set; }

    [Display(Name = "Full name")]
    [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 255")]
    public string? FullName { get; set; }

    [Display(Name = "Account Type")]
    [Range(0, 1, ErrorMessage = "Just have 2 type of account")]
    public short? Type { get; set; }
}
