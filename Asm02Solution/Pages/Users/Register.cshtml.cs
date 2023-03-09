using Asm02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace Asm02Solution.Pages.Users
{
    public class RegisterModel : PageModel
    {
        private readonly PizzaStore01Context _context;
        private readonly IToastNotification _notify;

        public RegisterModel(PizzaStore01Context context, IToastNotification notify)
        {
            _context = context;
            _notify = notify;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Accounts.Add(Account);
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                _notify.AddSuccessToastMessage("Register successfully.");
                return RedirectToPage("/Users/Login");
            }
            else
            {
                _notify.AddErrorToastMessage("Register Failed!");
            }
            return RedirectToPage("/Index");
        }
    }
}
