using Kendo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication2.Pages;

namespace Kendo.Pages
{
    public class wylogujModel : PageModel
    {
        private IcommanderRepo _repo;
        private ILogger<IndexModel> _logger;
        private IJwtAuthenticationManager _authentication;

        public wylogujModel(ILogger<IndexModel> logger, IJwtAuthenticationManager authentication, IcommanderRepo repo)
        {
            _repo = repo;
            _logger = logger;
            _authentication = authentication;
        }
        public IActionResult OnGet()
        {
            return Redirect("/index");

        }
    }
}
