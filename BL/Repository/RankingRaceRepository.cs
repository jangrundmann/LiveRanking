using System.Linq;
using BL.Models;
using DAL.Config;
using DAL.Data;

namespace BL.Repository
{
    class RankingRaceRepository : BaseRepository<RankingRaceDAL, RankingRace>
    {
        protected override IQueryable<RankingRace> GetIQueryable()
        {
            return dbSet
                .Select(entity => new RankingRace()
                {
                    // We cannot use AutoMapper here, because Entity Framework
                    // won't be able to process the expression. Hence manual
                    // mapping.
                    Id = entity.Id,
                    HasRankingDone = entity.HasRankingDone,
                    HasResults = entity.HasResults,
                    RankingRaceOrisId = entity.RankingRaceOrisId

                });
        }

        public RankingRaceRepository(LiveRankingDb context)
        : base(context, context.RankingRaces)
        {

        }
    }
}
