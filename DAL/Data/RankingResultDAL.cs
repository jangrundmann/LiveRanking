using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
   public class RankingResultDAL: BaseEntityDAL
    {
        public int Points { get; set; }
        public DateTime Date { get; set; }

        public int CompetitorId { get; set; }
        public int RankingRaceId { get; set; }
    }
}
