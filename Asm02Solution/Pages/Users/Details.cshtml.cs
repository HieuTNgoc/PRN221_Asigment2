using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asm02Solution.Models;

namespace Asm02Solution.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly Asm02Solution.Models.PizzaStore01Context _context;

        public DetailsModel(Asm02Solution.Models.PizzaStore01Context context)
        {
            _context = context;
        }

      public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }
    }
}
