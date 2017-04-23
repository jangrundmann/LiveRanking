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

        public override string ToString()
        {
            return "Ranking race: Id="+ Id + " orisId=" + RankingRaceOrisId + " results" + HasResults +" ranking" + HasRankingDone;
        }
    }
}
