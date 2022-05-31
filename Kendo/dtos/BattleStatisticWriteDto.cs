using Kendo.Models;
using System;
using System.Collections.Generic;

namespace Kendo.dtos
{
    public class BattleStatisticWriteDto
    {
        public int UserId { get; set; }
        public bool Won { get; set; }
       
        public int AllHits { get; set; }
        public TimeSpan Timespan { get; set; }
        public IEnumerable<Hit> hits { get; set; }
    }
}
