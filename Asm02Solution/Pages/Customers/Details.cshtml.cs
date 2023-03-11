using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asm02Solution.Models;
using NToastNotify;

namespace Asm02Solution.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly PizzaStore01Context _context;
        private readonly IToastNotification _notify;

        public DetailsModel(PizzaStore01Context context, IToastNotification notify)
        {
            _context = context;
            _notify = notify;
        }
        public Account Account { get; set; } = default!;

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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
