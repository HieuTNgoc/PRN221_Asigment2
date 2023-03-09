using Asm02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace Asm02Solution.Pages.Users
{
    public class LoginModel : PageModel
    {
        private readonly PizzaStore01Context _context;
        private readonly IToastNotification _notify;


        public LoginModel(PizzaStore01Context context, IToastNotification notify)
        {
            _context = context;
            _notify = notify;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account LoginAccount { get; set; }
        public Account Account { get; set; } = default!;



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Account = _context.Accounts.FirstOrDefault(u => u.UserName.Equals(LoginAccount.UserName) && u.Password.Equals(LoginAccount.Password));
            if (Account != null)
            {
                HttpContext.Session.SetString("UserName", Account.UserName);
                HttpContext.Session.SetInt32("AccountId", Account.AccountId);
                _notify.AddSuccessToastMessage("Login successfully.");
                return RedirectToPage("/Index");
            }
            else
            {
                _notify.AddErrorToastMessage("Wrong Username or Password");
                return Page();
            }
        }

    }
}
