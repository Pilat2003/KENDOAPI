using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Kendo.dtos
{
    public class UserStatisticWriteDto
    {
        public int userId { get; set; }
        public int CorrectHits { get; set; }
        public int AllHits { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
    }
}
