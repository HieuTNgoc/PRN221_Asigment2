using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asm02Solution.Models;

namespace Asm02Solution.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly Asm02Solution.Models.PizzaStore01Context _context;

        public DetailsModel(Asm02Solution.Models.PizzaStore01Context context)
        {
            _context = context;
        }
        public Account Account { get; set; } = default!;

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
