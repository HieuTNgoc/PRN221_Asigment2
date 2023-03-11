using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asm02Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace Asm02Solution.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Asm02Solution.Models.PizzaStore01Context _context;

        public CreateModel(Asm02Solution.Models.PizzaStore01Context context)
        {
            _context = context;
        }
        public Account Account { get; set; } = default!;
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

            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "ContactName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            OrderDetail.OrderId = Order.OrderId;
            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
