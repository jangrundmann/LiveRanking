using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace DAL.Config
{
    public class LiveRankingDb: DbContext
    {
        public LiveRankingDb() : base()
        {
            Database.SetInitializer<LiveRankingDb>(new DropCreateDatabaseIfModelChanges<LiveRankingDb>());
        }
        public DbSet<CompetitorDAL> Competitors { get; set; }
        public DbSet<RankingRaceDAL> RankingRaces { get; set; }
        public DbSet<RankingResultDAL> RankingResults { get; set; }

    }
}
