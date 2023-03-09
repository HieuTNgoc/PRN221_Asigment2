using Asm02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Asm02Solution.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PizzaStore01Context _context;

        public IndexModel(PizzaStore01Context context)
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

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToPage("/Users/Login");
        }
    }
}