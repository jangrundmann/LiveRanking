namespace DAL.Data
{
    public class RankingRaceDAL : BaseEntityDAL
    {
        
        public int RankingRaceId { get; set; }
        public int RankingRaceOrisId { get; set; }
        public bool HasResults { get; set; }
        public bool HasRankingDone { get; set; }


    }
}
