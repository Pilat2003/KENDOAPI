using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Models
{
    public class BattleStatistic
    { 
        public enum BodyPart
        {
            Men,
            Migi_Men,
            Hidari_Men,
            Tsuki,
            Kote,
            Hidari_Kote,
            Migi_Do,
            Hidari_Do

        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool Won { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required]
        public int AllHits { get; set; }
        [Required]
        public TimeSpan Timespan { get; set; }
        [Required]
        public string hits { get; set; }


    }
      
}
