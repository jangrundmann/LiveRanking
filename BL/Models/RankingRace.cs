namespace BL.Models
{
    public class RankingRace :BaseEntity
    {
        public RankingRace()
        {
            
        }
        public RankingRace(int id)
        {
            RankingRaceId = id;
        }
        public int RankingRaceId { get; set; }
        public int RankingRaceOrisId { get; set; }
        public bool HasResults { get; set; }
        public bool HasRankingDone { get; set; }


    }
}
