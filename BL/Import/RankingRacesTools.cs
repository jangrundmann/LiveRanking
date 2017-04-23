using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.JModels;
using BL.Models;
using BL.Repository;
using DAL.Config;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BL.Import
{
    public static class RankingRacesTools
    {
        public static List<RankingRace> DownloadRankingRaces(List<string> months)
        {
            List < RankingRace > races = new List<RankingRace>();
            // RankingRaceRepository rep = new RankingRaceRepository(new LiveRankingDb());
            foreach (string month in months)
            {
                string response = ApiCalls.GetRankingEventsPageContent(month);

                races.AddRange(ParseRankingRaces(response));
            }
            return races;
        }

        public static void SaveResults(StreamWriter output, List<RankingRace> races)
        {
            List<JObject> jsonRacesList = new List<JObject>();
            foreach (var race in races)
            {
                if (race.HasResults)
                {

                   // List<Result> resultsClass = new List<Result>();
                    string results = ApiCalls.GetEventResults(race.RankingRaceOrisId);
                  /*var raceExport = JsonConvert.DeserializeObject<dynamic>(results);
                    var data = raceExport.Data;*/
                    
                    
                    JObject jsonRace = JObject.Parse(results);
                    
                    jsonRacesList.Add(jsonRace);
                    /*using (output)
                    {
                        output.Write(results);
                        output.WriteLine();
                    }*/
                }
            }
           
        }
        public static List<RankingRace> ParseRankingRaces(string page)
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
