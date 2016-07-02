namespace BL.Models
{
    public class RankingRace :BaseEntity
    {
        public RankingRace()
        {
            
        }
        public RankingRace(int id)
        {
            RankingRaceOrisId = id;
        }
        public int RankingRaceOrisId { get; set; }
        public bool HasResults { get; set; }
        public bool HasRankingDone { get; set; }


    }
}
