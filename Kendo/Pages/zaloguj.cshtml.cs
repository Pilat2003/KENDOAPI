using Kendo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication2.Pages
{
    public class zalogujModel : PageModel
    {
        private IcommanderRepo _repo;
        private ILogger<IndexModel> _logger;
        private IJwtAuthenticationManager _authentication;

        public zalogujModel(ILogger<IndexModel> logger, IJwtAuthenticationManager authentication, IcommanderRepo repo)
        {
            _repo = repo;
            _logger = logger;
            _authentication = authentication;
        }
        public void OnGet(string token)
        {
            
        }
    }
}
