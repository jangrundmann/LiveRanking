using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class CompetitorDAL : BaseEntityDAL
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
