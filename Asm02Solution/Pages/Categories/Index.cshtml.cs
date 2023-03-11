using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asm02Solution.Models;
using NToastNotify;

namespace Asm02Solution.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly PizzaStore01Context _context;
        private readonly IToastNotification _notify;

        public IndexModel(PizzaStore01Context context, IToastNotification notify)
        {
            _context = context;
            _notify = notify;
        }
        public Account Account { get; set; } = default!;

        public IList<Category> Category { get;set; } = default!;

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

            if (_context.Categories != null)
            {
                Category = await _context.Categories.ToListAsync();
            }
            return Page();
        }
    }
}
