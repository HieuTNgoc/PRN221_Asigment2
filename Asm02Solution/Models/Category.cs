using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm02Solution.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    [Display(Name = "Category Name")]
    [Required(ErrorMessage = "Category name is required")]
    [StringLength(maximumLength:255, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 255")]
    public string? CategoryName { get; set; }

    [Display(Name = "Description")]
    [Required(ErrorMessage = "Category description is required")]
    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
