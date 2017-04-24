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
using Microsoft.VisualBasic.FileIO;

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
        public static List<RaceExport> ExtractResults(List<RankingRace> races)
        {
            List<RaceExport> racesExport = new List<RaceExport>();
            foreach (var race in races)
            {
                if (race.HasResults)
                {

                    string results = ApiCalls.GetEventResults(race.RankingRaceOrisId);
                    
                    RaceExport raceExport = new RaceExport();
                    List<Result> resList = new List<Result>();

                    JObject jsonRace = JObject.Parse(results);

                    raceExport.Method = (string) jsonRace["Method"];
                    raceExport.Format = (string)jsonRace["Format"];
                    raceExport.Status = (string)jsonRace["Status"];
                    raceExport.ExportCreated = (string) jsonRace["ExportCreated"];

                    foreach (var result in jsonRace["Data"].Children())
                    {
                        Result res = new Result();

                        res.ID = (string) result.First["ID"];
                        res.ClassID = (string)result.First["ClassID"];
                        res.ClassDesc = (string)result.First["ClassDesc"];
                        res.Sort = (string)result.First["Sort"];
                        res.Place = (string)result.First["Place"];
                        res.Name = (string)result.First["Name"];
                        res.RegNo = (string)result.First["RegNo"];
                        res.Lic = (string)result.First["Lic"];
                        res.ClubNameResults = (string)result.First["ClubNameResults"];
                        res.Time = (string)result.First["Time"];
                        res.Loss = (string)result.First["Loss"];
                        res.StartTime = (string)result.First["StartTime"];
                        res.FinishTime = (string)result.First["FinishTime"];
                        res.UserID = (string)result.First["UserID"];
                        res.ClubID = (string)result.First["ClubID"];

                        resList.Add(res);
                    }
                    raceExport.Data = resList;
                    racesExport.Add(raceExport);
                }      
            }
            return racesExport;

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

        public static List<CompetitorRankingStanding> ParseRankingStandingsFromCsv(StreamReader csv)
        {
            List<CompetitorRankingStanding>standings = new List<CompetitorRankingStanding>();
            using (TextFieldParser parser = new TextFieldParser(csv))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                bool headrow = true;
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    if (headrow)
                    {
                        headrow = false;
                        continue;
                    }

                    CompetitorRankingStanding s = new CompetitorRankingStanding
                    {
                        Poradi = fields[0],
                        Prijmeni = fields[1],
                        Jmeno = fields[2],
                        RegNo = fields[3],
                        Body = fields[4],
                        Coef = fields[5],
                        RankMinule = fields[6]
                    };
                    standings.Add(s);
                }
            }
            csv.Close();
            return standings;
        }
        
    }

}
