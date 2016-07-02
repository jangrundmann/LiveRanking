using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.Import
{
    public static class CompetitorTools
    {
        public static int ImportRankingFromFile(string path)
        {
            var cs = new List<Competitor>();

            using (var stream = new StreamReader(path))
            {
                var header = stream.ReadLine();
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    if (line != null)
                    {
                        var columns = line.Split(';');
                        var c = new Competitor();
                        c.Name = columns[2];
                        c.Surname = columns[1];
                        c.RegNo = columns[3];

                        int rp;
                        int.TryParse(columns[4], out rp);
                        c.RankingPoints = rp;
                        int.TryParse(columns[5], out rp);
                        c.RankingCoeficient = rp;
                        cs.Add(c);
                    }
                }
            }

            return cs.Count;
        }
    }
}
