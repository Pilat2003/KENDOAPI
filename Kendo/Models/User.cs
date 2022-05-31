using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kendo.Models
{
    public class User
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        
        public virtual UserStatistic UserStatistics { get; set; }
        
        public List<BattleStatistic> Statistics { get; set; }
    }
}
