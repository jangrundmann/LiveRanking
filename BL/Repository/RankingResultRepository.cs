using System.Linq;
using BL.Models;
using DAL.Config;
using DAL.Data;

namespace BL.Repository
{

    class RankingResultRepository : BaseRepository<RankingResultDAL, RankingResult>
    {
        protected override IQueryable<RankingResult> GetIQueryable()
        {
            return dbSet
                .Select(entity => new RankingResult()
                {
                    // We cannot use AutoMapper here, because Entity Framework
                    // won't be able to process the expression. Hence manual
                    // mapping.
                    Id = entity.Id,
                    Date = entity.Date,
                    CompetitorId = entity.CompetitorId,
                    Points = entity.Points,
                    RankingRaceId = entity.RankingRaceId

                });
        }

        public RankingResultRepository(LiveRankingDb context)
        : base(context, context.RankingResults)
        {

        }
    }
}
