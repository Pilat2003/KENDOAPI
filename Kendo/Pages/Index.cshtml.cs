using Kendo.Data;
using Kendo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IcommanderRepo _repo;
        private readonly ILogger<IndexModel> _logger;
        private readonly IJwtAuthenticationManager _authentication;

        [ViewData]
        public bool TokenExists { get; set; }

        [ViewData]
        public List<BattleStatistic> stats { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IJwtAuthenticationManager authentication, IcommanderRepo repo)
        {
            _repo = repo;
            _logger = logger;
            _authentication = authentication;
        }

     
        public IActionResult OnGet(string token)
        {
 
            System.Diagnostics.Debug.WriteLine(token);
            ViewData["Title"] = "Nic";
            if (token != null && token.Length > 0)
            {
                string _token = _authentication.GetIDFromToken(token);

                if (_token == null) return RedirectToPage("/zaloguj");
                TokenExists = true;
                stats = _repo.GetAllBattleStatisticsByUSerId(int.Parse(_token)).ToList();
            }
            return Page();

        }
    }
}
