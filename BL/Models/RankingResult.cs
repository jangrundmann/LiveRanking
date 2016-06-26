using System;

namespace BL.Models
{
   public class RankingResult : BaseEntity
    {
        public int RankingResultId { get; set; }
        public int Points { get; set; }
        public DateTime Date { get; set; }

        public int CompetitorId { get; set; }
        public int RankingRaceId { get; set; }
    }
}
