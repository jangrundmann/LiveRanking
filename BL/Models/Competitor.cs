using System.Collections.Generic;

namespace BL.Models
{
    public class Competitor : BaseEntity
    {
        public int CompetitorId { get; set; }
        public int CompetitorOrisId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RegNo { get; set; }
        public string Club { get; set; }
        public int RankingPoints { get; set; }
        public int RankingCoeficient { get; set; }
    }
}
