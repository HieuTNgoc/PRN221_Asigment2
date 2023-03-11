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
    public class DetailsModel : PageModel
    {
        private readonly Asm02Solution.Models.PizzaStore01Context _context;

        public DetailsModel(Asm02Solution.Models.PizzaStore01Context context)
        {
            _context = context;
        }
        public Account Account { get; set; } = default!;

        public Order Order { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

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

            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            var orderdetail = await _context.OrderDetails.FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            else
            {
                OrderDetail = orderdetail;
            }
            return Page();
        }
    }
}
