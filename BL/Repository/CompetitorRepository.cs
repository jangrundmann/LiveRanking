using System.Linq;
using BL.Models;
using DAL.Config;
using DAL.Data;

namespace BL.Repository
{
    class CompetitorRepository : BaseRepository<CompetitorDAL,Competitor>
    {
        protected override IQueryable<Competitor> GetIQueryable()
        {
            return dbSet
                .Select(entity => new Competitor()
                {
                // We cannot use AutoMapper here, because Entity Framework
                // won't be able to process the expression. Hence manual
                // mapping.
                    Id = entity.Id,
                    CompetitorOrisId = entity.CompetitorOrisId,
                    Club = entity.Club,
                    Name = entity.Name,
                    RankingCoeficient = entity.RankingCoeficient,
                    RankingPoints = entity.RankingPoints,
                    RegNo = entity.RegNo,
                    Surname = entity.Surname
                    
                });
        }

        public CompetitorRepository(LiveRankingDb context)
        : base(context, context.Competitors)
    {

        }
    }
}

