using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Models
{
    public class UserStatistic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int userId { get; set; }

        [ForeignKey("userId")]
        public User User { get; set; }
        [Required]
        public int CorrectHits { get; set; }
        [Required]
        public int AllHits { get; set; }
        [Required]
        public int Wins { get; set; }
        [Required]
        public int Loses { get; set; }
    }
}
