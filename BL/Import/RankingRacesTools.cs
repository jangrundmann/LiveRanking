using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.Repository;
using DAL.Config;
using HtmlAgilityPack;

namespace BL.Import
{
    public static class RankingRacesTools
    {
        public static void DownloadRankingRaces()
        {
            RankingRaceRepository rep = new RankingRaceRepository(new LiveRankingDb());
            List<string> months = new List<string>{ "2015-05", "2015-06", "2015-07", "2015-08",
                "2015-09" ,"2015-10" , "2015-11" , "2015-12" , "2016-01", "2016-02", "2016-03",
                "2016-04", "2016-05", "2016-06" };
            foreach (string month in months)
            {
                string response = ApiCalls.GetRankingEventsPageContent(month);
                foreach (RankingRace race in GetRankingRaces(response))
                {
                    rep.Add(race);
                }
            }
        }

        public static List<RankingRace> GetRankingRaces(string page)
        {
            List<RankingRace> rankingRaces = new List<RankingRace>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);
            try
            {
                foreach (HtmlNode rankingRace in doc.DocumentNode.SelectNodes("//tbody/tr"))
                {
                    int idNumber;

                    if (int.TryParse(rankingRace.SelectSingleNode("td/a").InnerText, out idNumber))
                    {
                        RankingRace r = new RankingRace(idNumber);
                        string results = rankingRace.SelectSingleNode("(td[@class='tac']/span)[1]").InnerText;
                        string ranking = rankingRace.SelectSingleNode("(td[@class='tac']/span)[2]").InnerText;
                        if (results.Equals("Ano"))
                        {
                            r.HasResults = true;
                        }
                        else if (results.Equals("Ne"))
                        {
                            r.HasResults = false;
                        }
                        if (ranking.Equals("Ano"))
                        {
                            r.HasRankingDone = true;
                        }
                        else if (ranking.Equals("Ne"))
                        {
                            r.HasRankingDone = false;
                        }
                        rankingRaces.Add(r);
                    }


                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            return rankingRaces;
        }
        public static List<int> GetEventIds(string page)
        {
            List<int> aId = new List<int>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);

            foreach (HtmlNode id in doc.DocumentNode.SelectNodes("//tbody/tr/td/a"))
            {
                int idNumber;
                if (int.TryParse(id.InnerText, out idNumber))
                {
                    aId.Add(idNumber);
                }

            }

            return aId;
        }
    }

}
