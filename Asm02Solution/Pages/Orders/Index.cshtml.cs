using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asm02Solution.Models;

namespace Asm02Solution.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Asm02Solution.Models.PizzaStore01Context _context;

        public IndexModel(Asm02Solution.Models.PizzaStore01Context context)
        {
            _context = context;
        }
        public Account Account { get; set; } = default!;

        public IList<Order> Order { get;set; } = default!;
        public IList<OrderDetail> OrderDetail { get; set; } = default!;

        [BindProperty]
        public Product Product { get; set; }
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

            if (_context.OrderDetails != null)
            {
                OrderDetail = await _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).ToListAsync();
            }

            return Page();
        }
    }
}
