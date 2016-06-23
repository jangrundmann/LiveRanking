using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;

namespace LiveRanking
{
    static class ParseRankingEvents
    {
        public static ICollection<int> GetEventIds(string page)
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

        public static ICollection<Race> GetEvents(string page)
        {
            List<Race> races = new List<Race>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);

            foreach (HtmlNode race in doc.DocumentNode.SelectNodes("//tbody/tr"))
            {
                int idNumber;
                
                if (int.TryParse(race.SelectSingleNode("td/a").InnerText, out idNumber))
                {
                    Race r = new Race(idNumber);
                    string results = race.SelectSingleNode("(td[@class='tac']/span)[1]").InnerText;
                    string ranking = race.SelectSingleNode("(td[@class='tac']/span)[2]").InnerText;
                    if(results.Equals("Ano"))
                    {
                        r.results = true;
                    }else if(results.Equals("Ne"))
                    {
                        r.results = false;
                    }
                    if(ranking.Equals("Ano"))
                    {
                        r.rankingDone = true;
                    }else if (ranking.Equals("Ne"))
                    {
                        r.rankingDone = false;
                    }
                    races.Add(r);
                }


            }

            return races;
        }
        private static Stream ToStream(this string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        
    }
}
