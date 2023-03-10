using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asm02Solution.Models;

namespace Asm02Solution.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly Asm02Solution.Models.PizzaStore01Context _context;

        public IndexModel(Asm02Solution.Models.PizzaStore01Context context)
        {
            _context = context;
        }
        public Account Account { get; set; } = default!;

        public IList<Supplier> Supplier { get;set; } = default!;

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

            if (_context.Suppliers != null)
            {
                Supplier = await _context.Suppliers.ToListAsync();
            }

            return Page();

        }
    }
}
