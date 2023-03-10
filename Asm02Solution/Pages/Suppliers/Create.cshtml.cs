using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asm02Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace Asm02Solution.Pages.Suppliers
{
    public class CreateModel : PageModel
    {
        private readonly Asm02Solution.Models.PizzaStore01Context _context;

        public CreateModel(Asm02Solution.Models.PizzaStore01Context context)
        {
            _context = context;
        }
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            int? curr_account_id = HttpContext.Session.GetInt32("AccountId");
            if (curr_account_id == null)
            {
                return Redirect("/Users/Login");
            }
            Account = await _context.Accounts.FirstOrDefaultAsync(m => m.AccountId.Equals(curr_account_id));

            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public Supplier Supplier { get; set; }
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Suppliers.Add(Supplier);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
