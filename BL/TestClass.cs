using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.Repository;
using DAL.Config;

namespace BL
{
   public static class TestClass
    {
        public static int InsertIntoDB(Competitor c)
        {
            CompetitorRepository rep = new CompetitorRepository(new LiveRankingDb());
            rep.Add(c);
            return 0;
        }
    }
}
