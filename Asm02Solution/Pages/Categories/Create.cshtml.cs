using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asm02Solution.Models;
using NToastNotify;

namespace Asm02Solution.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Asm02Solution.Models.PizzaStore01Context _context;
        private readonly IToastNotification _notify;

        public CreateModel(PizzaStore01Context context, IToastNotification notify)
        {
            _context = context;
            _notify = notify;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            int res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                _notify.AddSuccessToastMessage("Category created successfully.");
            } else
            {
                _notify.AddErrorToastMessage("Category not created successfully!");
            }

            return RedirectToPage("./Index");
        }
    }
}
