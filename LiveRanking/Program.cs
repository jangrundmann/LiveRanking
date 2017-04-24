using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BL;
using BL.Models;
using BL.Import;
using BL.JModels;
using BL.Repository;
using DAL.Config;
using DAL.Data;
using Newtonsoft.Json.Linq;

namespace LiveRanking
{
    class Program
    {
        private static string _directory = @"C:\Users\Jan\Documents\liveranking";
        static void Main(string[] args)
        {
            //TimeSpan t1 = new TimeSpan(0, 0, 47, 56);
            //TimeSpan t2 = new TimeSpan(0, 0, 50, 48);
            //TimeSpan t3 = new TimeSpan(0, 0, 51, 25);
            //double t4 = (t1 + t2 + t3).TotalSeconds;
            //TimeSpan t5 = TimeSpan.FromSeconds(t4/3);
            //int rank5sum = 7345 + 5170 + 5729 + 4794 + 4419;

            //Calculator calc = new Calculator((int)t4/3,rank5sum/5,0,1,12);
            //List<TimeSpan>list = new List<TimeSpan>();
            //list.Add(t1);
            //list.Add(t2);
            //list.Add(t3);
            //list.Add(new TimeSpan(0,0,52,04));
            //list.Add(new TimeSpan(0,0,54,02));
            //list.Add(new TimeSpan(0,0,57,12));
            //list.Add(new TimeSpan(0,0,57,35));
            //list.Add(new TimeSpan(0,0,57,46));
            //list.Add(new TimeSpan(0,0,61,52));
            //list.Add(new TimeSpan(0,0,65,28));
            //list.Add(new TimeSpan(0,0,66,15));
            //list.Add(new TimeSpan(0,0,69,48));
            //foreach (TimeSpan l in list)
            //{
            //    Console.WriteLine(calc.Calculate((int)l.TotalSeconds, 1));
            //}

            //Competitor c =new Competitor();
            //c.Club = "Lokomotiva Pardubice";
            //c.CompetitorOrisId = 2468;
            //c.Name = "Petr";
            //c.RankingCoeficient = 6958;
            //c.RankingPoints = 2993593;
            //c.RegNo = "LPU9401";
            //c.Surname = "Janů";
            //TestClass.InsertIntoDB(c);
            //using (var db = new LiveRankingDb())
            //{
            //    var query = from p in db.Competitors
            //        select p;
            //    foreach (var competitor in query)
            //    {
            //        Console.WriteLine($"{competitor.Club}, {competitor.CompetitorOrisId}, {competitor.Name}, {competitor.Surname}, {competitor.RegNo}");
            //    }

            //}
            //Console.ReadKey();
            /*
            // string response = call.GetEvent(3300);
            string response2 = ApiCalls.GetRankingEvents("2016-06");
            //Console.WriteLine(response);
            using (StreamWriter outputFile1 = new StreamWriter(_directory + @"\vysledky_zavodu.txt"))
            {
                foreach (Race race in ParseRankingEvents.GetEvents(response2))
                {
                    outputFile1.WriteLine($"Id: {race.Id} Ranking: {race.rankingDone} Results: {race.results}");
                    if (race.results)
                    {
                        using (StreamWriter outputFile = new StreamWriter(_directory + @"\vysledky_" + race.Id + ".txt"))
                        {
                            JObject jObject1 = JObject.Parse(ApiCalls.GetEventResults(race.Id));
                            outputFile.Write(jObject1.ToString());
                        }

                    }

                   // Console.WriteLine($"Zavod: {id}");
                   //Newtonsoft.Json.Linq.JObject jObject1 = Newtonsoft.Json.Linq.JObject.Parse(ApiCalls.GetEventResults(id));
                   //outputFile1.Write(jObject1.ToString());
                }
            }
            //using (StreamWriter outputFile = new StreamWriter(_directory + @"\vysledky_teplice.txt"))
            //{
            //    JObject jObject2 = JObject.Parse(ApiCalls.GetEvent(3304));
            //    outputFile.Write(jObject2.ToString());
            //    jObject2 = JObject.Parse(ApiCalls.GetEventResults(3304));
            //    outputFile.Write(jObject2.ToString());


            //}
            //Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(response);
            //Console.WriteLine(jObject.ToString());
            
           //Console.ReadKey();+*/
            //RankingRacesTools.DownloadRankingRaces();

            //Console.WriteLine(CompetitorTools.ImportRankingFromFile(_directory + "\\export_ranking_m.csv"));


            List<string> months = new List<string> {"2017-04"};
            
            StreamWriter outputFile = new StreamWriter(_directory + @"\vysledky_duben.txt");

            List<RankingRace> l1 = new List<RankingRace>();
            l1.Add(RankingRacesTools.DownloadRankingRaces(months).First());
            List<RaceExport> l2 = RankingRacesTools.ExtractResults(l1);
            List<CompetitorRankingStanding>l3 = RankingRacesTools.ParseRankingStandingsFromCsv(ApiCalls.GetRankingStandingsCsv("2017-03-31", "M"));
        }
    }
}
